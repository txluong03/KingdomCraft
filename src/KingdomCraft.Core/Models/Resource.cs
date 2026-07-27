namespace KingdomCraft.Core.Models;

public enum ResourceType
{
    Gold,
    Wood,
    Stone,
    Food
}

public class ResourceStack
{
    public ResourceType Type { get; set; }
    public int Amount { get; set; }

    public ResourceStack(ResourceType type, int amount)
    {
        Type = type;
        Amount = amount;
    }
}
