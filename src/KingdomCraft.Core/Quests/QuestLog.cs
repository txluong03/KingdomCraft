namespace KingdomCraft.Core.Quests;

/// <summary>Theo dõi quest đã hoàn thành của 1 người chơi.</summary>
public class QuestLog
{
    public HashSet<string> CompletedQuestIds { get; } = new();

    public bool IsCompleted(string questId) => CompletedQuestIds.Contains(questId);

    public bool Complete(string questId) => CompletedQuestIds.Add(questId);
}
