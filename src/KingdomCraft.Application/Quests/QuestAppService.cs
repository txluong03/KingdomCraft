using KingdomCraft.Core.Entities;
using KingdomCraft.Core.Items;
using KingdomCraft.Core.Quests;
using CoreKingdomState = KingdomCraft.Core.Kingdom.KingdomState;

namespace KingdomCraft.Application.Quests;

/// <summary>
/// Ranh giới ứng dụng cho quest — chấm điều kiện hoàn thành theo trạng thái
/// hiện tại của Player/KingdomState mỗi lần <see cref="EvaluateQuests"/> được
/// gọi (poll, chưa event-driven). Xem Docs/03_Gameplay/QuestFlow.md.
/// </summary>
public class QuestAppService
{
    private readonly Player _player;
    private readonly CoreKingdomState _kingdom;

    public QuestAppService(Player player, CoreKingdomState kingdom)
    {
        _player = player;
        _kingdom = kingdom;
    }

    public List<QuestDto> GetQuestLog()
    {
        lock (_player.SyncRoot)
        {
            return QuestCatalog.All.Select(Map).ToList();
        }
    }

    /// <summary>Chấm lại toàn bộ quest chưa hoàn thành, trả về quest vừa mới hoàn thành ở lần gọi này.</summary>
    public List<QuestDto> EvaluateQuests()
    {
        lock (_player.SyncRoot)
        {
            var newlyCompleted = new List<QuestDto>();

            foreach (var quest in QuestCatalog.All)
            {
                if (_player.QuestLog.IsCompleted(quest.Id))
                    continue;

                if (IsObjectiveMet(quest.ObjectiveType) && _player.QuestLog.Complete(quest.Id))
                {
                    newlyCompleted.Add(Map(quest));
                }
            }

            return newlyCompleted;
        }
    }

    private bool IsObjectiveMet(QuestObjectiveType objectiveType) => objectiveType switch
    {
        QuestObjectiveType.CraftAnyTool => _player.Inventory.Slots
            .Any(slot => ItemCatalog.Find(slot.ItemId)?.Category == ItemCategory.Tool),
        QuestObjectiveType.ConstructBuilding => _kingdom.Buildings
            .Any(building => building.Type != Core.Kingdom.BuildingType.TownHall),
        QuestObjectiveType.RecruitNpc => _kingdom.Npcs.Count > 0,
        _ => false
    };

    private QuestDto Map(QuestDefinition quest) => new()
    {
        Id = quest.Id,
        Title = quest.Title,
        Description = quest.Description,
        IsCompleted = _player.QuestLog.IsCompleted(quest.Id)
    };
}
