using System.Text.Json;

namespace KingdomCraft.Client.Networking;

/// <summary>Response nhận từ KingdomCraft.Server — `Data` để nguyên JsonElement vì hình dạng khác nhau theo từng action.</summary>
public class GameResponse
{
    public bool Success { get; set; }
    public JsonElement Data { get; set; }
    public string? Error { get; set; }
}
