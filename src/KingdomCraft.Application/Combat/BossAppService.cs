using KingdomCraft.Core.Entities;
using CoreBoss = KingdomCraft.Core.Combat.Boss;
using CoreBossCatalog = KingdomCraft.Core.Combat.BossCatalog;
using CoreBossRegistry = KingdomCraft.Core.Combat.BossRegistry;
using CoreCombatSystem = KingdomCraft.Core.Combat.CombatSystem;
using CoreWeaponStats = KingdomCraft.Core.Combat.WeaponStats;

namespace KingdomCraft.Application.Combat;

/// <summary>
/// Ranh giới ứng dụng cho đánh boss — xem Docs/03_Gameplay/BossFlow.md,
/// Docs/10_Combat/BossFight.md.
/// </summary>
public class BossAppService
{
    private readonly CoreBossRegistry _bossRegistry;
    private readonly Player _player;
    private readonly CoreCombatSystem _combatSystem = new();

    public BossAppService(CoreBossRegistry bossRegistry, Player player)
    {
        _bossRegistry = bossRegistry;
        _player = player;
    }

    public BossDto SpawnBoss(SpawnBossInput input)
    {
        var template = CoreBossCatalog.Find(input.TemplateId)
            ?? throw new InvalidOperationException($"Không tìm thấy mẫu boss '{input.TemplateId}'.");

        return Map(_bossRegistry.Spawn(template));
    }

    public BossDto GetBoss(GetBossInput input) => Map(Find(input.BossId));

    public AttackResultDto AttackBoss(AttackBossInput input)
    {
        var boss = Find(input.BossId);

        // Khóa cả Player lẫn Boss: nhiều người chơi có thể cùng đánh 1 world
        // boss, và 1 người chơi cũng có thể bị nhiều nguồn trừ Health cùng lúc.
        // Thứ tự khóa (player rồi tới boss) luôn cố định trong method này nên
        // không có rủi ro deadlock giữa các lần gọi.
        lock (_player.SyncRoot)
        {
            lock (boss.SyncRoot)
            {
                var hasWeapon = input.WeaponItemId is not null && _player.Inventory.GetQuantity(input.WeaponItemId) > 0;
                var attackPower = hasWeapon ? CoreWeaponStats.GetAttackPower(input.WeaponItemId) : CoreWeaponStats.UnarmedAttackPower;

                var result = _combatSystem.Attack(_player, boss, attackPower);

                return new AttackResultDto
                {
                    Success = result.Success,
                    BossHealth = result.BossHealth,
                    PlayerHealth = result.PlayerHealth,
                    Message = result.Message
                };
            }
        }
    }

    private CoreBoss Find(string bossId) =>
        _bossRegistry.Find(bossId) ?? throw new InvalidOperationException($"Không tìm thấy boss '{bossId}'.");

    private static BossDto Map(CoreBoss boss) => new()
    {
        Id = boss.Id,
        Name = boss.Name,
        MaxHealth = boss.MaxHealth,
        Health = boss.Health,
        AttackPower = boss.AttackPower
    };
}
