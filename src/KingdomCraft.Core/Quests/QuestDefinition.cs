namespace KingdomCraft.Core.Quests;

/// <summary>Định nghĩa tĩnh cho 1 quest — xem Docs/03_Gameplay/QuestFlow.md.</summary>
public class QuestDefinition
{
    public string Id { get; }
    public string Title { get; }
    public string Description { get; }
    public QuestObjectiveType ObjectiveType { get; }

    public QuestDefinition(string id, string title, string description, QuestObjectiveType objectiveType)
    {
        Id = id;
        Title = title;
        Description = description;
        ObjectiveType = objectiveType;
    }
}
