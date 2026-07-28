namespace KingdomCraft.Core.Combat;

/// <summary>2 mẫu boss khởi đầu — xem Docs/03_Gameplay/BossFlow.md.</summary>
public static class BossCatalog
{
    public static readonly IReadOnlyList<BossTemplate> All = new List<BossTemplate>
    {
        new("slime_king", "Slime Vua", maxHealth: 40, attackPower: 4),
        new("alpha_wolf", "Sói Đầu Đàn", maxHealth: 70, attackPower: 7)
    };

    public static BossTemplate? Find(string templateId) =>
        All.FirstOrDefault(template => template.TemplateId == templateId);
}
