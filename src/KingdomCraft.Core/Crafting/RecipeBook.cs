namespace KingdomCraft.Core.Crafting;

/// <summary>Danh mục recipe tối thiểu — xem Docs/08_Crafting/Recipes.md.</summary>
public static class RecipeBook
{
    public static readonly IReadOnlyList<Recipe> All = new List<Recipe>
    {
        new("craft_plank", "plank", 4,
            new List<RecipeIngredient> { new("wood", 1) },
            CraftStation.None),

        new("craft_wooden_axe", "wooden_axe", 1,
            new List<RecipeIngredient> { new("plank", 3) },
            CraftStation.Workbench),

        new("craft_wooden_pickaxe", "wooden_pickaxe", 1,
            new List<RecipeIngredient> { new("plank", 3) },
            CraftStation.Workbench),

        new("craft_stone_axe", "stone_axe", 1,
            new List<RecipeIngredient> { new("plank", 2), new("stone", 3) },
            CraftStation.Workbench),

        new("craft_stone_pickaxe", "stone_pickaxe", 1,
            new List<RecipeIngredient> { new("plank", 2), new("stone", 3) },
            CraftStation.Workbench)
    };

    public static Recipe? Find(string recipeId) =>
        All.FirstOrDefault(recipe => recipe.Id == recipeId);
}
