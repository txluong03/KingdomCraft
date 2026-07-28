namespace KingdomCraft.Application.Combat;

public class AttackResultDto
{
    public bool Success { get; set; }
    public int BossHealth { get; set; }
    public int PlayerHealth { get; set; }
    public string Message { get; set; } = string.Empty;
}
