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
| 2026-07-28 | Hoàn thành [[DevelopmentRoadmap]] Bước 1 (Core Loop tối thiểu): `Inventory`/`ItemStack` gắn vào `Player`; Client render 1 chunk voxel demo (`Game1`+`ChunkMeshBuilder`+`VoxelRaycaster`+`FlyCamera`) kèm đặt/phá khối; mở rộng test `AutomationSystem` | Theo đúng thứ tự 4 mục trong Bước 1; `dotnet build`/`dotnet test` pass (12/12) | Chủ dự án |
| 2026-07-28 | Tắt hẳn backface culling (`RasterizerState.CullMode = None`) trong `Game1` thay vì tính đúng chiều winding cho từng mặt khối | Không thể kiểm tra hình ảnh trực quan trong môi trường dev hiện tại — ưu tiên chắc chắn hiển thị hơn tối ưu hiệu năng; xem KI-05 | Trợ lý (cần xác nhận lại khi có màn hình) |
| 2026-07-28 | Thêm project `KingdomCraft.Application` (AppService + DTO), mượn convention `FooAppService`/`CreateFooInput`/`FooDto` từ dự án OC-TXNG (ABP Boilerplate) của người dùng — **chỉ mượn khung code, không mượn nội dung nghiệp vụ**; KHÔNG thêm EF Core/multi-tenant/RBAC | Chuẩn bị ranh giới rõ ràng cho networking (Bước 3) và Save/Load (Bước 5) mà không tạo kiến trúc rỗng ở quy mô hiện tại — người dùng chọn "áp dụng một phần" khi được hỏi | Chủ dự án |

## Liên kết
[[DevelopmentRoadmap]] · [[DailyLog]] · [[KnownIssues]]
