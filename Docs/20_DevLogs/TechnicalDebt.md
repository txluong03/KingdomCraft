# Technical Debt — KingdomCraft

Nợ kỹ thuật cụ thể ứng với từng vấn đề ở [[KnownIssues]], kèm mức ưu tiên
xử lý. Thứ tự ưu tiên nên bám theo trình tự thật của [[DevelopmentRoadmap]]
(Bước 0 trước mọi thứ khác), không phải mức độ khó chịu chủ quan.

| ID | Nợ kỹ thuật | Ưu tiên | Liên kết |
|---|---|---|---|
| TD-01 | Hợp nhất 2 bộ model (`Models/Services/GameEngine` vs `Kingdom/Entities/Simulation`) thành một hướng duy nhất (KI-01) | Cao | [[DevelopmentRoadmap]] |
| TD-02 | Xóa/loại bỏ project mồ côi `KingdomCraft.Game`, cập nhật `KingdomCraft.sln` (KI-02) | Cao | [[DevelopmentRoadmap]] |
| TD-03 | Khởi tạo git repository và áp dụng [[BranchStrategy]] (KI-03) | Cao | [[DevelopmentRoadmap]] |
| TD-04 | Xây networking thật cho `KingdomCraft.Server`, thay vòng lặp `Task.Delay` demo (KI-04) | Trung bình | [[DevelopmentRoadmap]] |

## Liên kết
[[KnownIssues]] · [[DevelopmentRoadmap]] · [[Milestones]] · [[RiskManagement]]
