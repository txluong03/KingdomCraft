using KingdomCraft.Core.Kingdom;

namespace KingdomCraft.Core.Economy;

/// <summary>Bán tài nguyên tồn kho vương quốc lấy Gold theo <see cref="MarketRates"/>.</summary>
public class EconomySystem
{
    public bool TrySellResource(KingdomState kingdom, string resourceName, int quantity)
    {
        if (quantity <= 0)
            return false;

        var rate = MarketRates.GetGoldPerUnit(resourceName);
        if (rate is null)
            return false;

        if (!kingdom.Resources.TrySpend(resourceName, quantity))
            return false;

        kingdom.Resources.Add("gold", rate.Value * quantity);
        return true;
    }
}
