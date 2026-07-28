namespace KingdomCraft.Core.World;

/// <summary>
/// Ánh xạ khối bị phá → item rơi ra (Docs/09_Building/Blocks.md — "ý định
/// thiết kế" trước đây, giờ đã nối vào gameplay thật). Chỉ Stone/Wood có
/// item tương ứng trong <see cref="Items.ItemCatalog"/> — các loại khác
/// (Dirt/Grass/Sand/Water) chưa quyết định, tạm không rơi gì.
/// </summary>
public static class BlockDrops
{
    public static (string ItemId, int Quantity)? GetDrop(BlockType blockType) => blockType switch
    {
        BlockType.Stone => ("stone", 1),
        BlockType.Wood => ("wood", 1),
        _ => null
    };
}
