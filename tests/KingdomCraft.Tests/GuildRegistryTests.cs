using KingdomCraft.Core.Guilds;
using Xunit;

namespace KingdomCraft.Tests;

public class GuildRegistryTests
{
    [Fact]
    public void Create_AddsFounderAsMember()
    {
        var registry = new GuildRegistry();

        var guild = registry.Create("Liên minh Rồng", "kingdom-a");

        Assert.Single(guild.MemberKingdomIds);
        Assert.Contains("kingdom-a", guild.MemberKingdomIds);
    }

    [Fact]
    public void Join_NewKingdom_AddsToMembers()
    {
        var registry = new GuildRegistry();
        var guild = registry.Create("Liên minh Rồng", "kingdom-a");

        var success = registry.Join(guild.Id, "kingdom-b");

        Assert.True(success);
        Assert.Equal(2, guild.MemberKingdomIds.Count);
    }

    [Fact]
    public void Join_KingdomAlreadyInAnotherGuild_Fails()
    {
        var registry = new GuildRegistry();
        var guildA = registry.Create("Liên minh Rồng", "kingdom-a");
        var guildB = registry.Create("Liên minh Hổ", "kingdom-b");

        var success = registry.Join(guildB.Id, "kingdom-a");

        Assert.False(success);
        Assert.DoesNotContain("kingdom-a", guildB.MemberKingdomIds);
    }

    [Fact]
    public void Join_UnknownGuildId_Fails()
    {
        var registry = new GuildRegistry();

        Assert.False(registry.Join("khong-ton-tai", "kingdom-a"));
    }

    [Fact]
    public void Leave_ExistingMember_RemovesFromGuild()
    {
        var registry = new GuildRegistry();
        var guild = registry.Create("Liên minh Rồng", "kingdom-a");

        var success = registry.Leave(guild.Id, "kingdom-a");

        Assert.True(success);
        Assert.Empty(guild.MemberKingdomIds);
    }

    [Fact]
    public void Leave_ThenJoinAnotherGuild_Succeeds()
    {
        var registry = new GuildRegistry();
        var guildA = registry.Create("Liên minh Rồng", "kingdom-a");
        var guildB = registry.Create("Liên minh Hổ", "kingdom-b");

        registry.Leave(guildA.Id, "kingdom-a");
        var success = registry.Join(guildB.Id, "kingdom-a");

        Assert.True(success);
        Assert.Contains("kingdom-a", guildB.MemberKingdomIds);
    }
}
