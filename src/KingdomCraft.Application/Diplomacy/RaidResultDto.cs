namespace KingdomCraft.Application.Diplomacy;

public class RaidResultDto
{
    public bool Success { get; set; }
    public string Message { get; set; } = string.Empty;
    public Dictionary<string, int> AttackerResources { get; set; } = new();
    public Dictionary<string, int> DefenderResources { get; set; } = new();
}
