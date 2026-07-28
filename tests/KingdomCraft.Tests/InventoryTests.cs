using KingdomCraft.Core.Entities;
using Xunit;

namespace KingdomCraft.Tests;

public class InventoryTests
{
    [Fact]
    public void TryAdd_NewItem_CreatesSlot()
    {
        var inventory = new Inventory(capacity: 2);

        var added = inventory.TryAdd("wood", 5);

        Assert.True(added);
        Assert.Equal(5, inventory.GetQuantity("wood"));
    }

    [Fact]
    public void TryAdd_SameItemTwice_MergesIntoExistingSlot()
    {
        var inventory = new Inventory(capacity: 1);

        inventory.TryAdd("wood", 5);
        var added = inventory.TryAdd("wood", 3);

        Assert.True(added);
        Assert.Equal(8, inventory.GetQuantity("wood"));
        Assert.Single(inventory.Slots);
    }

    [Fact]
    public void TryAdd_NewItemWhenFull_Fails()
    {
        var inventory = new Inventory(capacity: 1);
        inventory.TryAdd("wood", 1);

        var added = inventory.TryAdd("stone", 1);

        Assert.False(added);
        Assert.Equal(0, inventory.GetQuantity("stone"));
    }

    [Fact]
    public void TryRemove_PartialQuantity_KeepsSlotWithRemainder()
    {
        var inventory = new Inventory();
        inventory.TryAdd("food", 10);

        var removed = inventory.TryRemove("food", 4);

        Assert.True(removed);
        Assert.Equal(6, inventory.GetQuantity("food"));
    }

    [Fact]
    public void TryRemove_ExactQuantity_RemovesSlot()
    {
        var inventory = new Inventory();
        inventory.TryAdd("food", 4);

        var removed = inventory.TryRemove("food", 4);

        Assert.True(removed);
        Assert.Equal(0, inventory.GetQuantity("food"));
        Assert.Empty(inventory.Slots);
    }

    [Fact]
    public void TryRemove_MoreThanAvailable_Fails()
    {
        var inventory = new Inventory();
        inventory.TryAdd("food", 2);

        var removed = inventory.TryRemove("food", 5);

        Assert.False(removed);
        Assert.Equal(2, inventory.GetQuantity("food"));
    }
}
