namespace KingdomCraft.Core.Crafting;

public class RecipeIngredient
{
    public string ItemId { get; }
    public int Quantity { get; }

    public RecipeIngredient(string itemId, int quantity)
    {
        ItemId = itemId;
        Quantity = quantity;
    }
}
