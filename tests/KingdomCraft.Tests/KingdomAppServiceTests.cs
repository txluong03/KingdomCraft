using KingdomCraft.Application.Kingdom;
using KingdomCraft.Core.Entities;
using KingdomCraft.Core.Kingdom;
using Xunit;

namespace KingdomCraft.Tests;

public class KingdomAppServiceTests
{
    [Fact]
    public void CreateBuilding_AddsBuildingAndReturnsDto()
    {
        var appService = new KingdomAppService(new KingdomState());

        var result = appService.CreateBuilding(new CreateBuildingInput { Type = BuildingType.Farm, Level = 2 });

        Assert.Equal(BuildingType.Farm, result.Type);
        Assert.Equal(2, result.Level);
        Assert.Single(appService.GetKingdomState().Buildings);
    }

    [Fact]
    public void RecruitNpc_AddsNpcAndReturnsDto()
    {
        var appService = new KingdomAppService(new KingdomState());

        var result = appService.RecruitNpc(new RecruitNpcInput { Name = "Farmer A", Role = NpcRole.Farmer, SkillLevel = 3 });

        Assert.Equal("Farmer A", result.Name);
        Assert.Equal(NpcRole.Farmer, result.Role);
        Assert.Single(appService.GetKingdomState().Npcs);
    }

    [Fact]
    public void AssignNpcRole_UpdatesExistingNpc()
    {
        var appService = new KingdomAppService(new KingdomState());
        var npc = appService.RecruitNpc(new RecruitNpcInput { Role = NpcRole.Idle });

        var updated = appService.AssignNpcRole(new AssignNpcRoleInput { NpcId = npc.Id, Role = NpcRole.Steward });

        Assert.Equal(NpcRole.Steward, updated.Role);
    }

    [Fact]
    public void AssignNpcRole_UnknownNpcId_Throws()
    {
        var appService = new KingdomAppService(new KingdomState());

        Assert.Throws<InvalidOperationException>(() =>
            appService.AssignNpcRole(new AssignNpcRoleInput { NpcId = "khong-ton-tai", Role = NpcRole.Farmer }));
    }

    [Fact]
    public void TrainNpc_IncreasesSkillLevel()
    {
        var appService = new KingdomAppService(new KingdomState());
        var npc = appService.RecruitNpc(new RecruitNpcInput { Role = NpcRole.Farmer, SkillLevel = 2 });

        var trained = appService.TrainNpc(new TrainNpcInput { NpcId = npc.Id, SkillIncrease = 3 });

        Assert.Equal(5, trained.SkillLevel);
    }

    [Fact]
    public void TrainNpc_UnknownNpcId_Throws()
    {
        var appService = new KingdomAppService(new KingdomState());

        Assert.Throws<InvalidOperationException>(() =>
            appService.TrainNpc(new TrainNpcInput { NpcId = "khong-ton-tai" }));
    }

    [Fact]
    public void Tick_RecruitedFarmerProducesFood_ReflectedInDto()
    {
        var appService = new KingdomAppService(new KingdomState());
        appService.RecruitNpc(new RecruitNpcInput { Role = NpcRole.Farmer, SkillLevel = 5 });

        var state = appService.Tick();

        Assert.Equal(5, state.Resources.GetValueOrDefault("food"));
        Assert.True(state.AutomationLevel > 0);
    }
}
