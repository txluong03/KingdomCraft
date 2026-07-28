using KingdomCraft.Application.Crafting;
using KingdomCraft.Application.Kingdom;
using KingdomCraft.Core.Entities;
using KingdomCraft.Core.Kingdom;
using Xunit;

namespace KingdomCraft.Tests;

public class CraftingAppServiceTests
{
    [Fact]
    public void GetAllRecipes_ReturnsAllFiveRecipes()
    {
        var appService = new CraftingAppService(new Player(), new KingdomState());

        var recipes = appService.GetAllRecipes();

        Assert.Equal(5, recipes.Count);
    }

    [Fact]
    public void Craft_UnknownRecipeId_ReturnsFailure()
    {
        var appService = new CraftingAppService(new Player(), new KingdomState());

        var result = appService.Craft(new CraftInput { RecipeId = "khong-ton-tai" });

        Assert.False(result.Success);
    }

    [Fact]
    public void Craft_ValidRecipeWithIngredients_UpdatesInventorySnapshot()
    {
        var player = new Player();
        player.Inventory.TryAdd("wood", 1);
        var appService = new CraftingAppService(player, new KingdomState());

        var result = appService.Craft(new CraftInput { RecipeId = "craft_plank" });

        Assert.True(result.Success);
        Assert.Equal(4, result.InventorySnapshot.GetValueOrDefault("plank"));
        Assert.False(result.InventorySnapshot.ContainsKey("wood"));
    }

    [Fact]
    public void Craft_RecipeGatedByUnresearchedTechnology_Fails()
    {
        var player = new Player();
        player.Inventory.TryAdd("plank", 2);
        player.Inventory.TryAdd("stone", 3);
        var appService = new CraftingAppService(player, new KingdomState());

        var result = appService.Craft(new CraftInput { RecipeId = "craft_stone_axe", HasStationAccess = true });

        Assert.False(result.Success);
        Assert.Equal(0, result.InventorySnapshot.GetValueOrDefault("stone_axe"));
    }

    [Fact]
    public void Craft_RecipeAfterResearchingTechnology_Succeeds()
    {
        var kingdom = new KingdomState();
        kingdom.Resources.Add("gold", 20);
        new KingdomAppService(kingdom).ResearchTechnology(new ResearchTechnologyInput { TechnologyId = "stone_working" });

        var player = new Player();
        player.Inventory.TryAdd("plank", 2);
        player.Inventory.TryAdd("stone", 3);
        var appService = new CraftingAppService(player, kingdom);

        var result = appService.Craft(new CraftInput { RecipeId = "craft_stone_axe", HasStationAccess = true });

        Assert.True(result.Success);
        Assert.Equal(1, result.InventorySnapshot.GetValueOrDefault("stone_axe"));
    }
}
