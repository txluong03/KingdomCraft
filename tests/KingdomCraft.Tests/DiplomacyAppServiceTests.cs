using KingdomCraft.Application.Diplomacy;
using KingdomCraft.Application.Guilds;
using KingdomCraft.Core.Diplomacy;
using KingdomCraft.Core.Entities;
using KingdomCraft.Core.Guilds;
using KingdomCraft.Core.Kingdom;
using Xunit;

namespace KingdomCraft.Tests;

public class DiplomacyAppServiceTests
{
    private static (DiplomacyAppService Diplomacy, GuildAppService Guild, KingdomRegistry Kingdoms) CreateServices()
    {
        var kingdomRegistry = new KingdomRegistry();
        var guildRegistry = new GuildRegistry();
        return (
            new DiplomacyAppService(new DiplomacyRegistry(), kingdomRegistry, guildRegistry),
            new GuildAppService(guildRegistry, kingdomRegistry),
            kingdomRegistry);
    }

    [Fact]
    public void DeclareWar_ThenRaid_StrongerAttackerSucceeds()
    {
        var (diplomacy, _, kingdoms) = CreateServices();
        var attacker = kingdoms.Create("A");
        var defender = kingdoms.Create("B");
        attacker.Npcs.Add(new Npc { Role = NpcRole.Soldier, SkillLevel = 10 });
        defender.Resources.Add("gold", 100);

        var declareResult = diplomacy.DeclareWar(attacker.Id, new DeclareWarInput { TargetKingdomId = defender.Id });
        Assert.True(declareResult.Success);

        var raidResult = diplomacy.Raid(attacker.Id, new RaidInput { TargetKingdomId = defender.Id });

        Assert.True(raidResult.Success);
        Assert.Equal(20, raidResult.AttackerResources.GetValueOrDefault("gold"));
    }

    [Fact]
    public void Raid_WithoutDeclaringWarFirst_Fails()
    {
        var (diplomacy, _, kingdoms) = CreateServices();
        var attacker = kingdoms.Create("A");
        var defender = kingdoms.Create("B");

        var result = diplomacy.Raid(attacker.Id, new RaidInput { TargetKingdomId = defender.Id });

        Assert.False(result.Success);
    }

    [Fact]
    public void DeclareWar_OnGuildMate_Fails()
    {
        var (diplomacy, guild, kingdoms) = CreateServices();
        var kingdomA = kingdoms.Create("A");
        var kingdomB = kingdoms.Create("B");
        var createdGuild = guild.CreateGuild(kingdomA.Id, new CreateGuildInput { Name = "Liên minh" });
        guild.Join(kingdomB.Id, new JoinGuildInput { GuildId = createdGuild.Id });

        var result = diplomacy.DeclareWar(kingdomA.Id, new DeclareWarInput { TargetKingdomId = kingdomB.Id });

        Assert.False(result.Success);
    }
}
