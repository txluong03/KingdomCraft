namespace KingdomCraft.Core.Entities;

public class Player
{
    public string Id { get; set; } = Guid.NewGuid().ToString();
    public string Name { get; set; } = string.Empty;

    public int Health { get; set; } = 100;
    public int Hunger { get; set; } = 100;

    /// <summary>Chỉ số RPG cơ bản, mở rộng sau khi có tài liệu thiết kế chi tiết.</summary>
    public int Level { get; set; } = 1;
    public int Experience { get; set; } = 0;

    public (int X, int Y, int Z) Position { get; set; }

    public Inventory Inventory { get; } = new();
}
