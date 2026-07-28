using KingdomCraft.Core.Kingdom;

namespace KingdomCraft.Application.Kingdom;

public class CreateBuildingInput
{
    public BuildingType Type { get; set; }
    public string? Name { get; set; }
    public int? Level { get; set; }
}
