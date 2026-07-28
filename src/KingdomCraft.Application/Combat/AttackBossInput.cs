namespace KingdomCraft.Application.Combat;

public class AttackBossInput
{
    public string BossId { get; set; } = string.Empty;

    /// <summary>Id item Tool trong Inventory dùng làm vũ khí — null/không có nghĩa là đánh tay không.</summary>
    public string? WeaponItemId { get; set; }
}
