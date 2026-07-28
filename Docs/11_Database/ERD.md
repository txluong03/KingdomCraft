# ERD (Sơ đồ quan hệ thực thể) — KingdomCraft

## Mục đích
Phác thảo sơ đồ quan hệ giữa các thực thể cần lưu trữ bền vững (Player,
Kingdom, Npc, Building, ResourceStockpile...) để chuẩn bị cho lớp
Infrastructure. **Định hướng tương lai**: hiện code chưa có bất kỳ database
nào — `KingdomState`, `Npc`, `Building` chỉ tồn tại trong bộ nhớ khi
`KingdomCraft.Server` chạy, tắt server là mất toàn bộ dữ liệu.

## Nội dung cần điền
- Entity chính ánh xạ từ Core hiện có: `Player`, `KingdomState`, `Npc`,
  `Building`, `ResourceStockpile`
- Quan hệ 1-n: 1 Kingdom — nhiều Npc, 1 Kingdom — nhiều Building
- Quan hệ Player ↔ Kingdom (1 Player sở hữu 1 hay nhiều Kingdom?)
- Entity mới cần thêm ngoài Core hiện tại: Account/User (đăng nhập), item
  instance trong inventory, Recipe, Schedule của NPC
- Quan hệ Npc ↔ Building: `Building.AssignedNpcId` hiện là string lỏng lẻo,
  cần thể hiện thành khóa ngoại thật trong ERD
- Phân biệt entity là snapshot theo thời gian (dữ liệu save) với bảng cấu
  hình tĩnh (`BuildingType`, định nghĩa NpcRole, Recipe)
- Ký hiệu/công cụ vẽ ERD sẽ dùng (Mermaid, dbdiagram.io...)

## Câu hỏi mở
- Dùng mô hình quan hệ (SQL) hay tài liệu (NoSQL/document) cho save game —
  `ResourceStockpile` hiện là `Dictionary<string,int>` gợi ý document-store
  dễ hơn, có đánh đổi gì không?
- 1 Player có sở hữu nhiều Kingdom (multi-world) hay chỉ 1?
- Multiplayer: 1 Kingdom có thuộc về nhiều Player (guild/vương quốc chung)
  không?

## Liên kết
- [[Tables]]
- [[KingdomSystem]]
- [[SaveGame]]
- [[DevelopmentRoadmap]]
