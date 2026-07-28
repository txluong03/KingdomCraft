namespace KingdomCraft.Core.Guilds;

/// <summary>Liên minh giữa nhiều vương quốc (tham chiếu qua KingdomId, giống AssignedNpcId).</summary>
public class Guild
{
    public string Id { get; set; } = Guid.NewGuid().ToString();
    public string Name { get; set; } = string.Empty;
    public List<string> MemberKingdomIds { get; set; } = new();
}
