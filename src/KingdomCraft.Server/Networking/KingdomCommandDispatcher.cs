using System.Text.Json;
using System.Text.Json.Serialization;
using KingdomCraft.Application.Combat;
using KingdomCraft.Application.Crafting;
using KingdomCraft.Application.Diplomacy;
using KingdomCraft.Application.Economy;
using KingdomCraft.Application.Guilds;
using KingdomCraft.Application.Kingdom;
using KingdomCraft.Application.Persistence;
using KingdomCraft.Application.Players;
using KingdomCraft.Application.Quests;
using CoreBossRegistry = KingdomCraft.Core.Combat.BossRegistry;
using CoreKingdomRegistry = KingdomCraft.Core.Kingdom.KingdomRegistry;
using CoreKingdomState = KingdomCraft.Core.Kingdom.KingdomState;
using CorePlayer = KingdomCraft.Core.Entities.Player;
using CorePlayerRegistry = KingdomCraft.Core.Entities.PlayerRegistry;

namespace KingdomCraft.Server.Networking;

/// <summary>
/// Nối 1 <see cref="KingdomCommand"/> tới đúng AppService — quản lý NHIỀU
/// vương quốc cùng lúc qua <see cref="CoreKingdomRegistry"/> (khớp `KingdomId`
/// trên mỗi command), cộng với Guild dùng chung cho toàn server. Ranh giới
/// network mỏng, không chứa business logic (logic thật nằm ở Application/Core).
/// </summary>
public class KingdomCommandDispatcher
{
    private static readonly JsonSerializerOptions JsonOptions = CreateJsonOptions();

    private static JsonSerializerOptions CreateJsonOptions()
    {
        var options = new JsonSerializerOptions(JsonSerializerDefaults.Web);
        options.Converters.Add(new JsonStringEnumConverter());
        return options;
    }

    private readonly CoreKingdomRegistry _kingdomRegistry;
    private readonly CorePlayerRegistry _playerRegistry;
    private readonly CoreBossRegistry _bossRegistry;
    private readonly GuildAppService _guildAppService;
    private readonly DiplomacyAppService _diplomacyAppService;
    private readonly SaveGameAppService _saveGameAppService;
    private readonly PlayerAppService _playerAppService;
    private readonly Dictionary<string, KingdomSession> _sessions = new();
    private readonly object _sessionsLock = new();

    public KingdomCommandDispatcher(
        CoreKingdomRegistry kingdomRegistry,
        CorePlayerRegistry playerRegistry,
        CoreBossRegistry bossRegistry,
        GuildAppService guildAppService,
        DiplomacyAppService diplomacyAppService,
        SaveGameAppService saveGameAppService)
    {
        _kingdomRegistry = kingdomRegistry;
        _playerRegistry = playerRegistry;
        _bossRegistry = bossRegistry;
        _guildAppService = guildAppService;
        _diplomacyAppService = diplomacyAppService;
        _saveGameAppService = saveGameAppService;
        _playerAppService = new PlayerAppService(playerRegistry);
    }

    public KingdomResponse Dispatch(KingdomCommand command)
    {
        try
        {
            object? data = command.Action switch
            {
                "CreateKingdom" => CreateKingdom(Deserialize<CreateKingdomInput>(command.Payload)),
                "GetKingdomState" => GetSession(command).KingdomAppService.GetKingdomState(),
                "Tick" => GetSession(command).KingdomAppService.Tick(),
                "CreateBuilding" => GetSession(command).KingdomAppService.CreateBuilding(Deserialize<CreateBuildingInput>(command.Payload)),
                "RecruitNpc" => GetSession(command).KingdomAppService.RecruitNpc(Deserialize<RecruitNpcInput>(command.Payload)),
                "AssignNpcRole" => GetSession(command).KingdomAppService.AssignNpcRole(Deserialize<AssignNpcRoleInput>(command.Payload)),
                "TrainNpc" => GetSession(command).KingdomAppService.TrainNpc(Deserialize<TrainNpcInput>(command.Payload)),
                "SellResource" => GetSession(command).EconomyAppService.SellResource(Deserialize<SellResourceInput>(command.Payload)),
                "CreateGuild" => _guildAppService.CreateGuild(RequireKingdomId(command), Deserialize<CreateGuildInput>(command.Payload)),
                "JoinGuild" => _guildAppService.Join(RequireKingdomId(command), Deserialize<JoinGuildInput>(command.Payload)),
                "LeaveGuild" => _guildAppService.Leave(RequireKingdomId(command), Deserialize<LeaveGuildInput>(command.Payload)),
                "GetGuild" => _guildAppService.GetGuild(Deserialize<GetGuildInput>(command.Payload)),
                "ResearchTechnology" => GetSession(command).KingdomAppService.ResearchTechnology(Deserialize<ResearchTechnologyInput>(command.Payload)),
                "GetDiplomacyStatus" => _diplomacyAppService.GetStatus(RequireKingdomId(command), Deserialize<GetDiplomacyStatusInput>(command.Payload)),
                "DeclareWar" => _diplomacyAppService.DeclareWar(RequireKingdomId(command), Deserialize<DeclareWarInput>(command.Payload)),
                "MakePeace" => _diplomacyAppService.MakePeace(RequireKingdomId(command), Deserialize<MakePeaceInput>(command.Payload)),
                "Raid" => _diplomacyAppService.Raid(RequireKingdomId(command), Deserialize<RaidInput>(command.Payload)),
                "SaveGame" => _saveGameAppService.Save(Deserialize<SaveGameInput>(command.Payload)),
                "LoadGame" => LoadGame(Deserialize<LoadGameInput>(command.Payload)),
                "CreatePlayer" => _playerAppService.CreatePlayer(Deserialize<CreatePlayerInput>(command.Payload)),
                "GetPlayer" => _playerAppService.GetPlayer(new GetPlayerInput { PlayerId = RequirePlayerId(command) }),
                "GatherItem" => _playerAppService.GatherItem(RequirePlayerId(command), Deserialize<GatherItemInput>(command.Payload)),
                "GetAllRecipes" => new CraftingAppService(RequirePlayer(command), RequireKingdom(command)).GetAllRecipes(),
                "Craft" => new CraftingAppService(RequirePlayer(command), RequireKingdom(command)).Craft(Deserialize<CraftInput>(command.Payload)),
                "GetQuestLog" => new QuestAppService(RequirePlayer(command), RequireKingdom(command)).GetQuestLog(),
                "EvaluateQuests" => new QuestAppService(RequirePlayer(command), RequireKingdom(command)).EvaluateQuests(),
                "SpawnBoss" => new BossAppService(_bossRegistry, RequirePlayer(command)).SpawnBoss(Deserialize<SpawnBossInput>(command.Payload)),
                "GetBoss" => new BossAppService(_bossRegistry, RequirePlayer(command)).GetBoss(Deserialize<GetBossInput>(command.Payload)),
                "AttackBoss" => new BossAppService(_bossRegistry, RequirePlayer(command)).AttackBoss(Deserialize<AttackBossInput>(command.Payload)),
                _ => throw new InvalidOperationException($"Không hỗ trợ action '{command.Action}'.")
            };

            return new KingdomResponse { Success = true, Data = data };
        }
        catch (Exception ex)
        {
            return new KingdomResponse { Success = false, Error = ex.Message };
        }
    }

    /// <summary>
    /// Sau khi Load, session cache cũ (nếu có) sẽ giữ tham chiếu KingdomState CŨ
    /// — phải xóa để GetSession tạo lại session mới trỏ đúng dữ liệu vừa nạp.
    /// </summary>
    private SaveGameResultDto LoadGame(LoadGameInput input)
    {
        var result = _saveGameAppService.Load(input);
        if (!result.Success)
            return result;

        lock (_sessionsLock)
        {
            foreach (var kingdom in _kingdomRegistry.All)
            {
                _sessions.Remove(kingdom.Id);
            }
        }

        return result;
    }

    private KingdomStateDto CreateKingdom(CreateKingdomInput input)
    {
        var kingdom = _kingdomRegistry.Create(input.Name);
        KingdomSession session;
        lock (_sessionsLock)
        {
            session = new KingdomSession(kingdom);
            _sessions[kingdom.Id] = session;
        }

        return session.KingdomAppService.GetKingdomState();
    }

    private KingdomSession GetSession(KingdomCommand command)
    {
        var kingdomId = RequireKingdomId(command);

        lock (_sessionsLock)
        {
            if (_sessions.TryGetValue(kingdomId, out var existing))
                return existing;
        }

        var kingdom = _kingdomRegistry.Find(kingdomId)
            ?? throw new InvalidOperationException($"Không tìm thấy vương quốc '{kingdomId}'.");

        lock (_sessionsLock)
        {
            if (!_sessions.TryGetValue(kingdomId, out var session))
            {
                session = new KingdomSession(kingdom);
                _sessions[kingdomId] = session;
            }

            return session;
        }
    }

    private static string RequireKingdomId(KingdomCommand command) =>
        string.IsNullOrEmpty(command.KingdomId)
            ? throw new InvalidOperationException("Thiếu KingdomId.")
            : command.KingdomId;

    private static string RequirePlayerId(KingdomCommand command) =>
        string.IsNullOrEmpty(command.PlayerId)
            ? throw new InvalidOperationException("Thiếu PlayerId.")
            : command.PlayerId;

    private CoreKingdomState RequireKingdom(KingdomCommand command) =>
        _kingdomRegistry.Find(RequireKingdomId(command))
            ?? throw new InvalidOperationException($"Không tìm thấy vương quốc '{command.KingdomId}'.");

    private CorePlayer RequirePlayer(KingdomCommand command) =>
        _playerRegistry.Find(RequirePlayerId(command))
            ?? throw new InvalidOperationException($"Không tìm thấy người chơi '{command.PlayerId}'.");

    private static T Deserialize<T>(JsonElement payload) =>
        payload.Deserialize<T>(JsonOptions) ?? throw new InvalidOperationException("Payload không hợp lệ.");
}
