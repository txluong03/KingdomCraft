using KingdomCraft.Core.World;

namespace KingdomCraft.Client.World;

/// <summary>
/// Sinh 1 chunk phẳng đơn giản để Client có gì đó render/tương tác thử.
/// KHÔNG phải world generation thật — xem Docs/04_WorldGeneration cho hướng
/// thiết kế noise/biome sau này.
/// </summary>
public static class DemoWorldGenerator
{
    public static Chunk CreateFlatTerrain()
    {
        var chunk = new Chunk { ChunkCoord = (0, 0) };

        for (var x = 0; x < Chunk.Size; x++)
        {
            for (var z = 0; z < Chunk.Size; z++)
            {
                for (var y = 0; y < 4; y++)
                {
                    chunk.SetBlock(x, y, z, BlockType.Stone);
                }

                for (var y = 4; y < 7; y++)
                {
                    chunk.SetBlock(x, y, z, BlockType.Dirt);
                }

                chunk.SetBlock(x, 7, z, BlockType.Grass);
            }
        }

        return chunk;
    }
}
