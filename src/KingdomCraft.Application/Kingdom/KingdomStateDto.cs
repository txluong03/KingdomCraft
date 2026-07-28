using KingdomCraft.Core.Kingdom;
using KingdomCraft.Core.Entities;

namespace KingdomCraft.Application.Kingdom;

/// <summary>Dữ liệu chỉ-đọc trả về cho Client/Server thay vì lộ thẳng entity Core.</summary>
public class KingdomStateDto
{
    public string Name { get; set; } = string.Empty;
    public int AutomationLevel { get; set; }
    public List<BuildingDto> Buildings { get; set; } = new();
    public List<NpcDto> Npcs { get; set; } = new();
    public Dictionary<string, int> Resources { get; set; } = new();
}

public class BuildingDto
{
    public string Id { get; set; } = string.Empty;
    public BuildingType Type { get; set; }
    public string Name { get; set; } = string.Empty;
    public int Level { get; set; }
    public string? AssignedNpcId { get; set; }
}

public class NpcDto
{
    public string Id { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public NpcRole Role { get; set; }
    public int SkillLevel { get; set; }
}
