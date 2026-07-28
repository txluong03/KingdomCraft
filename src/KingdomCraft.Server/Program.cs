using KingdomCraft.Application.Diplomacy;
using KingdomCraft.Application.Guilds;
using KingdomCraft.Application.Kingdom;
using KingdomCraft.Application.Persistence;
using KingdomCraft.Core.Combat;
using KingdomCraft.Core.Diplomacy;
using KingdomCraft.Core.Entities;
using KingdomCraft.Core.Guilds;
using KingdomCraft.Core.Kingdom;
using KingdomCraft.Server.Networking;

// Server headless cho chế độ multiplayer — quản lý NHIỀU vương quốc cùng
// lúc qua KingdomRegistry (mỗi client tự "CreateKingdom" để lấy KingdomId
// riêng, các action sau đó đều kèm KingdomId), cộng với Guild liên kết
// nhiều vương quốc (dùng chung GuildRegistry cho toàn server).
// - KingdomTcpServer: networking thật (thay vòng lặp Task.Delay demo trước
//   đây, KI-04) — client gửi 1 dòng JSON KingdomCommand, nhận lại 1 dòng
//   JSON KingdomResponse.
// - Vòng lặp tick nền: tick TẤT CẢ vương quốc trong registry mỗi giây,
//   đi qua chính dispatcher (không giữ AppService riêng) để dùng chung
//   session/lock với các client TCP, tránh 2 nguồn cùng ghi 1 KingdomState.
// - Save/Load: tải file save khi khởi động (nếu có), tự lưu định kỳ mỗi 30
//   tick (~30 giây). Guild/Diplomacy chưa được lưu (xem SaveGameAppService).
// - Player-scoped actions (CreatePlayer, Craft, EvaluateQuests, SpawnBoss,
//   AttackBoss...) cần PlayerId, dựng AppService mới mỗi lần gọi (không cache
//   như KingdomSession) vì lock nằm sẵn trên Player.SyncRoot/Boss.SyncRoot.

var kingdomRegistry = new KingdomRegistry();
var playerRegistry = new PlayerRegistry();
var bossRegistry = new BossRegistry();
var guildRegistry = new GuildRegistry();
var diplomacyRegistry = new DiplomacyRegistry();
var guildAppService = new GuildAppService(guildRegistry, kingdomRegistry);
var diplomacyAppService = new DiplomacyAppService(diplomacyRegistry, kingdomRegistry, guildRegistry);
var saveGameAppService = new SaveGameAppService(kingdomRegistry);
var dispatcher = new KingdomCommandDispatcher(kingdomRegistry, playerRegistry, bossRegistry, guildAppService, diplomacyAppService, saveGameAppService);

var loadResult = saveGameAppService.Load(new LoadGameInput());
if (loadResult is { Success: true, KingdomCount: > 0 })
{
    Console.WriteLine($"[LoadGame] {loadResult.Message}");
}

var defaultKingdom = kingdomRegistry.All.FirstOrDefault() ?? kingdomRegistry.Create("Vương quốc mẫu");
dispatcher.Dispatch(new KingdomCommand { Action = "GetKingdomState", KingdomId = defaultKingdom.Id }); // khởi tạo session

var tcpServer = new KingdomTcpServer(dispatcher, port: 5000);
tcpServer.Start();

using var cts = new CancellationTokenSource();
_ = tcpServer.RunAsync(cts.Token);

Console.WriteLine($"KingdomCraft.Server đang chạy, lắng nghe TCP tại cổng {tcpServer.Port}. Nhấn Ctrl+C để dừng.");
Console.WriteLine($"Vương quốc mặc định: {defaultKingdom.Name} (KingdomId={defaultKingdom.Id})");

var tickCount = 0;
while (true)
{
    foreach (var kingdom in kingdomRegistry.All)
    {
        var response = dispatcher.Dispatch(new KingdomCommand { Action = "Tick", KingdomId = kingdom.Id });
        if (response is { Success: true, Data: KingdomStateDto state })
        {
            Console.WriteLine($"[Tick] {kingdom.Name} ({kingdom.Id}) AutomationLevel={state.AutomationLevel} Food={state.Resources.GetValueOrDefault("food")}");
        }
    }

    tickCount++;
    if (tickCount % 30 == 0)
    {
        var saveResult = saveGameAppService.Save(new SaveGameInput());
        Console.WriteLine($"[AutoSave] {saveResult.Message}");
    }

    await Task.Delay(1000);
}
