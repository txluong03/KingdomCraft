using KingdomCraft.Client.Rendering;
using KingdomCraft.Client.World;
using KingdomCraft.Core.World;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace KingdomCraft.Client;

/// <summary>
/// Client demo tối thiểu cho Bước 1 (Docs/00_Project/DevelopmentRoadmap.md):
/// render 1 chunk voxel tĩnh (địa hình phẳng demo, không phải world gen thật)
/// và cho phép đặt/phá khối bằng ray từ tâm màn hình.
///
/// Điều khiển:
///  - W/A/S/D: di chuyển · Space/Shift: lên/xuống
///  - Phím mũi tên: xoay góc nhìn (không dùng mouse-look)
///  - Chuột trái: phá khối · Chuột phải: đặt khối Dirt
///  - Esc: thoát
///
/// Môi trường phát triển hiện tại không có màn hình để kiểm tra trực quan —
/// hãy tự chạy `dotnet run --project src/KingdomCraft.Client` và phản hồi lại
/// nếu hình ảnh/điều khiển có gì bất thường.
/// </summary>
public class Game1 : Game
{
    private const float RaycastDistance = 8f;

    private readonly GraphicsDeviceManager _graphics;
    private readonly Chunk _chunk;
    private readonly FlyCamera _camera;

    private BasicEffect? _effect;
    private VertexBuffer? _vertexBuffer;
    private int _vertexCount;
    private MouseState _previousMouse;

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
        _camera = new FlyCamera(new Vector3(8, 14, 30), yaw: 0f, pitch: -0.45f);
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

        _camera.Update(gameTime, keyboard);
        HandleBlockInteraction();

        base.Update(gameTime);
    }

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
            _chunk.SetBlock(block.X, block.Y, block.Z, BlockType.Air);
            RebuildMesh();
        }
        else if (IsInsideChunk(placement))
        {
            _chunk.SetBlock(placement.X, placement.Y, placement.Z, BlockType.Dirt);
            RebuildMesh();
        }
    }

    private static bool IsInsideChunk((int X, int Y, int Z) cell) =>
        cell.X >= 0 && cell.X < Chunk.Size && cell.Y >= 0 && cell.Y < Chunk.Height && cell.Z >= 0 && cell.Z < Chunk.Size;

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(new Color(135, 206, 235));

        if (_vertexBuffer is not null && _effect is not null && _vertexCount > 0)
        {
            _effect.World = Matrix.Identity;
            _effect.View = _camera.GetViewMatrix();
            _effect.Projection = _camera.GetProjectionMatrix(GraphicsDevice.Viewport.AspectRatio);

            GraphicsDevice.SetVertexBuffer(_vertexBuffer);
            foreach (var pass in _effect.CurrentTechnique.Passes)
            {
                pass.Apply();
                GraphicsDevice.DrawPrimitives(PrimitiveType.TriangleList, 0, _vertexCount / 3);
            }
        }

        base.Draw(gameTime);
    }
}
