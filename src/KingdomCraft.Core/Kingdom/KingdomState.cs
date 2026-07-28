using System.Text.Json.Serialization;

namespace KingdomCraft.Core.Kingdom;

/// <summary>
/// Đại diện cho trạng thái vương quốc của người chơi.
/// Trung tâm của cơ chế "chuyển giao": ban đầu người chơi tự làm mọi việc
/// (đốn gỗ, khai khoáng, xây dựng), càng về sau càng giao việc cho NPC quản lý.
/// </summary>
public class KingdomState
{
    public string Id { get; set; } = Guid.NewGuid().ToString();
    public string Name { get; set; } = "Vương quốc chưa đặt tên";

    /// <summary>
    /// Mức độ tự động hóa từ 0 (tự làm 100%) đến 100 (NPC tự vận hành hoàn toàn).
    /// </summary>
    public int AutomationLevel { get; set; } = 0;

    public List<Building> Buildings { get; set; } = new();

    public List<KingdomCraft.Core.Entities.Npc> Npcs { get; set; } = new();

    public ResourceStockpile Resources { get; set; } = new();

    /// <summary>Id các công nghệ đã nghiên cứu — xem Core/Technology/TechnologySystem.cs.</summary>
    public HashSet<string> ResearchedTechnologyIds { get; set; } = new();

    /// <summary>
    /// Lock dùng chung cho MỌI AppService thao tác lên vương quốc này
    /// (KingdomAppService, EconomyAppService...) — bắt buộc dùng chung 1 object
    /// duy nhất, nếu mỗi AppService tự giữ lock riêng thì các lock đó không
    /// loại trừ lẫn nhau và dữ liệu vẫn có thể bị race condition.
    /// </summary>
    [JsonIgnore]
    public object SyncRoot { get; } = new();
}
