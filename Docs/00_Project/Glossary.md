# Glossary — KingdomCraft

Thuật ngữ dùng xuyên suốt tài liệu và code. Cập nhật ngay khi thêm khái
niệm mới ở bất kỳ file nào khác — không để định nghĩa rải rác.

## Thế giới
- **Chunk** — khối thế giới kích thước `16×128×16` (xem
  `src/KingdomCraft.Core/World/Chunk.cs`), đơn vị sinh/tải thế giới.
- **Voxel/Block** — đơn vị nhỏ nhất của thế giới (`BlockType`: Air, Dirt,
  Grass, Stone, Wood, Sand, Water...).
- **Biome** — vùng địa lý có đặc trưng riêng (xem [[Biomes]]).

## Vương quốc & NPC
- **Kingdom / KingdomState** — trạng thái vương quốc của người chơi: tên,
  công trình, NPC, kho tài nguyên.
- **AutomationLevel** — chỉ số 0–100 thể hiện mức độ NPC tự vận hành thay
  người chơi; trung tâm của cơ chế "chuyển giao" (xem [[KingdomSystem]]).
- **NpcRole** — vai trò NPC: Idle, Farmer, Lumberjack, Miner, Soldier,
  Merchant, Steward (vai trò đặc biệt tăng AutomationLevel nhiều nhất).
- **Steward (Quản gia)** — NPC quản lý giúp tự động hóa vương quốc, không
  trực tiếp sản xuất tài nguyên.
- **SkillLevel** — mức kỹ năng của NPC, ảnh hưởng hiệu suất công việc.

## Gameplay
- **Tick / Turn** — đơn vị thời gian mô phỏng. Hiện có 2 khái niệm song
  song trong code (Turn theo lượt vs Tick theo thời gian thực) — sẽ hợp
  nhất theo [[DevelopmentRoadmap]] Bước 0.
- **Aggro** — mức độ một quái vật/NPC chú ý và tấn công một mục tiêu.
- **Durability** — độ bền công cụ/trang bị, giảm dần khi dùng.
- **Craft** — chế tạo vật phẩm từ nguyên liệu theo công thức (xem [[Recipes]]).

## Liên kết
[[NamingConvention]] · [[KingdomSystem]] · [[ProjectVision]]
