using KingdomCraft.Core.Combat;
using Xunit;

namespace KingdomCraft.Tests;

public class BossRegistryTests
{
    [Fact]
    public void Spawn_ThenFind_ReturnsSameBossWithFullHealth()
    {
        var registry = new BossRegistry();
        var template = BossCatalog.Find("slime_king")!;

        var boss = registry.Spawn(template);
        var found = registry.Find(boss.Id);

        Assert.Same(boss, found);
        Assert.Equal(template.MaxHealth, boss.Health);
    }

    [Fact]
    public void Find_UnknownId_ReturnsNull()
    {
        var registry = new BossRegistry();

        Assert.Null(registry.Find("khong-ton-tai"));
    }
}
