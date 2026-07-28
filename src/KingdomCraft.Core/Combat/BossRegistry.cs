namespace KingdomCraft.Core.Combat;

/// <summary>Lưu trữ boss đã spawn trong bộ nhớ — nhiều người chơi có thể cùng đánh 1 boss.</summary>
public class BossRegistry
{
    private readonly Dictionary<string, Boss> _bosses = new();
    private readonly object _syncRoot = new();

    public Boss Spawn(BossTemplate template)
    {
        lock (_syncRoot)
        {
            var boss = new Boss
            {
                Name = template.Name,
                MaxHealth = template.MaxHealth,
                Health = template.MaxHealth,
                AttackPower = template.AttackPower
            };

            _bosses[boss.Id] = boss;
            return boss;
        }
    }

    public Boss? Find(string bossId)
    {
        lock (_syncRoot)
        {
            return _bosses.TryGetValue(bossId, out var boss) ? boss : null;
        }
    }

    public IReadOnlyList<Boss> All
    {
        get
        {
            lock (_syncRoot)
            {
                return _bosses.Values.ToList();
            }
        }
    }
}
