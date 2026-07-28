using KingdomCraft.Application.Combat;
using KingdomCraft.Core.Combat;
using KingdomCraft.Core.Entities;
using Xunit;

namespace KingdomCraft.Tests;

public class BossAppServiceTests
{
    [Fact]
    public void SpawnBoss_UnknownTemplateId_Throws()
    {
        var appService = new BossAppService(new BossRegistry(), new Player());

        Assert.Throws<InvalidOperationException>(() =>
            appService.SpawnBoss(new SpawnBossInput { TemplateId = "khong-ton-tai" }));
    }

    [Fact]
    public void AttackBoss_WithOwnedWeapon_UsesWeaponAttackPower()
    {
        var player = new Player();
        player.Inventory.TryAdd("stone_axe", 1);
        var appService = new BossAppService(new BossRegistry(), player);
        var boss = appService.SpawnBoss(new SpawnBossInput { TemplateId = "slime_king" });

        var result = appService.AttackBoss(new AttackBossInput { BossId = boss.Id, WeaponItemId = "stone_axe" });

        Assert.True(result.Success);
        Assert.Equal(boss.MaxHealth - 5, result.BossHealth); // stone_axe = 5 attack power
    }

    [Fact]
    public void AttackBoss_WeaponNotOwned_FallsBackToUnarmed()
    {
        var player = new Player();
        var appService = new BossAppService(new BossRegistry(), player);
        var boss = appService.SpawnBoss(new SpawnBossInput { TemplateId = "slime_king" });

        var result = appService.AttackBoss(new AttackBossInput { BossId = boss.Id, WeaponItemId = "stone_axe" });

        Assert.Equal(boss.MaxHealth - 1, result.BossHealth); // unarmed = 1 attack power
    }

    [Fact]
    public void AttackBoss_UnknownBossId_Throws()
    {
        var appService = new BossAppService(new BossRegistry(), new Player());

        Assert.Throws<InvalidOperationException>(() =>
            appService.AttackBoss(new AttackBossInput { BossId = "khong-ton-tai" }));
    }
}
