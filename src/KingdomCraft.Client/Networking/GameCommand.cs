namespace KingdomCraft.Client.Networking;

/// <summary>
/// Request gửi tới KingdomCraft.Server qua TCP — cùng hình dạng JSON với
/// `KingdomCraft.Server.Networking.KingdomCommand`, viết riêng ở Client để
/// không phải reference ngược vào project Server.
/// </summary>
public class GameCommand
{
    public string Action { get; set; } = string.Empty;
    public string? KingdomId { get; set; }
    public string? PlayerId { get; set; }
    public object? Payload { get; set; }
}
