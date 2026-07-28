using System.Text.Json.Serialization;

namespace KingdomCraft.Core.Combat;

/// <summary>World boss — Health tồn tại xuyên suốt nhiều lần đánh (không reset mỗi trận).</summary>
public class Boss
{
    public string Id { get; set; } = Guid.NewGuid().ToString();
    public string Name { get; set; } = string.Empty;
    public int MaxHealth { get; set; }
    public int Health { get; set; }
    public int AttackPower { get; set; }

    /// <summary>Lock riêng vì nhiều người chơi có thể cùng đánh 1 world boss cùng lúc.</summary>
    [JsonIgnore]
    public object SyncRoot { get; } = new();
}
