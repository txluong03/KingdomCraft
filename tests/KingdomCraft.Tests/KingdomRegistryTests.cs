using KingdomCraft.Core.Kingdom;
using Xunit;

namespace KingdomCraft.Tests;

public class KingdomRegistryTests
{
    [Fact]
    public void Create_ThenFind_ReturnsSameKingdom()
    {
        var registry = new KingdomRegistry();

        var kingdom = registry.Create("Vương quốc A");
        var found = registry.Find(kingdom.Id);

        Assert.Same(kingdom, found);
    }

    [Fact]
    public void Find_UnknownId_ReturnsNull()
    {
        var registry = new KingdomRegistry();

        Assert.Null(registry.Find("khong-ton-tai"));
    }

    [Fact]
    public void All_ReturnsEveryCreatedKingdom()
    {
        var registry = new KingdomRegistry();
        registry.Create("A");
        registry.Create("B");

        Assert.Equal(2, registry.All.Count);
    }

    [Fact]
    public void Restore_PreservesOriginalId()
    {
        var registry = new KingdomRegistry();
        var kingdom = new KingdomState { Name = "Đã lưu" };

        registry.Restore(kingdom);

        Assert.Same(kingdom, registry.Find(kingdom.Id));
    }

    [Fact]
    public void Restore_ExistingId_Overwrites()
    {
        var registry = new KingdomRegistry();
        var original = registry.Create("A");
        var replacement = new KingdomState { Id = original.Id, Name = "B" };

        registry.Restore(replacement);

        Assert.Same(replacement, registry.Find(original.Id));
    }
}
