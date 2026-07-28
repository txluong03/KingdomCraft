using System.Net.Sockets;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using KingdomCraft.Application.Combat;
using KingdomCraft.Application.Crafting;
using KingdomCraft.Application.Diplomacy;
using KingdomCraft.Application.Guilds;
using KingdomCraft.Application.Kingdom;
using KingdomCraft.Application.Persistence;
using KingdomCraft.Application.Players;
using KingdomCraft.Application.Quests;
using KingdomCraft.Core.Combat;
using KingdomCraft.Core.Diplomacy;
using KingdomCraft.Core.Entities;
using KingdomCraft.Core.Guilds;
using KingdomCraft.Core.Kingdom;
using KingdomCraft.Server.Networking;
using Xunit;

namespace KingdomCraft.Tests;

public class KingdomTcpServerTests
{
    private static readonly JsonSerializerOptions JsonOptions = CreateJsonOptions();

    private static JsonSerializerOptions CreateJsonOptions()
    {
        var options = new JsonSerializerOptions(JsonSerializerDefaults.Web);
        options.Converters.Add(new JsonStringEnumConverter());
        return options;
    }

    private static (KingdomTcpServer Server, CancellationTokenSource Cts, Task RunTask) StartServer()
    {
        var kingdomRegistry = new KingdomRegistry();
        var playerRegistry = new PlayerRegistry();
        var bossRegistry = new BossRegistry();
        var guildRegistry = new GuildRegistry();
        var guildAppService = new GuildAppService(guildRegistry, kingdomRegistry);
        var diplomacyAppService = new DiplomacyAppService(new DiplomacyRegistry(), kingdomRegistry, guildRegistry);
        var saveGameAppService = new SaveGameAppService(kingdomRegistry);
        var dispatcher = new KingdomCommandDispatcher(kingdomRegistry, playerRegistry, bossRegistry, guildAppService, diplomacyAppService, saveGameAppService);
        var server = new KingdomTcpServer(dispatcher, port: 0);
        server.Start();
        var cts = new CancellationTokenSource();
        var runTask = server.RunAsync(cts.Token);
        return (server, cts, runTask);
    }

    private static async Task<KingdomResponse> SendCommandAsync(int port, KingdomCommand command)
    {
        using var client = new TcpClient();
        await client.ConnectAsync("127.0.0.1", port);
        await using var stream = client.GetStream();
        using var reader = new StreamReader(stream, Encoding.UTF8);
        await using var writer = new StreamWriter(stream, Encoding.UTF8) { AutoFlush = true };

        await writer.WriteLineAsync(JsonSerializer.Serialize(command, JsonOptions));
        var line = await reader.ReadLineAsync();

        return JsonSerializer.Deserialize<KingdomResponse>(line!, JsonOptions)!;
    }

    private static T ReadData<T>(KingdomResponse response)
    {
        var json = JsonSerializer.Serialize(response.Data, JsonOptions);
        return JsonSerializer.Deserialize<T>(json, JsonOptions)!;
    }

    private static async Task<string> CreateKingdomAsync(int port, string name)
    {
        var response = await SendCommandAsync(port, new KingdomCommand
        {
            Action = "CreateKingdom",
            Payload = JsonSerializer.SerializeToElement(new { Name = name }, JsonOptions)
        });

        Assert.True(response.Success);
        return ReadData<KingdomStateDto>(response).Id;
    }

    private static async Task<string> CreatePlayerAsync(int port, string name)
    {
        var response = await SendCommandAsync(port, new KingdomCommand
        {
            Action = "CreatePlayer",
            Payload = JsonSerializer.SerializeToElement(new { Name = name }, JsonOptions)
        });

        Assert.True(response.Success);
        return ReadData<PlayerDto>(response).Id;
    }

    [Fact]
    public async Task CreateKingdom_ThenRecruitNpc_ReflectsChangeOverTcp()
    {
        var (server, cts, _) = StartServer();
        try
        {
            var kingdomId = await CreateKingdomAsync(server.Port, "Vương quốc A");

            var recruitPayload = JsonSerializer.SerializeToElement(new { Role = "Farmer", SkillLevel = 4 }, JsonOptions);
            var recruitResponse = await SendCommandAsync(server.Port, new KingdomCommand { Action = "RecruitNpc", KingdomId = kingdomId, Payload = recruitPayload });
            Assert.True(recruitResponse.Success);

            var stateResponse = await SendCommandAsync(server.Port, new KingdomCommand { Action = "GetKingdomState", KingdomId = kingdomId });
            var state = ReadData<KingdomStateDto>(stateResponse);

            Assert.Single(state.Npcs);
            Assert.Equal(4, state.Npcs[0].SkillLevel);
        }
        finally
        {
            cts.Cancel();
            server.Stop();
        }
    }

    [Fact]
    public async Task Tick_OverTcp_ProducesResourcesFromRecruitedFarmer()
    {
        var (server, cts, _) = StartServer();
        try
        {
            var kingdomId = await CreateKingdomAsync(server.Port, "Vương quốc A");

            var recruitPayload = JsonSerializer.SerializeToElement(new { Role = "Farmer", SkillLevel = 3 }, JsonOptions);
            await SendCommandAsync(server.Port, new KingdomCommand { Action = "RecruitNpc", KingdomId = kingdomId, Payload = recruitPayload });

            var tickResponse = await SendCommandAsync(server.Port, new KingdomCommand { Action = "Tick", KingdomId = kingdomId });
            var state = ReadData<KingdomStateDto>(tickResponse);

            Assert.Equal(3, state.Resources.GetValueOrDefault("food"));
        }
        finally
        {
            cts.Cancel();
            server.Stop();
        }
    }

    [Fact]
    public async Task SellResource_OverTcp_ConvertsResourceToGold()
    {
        var (server, cts, _) = StartServer();
        try
        {
            var kingdomId = await CreateKingdomAsync(server.Port, "Vương quốc A");

            var recruitPayload = JsonSerializer.SerializeToElement(new { Role = "Farmer", SkillLevel = 10 }, JsonOptions);
            await SendCommandAsync(server.Port, new KingdomCommand { Action = "RecruitNpc", KingdomId = kingdomId, Payload = recruitPayload });
            await SendCommandAsync(server.Port, new KingdomCommand { Action = "Tick", KingdomId = kingdomId });

            var sellPayload = JsonSerializer.SerializeToElement(new { ResourceName = "food", Quantity = 4 }, JsonOptions);
            var sellResponse = await SendCommandAsync(server.Port, new KingdomCommand { Action = "SellResource", KingdomId = kingdomId, Payload = sellPayload });

            Assert.True(sellResponse.Success);
        }
        finally
        {
            cts.Cancel();
            server.Stop();
        }
    }

    [Fact]
    public async Task TwoKingdoms_AreIsolatedFromEachOther()
    {
        var (server, cts, _) = StartServer();
        try
        {
            var kingdomA = await CreateKingdomAsync(server.Port, "Vương quốc A");
            var kingdomB = await CreateKingdomAsync(server.Port, "Vương quốc B");

            var recruitPayload = JsonSerializer.SerializeToElement(new { Role = "Farmer", SkillLevel = 5 }, JsonOptions);
            await SendCommandAsync(server.Port, new KingdomCommand { Action = "RecruitNpc", KingdomId = kingdomA, Payload = recruitPayload });

            var stateA = ReadData<KingdomStateDto>(await SendCommandAsync(server.Port, new KingdomCommand { Action = "GetKingdomState", KingdomId = kingdomA }));
            var stateB = ReadData<KingdomStateDto>(await SendCommandAsync(server.Port, new KingdomCommand { Action = "GetKingdomState", KingdomId = kingdomB }));

            Assert.Single(stateA.Npcs);
            Assert.Empty(stateB.Npcs);
        }
        finally
        {
            cts.Cancel();
            server.Stop();
        }
    }

    [Fact]
    public async Task GuildFlow_CreateThenJoin_OverTcp()
    {
        var (server, cts, _) = StartServer();
        try
        {
            var founderKingdomId = await CreateKingdomAsync(server.Port, "Vương quốc A");
            var memberKingdomId = await CreateKingdomAsync(server.Port, "Vương quốc B");

            var createGuildResponse = await SendCommandAsync(server.Port, new KingdomCommand
            {
                Action = "CreateGuild",
                KingdomId = founderKingdomId,
                Payload = JsonSerializer.SerializeToElement(new { Name = "Liên minh Rồng" }, JsonOptions)
            });
            Assert.True(createGuildResponse.Success);
            var guild = ReadData<GuildDto>(createGuildResponse);
            Assert.Single(guild.MemberKingdomIds);

            var joinResponse = await SendCommandAsync(server.Port, new KingdomCommand
            {
                Action = "JoinGuild",
                KingdomId = memberKingdomId,
                Payload = JsonSerializer.SerializeToElement(new { GuildId = guild.Id }, JsonOptions)
            });
            Assert.True(ReadData<GuildActionResultDto>(joinResponse).Success);

            var getGuildResponse = await SendCommandAsync(server.Port, new KingdomCommand
            {
                Action = "GetGuild",
                Payload = JsonSerializer.SerializeToElement(new { GuildId = guild.Id }, JsonOptions)
            });
            var updatedGuild = ReadData<GuildDto>(getGuildResponse);

            Assert.Equal(2, updatedGuild.MemberKingdomIds.Count);
            Assert.Contains(founderKingdomId, updatedGuild.MemberKingdomIds);
            Assert.Contains(memberKingdomId, updatedGuild.MemberKingdomIds);
        }
        finally
        {
            cts.Cancel();
            server.Stop();
        }
    }

    [Fact]
    public async Task DeclareWarThenRaid_OverTcp_TransfersGoldWhenAttackerStronger()
    {
        var (server, cts, _) = StartServer();
        try
        {
            var attackerId = await CreateKingdomAsync(server.Port, "Vương quốc A");
            var defenderId = await CreateKingdomAsync(server.Port, "Vương quốc B");

            await SendCommandAsync(server.Port, new KingdomCommand
            {
                Action = "RecruitNpc",
                KingdomId = attackerId,
                Payload = JsonSerializer.SerializeToElement(new { Role = "Soldier", SkillLevel = 10 }, JsonOptions)
            });

            await SendCommandAsync(server.Port, new KingdomCommand
            {
                Action = "RecruitNpc",
                KingdomId = defenderId,
                Payload = JsonSerializer.SerializeToElement(new { Role = "Merchant", SkillLevel = 20 }, JsonOptions)
            });
            await SendCommandAsync(server.Port, new KingdomCommand { Action = "Tick", KingdomId = defenderId });

            var declareResponse = await SendCommandAsync(server.Port, new KingdomCommand
            {
                Action = "DeclareWar",
                KingdomId = attackerId,
                Payload = JsonSerializer.SerializeToElement(new { TargetKingdomId = defenderId }, JsonOptions)
            });
            Assert.True(ReadData<DiplomacyActionResultDto>(declareResponse).Success);

            var raidResponse = await SendCommandAsync(server.Port, new KingdomCommand
            {
                Action = "Raid",
                KingdomId = attackerId,
                Payload = JsonSerializer.SerializeToElement(new { TargetKingdomId = defenderId }, JsonOptions)
            });
            var raidResult = ReadData<RaidResultDto>(raidResponse);

            Assert.True(raidResult.Success);
            Assert.True(raidResult.AttackerResources.GetValueOrDefault("gold") > 0);
        }
        finally
        {
            cts.Cancel();
            server.Stop();
        }
    }

    [Fact]
    public async Task ResearchTechnology_OverTcp_UnlocksGatedBuilding()
    {
        var (server, cts, _) = StartServer();
        try
        {
            var kingdomId = await CreateKingdomAsync(server.Port, "Vương quốc A");

            await SendCommandAsync(server.Port, new KingdomCommand
            {
                Action = "RecruitNpc",
                KingdomId = kingdomId,
                Payload = JsonSerializer.SerializeToElement(new { Role = "Merchant", SkillLevel = 30 }, JsonOptions)
            });
            await SendCommandAsync(server.Port, new KingdomCommand { Action = "Tick", KingdomId = kingdomId });

            var beforeResponse = await SendCommandAsync(server.Port, new KingdomCommand
            {
                Action = "CreateBuilding",
                KingdomId = kingdomId,
                Payload = JsonSerializer.SerializeToElement(new { Type = "Market" }, JsonOptions)
            });
            Assert.False(beforeResponse.Success);

            var researchResponse = await SendCommandAsync(server.Port, new KingdomCommand
            {
                Action = "ResearchTechnology",
                KingdomId = kingdomId,
                Payload = JsonSerializer.SerializeToElement(new { TechnologyId = "commerce" }, JsonOptions)
            });
            Assert.True(ReadData<TechnologyResultDto>(researchResponse).Success);

            var afterResponse = await SendCommandAsync(server.Port, new KingdomCommand
            {
                Action = "CreateBuilding",
                KingdomId = kingdomId,
                Payload = JsonSerializer.SerializeToElement(new { Type = "Market" }, JsonOptions)
            });
            Assert.True(afterResponse.Success);
        }
        finally
        {
            cts.Cancel();
            server.Stop();
        }
    }

    [Fact]
    public async Task ActionWithoutKingdomId_ReturnsFailureResponse()
    {
        var (server, cts, _) = StartServer();
        try
        {
            var response = await SendCommandAsync(server.Port, new KingdomCommand { Action = "GetKingdomState" });

            Assert.False(response.Success);
            Assert.False(string.IsNullOrEmpty(response.Error));
        }
        finally
        {
            cts.Cancel();
            server.Stop();
        }
    }

    [Fact]
    public async Task UnknownAction_ReturnsFailureResponse()
    {
        var (server, cts, _) = StartServer();
        try
        {
            var response = await SendCommandAsync(server.Port, new KingdomCommand { Action = "KhongTonTai" });

            Assert.False(response.Success);
            Assert.False(string.IsNullOrEmpty(response.Error));
        }
        finally
        {
            cts.Cancel();
            server.Stop();
        }
    }

    [Fact]
    public async Task SaveGameThenLoadGame_OverTcp_RevertsMutationsAfterSave()
    {
        var (server, cts, _) = StartServer();
        var filePath = Path.Combine(Path.GetTempPath(), $"kingdomcraft-tcp-test-{Guid.NewGuid()}.json");
        try
        {
            var kingdomId = await CreateKingdomAsync(server.Port, "Vương quốc A");
            await SendCommandAsync(server.Port, new KingdomCommand
            {
                Action = "RecruitNpc",
                KingdomId = kingdomId,
                Payload = JsonSerializer.SerializeToElement(new { Role = "Farmer", SkillLevel = 3 }, JsonOptions)
            });

            var saveResponse = await SendCommandAsync(server.Port, new KingdomCommand
            {
                Action = "SaveGame",
                Payload = JsonSerializer.SerializeToElement(new { FilePath = filePath }, JsonOptions)
            });
            Assert.True(ReadData<SaveGameResultDto>(saveResponse).Success);

            // Tuyển thêm 1 NPC SAU khi save — LoadGame phải xóa thay đổi này đi.
            await SendCommandAsync(server.Port, new KingdomCommand
            {
                Action = "RecruitNpc",
                KingdomId = kingdomId,
                Payload = JsonSerializer.SerializeToElement(new { Role = "Miner", SkillLevel = 2 }, JsonOptions)
            });

            var loadResponse = await SendCommandAsync(server.Port, new KingdomCommand
            {
                Action = "LoadGame",
                Payload = JsonSerializer.SerializeToElement(new { FilePath = filePath }, JsonOptions)
            });
            Assert.True(ReadData<SaveGameResultDto>(loadResponse).Success);

            var stateResponse = await SendCommandAsync(server.Port, new KingdomCommand { Action = "GetKingdomState", KingdomId = kingdomId });
            var state = ReadData<KingdomStateDto>(stateResponse);

            Assert.Single(state.Npcs); // chỉ còn Farmer, Miner (tuyển sau save) đã bị revert
        }
        finally
        {
            cts.Cancel();
            server.Stop();
            if (File.Exists(filePath)) File.Delete(filePath);
        }
    }

    [Fact]
    public async Task CreatePlayerThenCraft_OverTcp_UpdatesInventory()
    {
        var (server, cts, _) = StartServer();
        try
        {
            var playerId = await CreatePlayerAsync(server.Port, "Người chơi A");
            var kingdomId = await CreateKingdomAsync(server.Port, "Vương quốc A");

            var recipesResponse = await SendCommandAsync(server.Port, new KingdomCommand
            {
                Action = "GetAllRecipes",
                PlayerId = playerId,
                KingdomId = kingdomId
            });
            Assert.Equal(5, ReadData<List<RecipeDto>>(recipesResponse).Count);

            var playerResponse = await SendCommandAsync(server.Port, new KingdomCommand
            {
                Action = "GetPlayer",
                PlayerId = playerId
            });
            var starterInventory = ReadData<PlayerDto>(playerResponse).Inventory;
            Assert.Equal(5, starterInventory.GetValueOrDefault("wood")); // CreatePlayer seed sẵn 5 wood/5 stone

            // Có sẵn wood từ starter inventory nên craft_plank (không cần trạm) phải thành công.
            var craftResponse = await SendCommandAsync(server.Port, new KingdomCommand
            {
                Action = "Craft",
                PlayerId = playerId,
                KingdomId = kingdomId,
                Payload = JsonSerializer.SerializeToElement(new { RecipeId = "craft_plank" }, JsonOptions)
            });
            var craftResult = ReadData<CraftResultDto>(craftResponse);

            Assert.True(craftResponse.Success);
            Assert.True(craftResult.Success);
            Assert.Equal(4, craftResult.InventorySnapshot.GetValueOrDefault("plank"));
        }
        finally
        {
            cts.Cancel();
            server.Stop();
        }
    }

    [Fact]
    public async Task EvaluateQuests_OverTcp_CompletesAfterRecruitingNpc()
    {
        var (server, cts, _) = StartServer();
        try
        {
            var playerId = await CreatePlayerAsync(server.Port, "Người chơi A");
            var kingdomId = await CreateKingdomAsync(server.Port, "Vương quốc A");

            await SendCommandAsync(server.Port, new KingdomCommand
            {
                Action = "RecruitNpc",
                KingdomId = kingdomId,
                Payload = JsonSerializer.SerializeToElement(new { Role = "Farmer" }, JsonOptions)
            });

            var evaluateResponse = await SendCommandAsync(server.Port, new KingdomCommand
            {
                Action = "EvaluateQuests",
                PlayerId = playerId,
                KingdomId = kingdomId
            });
            var newlyCompleted = ReadData<List<QuestDto>>(evaluateResponse);

            Assert.Contains(newlyCompleted, q => q.Id == "quest_first_npc");

            var questLogResponse = await SendCommandAsync(server.Port, new KingdomCommand
            {
                Action = "GetQuestLog",
                PlayerId = playerId,
                KingdomId = kingdomId
            });
            var questLog = ReadData<List<QuestDto>>(questLogResponse);

            Assert.True(questLog.Single(q => q.Id == "quest_first_npc").IsCompleted);
        }
        finally
        {
            cts.Cancel();
            server.Stop();
        }
    }

    [Fact]
    public async Task SpawnBossThenAttack_OverTcp_ReducesBossHealth()
    {
        var (server, cts, _) = StartServer();
        try
        {
            var playerId = await CreatePlayerAsync(server.Port, "Người chơi A");

            var spawnResponse = await SendCommandAsync(server.Port, new KingdomCommand
            {
                Action = "SpawnBoss",
                PlayerId = playerId,
                Payload = JsonSerializer.SerializeToElement(new { TemplateId = "slime_king" }, JsonOptions)
            });
            var boss = ReadData<BossDto>(spawnResponse);

            var attackResponse = await SendCommandAsync(server.Port, new KingdomCommand
            {
                Action = "AttackBoss",
                PlayerId = playerId,
                Payload = JsonSerializer.SerializeToElement(new { BossId = boss.Id }, JsonOptions)
            });
            var attackResult = ReadData<AttackResultDto>(attackResponse);

            Assert.True(attackResult.Success);
            Assert.Equal(boss.MaxHealth - 1, attackResult.BossHealth); // đánh tay không = 1 attack power
        }
        finally
        {
            cts.Cancel();
            server.Stop();
        }
    }
}
