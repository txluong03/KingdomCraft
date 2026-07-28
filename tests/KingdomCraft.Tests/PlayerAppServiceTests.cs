using KingdomCraft.Application.Players;
using KingdomCraft.Core.Entities;
using Xunit;

namespace KingdomCraft.Tests;

public class PlayerAppServiceTests
{
    [Fact]
    public void CreatePlayer_ReturnsDefaultStatsWithStarterInventory()
    {
        var appService = new PlayerAppService(new PlayerRegistry());

        var player = appService.CreatePlayer(new CreatePlayerInput { Name = "Người chơi A" });

        Assert.Equal("Người chơi A", player.Name);
        Assert.Equal(100, player.Health);
        Assert.Equal(5, player.Inventory.GetValueOrDefault("wood"));
        Assert.Equal(5, player.Inventory.GetValueOrDefault("stone"));
    }

    [Fact]
    public void GetPlayer_UnknownId_Throws()
    {
        var appService = new PlayerAppService(new PlayerRegistry());

        Assert.Throws<InvalidOperationException>(() =>
            appService.GetPlayer(new GetPlayerInput { PlayerId = "khong-ton-tai" }));
    }

    [Fact]
    public void GetPlayer_ReflectsInventoryChanges()
    {
        var registry = new PlayerRegistry();
        var appService = new PlayerAppService(registry);
        var created = appService.CreatePlayer(new CreatePlayerInput { Name = "A" });
        registry.Find(created.Id)!.Inventory.TryAdd("gold_coin", 5);

        var player = appService.GetPlayer(new GetPlayerInput { PlayerId = created.Id });

        Assert.Equal(5, player.Inventory.GetValueOrDefault("gold_coin"));
    }
}
