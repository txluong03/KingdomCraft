using KingdomCraft.Core.Entities;

namespace KingdomCraft.Application.Kingdom;

public class AssignNpcRoleInput
{
    public string NpcId { get; set; } = string.Empty;
    public NpcRole Role { get; set; }
}
