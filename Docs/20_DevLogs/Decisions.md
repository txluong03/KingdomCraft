# Decisions — KingdomCraft

Nhật ký các quyết định thiết kế/kỹ thuật quan trọng đã chốt, kèm lý do —
để không phải tranh luận lại từ đầu mỗi khi có thành viên mới hoặc quay
lại sau một thời gian dài. Quyết định lớn ảnh hưởng kiến trúc nên đối
chiếu thêm với [[DevelopmentRoadmap]].

| Ngày | Quyết định | Lý do | Người quyết |
|---|---|---|---|
| 2026-07-28 | Giữ hướng code `Kingdom/Entities/Simulation` (role-based NPC + `AutomationLevel`), bỏ hướng `Models/Services` (turn-based `GameEngine`) | Đúng tinh thần cơ chế chuyển giao trong [[ProjectVision]] | Chủ dự án |
| 2026-07-28 | Dùng vòng lặp real-time tick thay vì turn-based | Phù hợp sandbox khám phá tự do hơn | Chủ dự án |

## Liên kết
[[DevelopmentRoadmap]] · [[DailyLog]] · [[KnownIssues]]
