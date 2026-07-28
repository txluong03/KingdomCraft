# Blocks

## Danh sách hiện có (khớp `src/KingdomCraft.Core/World/Chunk.cs`)
`BlockType`: Air, Dirt, Grass, Stone, Wood, Sand, Water. Chưa có thuộc
tính độ cứng/tool yêu cầu/drop item cụ thể trong code — đây là file định
hướng cho khi cài đặt tương tác đào/phá thật.

## Ý định thiết kế — ánh xạ Block → Item (CHƯA cài đặt)
| BlockType | Item rơi ra (dự kiến) | Công cụ hiệu quả (dự kiến) |
|---|---|---|
| Stone | `stone` ([[ItemTypes]]) | `stone_pickaxe`/`wooden_pickaxe` |
| Wood | `wood` | `stone_axe`/`wooden_axe` |
| Dirt/Grass/Sand | (chưa quyết — có thể không rơi item ở bản demo) | — |
| Water/Air | Không rơi gì | — |

**Trạng thái:** đây là ý định thiết kế để tài liệu và code (`ItemCatalog`)
đã sẵn item `wood`/`stone` khớp nhau khi triển khai — `Game1`
(`src/KingdomCraft.Client`) hiện phá khối chỉ set `Air`, **chưa** cộng
item vào `Player.Inventory` (Client demo hiện không có `Player` instance).
Việc nối World→Item→Inventory cần thêm `Player` + HUD hiển thị inventory ở
Client, ghi nhận là việc tiếp theo ở [[TechnicalDebt]].

## Chưa quyết (để sau khi có thao tác đào/phá thật)
- Độ cứng (thời gian phá) từng loại block.
- Block trong suốt/không rắn ảnh hưởng [[Physics]] (Water chảy, ánh sáng
  qua kính...).
- Giới hạn xây/phá theo lãnh thổ vương quốc hay tự do toàn bản đồ.
- Block mới theo thời đại công nghệ ([[TechnologyTree]]: gạch, bê tông,
  kim loại...).

## Câu hỏi mở
- Có cần công cụ đúng loại mới phá được (như Minecraft: cuốc mới phá được
  đá) hay phá được bằng tay, công cụ chỉ tăng tốc độ?

## Liên kết
[[ItemTypes]] · [[Structure]] · [[Physics]] · [[TechnicalDebt]]
