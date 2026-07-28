using KingdomCraft.Core.Entities;

namespace KingdomCraft.Application.Kingdom;

public class RecruitNpcInput
{
    public string? Name { get; set; }
    public NpcRole Role { get; set; } = NpcRole.Idle;
    public int? SkillLevel { get; set; }
}
