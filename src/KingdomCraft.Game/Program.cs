using KingdomCraft.Core.Models;
using KingdomCraft.Core.Services;

var kingdom = new Kingdom("Ravenhold");
var engine = new GameEngine(kingdom);

Console.WriteLine($"=== Welcome to KingdomCraft: {kingdom.Name} ===");

engine.TryConstructBuilding(BuildingType.Farm, goldCost: 20);
engine.TryConstructBuilding(BuildingType.Lumberyard, goldCost: 20);

for (int i = 0; i < 3; i++)
{
    engine.AdvanceTurn();
    Console.WriteLine($"\n-- Turn {engine.Turn} --");
    foreach (var kv in kingdom.Resources)
    {
        Console.WriteLine($"{kv.Key}: {kv.Value}");
    }
}

engine.TryRecruitUnit(UnitType.Soldier, foodCost: 10);
Console.WriteLine($"\nArmy size: {kingdom.Army.Count}");
