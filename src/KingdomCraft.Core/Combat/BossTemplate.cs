namespace KingdomCraft.Core.Combat;

public class BossTemplate
{
    public string TemplateId { get; }
    public string Name { get; }
    public int MaxHealth { get; }
    public int AttackPower { get; }

    public BossTemplate(string templateId, string name, int maxHealth, int attackPower)
    {
        TemplateId = templateId;
        Name = name;
        MaxHealth = maxHealth;
        AttackPower = attackPower;
    }
}
