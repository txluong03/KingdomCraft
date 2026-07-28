namespace KingdomCraft.Application.Economy;

public class SellResourceResultDto
{
    public bool Success { get; set; }
    public string Message { get; set; } = string.Empty;
    public Dictionary<string, int> Resources { get; set; } = new();
}
