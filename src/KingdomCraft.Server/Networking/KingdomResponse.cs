namespace KingdomCraft.Server.Networking;

/// <summary>1 dòng response JSON trả về cho client qua TCP.</summary>
public class KingdomResponse
{
    public bool Success { get; set; }
    public object? Data { get; set; }
    public string? Error { get; set; }
}
