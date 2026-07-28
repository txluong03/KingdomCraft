using KingdomCraft.Application.Players;
using KingdomCraft.Core.Entities;
using Xunit;

namespace KingdomCraft.Tests;

public class PlayerAppServiceGatherItemTests
{
    [Fact]
    public void GatherItem_AddsToExistingStarterStack()
    {
        var registry = new PlayerRegistry();
        var appService = new PlayerAppService(registry);
        var created = appService.CreatePlayer(new CreatePlayerInput { Name = "A" });

        var player = appService.GatherItem(created.Id, new GatherItemInput { ItemId = "stone", Quantity = 2 });

        Assert.Equal(7, player.Inventory.GetValueOrDefault("stone")); // 5 seed + 2 gather
    }

    [Fact]
    public void GatherItem_UnknownPlayerId_Throws()
    {
        var appService = new PlayerAppService(new PlayerRegistry());

        Assert.Throws<InvalidOperationException>(() =>
            appService.GatherItem("khong-ton-tai", new GatherItemInput { ItemId = "stone", Quantity = 1 }));
    }
}
