using System.Text.Json;
using System.Text.Json.Serialization;
using CoreKingdomRegistry = KingdomCraft.Core.Kingdom.KingdomRegistry;
using CoreKingdomState = KingdomCraft.Core.Kingdom.KingdomState;

namespace KingdomCraft.Application.Persistence;

/// <summary>
/// Lưu/tải toàn bộ vương quốc trong <see cref="CoreKingdomRegistry"/> ra file
/// JSON (Docs/11_Database/SaveGame.md). Guild/Diplomacy CHƯA được lưu ở bản
/// này — chỉ KingdomState (công trình, NPC, tài nguyên, công nghệ đã nghiên
/// cứu), theo dõi phần còn thiếu ở TechnicalDebt.
/// </summary>
public class SaveGameAppService
{
    private const string DefaultFilePath = "kingdomcraft-savegame.json";

    private static readonly JsonSerializerOptions JsonOptions = CreateJsonOptions();

    private readonly CoreKingdomRegistry _kingdomRegistry;

    public SaveGameAppService(CoreKingdomRegistry kingdomRegistry)
    {
        _kingdomRegistry = kingdomRegistry;
    }

    public SaveGameResultDto Save(SaveGameInput input)
    {
        var filePath = ResolvePath(input.FilePath);
        var kingdoms = _kingdomRegistry.All;

        File.WriteAllText(filePath, JsonSerializer.Serialize(kingdoms, JsonOptions));

        return new SaveGameResultDto
        {
            Success = true,
            Message = $"Đã lưu {kingdoms.Count} vương quốc vào '{filePath}'.",
            KingdomCount = kingdoms.Count
        };
    }

    public SaveGameResultDto Load(LoadGameInput input)
    {
        var filePath = ResolvePath(input.FilePath);
        if (!File.Exists(filePath))
        {
            return new SaveGameResultDto { Success = false, Message = $"Không tìm thấy file '{filePath}'.", KingdomCount = 0 };
        }

        var kingdoms = JsonSerializer.Deserialize<List<CoreKingdomState>>(File.ReadAllText(filePath), JsonOptions)
            ?? new List<CoreKingdomState>();

        foreach (var kingdom in kingdoms)
        {
            _kingdomRegistry.Restore(kingdom);
        }

        return new SaveGameResultDto
        {
            Success = true,
            Message = $"Đã tải {kingdoms.Count} vương quốc từ '{filePath}'.",
            KingdomCount = kingdoms.Count
        };
    }

    private static string ResolvePath(string? filePath) =>
        string.IsNullOrEmpty(filePath) ? DefaultFilePath : filePath;

    private static JsonSerializerOptions CreateJsonOptions()
    {
        var options = new JsonSerializerOptions { WriteIndented = true };
        options.Converters.Add(new JsonStringEnumConverter());
        return options;
    }
}
