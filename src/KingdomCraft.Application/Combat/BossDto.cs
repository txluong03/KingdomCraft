namespace KingdomCraft.Application.Combat;

public class BossDto
{
    public string Id { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public int MaxHealth { get; set; }
    public int Health { get; set; }
    public int AttackPower { get; set; }
}
