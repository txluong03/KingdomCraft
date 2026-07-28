using CoreCrafting = KingdomCraft.Core.Crafting;
using KingdomCraft.Core.Entities;
using CoreKingdomState = KingdomCraft.Core.Kingdom.KingdomState;
using CoreTechnologySystem = KingdomCraft.Core.Technology.TechnologySystem;

namespace KingdomCraft.Application.Crafting;

/// <summary>
/// Ranh giới ứng dụng cho chế tạo — nhận Input DTO, trả về Dto, không lộ
/// thẳng <see cref="Inventory"/>/<see cref="CoreCrafting.Recipe"/> ra ngoài.
/// Xem Docs/08_Crafting/Recipes.md. `kingdom` dùng để kiểm tra công thức đã
/// mở khóa qua công nghệ hay chưa (Docs/02_GDD/TechnologyTree.md) — chế tạo
/// vẫn thao tác trên Inventory cá nhân của Player, không đụng ResourceStockpile.
/// </summary>
public class CraftingAppService
{
    private readonly Player _player;
    private readonly CoreKingdomState _kingdom;
    private readonly CoreCrafting.CraftingSystem _craftingSystem = new();
    private readonly CoreTechnologySystem _technologySystem = new();

    public CraftingAppService(Player player, CoreKingdomState kingdom)
    {
        _player = player;
        _kingdom = kingdom;
    }

    public List<RecipeDto> GetAllRecipes() =>
        CoreCrafting.RecipeBook.All.Select(MapRecipe).ToList();

    public CraftResultDto Craft(CraftInput input)
    {
        lock (_player.SyncRoot)
        {
            var recipe = CoreCrafting.RecipeBook.Find(input.RecipeId);
            if (recipe is null)
            {
                return new CraftResultDto
                {
                    Success = false,
                    Message = $"Không tìm thấy công thức '{input.RecipeId}'.",
                    InventorySnapshot = Snapshot()
                };
            }

            if (!_technologySystem.IsRecipeUnlocked(_kingdom, recipe.Id))
            {
                return new CraftResultDto
                {
                    Success = false,
                    Message = "Công thức chưa được mở khóa — cần nghiên cứu công nghệ tương ứng trước.",
                    InventorySnapshot = Snapshot()
                };
            }

            var success = _craftingSystem.TryCraft(_player.Inventory, recipe, input.HasStationAccess);

            return new CraftResultDto
            {
                Success = success,
                Message = success ? "Chế tạo thành công." : "Thiếu nguyên liệu hoặc chưa đủ trạm chế tạo yêu cầu.",
                InventorySnapshot = Snapshot()
            };
        }
    }

    private Dictionary<string, int> Snapshot() =>
        _player.Inventory.Slots.ToDictionary(slot => slot.ItemId, slot => slot.Quantity);

    private static RecipeDto MapRecipe(CoreCrafting.Recipe recipe) => new()
    {
        Id = recipe.Id,
        OutputItemId = recipe.OutputItemId,
        OutputQuantity = recipe.OutputQuantity,
        RequiredStation = recipe.RequiredStation,
        Ingredients = recipe.Ingredients
            .Select(ingredient => new RecipeIngredientDto { ItemId = ingredient.ItemId, Quantity = ingredient.Quantity })
            .ToList()
    };
}
