# Decisions — KingdomCraft

Nhật ký các quyết định thiết kế/kỹ thuật quan trọng đã chốt, kèm lý do —
để không phải tranh luận lại từ đầu mỗi khi có thành viên mới hoặc quay
lại sau một thời gian dài. Quyết định lớn ảnh hưởng kiến trúc nên đối
chiếu thêm với [[DevelopmentRoadmap]].

| Ngày | Quyết định | Lý do | Người quyết |
|---|---|---|---|
| 2026-07-28 | Giữ hướng code `Kingdom/Entities/Simulation` (role-based NPC + `AutomationLevel`), bỏ hướng `Models/Services` (turn-based `GameEngine`) | Đúng tinh thần cơ chế chuyển giao trong [[ProjectVision]] | Chủ dự án |
| 2026-07-28 | Dùng vòng lặp real-time tick thay vì turn-based | Phù hợp sandbox khám phá tự do hơn | Chủ dự án |
| 2026-07-28 | Thực thi quyết định trên: xóa `Models/`+`Services/GameEngine` và project mồ côi `KingdomCraft.Game`; gộp `GetProductionPerTurn` cũ thành `Building.GetProductionPerTick()`, gọi trong `AutomationSystem.Tick` song song với sản xuất theo `NpcRole` | Hoàn tất [[DevelopmentRoadmap]] Bước 0; `dotnet build`/`dotnet test` pass sau khi dọn | Chủ dự án |
| 2026-07-28 | Đổi tên thư mục tài liệu từ `KingdomCraft-Docs/` thành `Docs/` | Rút gọn tên thư mục | Chủ dự án |

## Liên kết
[[DevelopmentRoadmap]] · [[DailyLog]] · [[KnownIssues]]
