using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace KingdomCraft.Client.Rendering;

/// <summary>
/// Camera bay tự do điều khiển bằng bàn phím (WASD di chuyển, phím mũi tên
/// xoay góc nhìn). Cố tình không dùng mouse-look để tránh rủi ro lỗi khóa/ẩn
/// con trỏ chuột không thể kiểm tra trực quan trong môi trường này.
/// </summary>
public class FlyCamera
{
    private const float MoveSpeed = 8f;
    private const float LookSpeed = 1.8f;
    private static readonly float MaxPitch = MathHelper.PiOver2 - 0.05f;

    public Vector3 Position { get; set; }
    public float Yaw { get; set; }
    public float Pitch { get; set; }

    public FlyCamera(Vector3 startPosition, float yaw = 0f, float pitch = 0f)
    {
        Position = startPosition;
        Yaw = yaw;
        Pitch = pitch;
    }

    public Vector3 Forward => new(
        MathF.Cos(Pitch) * MathF.Sin(Yaw),
        MathF.Sin(Pitch),
        -MathF.Cos(Pitch) * MathF.Cos(Yaw));

    public void Update(GameTime gameTime, KeyboardState keyboard)
    {
        var dt = (float)gameTime.ElapsedGameTime.TotalSeconds;

        if (keyboard.IsKeyDown(Keys.Left)) Yaw -= LookSpeed * dt;
        if (keyboard.IsKeyDown(Keys.Right)) Yaw += LookSpeed * dt;
        if (keyboard.IsKeyDown(Keys.Up)) Pitch += LookSpeed * dt;
        if (keyboard.IsKeyDown(Keys.Down)) Pitch -= LookSpeed * dt;
        Pitch = MathHelper.Clamp(Pitch, -MaxPitch, MaxPitch);

        var forward = Forward;
        var right = Vector3.Normalize(Vector3.Cross(forward, Vector3.Up));

        var move = Vector3.Zero;
        if (keyboard.IsKeyDown(Keys.W)) move += forward;
        if (keyboard.IsKeyDown(Keys.S)) move -= forward;
        if (keyboard.IsKeyDown(Keys.D)) move += right;
        if (keyboard.IsKeyDown(Keys.A)) move -= right;
        if (keyboard.IsKeyDown(Keys.Space)) move += Vector3.Up;
        if (keyboard.IsKeyDown(Keys.LeftShift)) move -= Vector3.Up;

        if (move != Vector3.Zero)
        {
            move.Normalize();
            Position += move * MoveSpeed * dt;
        }
    }

    public Matrix GetViewMatrix() => Matrix.CreateLookAt(Position, Position + Forward, Vector3.Up);

    public Matrix GetProjectionMatrix(float aspectRatio) =>
        Matrix.CreatePerspectiveFieldOfView(MathHelper.PiOver4, aspectRatio, 0.1f, 500f);
}
