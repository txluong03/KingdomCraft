# Known Issues — KingdomCraft

Vấn đề đã biết trong **hiện trạng code thật** (`src/KingdomCraft.*`), không
phải rủi ro giả định — đối chiếu [[RiskManagement]] cho rủi ro ở tầm dự
án. Mỗi mục có nợ kỹ thuật tương ứng ở [[TechnicalDebt]].

| ID | Vấn đề | Ảnh hưởng | Trạng thái |
|---|---|---|---|
| KI-01 | ~~2 bộ model song song chưa hợp nhất~~ | Nhầm lẫn, code thừa, bug khó debug | **Đã xử lý (2026-07-28)** — xóa `Models/`+`Services/GameEngine`, giữ `Kingdom/`+`Entities/`+`Simulation/AutomationSystem`, gộp `GetProductionPerTurn` thành `Building.GetProductionPerTick()`. Xem [[Decisions]] |
| KI-02 | ~~Project `KingdomCraft.Game` không nằm trong `KingdomCraft.sln`~~ | Project mồ côi, dễ bị quên khi build/dọn dẹp | **Đã xử lý (2026-07-28)** — xóa hẳn project, `KingdomCraft.Server` là entry point chạy thử |
| KI-03 | ~~Thư mục dự án chưa phải git repository~~ | Không rollback được, rủi ro mất code | **Đã xử lý** — đã `git init`, push/pull với remote |
| KI-04 | `KingdomCraft.Server` chỉ demo vòng lặp `Task.Delay`, chưa có networking thật | Chưa thể test multiplayer thật | Chưa xử lý — xem [[MultiplayerTests]], [[DevelopmentRoadmap]] Bước 3 |
| KI-05 | Client render voxel (`Game1`/`ChunkMeshBuilder`) build sạch nhưng chưa được kiểm tra trực quan (môi trường dev không có màn hình) | Có thể có lỗi hình ảnh (mặt khối lật, camera lệch) chưa phát hiện được | Chưa xử lý — cần chạy `dotnet run --project src/KingdomCraft.Client` thủ công và phản hồi |
| KI-06 | `Building.GetProductionPerTick()` (theo `Level`) và sản xuất theo `NpcRole` (theo `SkillLevel`) là 2 nguồn tài nguyên độc lập, chưa liên kết qua `Building.AssignedNpcId` | Số liệu kinh tế chưa nhất quán về mặt thiết kế | Chưa xử lý — xem [[KingdomSystem]], [[Economy]] |

## Liên kết
[[TechnicalDebt]] · [[DevelopmentRoadmap]] · [[Milestones]] · [[RiskManagement]]
