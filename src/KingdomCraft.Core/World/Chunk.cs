namespace KingdomCraft.Core.World;

public enum BlockType : byte
{
    Air = 0,
    Dirt,
    Grass,
    Stone,
    Wood,
    Sand,
    Water
}

/// <summary>
/// Một khối chunk trong thế giới sandbox (tương tự Minecraft ở tầng kỹ thuật,
/// nhưng nội dung/luật chơi trên đó sẽ khác biệt — xem docs/02-Sandbox.md).
/// </summary>
public class Chunk
{
    public const int Size = 16;
    public const int Height = 128;

    public (int X, int Z) ChunkCoord { get; set; }

    public BlockType[,,] Blocks { get; set; } = new BlockType[Size, Height, Size];

    public BlockType GetBlock(int x, int y, int z) => Blocks[x, y, z];

    public void SetBlock(int x, int y, int z, BlockType type) => Blocks[x, y, z] = type;
}
