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

### Changed
- Khởi tạo git repository, đã push/pull với remote.
- **Hợp nhất kiến trúc Core** (Bước 0 [[DevelopmentRoadmap]]): xóa
  `Models/` + `Services/GameEngine` (hướng turn-based), giữ
  `Kingdom/` + `Entities/` + `Simulation/AutomationSystem` (hướng
  role-based NPC + `AutomationLevel`); `AutomationSystem.Tick` giờ cộng
  thêm sản lượng từ `Building.GetProductionPerTick()`.

### Removed
- Project mồ côi `KingdomCraft.Game` (không nằm trong `.sln`).
- `tests/KingdomCraft.Tests/GameEngineTests.cs` (test cho `GameEngine` đã
  xóa).

### Fixed
- (chưa có)

## Liên kết
[[ReleasePlan]] · [[DailyLog]] · [[Decisions]]
