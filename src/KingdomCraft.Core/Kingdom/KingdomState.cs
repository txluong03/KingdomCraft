namespace KingdomCraft.Core.Kingdom;

/// <summary>
/// Đại diện cho trạng thái vương quốc của người chơi.
/// Trung tâm của cơ chế "chuyển giao": ban đầu người chơi tự làm mọi việc
/// (đốn gỗ, khai khoáng, xây dựng), càng về sau càng giao việc cho NPC quản lý.
/// </summary>
public class KingdomState
{
    public string Name { get; set; } = "Vương quốc chưa đặt tên";

    /// <summary>
    /// Mức độ tự động hóa từ 0 (tự làm 100%) đến 100 (NPC tự vận hành hoàn toàn).
    /// </summary>
    public int AutomationLevel { get; set; } = 0;

    public List<Building> Buildings { get; set; } = new();

    public List<KingdomCraft.Core.Entities.Npc> Npcs { get; set; } = new();

    public ResourceStockpile Resources { get; set; } = new();
}
