using System.Net.Sockets;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace KingdomCraft.Client.Networking;

/// <summary>
/// Kết nối TCP tới KingdomCraft.Server — mỗi lệnh là 1 dòng JSON
/// <see cref="GameCommand"/>, mỗi phản hồi là 1 dòng JSON <see cref="GameResponse"/>.
/// Cùng giao thức với `KingdomTcpServer` phía Server (xem
/// Docs cũ đã ghi ở DevelopmentRoadmap Bước 3).
/// </summary>
public class GameClient : IDisposable
{
    private static readonly JsonSerializerOptions JsonOptions = CreateJsonOptions();

    private readonly TcpClient _tcpClient = new();
    private StreamReader? _reader;
    private StreamWriter? _writer;

    public bool IsConnected { get; private set; }

    public async Task ConnectAsync(string host, int port)
    {
        await _tcpClient.ConnectAsync(host, port);
        var stream = _tcpClient.GetStream();
        _reader = new StreamReader(stream, Encoding.UTF8);
        _writer = new StreamWriter(stream, Encoding.UTF8) { AutoFlush = true };
        IsConnected = true;
    }

    public async Task<GameResponse> SendAsync(GameCommand command)
    {
        if (_writer is null || _reader is null)
            throw new InvalidOperationException("Chưa kết nối tới Server — gọi ConnectAsync trước.");

        await _writer.WriteLineAsync(JsonSerializer.Serialize(command, JsonOptions));
        var line = await _reader.ReadLineAsync() ?? throw new IOException("Server đã đóng kết nối.");

        return JsonSerializer.Deserialize<GameResponse>(line, JsonOptions)
            ?? throw new InvalidOperationException("Không đọc được phản hồi từ Server.");
    }

    /// <summary>Tiện ích đồng bộ cho Update() của MonoGame (không muốn lồng async/await trong game loop).</summary>
    public GameResponse Send(GameCommand command) => SendAsync(command).GetAwaiter().GetResult();

    public static T ReadData<T>(GameResponse response) =>
        response.Data.Deserialize<T>(JsonOptions) ?? throw new InvalidOperationException("Data rỗng hoặc sai định dạng.");

    public void Dispose()
    {
        _writer?.Dispose();
        _reader?.Dispose();
        _tcpClient.Dispose();
    }

    private static JsonSerializerOptions CreateJsonOptions()
    {
        var options = new JsonSerializerOptions(JsonSerializerDefaults.Web);
        options.Converters.Add(new JsonStringEnumConverter());
        return options;
    }
}
