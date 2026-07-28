using KingdomCraft.Core.Entities;

namespace KingdomCraft.Core.Combat;

public record AttackResult(bool Success, int BossHealth, int PlayerHealth, string Message);

/// <summary>Giải quyết 1 đòn tấn công (người chơi đánh, boss đánh trả nếu còn sống).</summary>
public class CombatSystem
{
    public AttackResult Attack(Player player, Boss boss, int attackPower)
    {
        if (boss.Health <= 0)
            return new AttackResult(false, boss.Health, player.Health, "Boss đã bị đánh bại.");

        if (player.Health <= 0)
            return new AttackResult(false, boss.Health, player.Health, "Người chơi đã gục ngã.");

        boss.Health = Math.Max(0, boss.Health - attackPower);

        if (boss.Health > 0)
        {
            player.Health = Math.Max(0, player.Health - boss.AttackPower);
        }

        var message = boss.Health == 0 ? "Đã hạ gục boss!" : "Đòn tấn công thành công.";
        return new AttackResult(true, boss.Health, player.Health, message);
    }
}
