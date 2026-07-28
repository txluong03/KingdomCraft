using KingdomCraft.Core.Entities;
using KingdomCraft.Core.Kingdom;
using KingdomCraft.Core.Simulation;
using Xunit;

namespace KingdomCraft.Tests;

public class AutomationSystemTests
{
    [Fact]
    public void Tick_FarmerProducesFood()
    {
        var kingdom = new KingdomState();
        kingdom.Npcs.Add(new Npc { Role = NpcRole.Farmer, SkillLevel = 3 });

        var system = new AutomationSystem();
        system.Tick(kingdom);

        Assert.Equal(3, kingdom.Resources.Get("food"));
    }

    [Fact]
    public void Tick_FarmBuildingProducesFoodIndependentlyOfNpc()
    {
        var kingdom = new KingdomState();
        kingdom.Buildings.Add(new Building { Type = BuildingType.Farm, Level = 2 });

        var system = new AutomationSystem();
        system.Tick(kingdom);

        Assert.Equal(20, kingdom.Resources.Get("food"));
    }

    [Fact]
    public void Tick_StewardIncreasesAutomationLevelMore()
    {
        var kingdom = new KingdomState();
        kingdom.Npcs.Add(new Npc { Role = NpcRole.Steward });

        var system = new AutomationSystem();
        system.Tick(kingdom);

        Assert.True(kingdom.AutomationLevel > 0);
    }
}
