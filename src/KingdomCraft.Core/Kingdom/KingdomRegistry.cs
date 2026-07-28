namespace KingdomCraft.Core.Kingdom;

/// <summary>
/// Quản lý nhiều vương quốc trong bộ nhớ (mỗi client/phiên chơi 1
/// <see cref="KingdomState"/> riêng, khớp `KingdomId`) — nền tảng cho
/// Server thật sự đa người chơi thay vì 1 KingdomState cố định.
/// </summary>
public class KingdomRegistry
{
    private readonly Dictionary<string, KingdomState> _kingdoms = new();
    private readonly object _syncRoot = new();

    public KingdomState Create(string name)
    {
        lock (_syncRoot)
        {
            var kingdom = new KingdomState { Name = name };
            _kingdoms[kingdom.Id] = kingdom;
            return kingdom;
        }
    }

    /// <summary>Nạp lại 1 vương quốc đã có sẵn Id (VD: từ file save) — ghi đè nếu Id đã tồn tại.</summary>
    public void Restore(KingdomState kingdom)
    {
        lock (_syncRoot)
        {
            _kingdoms[kingdom.Id] = kingdom;
        }
    }

    public KingdomState? Find(string kingdomId)
    {
        lock (_syncRoot)
        {
            return _kingdoms.TryGetValue(kingdomId, out var kingdom) ? kingdom : null;
        }
    }

    public IReadOnlyList<KingdomState> All
    {
        get
        {
            lock (_syncRoot)
            {
                return _kingdoms.Values.ToList();
            }
        }
    }
}
