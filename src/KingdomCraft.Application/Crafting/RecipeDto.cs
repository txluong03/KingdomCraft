using KingdomCraft.Core.Crafting;

namespace KingdomCraft.Application.Crafting;

public class RecipeDto
{
    public string Id { get; set; } = string.Empty;
    public string OutputItemId { get; set; } = string.Empty;
    public int OutputQuantity { get; set; }
    public List<RecipeIngredientDto> Ingredients { get; set; } = new();
    public CraftStation RequiredStation { get; set; }
}

public class RecipeIngredientDto
{
    public string ItemId { get; set; } = string.Empty;
    public int Quantity { get; set; }
}
