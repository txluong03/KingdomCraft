using KingdomCraft.Application.Economy;
using KingdomCraft.Application.Kingdom;
using CoreKingdomState = KingdomCraft.Core.Kingdom.KingdomState;

namespace KingdomCraft.Server.Networking;

/// <summary>
/// AppService instance dùng chung cho MỘT vương quốc, xuyên suốt vòng đời
/// vương quốc đó — bắt buộc để lock nội bộ của KingdomAppService/
/// EconomyAppService bảo vệ đúng KingdomState khi nhiều request cùng lúc
/// (nếu tạo AppService mới cho mỗi request, mỗi instance sẽ có lock riêng
/// và không loại trừ lẫn nhau).
/// </summary>
public class KingdomSession
{
    public KingdomAppService KingdomAppService { get; }
    public EconomyAppService EconomyAppService { get; }

    public KingdomSession(CoreKingdomState kingdom)
    {
        KingdomAppService = new KingdomAppService(kingdom);
        EconomyAppService = new EconomyAppService(kingdom);
    }
}
