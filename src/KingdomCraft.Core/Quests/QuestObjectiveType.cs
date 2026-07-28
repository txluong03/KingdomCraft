namespace KingdomCraft.Core.Quests;

public enum QuestObjectiveType
{
    /// <summary>Có ít nhất 1 item thuộc <see cref="Items.ItemCategory.Tool"/> trong Inventory.</summary>
    CraftAnyTool,

    /// <summary>Vương quốc có ít nhất 1 công trình khác TownHall.</summary>
    ConstructBuilding,

    /// <summary>Vương quốc có ít nhất 1 NPC.</summary>
    RecruitNpc
}
