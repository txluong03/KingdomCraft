using KingdomCraft.Core.World;
using Xunit;

namespace KingdomCraft.Tests;

public class BlockDropsTests
{
    [Theory]
    [InlineData(BlockType.Stone, "stone")]
    [InlineData(BlockType.Wood, "wood")]
    public void GetDrop_KnownBlockTypes_ReturnsExpectedItem(BlockType blockType, string expectedItemId)
    {
        var drop = BlockDrops.GetDrop(blockType);

        Assert.NotNull(drop);
        Assert.Equal(expectedItemId, drop!.Value.ItemId);
        Assert.Equal(1, drop.Value.Quantity);
    }

    [Theory]
    [InlineData(BlockType.Air)]
    [InlineData(BlockType.Dirt)]
    [InlineData(BlockType.Grass)]
    [InlineData(BlockType.Sand)]
    [InlineData(BlockType.Water)]
    public void GetDrop_UndecidedBlockTypes_ReturnsNull(BlockType blockType)
    {
        Assert.Null(BlockDrops.GetDrop(blockType));
    }
}
