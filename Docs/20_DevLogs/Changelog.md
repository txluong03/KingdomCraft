# Changelog — KingdomCraft

Theo định dạng [Keep a Changelog](https://keepachangelog.com/), gắn với
quy tắc versioning ở [[ReleasePlan]]. Trước bản `1.0`, mọi thay đổi nằm
dưới `0.MINOR.PATCH` và không có bản phát hành/build nào đã đóng gói —
mục **[Unreleased]** dưới đây phản ánh đúng thực tế đó.

## [Unreleased]

### Added
- Khởi tạo cấu trúc `Docs/` (các nhóm 00–20; phần lớn là khung tham khảo,
  chưa có nội dung/số liệu cuối cùng — xem README).
- `Building.GetProductionPerTick()` — công trình (Farm/Mine/LumberMill) tự
  sản xuất tài nguyên thụ động mỗi tick, độc lập với NPC được gán.
- Test `Tick_FarmBuildingProducesFoodIndependentlyOfNpc`.
- `KingdomCraft.Core.Entities.Inventory`/`ItemStack` — túi đồ dạng slot,
  gắn vào `Player.Inventory` (Bước 1 [[DevelopmentRoadmap]]).
- Test `InventoryTests` (6 case), thêm 3 test `AutomationSystemTests`
  (Miner, cộng dồn NPC+Building, cap `AutomationLevel` ở 100).
- Client render voxel tối thiểu: `Game1`, `Rendering/ChunkMeshBuilder`,
  `Rendering/VoxelRaycaster`, `Rendering/FlyCamera`,
  `World/DemoWorldGenerator` — render 1 chunk địa hình phẳng demo, đặt/phá
  khối bằng ray từ camera. **Build sạch nhưng chưa kiểm tra trực quan**
  (môi trường phát triển không có màn hình).
- Project mới `KingdomCraft.Application` — `Kingdom/KingdomAppService.cs`
  (`GetKingdomState`, `Tick`, `CreateBuilding`, `RecruitNpc`,
  `AssignNpcRole`) + DTO (`KingdomStateDto`, `BuildingDto`, `NpcDto`) + Input
  (`CreateBuildingInput`, `RecruitNpcInput`, `AssignNpcRoleInput`). Convention
  mượn từ dự án OC-TXNG (chỉ khung, không nội dung).
- Test `KingdomAppServiceTests` (5 case).

### Changed
- Khởi tạo git repository, đã push/pull với remote.
- **Hợp nhất kiến trúc Core** (Bước 0 [[DevelopmentRoadmap]]): xóa
  `Models/` + `Services/GameEngine` (hướng turn-based), giữ
  `Kingdom/` + `Entities/` + `Simulation/AutomationSystem` (hướng
  role-based NPC + `AutomationLevel`); `AutomationSystem.Tick` giờ cộng
  thêm sản lượng từ `Building.GetProductionPerTick()`.
- `KingdomCraft.Server` gọi `KingdomAppService.Tick()` thay vì gọi thẳng
  `AutomationSystem.Tick()`.

### Removed
- Project mồ côi `KingdomCraft.Game` (không nằm trong `.sln`).
- `tests/KingdomCraft.Tests/GameEngineTests.cs` (test cho `GameEngine` đã
  xóa).

### Fixed
- (chưa có)

## Liên kết
[[ReleasePlan]] · [[DailyLog]] · [[Decisions]]
