using KingdomCraft.Core.World;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace KingdomCraft.Client.Rendering;

/// <summary>
/// Dựng mesh tam giác (một màu mỗi loại khối, không texture) cho 1 <see cref="Chunk"/>.
/// Chỉ vẽ những mặt tiếp giáp khối rỗng (naive face culling) — chưa greedy meshing,
/// đủ dùng cho demo/prototype ở Bước 1 của DevelopmentRoadmap.
/// </summary>
public static class ChunkMeshBuilder
{
    public static VertexPositionColor[] BuildVertices(Chunk chunk)
    {
        var vertices = new List<VertexPositionColor>();

        for (var x = 0; x < Chunk.Size; x++)
        {
            for (var y = 0; y < Chunk.Height; y++)
            {
                for (var z = 0; z < Chunk.Size; z++)
                {
                    var block = chunk.GetBlock(x, y, z);
                    if (block == BlockType.Air) continue;

                    var color = BlockColor(block);
                    var origin = new Vector3(x, y, z);

                    if (IsAir(chunk, x, y + 1, z)) AddFace(vertices, origin, Face.Top, color);
                    if (IsAir(chunk, x, y - 1, z)) AddFace(vertices, origin, Face.Bottom, color);
                    if (IsAir(chunk, x - 1, y, z)) AddFace(vertices, origin, Face.Left, color);
                    if (IsAir(chunk, x + 1, y, z)) AddFace(vertices, origin, Face.Right, color);
                    if (IsAir(chunk, x, y, z - 1)) AddFace(vertices, origin, Face.Back, color);
                    if (IsAir(chunk, x, y, z + 1)) AddFace(vertices, origin, Face.Front, color);
                }
            }
        }

        return vertices.ToArray();
    }

    private static bool IsAir(Chunk chunk, int x, int y, int z)
    {
        // Ngoài biên chunk coi như khí, để vẫn vẽ mặt ở rìa chunk.
        if (x < 0 || x >= Chunk.Size || y < 0 || y >= Chunk.Height || z < 0 || z >= Chunk.Size)
            return true;

        return chunk.GetBlock(x, y, z) == BlockType.Air;
    }

    private static Color BlockColor(BlockType type) => type switch
    {
        BlockType.Dirt => new Color(121, 85, 58),
        BlockType.Grass => new Color(86, 148, 62),
        BlockType.Stone => new Color(120, 120, 120),
        BlockType.Wood => new Color(94, 66, 41),
        BlockType.Sand => new Color(220, 200, 140),
        BlockType.Water => new Color(64, 120, 200),
        _ => Color.Magenta
    };

    private enum Face { Top, Bottom, Left, Right, Front, Back }

    // Khối đơn vị từ (0,0,0) đến (1,1,1) tại `origin`. Không cần đúng chiều
    // winding vì Game1 tắt backface culling (RasterizerState.CullMode = None) —
    // môi trường này không render được nên không thể kiểm tra trực quan mặt nào
    // bị lật; ưu tiên chắc chắn hiển thị hơn tối ưu hiệu năng.
    private static void AddFace(List<VertexPositionColor> vertices, Vector3 origin, Face face, Color color)
    {
        Vector3[] corners = face switch
        {
            Face.Top => new[]
            {
                origin + new Vector3(0, 1, 0), origin + new Vector3(1, 1, 0), origin + new Vector3(1, 1, 1),
                origin + new Vector3(0, 1, 0), origin + new Vector3(1, 1, 1), origin + new Vector3(0, 1, 1)
            },
            Face.Bottom => new[]
            {
                origin + new Vector3(0, 0, 1), origin + new Vector3(1, 0, 1), origin + new Vector3(1, 0, 0),
                origin + new Vector3(0, 0, 1), origin + new Vector3(1, 0, 0), origin + new Vector3(0, 0, 0)
            },
            Face.Left => new[]
            {
                origin + new Vector3(0, 0, 0), origin + new Vector3(0, 0, 1), origin + new Vector3(0, 1, 1),
                origin + new Vector3(0, 0, 0), origin + new Vector3(0, 1, 1), origin + new Vector3(0, 1, 0)
            },
            Face.Right => new[]
            {
                origin + new Vector3(1, 0, 1), origin + new Vector3(1, 0, 0), origin + new Vector3(1, 1, 0),
                origin + new Vector3(1, 0, 1), origin + new Vector3(1, 1, 0), origin + new Vector3(1, 1, 1)
            },
            Face.Front => new[]
            {
                origin + new Vector3(1, 0, 1), origin + new Vector3(0, 0, 1), origin + new Vector3(0, 1, 1),
                origin + new Vector3(1, 0, 1), origin + new Vector3(0, 1, 1), origin + new Vector3(1, 1, 1)
            },
            Face.Back => new[]
            {
                origin + new Vector3(0, 0, 0), origin + new Vector3(1, 0, 0), origin + new Vector3(1, 1, 0),
                origin + new Vector3(0, 0, 0), origin + new Vector3(1, 1, 0), origin + new Vector3(0, 1, 0)
            },
            _ => Array.Empty<Vector3>()
        };

        foreach (var corner in corners)
        {
            vertices.Add(new VertexPositionColor(corner, color));
        }
    }
}
