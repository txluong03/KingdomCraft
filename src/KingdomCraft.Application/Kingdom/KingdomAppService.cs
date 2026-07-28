using KingdomCraft.Core.Entities;
using KingdomCraft.Core.Simulation;
using CoreBuilding = KingdomCraft.Core.Kingdom.Building;
using CoreKingdomState = KingdomCraft.Core.Kingdom.KingdomState;

namespace KingdomCraft.Application.Kingdom;

/// <summary>
/// Ranh giới ứng dụng cho 1 vương quốc — theo convention "FooAppService nhận
/// Input DTO, trả về Dto" mượn từ OC-TXNG (chỉ mượn khung, không phụ thuộc
/// EF Core/multi-tenant/RBAC vì KingdomCraft chưa cần). Server/Client tương lai
/// (Bước 3 — networking, Bước 5 — Save/Load) nên đi qua lớp này thay vì thao
/// tác thẳng lên <see cref="CoreKingdomState"/>.
/// </summary>
public class KingdomAppService
{
    private readonly CoreKingdomState _kingdom;
    private readonly AutomationSystem _automationSystem = new();

    public KingdomAppService(CoreKingdomState kingdom)
    {
        _kingdom = kingdom;
    }

    public KingdomStateDto GetKingdomState() => Map(_kingdom);

    /// <summary>Chạy 1 tick mô phỏng (xem GameLoop.md) và trả về trạng thái mới nhất.</summary>
    public KingdomStateDto Tick()
    {
        _automationSystem.Tick(_kingdom);
        return Map(_kingdom);
    }

    public BuildingDto CreateBuilding(CreateBuildingInput input)
    {
        var building = new CoreBuilding
        {
            Type = input.Type,
            Name = input.Name ?? string.Empty,
            Level = input.Level ?? 1
        };

        _kingdom.Buildings.Add(building);
        return MapBuilding(building);
    }

    public NpcDto RecruitNpc(RecruitNpcInput input)
    {
        var npc = new Npc
        {
            Name = input.Name ?? string.Empty,
            Role = input.Role,
            SkillLevel = input.SkillLevel ?? 1
        };

        _kingdom.Npcs.Add(npc);
        return MapNpc(npc);
    }

    public NpcDto AssignNpcRole(AssignNpcRoleInput input)
    {
        var npc = _kingdom.Npcs.FirstOrDefault(n => n.Id == input.NpcId);
        if (npc is null)
        {
            throw new InvalidOperationException($"Không tìm thấy NPC có Id '{input.NpcId}'.");
        }

        npc.Role = input.Role;
        return MapNpc(npc);
    }

    private static KingdomStateDto Map(CoreKingdomState kingdom) => new()
    {
        Name = kingdom.Name,
        AutomationLevel = kingdom.AutomationLevel,
        Buildings = kingdom.Buildings.Select(MapBuilding).ToList(),
        Npcs = kingdom.Npcs.Select(MapNpc).ToList(),
        Resources = new Dictionary<string, int>(kingdom.Resources.Amounts)
    };

    private static BuildingDto MapBuilding(CoreBuilding building) => new()
    {
        Id = building.Id,
        Type = building.Type,
        Name = building.Name,
        Level = building.Level,
        AssignedNpcId = building.AssignedNpcId
    };

    private static NpcDto MapNpc(Npc npc) => new()
    {
        Id = npc.Id,
        Name = npc.Name,
        Role = npc.Role,
        SkillLevel = npc.SkillLevel
    };
}
