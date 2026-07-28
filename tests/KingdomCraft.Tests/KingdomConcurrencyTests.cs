using KingdomCraft.Application.Economy;
using KingdomCraft.Application.Kingdom;
using KingdomCraft.Core.Entities;
using KingdomCraft.Core.Kingdom;
using Xunit;

namespace KingdomCraft.Tests;

/// <summary>
/// KingdomAppService và EconomyAppService phải dùng CHUNG 1 lock
/// (KingdomState.SyncRoot) vì cùng thao tác lên KingdomState.Resources
/// (Dictionary&lt;string,int&gt; không thread-safe). Trước khi sửa, 2 lớp này
/// mỗi cái giữ 1 lock riêng — không loại trừ lẫn nhau, gọi đồng thời từ
/// nhiều kết nối TCP có thể làm Dictionary corrupt/throw giữa chừng.
/// </summary>
public class KingdomConcurrencyTests
{
    [Fact]
    public async Task ConcurrentTickAndSellResource_DoNotCorruptState()
    {
        var kingdom = new KingdomState();
        var kingdomAppService = new KingdomAppService(kingdom);
        var economyAppService = new EconomyAppService(kingdom);

        for (var i = 0; i < 20; i++)
        {
            kingdomAppService.RecruitNpc(new RecruitNpcInput { Role = NpcRole.Farmer, SkillLevel = 5 });
        }

        var tasks = new List<Task>();
        for (var i = 0; i < 200; i++)
        {
            tasks.Add(Task.Run(() => kingdomAppService.Tick()));
            tasks.Add(Task.Run(() => economyAppService.SellResource(new SellResourceInput { ResourceName = "food", Quantity = 1 })));
        }

        var exception = await Record.ExceptionAsync(() => Task.WhenAll(tasks));

        Assert.Null(exception);
        var finalState = kingdomAppService.GetKingdomState();
        Assert.All(finalState.Resources.Values, amount => Assert.True(amount >= 0));
    }
}
