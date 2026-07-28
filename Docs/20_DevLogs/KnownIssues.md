# Known Issues — KingdomCraft

Vấn đề đã biết trong **hiện trạng code thật** (`src/KingdomCraft.*`), không
phải rủi ro giả định — đối chiếu [[RiskManagement]] cho rủi ro ở tầm dự
án. Mỗi mục có nợ kỹ thuật tương ứng ở [[TechnicalDebt]].

| ID | Vấn đề | Ảnh hưởng | Trạng thái |
|---|---|---|---|
| KI-01 | 2 bộ model song song chưa hợp nhất: `Models/`+`Services/GameEngine` (turn-based, dùng bởi `KingdomCraft.Game`) vs `Kingdom/`+`Entities/`+`Simulation/AutomationSystem` (role-based, dùng bởi `KingdomCraft.Server`) | Nhầm lẫn, code thừa, bug khó debug | Chưa xử lý — xem [[DevelopmentRoadmap]] Bước 0 |
| KI-02 | Project `KingdomCraft.Game` không nằm trong `KingdomCraft.sln` | Project mồ côi, dễ bị quên khi build/dọn dẹp | Chưa xử lý — xem [[Milestones]] Sprint 1 |
| KI-03 | Thư mục dự án chưa phải git repository | Không rollback được, rủi ro mất code | Chưa xử lý — xem [[BranchStrategy]] |
| KI-04 | `KingdomCraft.Server` chỉ demo vòng lặp `Task.Delay`, chưa có networking thật | Chưa thể test multiplayer thật | Chưa xử lý — xem [[MultiplayerTests]], [[DevelopmentRoadmap]] Bước 3 |

## Liên kết
[[TechnicalDebt]] · [[DevelopmentRoadmap]] · [[Milestones]] · [[RiskManagement]]
