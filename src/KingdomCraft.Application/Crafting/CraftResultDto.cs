namespace KingdomCraft.Application.Crafting;

public class CraftResultDto
{
    public bool Success { get; set; }
    public string Message { get; set; } = string.Empty;
    public Dictionary<string, int> InventorySnapshot { get; set; } = new();
}
