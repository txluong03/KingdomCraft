using KingdomCraft.Core.Economy;
using KingdomCraft.Core.Kingdom;
using Xunit;

namespace KingdomCraft.Tests;

public class EconomySystemTests
{
    [Fact]
    public void TrySellResource_EnoughStock_ConvertsToGoldAtFixedRate()
    {
        var kingdom = new KingdomState();
        kingdom.Resources.Add("stone", 10);
        var system = new EconomySystem();

        var success = system.TrySellResource(kingdom, "stone", 5);

        Assert.True(success);
        Assert.Equal(5, kingdom.Resources.Get("stone"));
        Assert.Equal(10, kingdom.Resources.Get("gold")); // 5 * 2 gold/unit
    }

    [Fact]
    public void TrySellResource_NotEnoughStock_Fails()
    {
        var kingdom = new KingdomState();
        kingdom.Resources.Add("wood", 2);
        var system = new EconomySystem();

        var success = system.TrySellResource(kingdom, "wood", 5);

        Assert.False(success);
        Assert.Equal(2, kingdom.Resources.Get("wood"));
        Assert.Equal(0, kingdom.Resources.Get("gold"));
    }

    [Fact]
    public void TrySellResource_UnknownResource_Fails()
    {
        var kingdom = new KingdomState();
        var system = new EconomySystem();

        var success = system.TrySellResource(kingdom, "khong-ton-tai", 1);

        Assert.False(success);
    }
}
