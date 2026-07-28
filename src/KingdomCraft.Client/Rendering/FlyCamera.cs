using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace KingdomCraft.Client.Rendering;

/// <summary>
/// Camera kiểu "đi bộ": WASD di chuyển NGANG (không tự bay lên/xuống — trọng
/// lực/nhảy do Game1 quản lý riêng, xem ApplyGravityAndJump), phím mũi tên
/// xoay góc nhìn. Cố tình không dùng mouse-look để tránh rủi ro lỗi khóa/ẩn
/// con trỏ chuột không thể kiểm tra trực quan trong môi trường này.
/// </summary>
public class FlyCamera
{
    private const float MoveSpeed = 6f;
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

    /// <summary>Hướng nhìn đầy đủ (gồm cả pitch) — dùng để ngắm/raycast khi đào khối.</summary>
    public Vector3 Forward => new(
        MathF.Cos(Pitch) * MathF.Sin(Yaw),
        MathF.Sin(Pitch),
        -MathF.Cos(Pitch) * MathF.Cos(Yaw));

    /// <summary>Hướng đi bộ (Y luôn = 0) — nhìn lên/xuống không làm nhân vật bay lên/chúi xuống.</summary>
    public Vector3 HorizontalForward => new(MathF.Sin(Yaw), 0f, -MathF.Cos(Yaw));

    public void Update(GameTime gameTime, KeyboardState keyboard)
    {
        var dt = (float)gameTime.ElapsedGameTime.TotalSeconds;

        if (keyboard.IsKeyDown(Keys.Left)) Yaw -= LookSpeed * dt;
        if (keyboard.IsKeyDown(Keys.Right)) Yaw += LookSpeed * dt;
        if (keyboard.IsKeyDown(Keys.Up)) Pitch += LookSpeed * dt;
        if (keyboard.IsKeyDown(Keys.Down)) Pitch -= LookSpeed * dt;
        Pitch = MathHelper.Clamp(Pitch, -MaxPitch, MaxPitch);

        var forward = HorizontalForward;
        var right = Vector3.Normalize(Vector3.Cross(forward, Vector3.Up));

        var move = Vector3.Zero;
        if (keyboard.IsKeyDown(Keys.W)) move += forward;
        if (keyboard.IsKeyDown(Keys.S)) move -= forward;
        if (keyboard.IsKeyDown(Keys.D)) move += right;
        if (keyboard.IsKeyDown(Keys.A)) move -= right;

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
