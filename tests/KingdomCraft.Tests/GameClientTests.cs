using KingdomCraft.Application.Diplomacy;
using KingdomCraft.Application.Guilds;
using KingdomCraft.Application.Kingdom;
using KingdomCraft.Application.Persistence;
using KingdomCraft.Client.Networking;
using KingdomCraft.Core.Combat;
using KingdomCraft.Core.Diplomacy;
using KingdomCraft.Core.Entities;
using KingdomCraft.Core.Guilds;
using KingdomCraft.Core.Kingdom;
using KingdomCraft.Server.Networking;
using Xunit;

namespace KingdomCraft.Tests;

/// <summary>
/// Xác nhận GameClient (dùng bởi KingdomCraft.Client) thật sự nói chuyện được
/// với KingdomTcpServer thật — đây là phần mình KHÔNG thể kiểm tra trực quan
/// (không có màn hình chạy MonoGame), nên test networking logic kỹ ở đây.
/// </summary>
public class GameClientTests
{
    private static (KingdomTcpServer Server, CancellationTokenSource Cts) StartServer()
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
        _ = server.RunAsync(cts.Token);
        return (server, cts);
    }

    [Fact]
    public async Task ConnectCreatePlayerAndKingdom_ThenRecruitNpc_Succeeds()
    {
        var (server, cts) = StartServer();
        using var client = new GameClient();
        try
        {
            await client.ConnectAsync("127.0.0.1", server.Port);
            Assert.True(client.IsConnected);

            var playerResponse = await client.SendAsync(new GameCommand
            {
                Action = "CreatePlayer",
                Payload = new { Name = "Người chơi Test" }
            });
            Assert.True(playerResponse.Success);

            var kingdomResponse = await client.SendAsync(new GameCommand
            {
                Action = "CreateKingdom",
                Payload = new { Name = "Vương quốc Test" }
            });
            Assert.True(kingdomResponse.Success);
            var kingdomId = GameClient.ReadData<KingdomStateDto>(kingdomResponse).Id;

            var recruitResponse = await client.SendAsync(new GameCommand
            {
                Action = "RecruitNpc",
                KingdomId = kingdomId,
                Payload = new { Role = "Farmer", SkillLevel = 3 }
            });
            Assert.True(recruitResponse.Success);
            var recruitedNpc = GameClient.ReadData<NpcDto>(recruitResponse);
            Assert.Equal(3, recruitedNpc.SkillLevel);

            var stateResponse = await client.SendAsync(new GameCommand { Action = "GetKingdomState", KingdomId = kingdomId });
            var state = GameClient.ReadData<KingdomStateDto>(stateResponse);
            Assert.Single(state.Npcs);
        }
        finally
        {
            cts.Cancel();
            server.Stop();
        }
    }

    [Fact]
    public async Task CreatePlayer_ReceivesStarterInventory()
    {
        var (server, cts) = StartServer();
        using var client = new GameClient();
        try
        {
            await client.ConnectAsync("127.0.0.1", server.Port);

            var response = await client.SendAsync(new GameCommand
            {
                Action = "CreatePlayer",
                Payload = new { Name = "Người chơi Test" }
            });

            var player = GameClient.ReadData<KingdomCraft.Application.Players.PlayerDto>(response);
            Assert.Equal(5, player.Inventory.GetValueOrDefault("wood"));
            Assert.Equal(5, player.Inventory.GetValueOrDefault("stone"));
        }
        finally
        {
            cts.Cancel();
            server.Stop();
        }
    }

    [Fact]
    public async Task GatherItem_OverTcp_AddsToInventory()
    {
        var (server, cts) = StartServer();
        using var client = new GameClient();
        try
        {
            await client.ConnectAsync("127.0.0.1", server.Port);
            var playerResponse = await client.SendAsync(new GameCommand { Action = "CreatePlayer", Payload = new { Name = "Thợ mỏ" } });
            var playerId = GameClient.ReadData<KingdomCraft.Application.Players.PlayerDto>(playerResponse).Id;

            var gatherResponse = await client.SendAsync(new GameCommand
            {
                Action = "GatherItem",
                PlayerId = playerId,
                Payload = new { ItemId = "stone", Quantity = 3 }
            });

            Assert.True(gatherResponse.Success);
            var player = GameClient.ReadData<KingdomCraft.Application.Players.PlayerDto>(gatherResponse);
            Assert.Equal(8, player.Inventory.GetValueOrDefault("stone")); // 5 seed + 3 gather
        }
        finally
        {
            cts.Cancel();
            server.Stop();
        }
    }

    [Fact]
    public async Task SendAsync_WithoutConnecting_Throws()
    {
        using var client = new GameClient();

        await Assert.ThrowsAsync<InvalidOperationException>(() =>
            client.SendAsync(new GameCommand { Action = "GetKingdomState" }));
    }
}
