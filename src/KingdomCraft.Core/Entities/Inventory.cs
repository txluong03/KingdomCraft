namespace KingdomCraft.Core.Entities;

/// <summary>Một chồng vật phẩm cùng loại trong <see cref="Inventory"/>.</summary>
public class ItemStack
{
    public string ItemId { get; }
    public int Quantity { get; set; }

    public ItemStack(string itemId, int quantity)
    {
        ItemId = itemId;
        Quantity = quantity;
    }
}

/// <summary>
/// Túi đồ dạng slot của người chơi. Chưa có khái niệm loại vật phẩm cụ thể
/// (xem Docs/07_Items — vẫn là khung thiết kế), nên dùng `itemId` dạng chuỗi
/// tự do thay vì enum cố định.
/// </summary>
public class Inventory
{
    public int Capacity { get; }
    public List<ItemStack> Slots { get; } = new();

    public Inventory(int capacity = 20)
    {
        Capacity = capacity;
    }

    public int GetQuantity(string itemId) =>
        Slots.FirstOrDefault(s => s.ItemId == itemId)?.Quantity ?? 0;

    /// <summary>Gộp vào slot có sẵn nếu cùng loại, nếu không thì tạo slot mới (nếu còn chỗ).</summary>
    public bool TryAdd(string itemId, int quantity)
    {
        var existing = Slots.FirstOrDefault(s => s.ItemId == itemId);
        if (existing is not null)
        {
            existing.Quantity += quantity;
            return true;
        }

        if (Slots.Count >= Capacity)
            return false;

        Slots.Add(new ItemStack(itemId, quantity));
        return true;
    }

    public bool TryRemove(string itemId, int quantity)
    {
        var existing = Slots.FirstOrDefault(s => s.ItemId == itemId);
        if (existing is null || existing.Quantity < quantity)
            return false;

        existing.Quantity -= quantity;
        if (existing.Quantity == 0)
            Slots.Remove(existing);

        return true;
    }
}
