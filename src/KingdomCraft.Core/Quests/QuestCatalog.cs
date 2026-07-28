namespace KingdomCraft.Core.Quests;

/// <summary>3 quest khởi đầu — xem Docs/03_Gameplay/QuestFlow.md.</summary>
public static class QuestCatalog
{
    public static readonly IReadOnlyList<QuestDefinition> All = new List<QuestDefinition>
    {
        new("quest_first_tool", "Chế tạo công cụ đầu tiên",
            "Chế tạo bất kỳ công cụ nào để bước vào giai đoạn Thợ thủ công.",
            QuestObjectiveType.CraftAnyTool),

        new("quest_first_building", "Xây công trình sản xuất đầu tiên",
            "Xây một công trình sản xuất để bước vào giai đoạn Chủ trang trại.",
            QuestObjectiveType.ConstructBuilding),

        new("quest_first_npc", "Tuyển NPC đầu tiên",
            "Tuyển một NPC để bắt đầu chuyển giao công việc, bước vào giai đoạn Trưởng làng.",
            QuestObjectiveType.RecruitNpc)
    };

    public static QuestDefinition? Find(string questId) =>
        All.FirstOrDefault(quest => quest.Id == questId);
}
