using CoreDiplomacyRegistry = KingdomCraft.Core.Diplomacy.DiplomacyRegistry;
using CoreDiplomacyStatus = KingdomCraft.Core.Diplomacy.DiplomacyStatus;
using CoreGuildRegistry = KingdomCraft.Core.Guilds.GuildRegistry;
using CoreKingdomRegistry = KingdomCraft.Core.Kingdom.KingdomRegistry;
using CoreKingdomState = KingdomCraft.Core.Kingdom.KingdomState;
using CoreWarSystem = KingdomCraft.Core.Diplomacy.WarSystem;

namespace KingdomCraft.Application.Diplomacy;

/// <summary>
/// Ranh giới ứng dụng cho quan hệ ngoại giao/chiến tranh giữa các vương
/// quốc — xem Docs/03_Gameplay (MultiplayerFlow) và Docs/02_GDD/KingdomSystem.md.
/// </summary>
public class DiplomacyAppService
{
    private readonly CoreDiplomacyRegistry _diplomacyRegistry;
    private readonly CoreKingdomRegistry _kingdomRegistry;
    private readonly CoreGuildRegistry _guildRegistry;
    private readonly CoreWarSystem _warSystem = new();

    public DiplomacyAppService(CoreDiplomacyRegistry diplomacyRegistry, CoreKingdomRegistry kingdomRegistry, CoreGuildRegistry guildRegistry)
    {
        _diplomacyRegistry = diplomacyRegistry;
        _kingdomRegistry = kingdomRegistry;
        _guildRegistry = guildRegistry;
    }

    public DiplomacyStatusDto GetStatus(string kingdomId, GetDiplomacyStatusInput input) => new()
    {
        Status = _diplomacyRegistry.GetStatus(kingdomId, input.TargetKingdomId)
    };

    public DiplomacyActionResultDto DeclareWar(string kingdomId, DeclareWarInput input)
    {
        EnsureKingdomExists(kingdomId);
        EnsureKingdomExists(input.TargetKingdomId);

        if (AreGuildMates(kingdomId, input.TargetKingdomId))
        {
            return Result(false, "Không thể tuyên chiến với vương quốc cùng guild.");
        }

        var success = _diplomacyRegistry.DeclareWar(kingdomId, input.TargetKingdomId);
        return Result(success, success ? "Đã tuyên chiến." : "Không thể tuyên chiến với chính mình.");
    }

    public DiplomacyActionResultDto MakePeace(string kingdomId, MakePeaceInput input)
    {
        var success = _diplomacyRegistry.MakePeace(kingdomId, input.TargetKingdomId);
        return Result(success, "Đã lập lại hòa bình.");
    }

    public RaidResultDto Raid(string kingdomId, RaidInput input)
    {
        var attacker = Find(kingdomId);
        var defender = Find(input.TargetKingdomId);

        if (_diplomacyRegistry.GetStatus(kingdomId, input.TargetKingdomId) != CoreDiplomacyStatus.AtWar)
        {
            return new RaidResultDto { Success = false, Message = "Hai vương quốc không trong tình trạng chiến tranh." };
        }

        var success = _warSystem.TryRaid(attacker, defender);

        return new RaidResultDto
        {
            Success = success,
            Message = success ? "Đột kích thành công, cướp được tài nguyên." : "Đột kích thất bại (quân sự không đủ mạnh).",
            AttackerResources = new Dictionary<string, int>(attacker.Resources.Amounts),
            DefenderResources = new Dictionary<string, int>(defender.Resources.Amounts)
        };
    }

    private bool AreGuildMates(string kingdomIdA, string kingdomIdB)
    {
        var guildOfA = _guildRegistry.FindGuildOfKingdom(kingdomIdA);
        return guildOfA is not null && guildOfA.Id == _guildRegistry.FindGuildOfKingdom(kingdomIdB)?.Id;
    }

    private void EnsureKingdomExists(string kingdomId) => Find(kingdomId);

    private CoreKingdomState Find(string kingdomId) =>
        _kingdomRegistry.Find(kingdomId) ?? throw new InvalidOperationException($"Không tìm thấy vương quốc '{kingdomId}'.");

    private static DiplomacyActionResultDto Result(bool success, string message) => new() { Success = success, Message = message };
}
