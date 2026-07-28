using CorePlayer = KingdomCraft.Core.Entities.Player;
using CorePlayerRegistry = KingdomCraft.Core.Entities.PlayerRegistry;

namespace KingdomCraft.Application.Players;

/// <summary>Đăng ký/tra cứu người chơi — xem Docs/05_Player.</summary>
public class PlayerAppService
{
    private readonly CorePlayerRegistry _playerRegistry;

    public PlayerAppService(CorePlayerRegistry playerRegistry)
    {
        _playerRegistry = playerRegistry;
    }

    /// <summary>
    /// Tạo người chơi mới, tặng sẵn 1 bộ khởi đầu nhỏ (5 wood + 5 stone) để
    /// test được Crafting ngay cả trước khi đào/chặt được block đầu tiên.
    /// Thu thập thật xem <see cref="GatherItem"/> (Client gọi khi phá khối,
    /// xem Core/World/BlockDrops.cs).
    /// </summary>
    public PlayerDto CreatePlayer(CreatePlayerInput input)
    {
        var player = _playerRegistry.Create(input.Name);
        player.Inventory.TryAdd("wood", 5);
        player.Inventory.TryAdd("stone", 5);
        return Map(player);
    }

    public PlayerDto GetPlayer(GetPlayerInput input) => Map(Find(input.PlayerId));

    /// <summary>Cộng item vào Inventory khi người chơi đào/chặt được khối (xem Docs/09_Building/Blocks.md).</summary>
    public PlayerDto GatherItem(string playerId, GatherItemInput input)
    {
        var player = Find(playerId);

        lock (player.SyncRoot)
        {
            player.Inventory.TryAdd(input.ItemId, input.Quantity);
        }

        return Map(player);
    }

    private CorePlayer Find(string playerId) =>
        _playerRegistry.Find(playerId) ?? throw new InvalidOperationException($"Không tìm thấy người chơi '{playerId}'.");

    private static PlayerDto Map(CorePlayer player)
    {
        lock (player.SyncRoot)
        {
            return new PlayerDto
            {
                Id = player.Id,
                Name = player.Name,
                Health = player.Health,
                Hunger = player.Hunger,
                Level = player.Level,
                Experience = player.Experience,
                Inventory = player.Inventory.Slots.ToDictionary(slot => slot.ItemId, slot => slot.Quantity)
            };
        }
    }
}
