namespace KingdomCraft.Core.Models;

public enum BuildingType
{
    TownHall,
    Farm,
    Barracks,
    Wall,
    Mine,
    Lumberyard
}

public class Building
{
    public BuildingType Type { get; set; }
    public int Level { get; set; } = 1;

    public Building(BuildingType type, int level = 1)
    {
        Type = type;
        Level = level;
    }

    public ResourceStack? GetProductionPerTurn()
    {
        return Type switch
        {
            BuildingType.Farm => new ResourceStack(ResourceType.Food, 10 * Level),
            BuildingType.Mine => new ResourceStack(ResourceType.Stone, 8 * Level),
            BuildingType.Lumberyard => new ResourceStack(ResourceType.Wood, 8 * Level),
            _ => null
        };
    }
}
