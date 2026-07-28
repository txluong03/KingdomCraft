namespace KingdomCraft.Core.Entities;

/// <summary>Quản lý nhiều người chơi trong bộ nhớ — song song với KingdomRegistry.</summary>
public class PlayerRegistry
{
    private readonly Dictionary<string, Player> _players = new();
    private readonly object _syncRoot = new();

    public Player Create(string name)
    {
        lock (_syncRoot)
        {
            var player = new Player { Name = name };
            _players[player.Id] = player;
            return player;
        }
    }

    public void Restore(Player player)
    {
        lock (_syncRoot)
        {
            _players[player.Id] = player;
        }
    }

    public Player? Find(string playerId)
    {
        lock (_syncRoot)
        {
            return _players.TryGetValue(playerId, out var player) ? player : null;
        }
    }

    public IReadOnlyList<Player> All
    {
        get
        {
            lock (_syncRoot)
            {
                return _players.Values.ToList();
            }
        }
    }
}
