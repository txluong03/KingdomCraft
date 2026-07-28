namespace KingdomCraft.Core.Diplomacy;

/// <summary>Quan hệ ngoại giao giữa 2 vương quốc — mặc định Neutral nếu chưa từng khai báo.</summary>
public class DiplomacyRegistry
{
    private readonly Dictionary<(string, string), DiplomacyStatus> _relations = new();
    private readonly object _syncRoot = new();

    public DiplomacyStatus GetStatus(string kingdomIdA, string kingdomIdB)
    {
        lock (_syncRoot)
        {
            return _relations.TryGetValue(Key(kingdomIdA, kingdomIdB), out var status) ? status : DiplomacyStatus.Neutral;
        }
    }

    public bool DeclareWar(string kingdomIdA, string kingdomIdB)
    {
        if (kingdomIdA == kingdomIdB)
            return false;

        lock (_syncRoot)
        {
            _relations[Key(kingdomIdA, kingdomIdB)] = DiplomacyStatus.AtWar;
            return true;
        }
    }

    public bool MakePeace(string kingdomIdA, string kingdomIdB)
    {
        lock (_syncRoot)
        {
            _relations[Key(kingdomIdA, kingdomIdB)] = DiplomacyStatus.Neutral;
            return true;
        }
    }

    private static (string, string) Key(string a, string b) =>
        string.CompareOrdinal(a, b) <= 0 ? (a, b) : (b, a);
}
