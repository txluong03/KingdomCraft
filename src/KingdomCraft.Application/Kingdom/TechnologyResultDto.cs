namespace KingdomCraft.Application.Kingdom;

public class TechnologyResultDto
{
    public bool Success { get; set; }
    public string Message { get; set; } = string.Empty;
    public List<string> ResearchedTechnologyIds { get; set; } = new();
}
