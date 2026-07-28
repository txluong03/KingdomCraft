# Development Roadmap — KingdomCraft

Lộ trình kỹ thuật (thứ tự module nên code), khác với [[ProductRoadmap]] là
lộ trình trải nghiệm người chơi. Thứ tự dưới đây phản ánh **hiện trạng repo**
(xem `F:\KingdomCraft\src`), không phải liệt kê lý tưởng chung chung.

## Bước 0 — Dọn nền tảng ✅ Đã xong (2026-07-28)
Trước đây code có **2 bộ model song song chưa hợp nhất** (`Models/`+
`Services/GameEngine` turn-based vs `Kingdom/`+`Entities/`+
`Simulation/AutomationSystem` role-based). Đã xử lý theo đúng quyết định ở
[[Decisions]]:
- Giữ hướng `Kingdom/`+`Entities/`+`Simulation` (role-based NPC +
  `AutomationLevel`) — đúng tinh thần [[ProjectVision]].
- Gộp ý hay của bộ cũ: `Building.GetProductionPerTurn()` →
  `Building.GetProductionPerTick()` (namespace `Kingdom`), gọi trong
  `AutomationSystem.Tick` song song với sản xuất theo `NpcRole` — công
  trình (Farm/Mine/LumberMill) giờ tự sản xuất thụ động theo `Level`, độc
  lập với NPC được gán.
- Xóa `Models/`, `Services/`, project mồ côi `KingdomCraft.Game`,
  `GameEngineTests.cs`; thêm test `Tick_FarmBuildingProducesFoodIndependentlyOfNpc`.
- `dotnet build` + `dotnet test` pass (3/3).

Còn để ngỏ (không thuộc Bước 0): liên kết `Building.AssignedNpcId` với sản
lượng thực tế (hiện 2 nguồn sản xuất — building và NPC theo role — độc lập
nhau, xem [[KingdomSystem]]); CI tối thiểu (`.github/` đã có nhưng chưa xác
nhận workflow build/test tự động — xem [[Milestones]] Sprint 1, [[CI_CD]]).

## Bước 1 — Core Loop tối thiểu ✅ Đã xong về code, chờ xác nhận trực quan (2026-07-28)
1. [x] `Player` — vẫn đơn giản (Health/Hunger/Level/Experience/Position),
   thêm `Inventory` thay cho `Dictionary<string,int>` thô.
2. [x] `Inventory` cơ bản — `Entities/Inventory.cs` (`ItemStack` + `Inventory`
   dạng slot, `itemId` chuỗi tự do vì [[ItemTypes]] chưa chốt danh mục cụ
   thể). Test: `InventoryTests` (6 case).
3. [x] World/Chunk render ở Client (đặt/phá khối) — `Game1`,
   `Rendering/ChunkMeshBuilder` (naive face-culling, không texture),
   `Rendering/VoxelRaycaster` (step-marching ray), `Rendering/FlyCamera`
   (bàn phím, không mouse-look), `World/DemoWorldGenerator` (địa hình phẳng
   demo — chưa phải world gen thật, xem [[TerrainGeneration]]). Chuột trái
   phá khối, chuột phải đặt Dirt. **`dotnet build` sạch nhưng chưa được
   kiểm tra trực quan** — môi trường phát triển không có màn hình để chạy
   MonoGame. Cần tự `dotnet run --project src/KingdomCraft.Client` và báo
   lại nếu render/điều khiển có vấn đề (đặc biệt: mặt khối có hiển thị
   đúng không — hiện tắt hẳn backface culling để né rủi ro sai chiều
   winding không kiểm tra được).
4. [x] `KingdomState` + `AutomationSystem` — thêm test Miner, cộng dồn
   NPC+Building, cap `AutomationLevel` ở 100 (tổng 9 test cho automation +
   building).

## Kiến trúc bổ sung — Application layer ✅ Đã xong (2026-07-28)
Thêm `KingdomCraft.Application` (AppService + DTO), mượn convention
`FooAppService`/`CreateFooInput`/`FooDto` từ dự án OC-TXNG của người dùng —
**chỉ mượn khung code, không mượn nội dung/business logic**, và không kèm
EF Core/multi-tenant/RBAC (chưa cần ở quy mô hiện tại, xem [[Decisions]]).
- `Application/Kingdom/KingdomAppService.cs`: `GetKingdomState`, `Tick`,
  `CreateBuilding`, `RecruitNpc`, `AssignNpcRole` — nhận Input DTO, trả về
  Dto, không lộ thẳng `KingdomState`/`Building`/`Npc` domain entity ra ngoài.
- `KingdomCraft.Server` giờ gọi qua `KingdomAppService.Tick()` thay vì gọi
  thẳng `AutomationSystem.Tick()`.
- 5 test mới (`KingdomAppServiceTests`), tổng 17 test pass.
- Mục đích: chuẩn bị sẵn ranh giới cho Bước 3 (networking — Server expose
  đúng các method này qua API/socket thay vì viết lại) và Bước 5 (Save/Load
  — serialize DTO thay vì domain entity).

## Bước 2 — Gameplay cốt lõi
5. Crafting (recipe tối thiểu)
6. Building (mở rộng `Building`/`KingdomBuildings`)
7. NPC: bổ nhiệm, thăng cấp, lịch làm việc (`Schedule`, `VillagerAI`)
8. Quest cơ bản

## Bước 3 — Kinh tế & multiplayer
9. Economy (thị trường, thuế)
10. Multiplayer đồng bộ (`KingdomCraft.Server` + networking thật, hiện chỉ
    là vòng lặp `Task.Delay` demo)
11. Guild

## Bước 4 — Chiều sâu & PvP
12. War/Diplomacy giữa vương quốc
13. Boss/Dungeon nâng cao
14. Cây công nghệ đầy đủ

## Liên kết
[[ProductRoadmap]] · [[Milestones]] · [[CodingConvention]]
