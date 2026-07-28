using KingdomCraft.Application.Combat;
using KingdomCraft.Application.Crafting;
using KingdomCraft.Application.Kingdom;
using KingdomCraft.Application.Players;
using KingdomCraft.Application.Quests;

namespace KingdomCraft.Client.Networking;

/// <summary>
/// Gói gọn tương tác qua <see cref="GameClient"/> — vừa in ra console, vừa
/// lưu lại trạng thái mới nhất (<see cref="LastPlayer"/>/<see cref="LastKingdom"/>/
/// <see cref="LastMessage"/>) để Game1 vẽ lên HUD trong cửa sổ game (không
/// bắt buộc phải xem console nữa). Không bắt lỗi hình ảnh (đó là việc của
/// Game1) — chỉ đảm bảo action mạng không làm crash game khi Server chưa
/// chạy hoặc trả lỗi.
/// </summary>
public class GameSession : IDisposable
{
    private readonly GameClient _client = new();
    private string? _playerId;
    private string? _kingdomId;
    private string? _bossId;

    public bool IsReady => _playerId is not null && _kingdomId is not null;

    /// <summary>Trạng thái Player mới nhất đã biết — null nếu chưa từng lấy được.</summary>
    public PlayerDto? LastPlayer { get; private set; }

    /// <summary>Trạng thái Kingdom mới nhất đã biết — null nếu chưa từng lấy được.</summary>
    public KingdomStateDto? LastKingdom { get; private set; }

    /// <summary>Dòng thông báo gần nhất — dùng để hiện trong HUD thay vì chỉ console.</summary>
    public string LastMessage { get; private set; } = string.Empty;

    public void Connect(string host, int port)
    {
        try
        {
            _client.ConnectAsync(host, port).GetAwaiter().GetResult();

            var player = GameClient.ReadData<PlayerDto>(_client.Send(new GameCommand
            {
                Action = "CreatePlayer",
                Payload = new { Name = "Người chơi" }
            }));
            _playerId = player.Id;
            LastPlayer = player;

            var kingdom = GameClient.ReadData<KingdomStateDto>(_client.Send(new GameCommand
            {
                Action = "CreateKingdom",
                Payload = new { Name = "Vương quốc của " + player.Name }
            }));
            _kingdomId = kingdom.Id;
            LastKingdom = kingdom;

            Console.WriteLine($"[Network] Đã kết nối Server tại {host}:{port}.");
            Console.WriteLine($"[Network] PlayerId={_playerId}  KingdomId={_kingdomId}");
            PrintHelp();
            Log($"Đã kết nối. Túi đồ khởi đầu: {Describe(player.Inventory)}");
        }
        catch (Exception ex)
        {
            Log($"Không kết nối được tới Server tại {host}:{port} — {ex.Message}");
            Console.WriteLine("[Network] Hãy chạy `dotnet run --project src/KingdomCraft.Server` trước rồi khởi động lại Client.");
        }
    }

    public static void PrintHelp() => Console.WriteLine(
        "Phím tắt: F1 Trạng thái | F2 Craft Plank | F3 Craft Rìu gỗ | F4 Tuyển Farmer | " +
        "F5 Tick thủ công | F6 Chấm Quest | F7 Triệu hồi Boss | F8 Đánh Boss | V Đổi góc nhìn");

    public void PrintStatus()
    {
        if (!EnsureReady()) return;

        RunSafely(() =>
        {
            var player = GameClient.ReadData<PlayerDto>(_client.Send(new GameCommand { Action = "GetPlayer", PlayerId = _playerId }));
            var kingdom = GameClient.ReadData<KingdomStateDto>(_client.Send(new GameCommand { Action = "GetKingdomState", KingdomId = _kingdomId }));
            LastPlayer = player;
            LastKingdom = kingdom;

            Console.WriteLine("=== Trạng thái ===");
            Console.WriteLine($"Người chơi: {player.Name} · HP {player.Health} · Túi đồ: {Describe(player.Inventory)}");
            Console.WriteLine($"Vương quốc: {kingdom.Name} · AutomationLevel {kingdom.AutomationLevel} · Tài nguyên: {Describe(kingdom.Resources)}");
            Console.WriteLine($"Công trình: {kingdom.Buildings.Count} · NPC: {kingdom.Npcs.Count} · " +
                               $"Công nghệ đã nghiên cứu: {(kingdom.ResearchedTechnologyIds.Count == 0 ? "(chưa có)" : string.Join(", ", kingdom.ResearchedTechnologyIds))}");
            LastMessage = "Đã cập nhật trạng thái (F1).";
        });
    }

    public void CraftPlank() => Craft("craft_plank", hasStationAccess: false);

    public void CraftWoodenAxe() => Craft("craft_wooden_axe", hasStationAccess: true);

    private void Craft(string recipeId, bool hasStationAccess)
    {
        if (!EnsureReady()) return;

        RunSafely(() =>
        {
            var response = _client.Send(new GameCommand
            {
                Action = "Craft",
                PlayerId = _playerId,
                KingdomId = _kingdomId,
                Payload = new { RecipeId = recipeId, HasStationAccess = hasStationAccess }
            });
            var result = GameClient.ReadData<CraftResultDto>(response);
            if (LastPlayer is not null) LastPlayer.Inventory = result.InventorySnapshot;
            Log($"Craft {recipeId}: {(result.Success ? "Thành công" : "Thất bại")} — {result.Message}");
        });
    }

    public void RecruitFarmer()
    {
        if (!EnsureReady()) return;

        RunSafely(() =>
        {
            var response = _client.Send(new GameCommand
            {
                Action = "RecruitNpc",
                KingdomId = _kingdomId,
                Payload = new { Role = "Farmer", SkillLevel = 3 }
            });
            var npc = GameClient.ReadData<NpcDto>(response);
            Log($"Đã tuyển {npc.Role} (SkillLevel={npc.SkillLevel}).");
        });
    }

    /// <summary>Gọi khi người chơi đào/phá được 1 khối có item tương ứng (xem Core/World/BlockDrops.cs).</summary>
    public void GatherItem(string itemId, int quantity)
    {
        if (!EnsureReady()) return;

        RunSafely(() =>
        {
            var response = _client.Send(new GameCommand
            {
                Action = "GatherItem",
                PlayerId = _playerId,
                Payload = new { ItemId = itemId, Quantity = quantity }
            });
            var player = GameClient.ReadData<PlayerDto>(response);
            LastPlayer = player;
            Log($"+{quantity} {itemId} → Túi đồ: {Describe(player.Inventory)}");
        });
    }

    public void TickManually()
    {
        if (!EnsureReady()) return;

        RunSafely(() =>
        {
            var state = GameClient.ReadData<KingdomStateDto>(_client.Send(new GameCommand { Action = "Tick", KingdomId = _kingdomId }));
            LastKingdom = state;
            Log($"Tick: AutomationLevel={state.AutomationLevel} · {Describe(state.Resources)}");
        });
    }

    public void EvaluateQuests()
    {
        if (!EnsureReady()) return;

        RunSafely(() =>
        {
            var response = _client.Send(new GameCommand { Action = "EvaluateQuests", PlayerId = _playerId, KingdomId = _kingdomId });
            var completed = GameClient.ReadData<List<QuestDto>>(response);
            Log(completed.Count == 0
                ? "Chưa có quest nào vừa hoàn thành."
                : $"Vừa hoàn thành: {string.Join(", ", completed.Select(q => q.Title))}");
        });
    }

    public void SpawnBoss()
    {
        if (!EnsureReady()) return;

        RunSafely(() =>
        {
            var response = _client.Send(new GameCommand { Action = "SpawnBoss", PlayerId = _playerId, Payload = new { TemplateId = "slime_king" } });
            var boss = GameClient.ReadData<BossDto>(response);
            _bossId = boss.Id;
            Log($"Đã triệu hồi {boss.Name} (Health {boss.Health}/{boss.MaxHealth}).");
        });
    }

    public void AttackBoss()
    {
        if (!EnsureReady()) return;

        if (_bossId is null)
        {
            Log("Chưa triệu hồi boss nào — bấm F7 trước.");
            return;
        }

        RunSafely(() =>
        {
            var response = _client.Send(new GameCommand
            {
                Action = "AttackBoss",
                PlayerId = _playerId,
                Payload = new { BossId = _bossId, WeaponItemId = "wooden_axe" }
            });
            var result = GameClient.ReadData<AttackResultDto>(response);
            Log($"{result.Message} Boss HP={result.BossHealth}, Player HP={result.PlayerHealth}.");
        });
    }

    private bool EnsureReady()
    {
        if (IsReady) return true;
        Log("Chưa kết nối Server — không thực hiện được hành động.");
        return false;
    }

    private static void RunSafely(Action action)
    {
        try
        {
            action();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"[Network] Lỗi: {ex.Message}");
        }
    }

    private void Log(string message)
    {
        Console.WriteLine($"[Game] {message}");
        LastMessage = message;
    }

    private static string Describe(Dictionary<string, int> items) =>
        items.Count == 0 ? "(trống)" : string.Join(", ", items.Select(kv => $"{kv.Key}={kv.Value}"));

    public void Dispose() => _client.Dispose();
}
