namespace KingdomCraft.Core.Economy;

/// <summary>Tỷ giá quy đổi tài nguyên vương quốc sang Gold — thị trường tối thiểu.</summary>
public static class MarketRates
{
    private static readonly Dictionary<string, int> GoldPerUnit = new()
    {
        ["wood"] = 1,
        ["stone"] = 2,
        ["food"] = 1
    };

    public static int? GetGoldPerUnit(string resourceName) =>
        GoldPerUnit.TryGetValue(resourceName, out var rate) ? rate : null;
}
