using KingdomCraft.Core.Models;

namespace KingdomCraft.Core.Services;

public class GameEngine
{
    public Kingdom Kingdom { get; }
    public int Turn { get; private set; } = 0;

    public GameEngine(Kingdom kingdom)
    {
        Kingdom = kingdom;
    }

    public void AdvanceTurn()
    {
        Turn++;

        foreach (var building in Kingdom.Buildings)
        {
            var production = building.GetProductionPerTurn();
            if (production is not null)
            {
                Kingdom.AddResource(production.Type, production.Amount);
            }
        }
    }

    public bool TryConstructBuilding(BuildingType type, int goldCost)
    {
        if (!Kingdom.TrySpend(ResourceType.Gold, goldCost))
            return false;

        Kingdom.Buildings.Add(new Building(type));
        return true;
    }

    public bool TryRecruitUnit(UnitType type, int foodCost)
    {
        if (!Kingdom.TrySpend(ResourceType.Food, foodCost))
            return false;

        Kingdom.Army.Add(new Unit(type));
        return true;
    }
}
