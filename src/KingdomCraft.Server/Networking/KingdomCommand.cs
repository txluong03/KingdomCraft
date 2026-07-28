using System.Text.Json;

namespace KingdomCraft.Server.Networking;

/// <summary>1 dòng request JSON gửi qua TCP tới KingdomCraft.Server.</summary>
public class KingdomCommand
{
    public string Action { get; set; } = string.Empty;

    /// <summary>Vương quốc thực hiện hành động này — bắt buộc với action Kingdom-scoped (trừ "CreateKingdom").</summary>
    public string? KingdomId { get; set; }

    /// <summary>Người chơi thực hiện hành động này — bắt buộc với action Player-scoped (Craft, Quest, Boss...).</summary>
    public string? PlayerId { get; set; }

    // default(JsonElement) có ValueKind.Undefined và làm serializer crash khi
    // action không cần payload (VD: "Tick", "GetKingdomState") — khởi tạo
    // sẵn thành JSON null để luôn serialize được.
    public JsonElement Payload { get; set; } = JsonDocument.Parse("null").RootElement;
}
