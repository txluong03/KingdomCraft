using CoreGuild = KingdomCraft.Core.Guilds.Guild;
using CoreGuildRegistry = KingdomCraft.Core.Guilds.GuildRegistry;
using CoreKingdomRegistry = KingdomCraft.Core.Kingdom.KingdomRegistry;

namespace KingdomCraft.Application.Guilds;

/// <summary>
/// Ranh giới ứng dụng cho Guild — liên minh nhiều vương quốc (theo KingdomId).
/// `kingdomId` truyền vào mỗi method là vương quốc đang thực hiện hành động
/// (founder khi tạo, thành viên khi join/leave), không nằm trong Input DTO
/// để khớp convention `KingdomId` cấp cao ở <see cref="Server.Networking.KingdomCommand"/>.
/// </summary>
public class GuildAppService
{
    private readonly CoreGuildRegistry _guildRegistry;
    private readonly CoreKingdomRegistry _kingdomRegistry;

    public GuildAppService(CoreGuildRegistry guildRegistry, CoreKingdomRegistry kingdomRegistry)
    {
        _guildRegistry = guildRegistry;
        _kingdomRegistry = kingdomRegistry;
    }

    public GuildDto CreateGuild(string founderKingdomId, CreateGuildInput input)
    {
        EnsureKingdomExists(founderKingdomId);
        var guild = _guildRegistry.Create(input.Name, founderKingdomId);
        return Map(guild);
    }

    public GuildDto GetGuild(GetGuildInput input) => Map(Find(input.GuildId));

    public GuildActionResultDto Join(string kingdomId, JoinGuildInput input)
    {
        EnsureKingdomExists(kingdomId);
        var success = _guildRegistry.Join(input.GuildId, kingdomId);
        return new GuildActionResultDto
        {
            Success = success,
            Message = success
                ? "Đã gia nhập guild."
                : "Không thể gia nhập (guild không tồn tại hoặc vương quốc đã thuộc guild khác)."
        };
    }

    public GuildActionResultDto Leave(string kingdomId, LeaveGuildInput input)
    {
        var success = _guildRegistry.Leave(input.GuildId, kingdomId);
        return new GuildActionResultDto
        {
            Success = success,
            Message = success
                ? "Đã rời guild."
                : "Không thể rời (guild không tồn tại hoặc vương quốc không phải thành viên)."
        };
    }

    private void EnsureKingdomExists(string kingdomId)
    {
        if (_kingdomRegistry.Find(kingdomId) is null)
        {
            throw new InvalidOperationException($"Không tìm thấy vương quốc '{kingdomId}'.");
        }
    }

    private CoreGuild Find(string guildId) =>
        _guildRegistry.Find(guildId) ?? throw new InvalidOperationException($"Không tìm thấy guild '{guildId}'.");

    private static GuildDto Map(CoreGuild guild) => new()
    {
        Id = guild.Id,
        Name = guild.Name,
        MemberKingdomIds = guild.MemberKingdomIds.ToList()
    };
}
