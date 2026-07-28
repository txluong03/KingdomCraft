using KingdomCraft.Application.Guilds;
using KingdomCraft.Core.Guilds;
using KingdomCraft.Core.Kingdom;
using Xunit;

namespace KingdomCraft.Tests;

public class GuildAppServiceTests
{
    private static (GuildAppService Service, KingdomRegistry KingdomRegistry) CreateService()
    {
        var kingdomRegistry = new KingdomRegistry();
        return (new GuildAppService(new GuildRegistry(), kingdomRegistry), kingdomRegistry);
    }

    [Fact]
    public void CreateGuild_UnknownFounderKingdom_Throws()
    {
        var (service, _) = CreateService();

        Assert.Throws<InvalidOperationException>(() =>
            service.CreateGuild("khong-ton-tai", new CreateGuildInput { Name = "Liên minh Rồng" }));
    }

    [Fact]
    public void CreateGuild_ValidFounder_ReturnsGuildWithFounderAsMember()
    {
        var (service, kingdomRegistry) = CreateService();
        var founder = kingdomRegistry.Create("Vương quốc A");

        var guild = service.CreateGuild(founder.Id, new CreateGuildInput { Name = "Liên minh Rồng" });

        Assert.Single(guild.MemberKingdomIds);
        Assert.Contains(founder.Id, guild.MemberKingdomIds);
    }

    [Fact]
    public void Join_ValidKingdomAndGuild_Succeeds()
    {
        var (service, kingdomRegistry) = CreateService();
        var founder = kingdomRegistry.Create("Vương quốc A");
        var member = kingdomRegistry.Create("Vương quốc B");
        var guild = service.CreateGuild(founder.Id, new CreateGuildInput { Name = "Liên minh Rồng" });

        var result = service.Join(member.Id, new JoinGuildInput { GuildId = guild.Id });

        Assert.True(result.Success);
    }

    [Fact]
    public void GetGuild_UnknownGuildId_Throws()
    {
        var (service, _) = CreateService();

        Assert.Throws<InvalidOperationException>(() =>
            service.GetGuild(new GetGuildInput { GuildId = "khong-ton-tai" }));
    }
}
