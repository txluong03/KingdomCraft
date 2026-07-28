using KingdomCraft.Core.World;

namespace KingdomCraft.Client.World;

/// <summary>
/// Sinh 1 chunk phẳng đơn giản kèm vài "cây" (cột Wood) và "đá" (khối Stone
/// nhô lên) để có gì đó cụ thể để đào/khai thác — vẫn CHƯA phải world
/// generation thật (bản đồ vô hạn/biome/noise), chỉ 1 chunk 16x16 cố định.
/// Xem Docs/04_WorldGeneration cho hướng thiết kế đầy đủ sau này.
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

        AddTree(chunk, 3, 3);
        AddTree(chunk, 12, 4);
        AddTree(chunk, 5, 12);
        AddTree(chunk, 13, 13);
        AddRock(chunk, 9, 9);
        AddRock(chunk, 2, 10);
        AddRock(chunk, 11, 2);

        return chunk;
    }

    /// <summary>"Cây" tối giản — cột Wood 3 khối (chưa có block Leaves riêng).</summary>
    private static void AddTree(Chunk chunk, int x, int z)
    {
        for (var y = 8; y < 11; y++)
        {
            chunk.SetBlock(x, y, z, BlockType.Wood);
        }
    }

    /// <summary>"Đá" tối giản — 2 khối Stone nhô lên khỏi mặt cỏ.</summary>
    private static void AddRock(Chunk chunk, int x, int z)
    {
        chunk.SetBlock(x, 8, z, BlockType.Stone);
        chunk.SetBlock(x, 9, z, BlockType.Stone);
    }
}
