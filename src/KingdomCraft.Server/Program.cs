using KingdomCraft.Core.Kingdom;
using KingdomCraft.Core.Simulation;

// Server headless cho chế độ multiplayer.
// Vòng lặp mô phỏng cơ bản: chạy AutomationSystem theo tick để vương quốc
// tự vận hành ngay cả khi client không kết nối.

var kingdom = new KingdomState { Name = "Vương quốc mẫu" };
var automation = new AutomationSystem();

Console.WriteLine("KingdomCraft.Server đang chạy. Nhấn Ctrl+C để dừng.");

while (true)
{
    automation.Tick(kingdom);
    Console.WriteLine($"[Tick] AutomationLevel={kingdom.AutomationLevel} Food={kingdom.Resources.Get("food")}");
    await Task.Delay(1000);
}
