namespace KingdomCraft.Core.Entities;

public enum NpcRole
{
    Idle,
    Farmer,
    Lumberjack,
    Miner,
    Soldier,
    Merchant,
    Steward // Quản gia - vai trò đặc biệt giúp tự động hóa quản lý vương quốc
}

/// <summary>
/// NPC tự động trong vương quốc. Khi người chơi bổ nhiệm NPC vào các vai trò,
/// hệ thống mô phỏng (Simulation) sẽ để NPC tự làm việc thay vì người chơi
/// phải thao tác thủ công.
/// </summary>
public class Npc
{
    public string Id { get; set; } = Guid.NewGuid().ToString();
    public string Name { get; set; } = string.Empty;
    public NpcRole Role { get; set; } = NpcRole.Idle;

    /// <summary>Mức độ kỹ năng, ảnh hưởng đến hiệu suất công việc được giao.</summary>
    public int SkillLevel { get; set; } = 1;

    public (int X, int Y, int Z) Position { get; set; }
}
