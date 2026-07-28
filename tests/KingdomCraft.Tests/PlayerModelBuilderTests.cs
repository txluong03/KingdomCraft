using KingdomCraft.Client.Rendering;
using Xunit;

namespace KingdomCraft.Tests;

public class PlayerModelBuilderTests
{
    [Fact]
    public void BuildVertices_ReturnsCompleteTriangles()
    {
        var vertices = PlayerModelBuilder.BuildVertices();

        Assert.NotEmpty(vertices);
        Assert.Equal(0, vertices.Length % 3);
    }
}
