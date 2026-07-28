using CoreEconomySystem = KingdomCraft.Core.Economy.EconomySystem;
using CoreKingdomState = KingdomCraft.Core.Kingdom.KingdomState;

namespace KingdomCraft.Application.Economy;

/// <summary>
/// Ranh giới ứng dụng cho kinh tế vương quốc — hiện chỉ có bán tài nguyên
/// tồn kho lấy Gold theo tỷ giá cố định (xem Docs/02_GDD/Economy.md).
/// </summary>
public class EconomyAppService
{
    private readonly CoreKingdomState _kingdom;
    private readonly CoreEconomySystem _economySystem = new();
    private readonly object _syncRoot;

    public EconomyAppService(CoreKingdomState kingdom)
    {
        _kingdom = kingdom;
        _syncRoot = kingdom.SyncRoot;
    }

    public SellResourceResultDto SellResource(SellResourceInput input)
    {
        lock (_syncRoot)
        {
            var success = _economySystem.TrySellResource(_kingdom, input.ResourceName, input.Quantity);

            return new SellResourceResultDto
            {
                Success = success,
                Message = success
                    ? $"Đã bán {input.Quantity} {input.ResourceName}."
                    : "Không đủ tài nguyên hoặc loại tài nguyên không thể bán.",
                Resources = new Dictionary<string, int>(_kingdom.Resources.Amounts)
            };
        }
    }
}
