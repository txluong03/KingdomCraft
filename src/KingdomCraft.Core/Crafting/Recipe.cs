namespace KingdomCraft.Core.Crafting;

/// <summary>Công thức chế tạo — xem Docs/08_Crafting/Recipes.md.</summary>
public class Recipe
{
    public string Id { get; }
    public string OutputItemId { get; }
    public int OutputQuantity { get; }
    public IReadOnlyList<RecipeIngredient> Ingredients { get; }
    public CraftStation RequiredStation { get; }

    public Recipe(string id, string outputItemId, int outputQuantity, IReadOnlyList<RecipeIngredient> ingredients, CraftStation requiredStation)
    {
        Id = id;
        OutputItemId = outputItemId;
        OutputQuantity = outputQuantity;
        Ingredients = ingredients;
        RequiredStation = requiredStation;
    }
}
