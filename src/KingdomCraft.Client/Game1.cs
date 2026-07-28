using KingdomCraft.Client.Networking;
using KingdomCraft.Client.Rendering;
using KingdomCraft.Client.World;
using KingdomCraft.Core.World;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace KingdomCraft.Client;

/// <summary>
/// Client — render 1 chunk voxel demo (địa hình phẳng có vài cây/đá để khai
/// thác, chưa phải world gen thật), nhân vật đi bộ có trọng lực/nhảy (kiểu
/// Minecraft), 2 góc nhìn (thứ 1/thứ 3, phím V), HUD trên màn hình (thanh
/// item, trạng thái, thông báo — không cần xem console nữa), và nối TCP thật
/// tới KingdomCraft.Server để chơi thử gameplay (Kingdom, Crafting, Quest,
/// Boss) bằng phím tắt.
///
/// Điều khiển di chuyển/render:
///  - W/A/S/D: đi bộ theo mặt đất (nhìn lên/xuống không làm bay lên/chúi xuống)
///  - Space: nhảy (chỉ khi đang đứng trên mặt đất) · trọng lực tự kéo xuống
///  - Phím mũi tên: xoay góc nhìn (không dùng mouse-look)
///  - V: đổi góc nhìn thứ 1 ↔ thứ 3 (giống phím F5 trong Minecraft — dùng V
///    vì F5 đã được dùng cho "Tick thủ công" ở đây)
///  - Chuột trái: đào khối (Stone/Wood rơi vào túi đồ qua Server) · Chuột phải: đặt khối Dirt
///  - Esc: thoát
///
/// Điều khiển gameplay (qua Server, kết quả hiện ở HUD dưới màn hình VÀ console):
///  - F1 Trạng thái · F2 Craft Plank · F3 Craft Rìu gỗ · F4 Tuyển Farmer
///  - F5 Tick thủ công · F6 Chấm Quest · F7 Triệu hồi Boss · F8 Đánh Boss
///
/// **Cần chạy `dotnet run --project src/KingdomCraft.Server` TRƯỚC** khi mở
/// Client — nếu không, phần render/di chuyển vẫn chạy bình thường nhưng phím
/// gameplay và đào khối sẽ báo lỗi kết nối (hiện ở HUD).
///
/// Môi trường phát triển hiện tại không có màn hình để kiểm tra trực quan —
/// hãy tự chạy Client và phản hồi lại nếu hình ảnh/HUD/góc nhìn thứ 3/đi lại
/// có gì bất thường (đây là phần rủi ro nhất vì chưa được xác nhận bằng mắt).
/// </summary>
public class Game1 : Game
{
    private const float RaycastDistance = 8f;
    private const string ServerHost = "127.0.0.1";
    private const int ServerPort = 5000;

    private const float EyeHeight = 1.6f;
    private const float Gravity = 20f;
    private const float JumpSpeed = 8f;
    private const float ThirdPersonDistance = 4f;
    private const float ThirdPersonHeight = 1.2f;

    private readonly GraphicsDeviceManager _graphics;
    private readonly Chunk _chunk;
    private readonly FlyCamera _camera;
    private readonly GameSession _gameSession = new();

    private BasicEffect? _effect;
    private VertexBuffer? _vertexBuffer;
    private int _vertexCount;
    private VertexBuffer? _playerModelVertexBuffer;
    private int _playerModelVertexCount;

    private SpriteBatch? _spriteBatch;
    private SpriteFont? _font;
    private Texture2D? _pixel;

    private MouseState _previousMouse;
    private KeyboardState _previousKeyboard;
    private float _verticalVelocity;
    private bool _isThirdPerson;

    public Game1()
    {
        _graphics = new GraphicsDeviceManager(this)
        {
            PreferredBackBufferWidth = 1280,
            PreferredBackBufferHeight = 720
        };
        Content.RootDirectory = "Content";
        IsMouseVisible = true;

        _chunk = DemoWorldGenerator.CreateFlatTerrain();
        // Đứng giữa nền demo (Grass ở y=7 → đứng ở y=8+EyeHeight), nhìn thẳng.
        _camera = new FlyCamera(new Vector3(8, 8 + EyeHeight, 8), yaw: 0f, pitch: 0f);
    }

    protected override void Initialize()
    {
        base.Initialize();
        GraphicsDevice.RasterizerState = new RasterizerState { CullMode = CullMode.None };
    }

    protected override void LoadContent()
    {
        _effect = new BasicEffect(GraphicsDevice) { VertexColorEnabled = true };
        RebuildMesh();

        var playerModelVertices = PlayerModelBuilder.BuildVertices();
        _playerModelVertexCount = playerModelVertices.Length;
        _playerModelVertexBuffer = new VertexBuffer(GraphicsDevice, typeof(VertexPositionColor), _playerModelVertexCount, BufferUsage.WriteOnly);
        _playerModelVertexBuffer.SetData(playerModelVertices);

        _spriteBatch = new SpriteBatch(GraphicsDevice);
        _font = Content.Load<SpriteFont>("DefaultFont");
        _pixel = new Texture2D(GraphicsDevice, 1, 1);
        _pixel.SetData(new[] { Color.White });

        Console.WriteLine("KingdomCraft.Client đã khởi động. Đang kết nối Server...");
        _gameSession.Connect(ServerHost, ServerPort);
    }

    private void RebuildMesh()
    {
        var vertices = ChunkMeshBuilder.BuildVertices(_chunk);
        _vertexCount = vertices.Length;

        _vertexBuffer?.Dispose();
        _vertexBuffer = null;

        if (_vertexCount == 0) return;

        _vertexBuffer = new VertexBuffer(GraphicsDevice, typeof(VertexPositionColor), _vertexCount, BufferUsage.WriteOnly);
        _vertexBuffer.SetData(vertices);
    }

    protected override void Update(GameTime gameTime)
    {
        var keyboard = Keyboard.GetState();
        if (keyboard.IsKeyDown(Keys.Escape)) Exit();
        if (WasPressed(keyboard, Keys.V)) _isThirdPerson = !_isThirdPerson;

        _camera.Update(gameTime, keyboard);
        ApplyGravityAndJump(gameTime, keyboard);
        HandleBlockInteraction();
        HandleGameplayShortcuts(keyboard);
        _previousKeyboard = keyboard;

        base.Update(gameTime);
    }

    /// <summary>
    /// Trọng lực + nhảy + va chạm mặt đất tối giản: mỗi cột (X,Z) có 1 độ cao
    /// mặt đất (khối rắn cao nhất) — đủ dùng cho địa hình demo hiện tại,
    /// CHƯA phải collision 3D đầy đủ (đi vào chân cây/đá sẽ "trèo" lên luôn
    /// thay vì bị chặn ngang, vì chỉ xét độ cao theo cột chứ không xét 2 bên).
    /// </summary>
    private void ApplyGravityAndJump(GameTime gameTime, KeyboardState keyboard)
    {
        var dt = (float)gameTime.ElapsedGameTime.TotalSeconds;
        var position = _camera.Position;

        var standingY = GetGroundHeight(position.X, position.Z) + EyeHeight;
        var isGrounded = position.Y <= standingY + 0.001f;

        if (isGrounded)
        {
            _verticalVelocity = 0f;
            position.Y = standingY;

            if (WasPressed(keyboard, Keys.Space))
            {
                _verticalVelocity = JumpSpeed;
            }
        }

        _verticalVelocity -= Gravity * dt;
        position.Y += _verticalVelocity * dt;

        var newStandingY = GetGroundHeight(position.X, position.Z) + EyeHeight;
        if (position.Y < newStandingY)
        {
            position.Y = newStandingY;
            _verticalVelocity = 0f;
        }

        _camera.Position = position;
    }

    /// <summary>Độ cao (Y) của mặt khối rắn cao nhất tại cột (X,Z) — 0 nếu ngoài chunk demo hoặc không có gì.</summary>
    private float GetGroundHeight(float worldX, float worldZ)
    {
        var blockX = (int)MathF.Floor(worldX);
        var blockZ = (int)MathF.Floor(worldZ);

        if (blockX < 0 || blockX >= Chunk.Size || blockZ < 0 || blockZ >= Chunk.Size)
            return 0f;

        for (var y = Chunk.Height - 1; y >= 0; y--)
        {
            if (_chunk.GetBlock(blockX, y, blockZ) != BlockType.Air)
            {
                return y + 1;
            }
        }

        return 0f;
    }

    private void HandleGameplayShortcuts(KeyboardState keyboard)
    {
        if (WasPressed(keyboard, Keys.F1)) _gameSession.PrintStatus();
        if (WasPressed(keyboard, Keys.F2)) _gameSession.CraftPlank();
        if (WasPressed(keyboard, Keys.F3)) _gameSession.CraftWoodenAxe();
        if (WasPressed(keyboard, Keys.F4)) _gameSession.RecruitFarmer();
        if (WasPressed(keyboard, Keys.F5)) _gameSession.TickManually();
        if (WasPressed(keyboard, Keys.F6)) _gameSession.EvaluateQuests();
        if (WasPressed(keyboard, Keys.F7)) _gameSession.SpawnBoss();
        if (WasPressed(keyboard, Keys.F8)) _gameSession.AttackBoss();
    }

    private bool WasPressed(KeyboardState keyboard, Keys key) =>
        keyboard.IsKeyDown(key) && _previousKeyboard.IsKeyUp(key);

    private void HandleBlockInteraction()
    {
        var mouse = Mouse.GetState();
        var leftClicked = mouse.LeftButton == ButtonState.Pressed && _previousMouse.LeftButton == ButtonState.Released;
        var rightClicked = mouse.RightButton == ButtonState.Pressed && _previousMouse.RightButton == ButtonState.Released;
        _previousMouse = mouse;

        if (!leftClicked && !rightClicked) return;

        var hit = VoxelRaycaster.Cast(_chunk, _camera.Position, _camera.Forward, RaycastDistance);
        if (hit is null) return;

        var (block, placement) = hit.Value;

        if (leftClicked)
        {
            var brokenType = _chunk.GetBlock(block.X, block.Y, block.Z);
            _chunk.SetBlock(block.X, block.Y, block.Z, BlockType.Air);
            RebuildMesh();

            var drop = BlockDrops.GetDrop(brokenType);
            if (drop is not null)
            {
                _gameSession.GatherItem(drop.Value.ItemId, drop.Value.Quantity);
            }
        }
        else if (IsInsideChunk(placement))
        {
            _chunk.SetBlock(placement.X, placement.Y, placement.Z, BlockType.Dirt);
            RebuildMesh();
        }
    }

    private static bool IsInsideChunk((int X, int Y, int Z) cell) =>
        cell.X >= 0 && cell.X < Chunk.Size && cell.Y >= 0 && cell.Y < Chunk.Height && cell.Z >= 0 && cell.Z < Chunk.Size;

    /// <summary>Vị trí "mắt máy quay" thật sự dùng để dựng hình — trùng _camera.Position ở góc nhìn thứ 1, lùi ra sau ở góc nhìn thứ 3.</summary>
    private Vector3 GetRenderEyePosition() =>
        _isThirdPerson
            ? _camera.Position - _camera.Forward * ThirdPersonDistance + Vector3.Up * ThirdPersonHeight
            : _camera.Position;

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(new Color(135, 206, 235));

        if (_effect is not null)
        {
            var renderEye = GetRenderEyePosition();
            _effect.View = _isThirdPerson
                ? Matrix.CreateLookAt(renderEye, _camera.Position, Vector3.Up)
                : Matrix.CreateLookAt(renderEye, renderEye + _camera.Forward, Vector3.Up);
            _effect.Projection = _camera.GetProjectionMatrix(GraphicsDevice.Viewport.AspectRatio);

            if (_vertexBuffer is not null && _vertexCount > 0)
            {
                _effect.World = Matrix.Identity;
                GraphicsDevice.SetVertexBuffer(_vertexBuffer);
                foreach (var pass in _effect.CurrentTechnique.Passes)
                {
                    pass.Apply();
                    GraphicsDevice.DrawPrimitives(PrimitiveType.TriangleList, 0, _vertexCount / 3);
                }
            }

            if (_isThirdPerson && _playerModelVertexBuffer is not null)
            {
                var feetPosition = _camera.Position - new Vector3(0, EyeHeight, 0);
                _effect.World = Matrix.CreateRotationY(_camera.Yaw) * Matrix.CreateTranslation(feetPosition);
                GraphicsDevice.SetVertexBuffer(_playerModelVertexBuffer);
                foreach (var pass in _effect.CurrentTechnique.Passes)
                {
                    pass.Apply();
                    GraphicsDevice.DrawPrimitives(PrimitiveType.TriangleList, 0, _playerModelVertexCount / 3);
                }
            }
        }

        DrawHud();

        base.Draw(gameTime);
    }

    private void DrawHud()
    {
        if (_spriteBatch is null || _font is null || _pixel is null) return;

        var viewport = GraphicsDevice.Viewport;
        _spriteBatch.Begin();

        DrawCrosshair(viewport);
        DrawTopLeftStatus();
        DrawBottomBar(viewport);

        _spriteBatch.End();
    }

    private void DrawCrosshair(Viewport viewport)
    {
        var center = new Vector2(viewport.Width / 2f, viewport.Height / 2f);
        const int size = 6;
        const int thickness = 2;
        _spriteBatch!.Draw(_pixel, new Rectangle((int)center.X - size, (int)center.Y - thickness / 2, size * 2, thickness), Color.White);
        _spriteBatch.Draw(_pixel, new Rectangle((int)center.X - thickness / 2, (int)center.Y - size, thickness, size * 2), Color.White);
    }

    private void DrawTopLeftStatus()
    {
        var lines = new List<string>
        {
            _gameSession.IsReady ? "Server: đã kết nối" : "Server: CHƯA kết nối (chạy KingdomCraft.Server trước)",
            $"Góc nhìn: {(_isThirdPerson ? "Thứ 3 (V để đổi)" : "Thứ 1 (V để đổi)")}"
        };

        if (_gameSession.LastPlayer is { } player)
        {
            lines.Add($"HP: {player.Health}/100");
        }

        if (_gameSession.LastKingdom is { } kingdom)
        {
            lines.Add($"Vương quốc: {kingdom.Name} | AutomationLevel {kingdom.AutomationLevel}");
        }

        if (!string.IsNullOrEmpty(_gameSession.LastMessage))
        {
            lines.Add($"> {_gameSession.LastMessage}");
        }

        var y = 10f;
        foreach (var line in lines)
        {
            _spriteBatch!.DrawString(_font, line, new Vector2(11, y + 1), Color.Black);
            _spriteBatch.DrawString(_font, line, new Vector2(10, y), Color.White);
            y += _font!.LineSpacing;
        }
    }

    private void DrawBottomBar(Viewport viewport)
    {
        const int barHeight = 56;
        var barRect = new Rectangle(0, viewport.Height - barHeight, viewport.Width, barHeight);
        _spriteBatch!.Draw(_pixel, barRect, new Color(0, 0, 0, 160));

        var inventory = _gameSession.LastPlayer?.Inventory;
        var text = inventory is null || inventory.Count == 0
            ? "Túi đồ: (trống)"
            : "Túi đồ: " + string.Join("   ", inventory.Select(kv => $"{kv.Key} x{kv.Value}"));

        _spriteBatch.DrawString(_font, text, new Vector2(11, viewport.Height - barHeight + 11), Color.Black);
        _spriteBatch.DrawString(_font, text, new Vector2(10, viewport.Height - barHeight + 10), Color.White);

        const string help = "F1 Trang thai | F2 Craft Plank | F3 Craft Riu | F4 Tuyen Farmer | F5 Tick | F6 Quest | F7 Boss | F8 Danh Boss | V Goc nhin";
        _spriteBatch.DrawString(_font, help, new Vector2(11, viewport.Height - barHeight + 30), Color.Black);
        _spriteBatch.DrawString(_font, help, new Vector2(10, viewport.Height - barHeight + 29), new Color(220, 220, 220));
    }

    protected override void UnloadContent()
    {
        _gameSession.Dispose();
        base.UnloadContent();
    }
}
