using KingdomCraft.Client.Rendering;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Xunit;

namespace KingdomCraft.Tests;

public class FlyCameraTests
{
    [Fact]
    public void HorizontalForward_IgnoresPitch()
    {
        var camera = new FlyCamera(Vector3.Zero, yaw: 0f, pitch: 0.7f);

        Assert.Equal(0f, camera.HorizontalForward.Y);
    }

    [Fact]
    public void Update_PressingW_MovesOnGroundPlaneOnly()
    {
        var camera = new FlyCamera(new Vector3(0, 5, 0), yaw: 0f, pitch: 0.5f);
        var gameTime = new GameTime(TimeSpan.Zero, TimeSpan.FromSeconds(1));

        camera.Update(gameTime, new KeyboardState(Keys.W));

        Assert.Equal(5f, camera.Position.Y); // pitch không còn ảnh hưởng độ cao khi đi bộ
        Assert.True(camera.Position.Z < 0f); // yaw=0 → tiến về hướng -Z
        Assert.Equal(0f, camera.Position.X, precision: 3);
    }

    [Fact]
    public void Update_NoKeysPressed_StaysInPlace()
    {
        var camera = new FlyCamera(new Vector3(1, 2, 3));
        var gameTime = new GameTime(TimeSpan.Zero, TimeSpan.FromSeconds(1));

        camera.Update(gameTime, new KeyboardState());

        Assert.Equal(new Vector3(1, 2, 3), camera.Position);
    }

    [Fact]
    public void Update_ArrowKeys_RotateYawAndPitch()
    {
        var camera = new FlyCamera(Vector3.Zero);
        var gameTime = new GameTime(TimeSpan.Zero, TimeSpan.FromSeconds(1));

        camera.Update(gameTime, new KeyboardState(Keys.Right, Keys.Up));

        Assert.True(camera.Yaw > 0f);
        Assert.True(camera.Pitch > 0f);
    }
}
