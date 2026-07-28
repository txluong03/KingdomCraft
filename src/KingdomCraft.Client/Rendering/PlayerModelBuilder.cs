using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace KingdomCraft.Client.Rendering;

/// <summary>
/// Mô hình nhân vật tối giản (vài khối hộp, không phải model thật) — chỉ để
/// hiện khi ở góc nhìn thứ 3 (Minecraft gọi nhân vật là "Steve", đây là
/// placeholder hình học). Toạ độ CỤC BỘ: gốc (0,0,0) là điểm chân đứng trên
/// mặt đất — Game1 áp Matrix xoay (theo hướng nhìn) + dịch chuyển tới vị trí
/// thật khi vẽ, không bake vị trí vào vertex như ChunkMeshBuilder.
/// </summary>
public static class PlayerModelBuilder
{
    public static VertexPositionColor[] BuildVertices()
    {
        var vertices = new List<VertexPositionColor>();

        AddBox(vertices, new Vector3(0, 0.6f, 0), new Vector3(0.6f, 1.2f, 0.4f), new Color(50, 90, 160));   // thân
        AddBox(vertices, new Vector3(0, 1.45f, 0), new Vector3(0.5f, 0.5f, 0.5f), new Color(230, 190, 150)); // đầu
        AddBox(vertices, new Vector3(0, 1.45f, -0.28f), new Vector3(0.2f, 0.15f, 0.15f), new Color(255, 210, 0)); // "mặt" — đánh dấu hướng nhìn (-Z khi Yaw=0)

        return vertices.ToArray();
    }

    private static void AddBox(List<VertexPositionColor> vertices, Vector3 center, Vector3 size, Color color)
    {
        var half = size / 2f;
        var min = center - half;
        var max = center + half;

        var p000 = new Vector3(min.X, min.Y, min.Z);
        var p100 = new Vector3(max.X, min.Y, min.Z);
        var p110 = new Vector3(max.X, max.Y, min.Z);
        var p010 = new Vector3(min.X, max.Y, min.Z);
        var p001 = new Vector3(min.X, min.Y, max.Z);
        var p101 = new Vector3(max.X, min.Y, max.Z);
        var p111 = new Vector3(max.X, max.Y, max.Z);
        var p011 = new Vector3(min.X, max.Y, max.Z);

        Quad(vertices, p000, p100, p110, p010, color); // -Z
        Quad(vertices, p101, p001, p011, p111, color); // +Z
        Quad(vertices, p001, p000, p010, p011, color); // -X
        Quad(vertices, p100, p101, p111, p110, color); // +X
        Quad(vertices, p010, p110, p111, p011, color); // top
        Quad(vertices, p001, p101, p100, p000, color); // bottom
    }

    // Không quan tâm chiều winding (Game1 tắt backface culling) — an toàn hơn
    // vì không thể kiểm tra trực quan trong môi trường này.
    private static void Quad(List<VertexPositionColor> vertices, Vector3 a, Vector3 b, Vector3 c, Vector3 d, Color color)
    {
        vertices.Add(new VertexPositionColor(a, color));
        vertices.Add(new VertexPositionColor(b, color));
        vertices.Add(new VertexPositionColor(c, color));
        vertices.Add(new VertexPositionColor(a, color));
        vertices.Add(new VertexPositionColor(c, color));
        vertices.Add(new VertexPositionColor(d, color));
    }
}
