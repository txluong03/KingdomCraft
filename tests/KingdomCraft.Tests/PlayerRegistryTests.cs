using KingdomCraft.Core.Entities;
using Xunit;

namespace KingdomCraft.Tests;

public class PlayerRegistryTests
{
    [Fact]
    public void Create_ThenFind_ReturnsSamePlayer()
    {
        var registry = new PlayerRegistry();

        var player = registry.Create("Người chơi A");
        var found = registry.Find(player.Id);

        Assert.Same(player, found);
    }

    [Fact]
    public void Find_UnknownId_ReturnsNull()
    {
        var registry = new PlayerRegistry();

        Assert.Null(registry.Find("khong-ton-tai"));
    }

    [Fact]
    public void Restore_PreservesOriginalId()
    {
        var registry = new PlayerRegistry();
        var player = new Player { Name = "Đã lưu" };

        registry.Restore(player);

        Assert.Same(player, registry.Find(player.Id));
    }
}
