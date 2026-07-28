using KingdomCraft.Application.Crafting;
using KingdomCraft.Application.Kingdom;
using KingdomCraft.Application.Quests;
using KingdomCraft.Core.Entities;
using KingdomCraft.Core.Kingdom;
using Xunit;

namespace KingdomCraft.Tests;

public class QuestAppServiceTests
{
    [Fact]
    public void GetQuestLog_InitiallyReturnsAllThreeQuestsIncomplete()
    {
        var appService = new QuestAppService(new Player(), new KingdomState());

        var quests = appService.GetQuestLog();

        Assert.Equal(3, quests.Count);
        Assert.All(quests, q => Assert.False(q.IsCompleted));
    }

    [Fact]
    public void EvaluateQuests_AfterCraftingTool_CompletesFirstToolQuest()
    {
        var player = new Player();
        var kingdom = new KingdomState();
        player.Inventory.TryAdd("plank", 3);
        new CraftingAppService(player, kingdom).Craft(new CraftInput { RecipeId = "craft_wooden_axe", HasStationAccess = true });

        var appService = new QuestAppService(player, kingdom);
        var newlyCompleted = appService.EvaluateQuests();

        Assert.Contains(newlyCompleted, q => q.Id == "quest_first_tool");
    }

    [Fact]
    public void EvaluateQuests_AfterRecruitingNpcAndBuilding_CompletesBothQuests()
    {
        var player = new Player();
        var kingdom = new KingdomState();
        var kingdomAppService = new KingdomAppService(kingdom);
        kingdomAppService.RecruitNpc(new RecruitNpcInput { Role = NpcRole.Farmer });
        kingdomAppService.CreateBuilding(new CreateBuildingInput { Type = BuildingType.Farm });

        var questAppService = new QuestAppService(player, kingdom);
        var newlyCompleted = questAppService.EvaluateQuests();

        Assert.Contains(newlyCompleted, q => q.Id == "quest_first_npc");
        Assert.Contains(newlyCompleted, q => q.Id == "quest_first_building");
    }

    [Fact]
    public void EvaluateQuests_CalledTwice_DoesNotReturnAlreadyCompletedQuestAgain()
    {
        var player = new Player();
        var kingdom = new KingdomState();
        new KingdomAppService(kingdom).RecruitNpc(new RecruitNpcInput { Role = NpcRole.Farmer });
        var appService = new QuestAppService(player, kingdom);

        var firstCall = appService.EvaluateQuests();
        var secondCall = appService.EvaluateQuests();

        Assert.Contains(firstCall, q => q.Id == "quest_first_npc");
        Assert.DoesNotContain(secondCall, q => q.Id == "quest_first_npc");
    }
}
