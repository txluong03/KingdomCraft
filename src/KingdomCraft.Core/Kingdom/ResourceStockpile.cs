namespace KingdomCraft.Core.Kingdom;

/// <summary>
/// Kho tài nguyên chung của vương quốc (khác với inventory cá nhân của người chơi).
/// </summary>
public class ResourceStockpile
{
    public Dictionary<string, int> Amounts { get; set; } = new();

    public int Get(string resourceName) =>
        Amounts.TryGetValue(resourceName, out var amount) ? amount : 0;

    public void Add(string resourceName, int amount)
    {
        Amounts[resourceName] = Get(resourceName) + amount;
    }

    public bool TrySpend(string resourceName, int amount)
    {
        if (Get(resourceName) < amount) return false;
        Amounts[resourceName] -= amount;
        return true;
    }
}
