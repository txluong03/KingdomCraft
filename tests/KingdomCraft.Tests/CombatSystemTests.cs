using KingdomCraft.Core.Combat;
using KingdomCraft.Core.Entities;
using Xunit;

namespace KingdomCraft.Tests;

public class CombatSystemTests
{
    [Fact]
    public void Attack_ReducesBossHealthAndPlayerTakesCounterDamage()
    {
        var player = new Player();
        var boss = new Boss { Health = 40, MaxHealth = 40, AttackPower = 5 };

        var result = new CombatSystem().Attack(player, boss, attackPower: 10);

        Assert.True(result.Success);
        Assert.Equal(30, result.BossHealth);
        Assert.Equal(95, result.PlayerHealth); // 100 - 5
    }

    [Fact]
    public void Attack_KillingBlow_BossDoesNotCounterAttack()
    {
        var player = new Player();
        var boss = new Boss { Health = 5, MaxHealth = 40, AttackPower = 5 };

        var result = new CombatSystem().Attack(player, boss, attackPower: 10);

        Assert.Equal(0, result.BossHealth);
        Assert.Equal(100, result.PlayerHealth); // không bị phản đòn vì boss đã chết
    }

    [Fact]
    public void Attack_BossAlreadyDefeated_Fails()
    {
        var player = new Player();
        var boss = new Boss { Health = 0, MaxHealth = 40, AttackPower = 5 };

        var result = new CombatSystem().Attack(player, boss, attackPower: 10);

        Assert.False(result.Success);
    }
}
