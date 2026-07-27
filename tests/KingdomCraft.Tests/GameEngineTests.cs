using KingdomCraft.Core.Models;
using KingdomCraft.Core.Services;
using Xunit;

namespace KingdomCraft.Tests;

public class GameEngineTests
{
    [Fact]
    public void AdvanceTurn_ProducesResourcesFromBuildings()
    {
        var kingdom = new Kingdom("TestKingdom");
        var engine = new GameEngine(kingdom);
        engine.TryConstructBuilding(BuildingType.Farm, goldCost: 20);

        var foodBefore = kingdom.Resources[ResourceType.Food];
        engine.AdvanceTurn();
        var foodAfter = kingdom.Resources[ResourceType.Food];

        Assert.True(foodAfter > foodBefore);
    }

    [Fact]
    public void TryConstructBuilding_FailsWithoutEnoughGold()
    {
        var kingdom = new Kingdom("PoorKingdom");
        kingdom.TrySpend(ResourceType.Gold, 100);
        var engine = new GameEngine(kingdom);

        var result = engine.TryConstructBuilding(BuildingType.Farm, goldCost: 20);

        Assert.False(result);
    }
}
