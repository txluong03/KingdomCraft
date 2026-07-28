namespace KingdomCraft.Application.Guilds;

public class GuildDto
{
    public string Id { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public List<string> MemberKingdomIds { get; set; } = new();
}
