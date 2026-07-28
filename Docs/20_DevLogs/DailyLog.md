# Daily Log — KingdomCraft

Nhật ký công việc hàng ngày, ghi ngắn gọn việc đã làm để tra cứu lại tiến
độ thật. Bổ sung chi tiết ngày-qua-ngày, không thay thế [[Milestones]]
(mốc sprint) hay [[Changelog]] (thay đổi theo bản phát hành).

Ghi mới nhất lên trên hoặc dưới đều được, miễn nhất quán trong file. Mỗi
dòng chỉ cần vài từ — chi tiết hơn thì mở [[Decisions]] hoặc [[KnownIssues]]
liên quan.

| Ngày | Việc đã làm | Ghi chú |
|---|---|---|
| 2026-07-28 | Khởi tạo bộ tài liệu `Docs/` (thêm khung sườn cho 15_TestCase → 20_DevLogs) | Chỉ là khung tham khảo, chưa có nội dung/số liệu cuối cùng |
| 2026-07-28 | Khởi tạo git repository, push/pull với remote | Thực hiện bởi chủ dự án |
| 2026-07-28 | Dọn code theo [[DevelopmentRoadmap]] Bước 0: xóa `Models/`+`Services/GameEngine` và project mồ côi `KingdomCraft.Game`, gộp `GetProductionPerTurn` cũ thành `Building.GetProductionPerTick()` trong `AutomationSystem.Tick` | `dotnet build` + `dotnet test` pass (3/3) sau khi dọn |
| 2026-07-28 | Bước 1 Core Loop: thêm `Inventory`/`ItemStack`, gắn vào `Player`; render 1 chunk voxel demo ở Client (`Game1` + `ChunkMeshBuilder` + `VoxelRaycaster` + `FlyCamera`) kèm đặt/phá khối; mở rộng test `AutomationSystem` | `dotnet build`/`dotnet test` pass (12/12 test). Phần render **chưa kiểm tra trực quan được** — cần tự chạy `dotnet run --project src/KingdomCraft.Client` |
| 2026-07-28 | Đọc dự án OC-TXNG (ABP Boilerplate) của chủ dự án làm tham khảo; thêm project `KingdomCraft.Application` (AppService + DTO) mượn convention đặt tên/khung code từ đó, không mượn nội dung nghiệp vụ; wire `KingdomCraft.Server` gọi qua `KingdomAppService` | `dotnet build`/`dotnet test` pass (17/17 test) |

## Liên kết
[[Decisions]] · [[Changelog]] · [[Milestones]]
