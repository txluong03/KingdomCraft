using KingdomCraft.Application.Kingdom;
using KingdomCraft.Application.Persistence;
using KingdomCraft.Core.Entities;
using KingdomCraft.Core.Kingdom;
using Xunit;

namespace KingdomCraft.Tests;

public class SaveGameAppServiceTests : IDisposable
{
    private readonly string _filePath = Path.Combine(Path.GetTempPath(), $"kingdomcraft-test-{Guid.NewGuid()}.json");

    public void Dispose()
    {
        if (File.Exists(_filePath))
        {
            File.Delete(_filePath);
        }
    }

    [Fact]
    public void Save_ThenLoadIntoFreshRegistry_RestoresFullKingdomState()
    {
        var originalRegistry = new KingdomRegistry();
        var kingdom = originalRegistry.Create("Vương quốc Rồng");
        kingdom.Buildings.Add(new Building { Type = BuildingType.Farm, Level = 3 });
        kingdom.Npcs.Add(new Npc { Name = "Nông dân A", Role = NpcRole.Farmer, SkillLevel = 5 });
        kingdom.Resources.Add("gold", 50);
        kingdom.ResearchedTechnologyIds.Add("stone_working");

        new SaveGameAppService(originalRegistry).Save(new SaveGameInput { FilePath = _filePath });

        var restoredRegistry = new KingdomRegistry();
        var loadResult = new SaveGameAppService(restoredRegistry).Load(new LoadGameInput { FilePath = _filePath });

        Assert.True(loadResult.Success);
        Assert.Equal(1, loadResult.KingdomCount);

        var restoredKingdom = restoredRegistry.Find(kingdom.Id);
        Assert.NotNull(restoredKingdom);
        Assert.Equal("Vương quốc Rồng", restoredKingdom!.Name);
        Assert.Single(restoredKingdom.Buildings);
        Assert.Equal(BuildingType.Farm, restoredKingdom.Buildings[0].Type);
        Assert.Equal(3, restoredKingdom.Buildings[0].Level);
        Assert.Single(restoredKingdom.Npcs);
        Assert.Equal(NpcRole.Farmer, restoredKingdom.Npcs[0].Role);
        Assert.Equal(50, restoredKingdom.Resources.Get("gold"));
        Assert.Contains("stone_working", restoredKingdom.ResearchedTechnologyIds);
    }

    [Fact]
    public void Load_FileDoesNotExist_ReturnsFailure()
    {
        var appService = new SaveGameAppService(new KingdomRegistry());

        var result = appService.Load(new LoadGameInput { FilePath = Path.Combine(Path.GetTempPath(), "khong-ton-tai.json") });

        Assert.False(result.Success);
        Assert.Equal(0, result.KingdomCount);
    }

    [Fact]
    public void Load_OverwritesExistingKingdomWithSameId()
    {
        var registry = new KingdomRegistry();
        var kingdom = registry.Create("Bản gốc");
        new SaveGameAppService(registry).Save(new SaveGameInput { FilePath = _filePath });

        kingdom.Name = "Đã đổi tên sau khi lưu";
        new SaveGameAppService(registry).Load(new LoadGameInput { FilePath = _filePath });

        Assert.Equal("Bản gốc", registry.Find(kingdom.Id)!.Name);
    }
}
