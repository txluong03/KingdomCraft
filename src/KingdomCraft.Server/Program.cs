using KingdomCraft.Application.Kingdom;
using KingdomCraft.Core.Kingdom;

// Server headless cho chế độ multiplayer.
// Vòng lặp mô phỏng cơ bản: gọi KingdomAppService.Tick() mỗi tick để vương quốc
// tự vận hành ngay cả khi client không kết nối. Đi qua Application layer (thay
// vì gọi thẳng AutomationSystem) để sẵn sàng cho networking thật ở Bước 3.

var kingdom = new KingdomState { Name = "Vương quốc mẫu" };
var kingdomAppService = new KingdomAppService(kingdom);

Console.WriteLine("KingdomCraft.Server đang chạy. Nhấn Ctrl+C để dừng.");

while (true)
{
    var state = kingdomAppService.Tick();
    Console.WriteLine($"[Tick] AutomationLevel={state.AutomationLevel} Food={state.Resources.GetValueOrDefault("food")}");
    await Task.Delay(1000);
}
