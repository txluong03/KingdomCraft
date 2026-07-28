using KingdomCraft.Client.World;
using KingdomCraft.Core.World;
using Xunit;

namespace KingdomCraft.Tests;

public class DemoWorldGeneratorTests
{
    [Fact]
    public void CreateFlatTerrain_HasGrassSurfaceOverStoneAndDirt()
    {
        var chunk = DemoWorldGenerator.CreateFlatTerrain();

        Assert.Equal(BlockType.Stone, chunk.GetBlock(0, 0, 0));
        Assert.Equal(BlockType.Dirt, chunk.GetBlock(0, 4, 0));
        Assert.Equal(BlockType.Grass, chunk.GetBlock(0, 7, 0));
        Assert.Equal(BlockType.Air, chunk.GetBlock(0, 8, 0));
    }

    [Fact]
    public void CreateFlatTerrain_HasAtLeastOneTreeAboveGrass()
    {
        var chunk = DemoWorldGenerator.CreateFlatTerrain();

        Assert.Equal(BlockType.Wood, chunk.GetBlock(3, 8, 3));
        Assert.Equal(BlockType.Wood, chunk.GetBlock(3, 9, 3));
        Assert.Equal(BlockType.Wood, chunk.GetBlock(3, 10, 3));
    }

    [Fact]
    public void CreateFlatTerrain_HasAtLeastOneRockAboveGrass()
    {
        var chunk = DemoWorldGenerator.CreateFlatTerrain();

        Assert.Equal(BlockType.Stone, chunk.GetBlock(9, 8, 9));
        Assert.Equal(BlockType.Stone, chunk.GetBlock(9, 9, 9));
    }
}
