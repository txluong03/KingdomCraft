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

## Liên kết
[[Decisions]] · [[Changelog]] · [[Milestones]]
