using KingdomCraft.Core.Entities;
using KingdomCraft.Core.Kingdom;

namespace KingdomCraft.Core.Diplomacy;

/// <summary>
/// Cơ chế Raid tối thiểu: so sánh tổng SkillLevel của NPC vai trò Soldier
/// giữa 2 bên. Không kiểm tra trạng thái AtWar ở đây — việc đó thuộc về
/// tầng ứng dụng (xem Application/Diplomacy/DiplomacyAppService).
/// </summary>
public class WarSystem
{
    private const int StolenGoldPercent = 20;

    public bool TryRaid(KingdomState attacker, KingdomState defender)
    {
        if (MilitaryStrength(attacker) <= MilitaryStrength(defender))
            return false;

        var stolenGold = defender.Resources.Get("gold") * StolenGoldPercent / 100;
        if (stolenGold <= 0)
            return false;

        defender.Resources.TrySpend("gold", stolenGold);
        attacker.Resources.Add("gold", stolenGold);
        return true;
    }

    public static int MilitaryStrength(KingdomState kingdom) =>
        kingdom.Npcs.Where(npc => npc.Role == NpcRole.Soldier).Sum(npc => npc.SkillLevel);
}
