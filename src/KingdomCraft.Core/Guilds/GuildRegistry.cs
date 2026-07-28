namespace KingdomCraft.Core.Guilds;

/// <summary>
/// Lưu trữ Guild trong bộ nhớ. Quy tắc: 1 vương quốc chỉ thuộc 1 guild tại
/// một thời điểm — phải Leave guild cũ trước khi Join guild khác.
/// </summary>
public class GuildRegistry
{
    private readonly Dictionary<string, Guild> _guilds = new();
    private readonly object _syncRoot = new();

    public Guild Create(string name, string founderKingdomId)
    {
        lock (_syncRoot)
        {
            var guild = new Guild { Name = name };
            guild.MemberKingdomIds.Add(founderKingdomId);
            _guilds[guild.Id] = guild;
            return guild;
        }
    }

    public Guild? Find(string guildId)
    {
        lock (_syncRoot)
        {
            return _guilds.TryGetValue(guildId, out var guild) ? guild : null;
        }
    }

    public bool Join(string guildId, string kingdomId)
    {
        lock (_syncRoot)
        {
            if (!_guilds.TryGetValue(guildId, out var guild))
                return false;

            var currentGuild = FindGuildOfKingdom(kingdomId);
            if (currentGuild is not null && currentGuild.Id != guildId)
                return false;

            if (!guild.MemberKingdomIds.Contains(kingdomId))
                guild.MemberKingdomIds.Add(kingdomId);

            return true;
        }
    }

    public bool Leave(string guildId, string kingdomId)
    {
        lock (_syncRoot)
        {
            return _guilds.TryGetValue(guildId, out var guild) && guild.MemberKingdomIds.Remove(kingdomId);
        }
    }

    /// <summary>Guild mà vương quốc này đang là thành viên, hoặc null nếu chưa ở guild nào.</summary>
    public Guild? FindGuildOfKingdom(string kingdomId)
    {
        lock (_syncRoot)
        {
            return _guilds.Values.FirstOrDefault(g => g.MemberKingdomIds.Contains(kingdomId));
        }
    }
}
