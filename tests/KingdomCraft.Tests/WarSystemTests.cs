using KingdomCraft.Core.Diplomacy;
using KingdomCraft.Core.Entities;
using KingdomCraft.Core.Kingdom;
using Xunit;

namespace KingdomCraft.Tests;

public class WarSystemTests
{
    [Fact]
    public void TryRaid_AttackerStronger_StealsGoldFromDefender()
    {
        var attacker = new KingdomState();
        attacker.Npcs.Add(new Npc { Role = NpcRole.Soldier, SkillLevel = 10 });

        var defender = new KingdomState();
        defender.Npcs.Add(new Npc { Role = NpcRole.Soldier, SkillLevel = 2 });
        defender.Resources.Add("gold", 100);

        var success = new WarSystem().TryRaid(attacker, defender);

        Assert.True(success);
        Assert.Equal(20, attacker.Resources.Get("gold")); // 20% of 100
        Assert.Equal(80, defender.Resources.Get("gold"));
    }

    [Fact]
    public void TryRaid_AttackerWeaker_Fails()
    {
        var attacker = new KingdomState();
        attacker.Npcs.Add(new Npc { Role = NpcRole.Soldier, SkillLevel = 1 });

        var defender = new KingdomState();
        defender.Npcs.Add(new Npc { Role = NpcRole.Soldier, SkillLevel = 10 });
        defender.Resources.Add("gold", 100);

        var success = new WarSystem().TryRaid(attacker, defender);

        Assert.False(success);
        Assert.Equal(100, defender.Resources.Get("gold"));
        Assert.Equal(0, attacker.Resources.Get("gold"));
    }

    [Fact]
    public void TryRaid_DefenderHasNoGold_Fails()
    {
        var attacker = new KingdomState();
        attacker.Npcs.Add(new Npc { Role = NpcRole.Soldier, SkillLevel = 10 });
        var defender = new KingdomState();

        var success = new WarSystem().TryRaid(attacker, defender);

        Assert.False(success);
    }
}
