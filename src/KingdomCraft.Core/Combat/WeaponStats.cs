namespace KingdomCraft.Core.Combat;

/// <summary>
/// Sát thương tạm dùng công cụ có sẵn (Docs/07_Items) làm vũ khí — chưa có
/// item Weapon riêng, xem Docs/10_Combat/Weapons.md.
/// </summary>
public static class WeaponStats
{
    public const int UnarmedAttackPower = 1;

    private static readonly Dictionary<string, int> AttackPowerByItemId = new()
    {
        ["wooden_axe"] = 3,
        ["wooden_pickaxe"] = 2,
        ["stone_axe"] = 5,
        ["stone_pickaxe"] = 4
    };

    public static int GetAttackPower(string? itemId) =>
        itemId is not null && AttackPowerByItemId.TryGetValue(itemId, out var power) ? power : UnarmedAttackPower;
}
