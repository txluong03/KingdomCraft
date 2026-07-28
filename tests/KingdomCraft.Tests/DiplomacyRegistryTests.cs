using KingdomCraft.Core.Diplomacy;
using Xunit;

namespace KingdomCraft.Tests;

public class DiplomacyRegistryTests
{
    [Fact]
    public void GetStatus_NeverDeclared_ReturnsNeutral()
    {
        var registry = new DiplomacyRegistry();

        Assert.Equal(DiplomacyStatus.Neutral, registry.GetStatus("a", "b"));
    }

    [Fact]
    public void DeclareWar_ThenGetStatus_ReturnsAtWarRegardlessOfOrder()
    {
        var registry = new DiplomacyRegistry();

        registry.DeclareWar("a", "b");

        Assert.Equal(DiplomacyStatus.AtWar, registry.GetStatus("a", "b"));
        Assert.Equal(DiplomacyStatus.AtWar, registry.GetStatus("b", "a"));
    }

    [Fact]
    public void DeclareWar_SameKingdom_Fails()
    {
        var registry = new DiplomacyRegistry();

        Assert.False(registry.DeclareWar("a", "a"));
    }

    [Fact]
    public void MakePeace_AfterWar_ReturnsToNeutral()
    {
        var registry = new DiplomacyRegistry();
        registry.DeclareWar("a", "b");

        registry.MakePeace("a", "b");

        Assert.Equal(DiplomacyStatus.Neutral, registry.GetStatus("a", "b"));
    }
}
