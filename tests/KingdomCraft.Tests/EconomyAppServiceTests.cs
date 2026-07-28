using KingdomCraft.Application.Economy;
using KingdomCraft.Core.Kingdom;
using Xunit;

namespace KingdomCraft.Tests;

public class EconomyAppServiceTests
{
    [Fact]
    public void SellResource_EnoughStock_ReturnsSuccessAndUpdatedResources()
    {
        var kingdom = new KingdomState();
        kingdom.Resources.Add("food", 20);
        var appService = new EconomyAppService(kingdom);

        var result = appService.SellResource(new SellResourceInput { ResourceName = "food", Quantity = 10 });

        Assert.True(result.Success);
        Assert.Equal(10, result.Resources.GetValueOrDefault("food"));
        Assert.Equal(10, result.Resources.GetValueOrDefault("gold"));
    }

    [Fact]
    public void SellResource_NotEnoughStock_ReturnsFailure()
    {
        var appService = new EconomyAppService(new KingdomState());

        var result = appService.SellResource(new SellResourceInput { ResourceName = "wood", Quantity = 1 });

        Assert.False(result.Success);
    }
}
