using KingdomCraft.Core.World;
using Microsoft.Xna.Framework;

namespace KingdomCraft.Client.Rendering;

/// <summary>
/// Ray đơn giản kiểu "step-marching" (không phải DDA/Amanatides-Woo chuẩn) để
/// tìm khối đầu tiên bị trúng từ camera — đủ chính xác cho tương tác đặt/phá
/// khối ở khoảng cách gần, đổi lấy sự đơn giản/an toàn vì không thể kiểm tra
/// trực quan trong môi trường này.
/// </summary>
public static class VoxelRaycaster
{
    private const float Step = 0.05f;

    /// <summary>
    /// Trả về ô khối bị trúng (`Block`) và ô rỗng liền trước đó theo tia
    /// (`Placement`, dùng để đặt khối mới), hoặc null nếu không trúng gì
    /// trong <paramref name="maxDistance"/>.
    /// </summary>
    public static ((int X, int Y, int Z) Block, (int X, int Y, int Z) Placement)? Cast(
        Chunk chunk, Vector3 origin, Vector3 direction, float maxDistance)
    {
        if (direction == Vector3.Zero) return null;
        direction = Vector3.Normalize(direction);

        (int X, int Y, int Z)? previousCell = null;

        for (var travelled = 0f; travelled < maxDistance; travelled += Step)
        {
            var point = origin + direction * travelled;
            var cell = ((int)MathF.Floor(point.X), (int)MathF.Floor(point.Y), (int)MathF.Floor(point.Z));

            if (IsSolid(chunk, cell))
            {
                return (cell, previousCell ?? cell);
            }

            previousCell = cell;
        }

        return null;
    }

    private static bool IsSolid(Chunk chunk, (int X, int Y, int Z) cell)
    {
        if (cell.X < 0 || cell.X >= Chunk.Size || cell.Y < 0 || cell.Y >= Chunk.Height || cell.Z < 0 || cell.Z >= Chunk.Size)
            return false;

        return chunk.GetBlock(cell.X, cell.Y, cell.Z) != BlockType.Air;
    }
}
