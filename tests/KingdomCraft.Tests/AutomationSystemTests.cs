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

    [Fact]
    public void Tick_MinerProducesStone()
    {
        var kingdom = new KingdomState();
        kingdom.Npcs.Add(new Npc { Role = NpcRole.Miner, SkillLevel = 4 });

        var system = new AutomationSystem();
        system.Tick(kingdom);

        Assert.Equal(4, kingdom.Resources.Get("stone"));
    }

    [Fact]
    public void Tick_NpcAndBuildingProductionAccumulateTogether()
    {
        var kingdom = new KingdomState();
        kingdom.Npcs.Add(new Npc { Role = NpcRole.Farmer, SkillLevel = 3 });
        kingdom.Buildings.Add(new Building { Type = BuildingType.Farm, Level = 1 });

        var system = new AutomationSystem();
        system.Tick(kingdom);

        // NPC (3) + Building Level 1 (10 * 1) = 13
        Assert.Equal(13, kingdom.Resources.Get("food"));
    }

    [Fact]
    public void Tick_AutomationLevel_CapsAt100()
    {
        var kingdom = new KingdomState();
        for (var i = 0; i < 30; i++)
        {
            kingdom.Npcs.Add(new Npc { Role = NpcRole.Steward });
        }

        var system = new AutomationSystem();
        system.Tick(kingdom);

        Assert.Equal(100, kingdom.AutomationLevel);
    }
}
