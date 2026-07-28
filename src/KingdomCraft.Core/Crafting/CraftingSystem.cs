using KingdomCraft.Core.Entities;

namespace KingdomCraft.Core.Crafting;

/// <summary>
/// Xử lý chế tạo tức thời (không tick chờ) — xem Docs/08_Crafting/Recipes.md.
/// Thất bại (thiếu nguyên liệu/sai trạm) không làm thay đổi <see cref="Inventory"/>.
/// </summary>
public class CraftingSystem
{
    public bool TryCraft(Inventory inventory, Recipe recipe, bool hasStationAccess)
    {
        if (recipe.RequiredStation != CraftStation.None && !hasStationAccess)
            return false;

        foreach (var ingredient in recipe.Ingredients)
        {
            if (inventory.GetQuantity(ingredient.ItemId) < ingredient.Quantity)
                return false;
        }

        foreach (var ingredient in recipe.Ingredients)
        {
            inventory.TryRemove(ingredient.ItemId, ingredient.Quantity);
        }

        inventory.TryAdd(recipe.OutputItemId, recipe.OutputQuantity);
        return true;
    }
}
