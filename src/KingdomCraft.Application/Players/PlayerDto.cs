namespace KingdomCraft.Application.Players;

public class PlayerDto
{
    public string Id { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public int Health { get; set; }
    public int Hunger { get; set; }
    public int Level { get; set; }
    public int Experience { get; set; }
    public Dictionary<string, int> Inventory { get; set; } = new();
}
