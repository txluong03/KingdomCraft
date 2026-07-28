using KingdomCraft.Core.Crafting;
using KingdomCraft.Core.Entities;
using Xunit;

namespace KingdomCraft.Tests;

public class CraftingSystemTests
{
    [Fact]
    public void TryCraft_EnoughIngredientsNoStationRequired_Succeeds()
    {
        var inventory = new Inventory();
        inventory.TryAdd("wood", 1);
        var recipe = RecipeBook.Find("craft_plank")!;
        var system = new CraftingSystem();

        var success = system.TryCraft(inventory, recipe, hasStationAccess: false);

        Assert.True(success);
        Assert.Equal(0, inventory.GetQuantity("wood"));
        Assert.Equal(4, inventory.GetQuantity("plank"));
    }

    [Fact]
    public void TryCraft_MissingIngredients_FailsWithoutChangingInventory()
    {
        var inventory = new Inventory();
        var recipe = RecipeBook.Find("craft_plank")!;
        var system = new CraftingSystem();

        var success = system.TryCraft(inventory, recipe, hasStationAccess: false);

        Assert.False(success);
        Assert.Equal(0, inventory.GetQuantity("plank"));
    }

    [Fact]
    public void TryCraft_RequiresStationButNotAvailable_Fails()
    {
        var inventory = new Inventory();
        inventory.TryAdd("plank", 3);
        var recipe = RecipeBook.Find("craft_wooden_axe")!;
        var system = new CraftingSystem();

        var success = system.TryCraft(inventory, recipe, hasStationAccess: false);

        Assert.False(success);
        Assert.Equal(3, inventory.GetQuantity("plank"));
        Assert.Equal(0, inventory.GetQuantity("wooden_axe"));
    }

    [Fact]
    public void TryCraft_RequiresStationAndAvailable_Succeeds()
    {
        var inventory = new Inventory();
        inventory.TryAdd("plank", 3);
        var recipe = RecipeBook.Find("craft_wooden_axe")!;
        var system = new CraftingSystem();

        var success = system.TryCraft(inventory, recipe, hasStationAccess: true);

        Assert.True(success);
        Assert.Equal(0, inventory.GetQuantity("plank"));
        Assert.Equal(1, inventory.GetQuantity("wooden_axe"));
    }
}
