namespace KingdomCraft.Core.Kingdom;

public enum BuildingType
{
    TownHall,
    Farm,
    LumberMill,
    Mine,
    Barracks,
    Market,
    House,
    Wall,
    Custom
}

public class Building
{
    public string Id { get; set; } = Guid.NewGuid().ToString();
    public BuildingType Type { get; set; }
    public string Name { get; set; } = string.Empty;

    /// <summary>Vị trí trong world (tọa độ voxel/ô lưới).</summary>
    public (int X, int Y, int Z) Position { get; set; }

    public int Level { get; set; } = 1;

    /// <summary>NPC nào (nếu có) đang quản lý công trình này.</summary>
    public string? AssignedNpcId { get; set; }

    /// <summary>
    /// Sản lượng thụ động mỗi tick, độc lập với NPC được gán (xem
    /// <see cref="KingdomCraft.Core.Simulation.AutomationSystem"/>). Trả về null
    /// nếu loại công trình không tự sản xuất tài nguyên.
    /// </summary>
    public (string ResourceName, int Amount)? GetProductionPerTick() => Type switch
    {
        BuildingType.Farm => ("food", 10 * Level),
        BuildingType.Mine => ("stone", 8 * Level),
        BuildingType.LumberMill => ("wood", 8 * Level),
        BuildingType.Market => ("gold", 6 * Level),
        _ => null
    };
}
