using KingdomCraft.Core.Kingdom;
using KingdomCraft.Core.Technology;
using Xunit;

namespace KingdomCraft.Tests;

public class TechnologySystemTests
{
    [Fact]
    public void IsRecipeUnlocked_NoGatingTech_DefaultsToUnlocked()
    {
        var system = new TechnologySystem();

        Assert.True(system.IsRecipeUnlocked(new KingdomState(), "craft_plank"));
    }

    [Fact]
    public void IsRecipeUnlocked_GatedRecipeNotResearched_ReturnsFalse()
    {
        var system = new TechnologySystem();

        Assert.False(system.IsRecipeUnlocked(new KingdomState(), "craft_stone_axe"));
    }

    [Fact]
    public void TryResearch_EnoughGold_UnlocksAndDeductsGold()
    {
        var kingdom = new KingdomState();
        kingdom.Resources.Add("gold", 20);
        var system = new TechnologySystem();

        var success = system.TryResearch(kingdom, "stone_working");

        Assert.True(success);
        Assert.Equal(0, kingdom.Resources.Get("gold"));
        Assert.True(system.IsRecipeUnlocked(kingdom, "craft_stone_axe"));
    }

    [Fact]
    public void TryResearch_NotEnoughGold_Fails()
    {
        var kingdom = new KingdomState();
        var system = new TechnologySystem();

        Assert.False(system.TryResearch(kingdom, "stone_working"));
    }

    [Fact]
    public void TryResearch_AlreadyResearched_Fails()
    {
        var kingdom = new KingdomState();
        kingdom.Resources.Add("gold", 100);
        var system = new TechnologySystem();
        system.TryResearch(kingdom, "stone_working");

        var success = system.TryResearch(kingdom, "stone_working");

        Assert.False(success);
    }

    [Fact]
    public void IsBuildingUnlocked_MarketGatedByCommerce()
    {
        var kingdom = new KingdomState();
        var system = new TechnologySystem();

        Assert.False(system.IsBuildingUnlocked(kingdom, BuildingType.Market));

        kingdom.Resources.Add("gold", 30);
        system.TryResearch(kingdom, "commerce");

        Assert.True(system.IsBuildingUnlocked(kingdom, BuildingType.Market));
    }

    [Fact]
    public void IsBuildingUnlocked_UngatedBuildingType_DefaultsToUnlocked()
    {
        var system = new TechnologySystem();

        Assert.True(system.IsBuildingUnlocked(new KingdomState(), BuildingType.Farm));
    }
}
