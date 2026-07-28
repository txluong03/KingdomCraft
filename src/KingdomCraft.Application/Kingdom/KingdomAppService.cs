using KingdomCraft.Core.Entities;
using KingdomCraft.Core.Simulation;
using CoreBuilding = KingdomCraft.Core.Kingdom.Building;
using CoreKingdomState = KingdomCraft.Core.Kingdom.KingdomState;
using CoreTechnologySystem = KingdomCraft.Core.Technology.TechnologySystem;

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
    private readonly CoreTechnologySystem _technologySystem = new();
    private readonly object _syncRoot;

    public KingdomAppService(CoreKingdomState kingdom)
    {
        _kingdom = kingdom;
        _syncRoot = kingdom.SyncRoot;
    }

    public KingdomStateDto GetKingdomState()
    {
        lock (_syncRoot)
        {
            return Map(_kingdom);
        }
    }

    /// <summary>Chạy 1 tick mô phỏng (xem GameLoop.md) và trả về trạng thái mới nhất.</summary>
    public KingdomStateDto Tick()
    {
        lock (_syncRoot)
        {
            _automationSystem.Tick(_kingdom);
            return Map(_kingdom);
        }
    }

    public BuildingDto CreateBuilding(CreateBuildingInput input)
    {
        lock (_syncRoot)
        {
            if (!_technologySystem.IsBuildingUnlocked(_kingdom, input.Type))
            {
                throw new InvalidOperationException($"Công trình '{input.Type}' chưa được mở khóa — cần nghiên cứu công nghệ tương ứng trước.");
            }

            var building = new CoreBuilding
            {
                Type = input.Type,
                Name = input.Name ?? string.Empty,
                Level = input.Level ?? 1
            };

            _kingdom.Buildings.Add(building);
            return MapBuilding(building);
        }
    }

    public NpcDto RecruitNpc(RecruitNpcInput input)
    {
        lock (_syncRoot)
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
    }

    public NpcDto AssignNpcRole(AssignNpcRoleInput input)
    {
        lock (_syncRoot)
        {
            var npc = _kingdom.Npcs.FirstOrDefault(n => n.Id == input.NpcId);
            if (npc is null)
            {
                throw new InvalidOperationException($"Không tìm thấy NPC có Id '{input.NpcId}'.");
            }

            npc.Role = input.Role;
            return MapNpc(npc);
        }
    }

    /// <summary>Huấn luyện/thăng cấp NPC — tăng SkillLevel (xem Docs/06_NPC_AI/VillagerAI.md).</summary>
    public NpcDto TrainNpc(TrainNpcInput input)
    {
        lock (_syncRoot)
        {
            var npc = _kingdom.Npcs.FirstOrDefault(n => n.Id == input.NpcId);
            if (npc is null)
            {
                throw new InvalidOperationException($"Không tìm thấy NPC có Id '{input.NpcId}'.");
            }

            npc.SkillLevel += input.SkillIncrease;
            return MapNpc(npc);
        }
    }

    /// <summary>Nghiên cứu công nghệ (tiêu tốn Gold) — xem Docs/02_GDD/TechnologyTree.md.</summary>
    public TechnologyResultDto ResearchTechnology(ResearchTechnologyInput input)
    {
        lock (_syncRoot)
        {
            var success = _technologySystem.TryResearch(_kingdom, input.TechnologyId);

            return new TechnologyResultDto
            {
                Success = success,
                Message = success
                    ? "Nghiên cứu thành công."
                    : "Không thể nghiên cứu (công nghệ không tồn tại, đã nghiên cứu rồi, hoặc không đủ Gold).",
                ResearchedTechnologyIds = _kingdom.ResearchedTechnologyIds.ToList()
            };
        }
    }

    private static KingdomStateDto Map(CoreKingdomState kingdom) => new()
    {
        Id = kingdom.Id,
        Name = kingdom.Name,
        AutomationLevel = kingdom.AutomationLevel,
        Buildings = kingdom.Buildings.Select(MapBuilding).ToList(),
        Npcs = kingdom.Npcs.Select(MapNpc).ToList(),
        Resources = new Dictionary<string, int>(kingdom.Resources.Amounts),
        ResearchedTechnologyIds = kingdom.ResearchedTechnologyIds.ToList()
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
