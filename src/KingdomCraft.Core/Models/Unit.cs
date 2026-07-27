namespace KingdomCraft.Core.Models;

public enum UnitType
{
    Peasant,
    Soldier,
    Archer,
    Knight
}

public class Unit
{
    public UnitType Type { get; set; }
    public int Attack { get; set; }
    public int Defense { get; set; }
    public int Health { get; set; }

    public Unit(UnitType type)
    {
        Type = type;
        (Attack, Defense, Health) = type switch
        {
            UnitType.Peasant => (1, 1, 5),
            UnitType.Soldier => (5, 4, 20),
            UnitType.Archer => (7, 2, 15),
            UnitType.Knight => (10, 8, 35),
            _ => (0, 0, 0)
        };
    }
}
