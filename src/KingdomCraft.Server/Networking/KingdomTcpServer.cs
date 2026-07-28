using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace KingdomCraft.Server.Networking;

/// <summary>
/// Server TCP tối thiểu: mỗi dòng gửi lên là 1 JSON <see cref="KingdomCommand"/>,
/// mỗi dòng trả về là 1 JSON <see cref="KingdomResponse"/>. Thay cho vòng lặp
/// `Task.Delay` demo trước đây (KI-04) — đây là networking thật đầu tiên,
/// chưa mã hóa/xác thực (chỉ dùng cho LAN/dev, xem AntiCheat cho sau này).
/// </summary>
public class KingdomTcpServer
{
    private static readonly JsonSerializerOptions JsonOptions = CreateJsonOptions();

    private static JsonSerializerOptions CreateJsonOptions()
    {
        var options = new JsonSerializerOptions(JsonSerializerDefaults.Web);
        options.Converters.Add(new JsonStringEnumConverter());
        return options;
    }

    private readonly TcpListener _listener;
    private readonly KingdomCommandDispatcher _dispatcher;

    public KingdomTcpServer(KingdomCommandDispatcher dispatcher, int port = 0)
    {
        _dispatcher = dispatcher;
        _listener = new TcpListener(IPAddress.Loopback, port);
    }

    /// <summary>Cổng TCP thực tế đang lắng nghe (hữu ích khi khởi tạo với port = 0).</summary>
    public int Port => ((IPEndPoint)_listener.LocalEndpoint).Port;

    public void Start() => _listener.Start();

    public void Stop() => _listener.Stop();

    public async Task RunAsync(CancellationToken cancellationToken)
    {
        while (!cancellationToken.IsCancellationRequested)
        {
            TcpClient client;
            try
            {
                client = await _listener.AcceptTcpClientAsync(cancellationToken);
            }
            catch (Exception ex) when (ex is ObjectDisposedException or OperationCanceledException or SocketException)
            {
                break;
            }

            _ = HandleClientAsync(client, cancellationToken);
        }
    }

    private async Task HandleClientAsync(TcpClient client, CancellationToken cancellationToken)
    {
        using var _ = client;
        await using var stream = client.GetStream();
        using var reader = new StreamReader(stream, Encoding.UTF8);
        await using var writer = new StreamWriter(stream, Encoding.UTF8) { AutoFlush = true };

        while (!cancellationToken.IsCancellationRequested)
        {
            string? line;
            try
            {
                line = await reader.ReadLineAsync(cancellationToken);
            }
            catch (IOException)
            {
                break;
            }

            if (line is null)
                break;

            var response = HandleLine(line);
            await writer.WriteLineAsync(JsonSerializer.Serialize(response, JsonOptions));
        }
    }

    private KingdomResponse HandleLine(string line)
    {
        try
        {
            var command = JsonSerializer.Deserialize<KingdomCommand>(line, JsonOptions)
                ?? throw new InvalidOperationException("Request rỗng.");
            return _dispatcher.Dispatch(command);
        }
        catch (Exception ex)
        {
            return new KingdomResponse { Success = false, Error = ex.Message };
        }
    }
}
