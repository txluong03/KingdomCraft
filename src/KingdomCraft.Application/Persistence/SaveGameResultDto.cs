namespace KingdomCraft.Application.Persistence;

public class SaveGameResultDto
{
    public bool Success { get; set; }
    public string Message { get; set; } = string.Empty;
    public int KingdomCount { get; set; }
}
