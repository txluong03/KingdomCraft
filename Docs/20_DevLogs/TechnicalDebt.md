# Technical Debt — KingdomCraft

Nợ kỹ thuật cụ thể ứng với từng vấn đề ở [[KnownIssues]], kèm mức ưu tiên
xử lý. Thứ tự ưu tiên nên bám theo trình tự thật của [[DevelopmentRoadmap]]
(Bước 0 trước mọi thứ khác), không phải mức độ khó chịu chủ quan.

| ID | Nợ kỹ thuật | Ưu tiên | Liên kết |
|---|---|---|---|
| TD-01 | ~~Hợp nhất 2 bộ model~~ — **Xong (2026-07-28)** (KI-01) | Cao | [[DevelopmentRoadmap]] |
| TD-02 | ~~Xóa project mồ côi `KingdomCraft.Game`~~ — **Xong (2026-07-28)** (KI-02) | Cao | [[DevelopmentRoadmap]] |
| TD-03 | ~~Khởi tạo git repository~~ — **Xong** (KI-03). Còn thiếu: áp dụng [[BranchStrategy]] đầy đủ (feature branch/PR) | Trung bình | [[BranchStrategy]] |
| TD-04 | Xây networking thật cho `KingdomCraft.Server`, thay vòng lặp `Task.Delay` demo (KI-04) | Trung bình | [[DevelopmentRoadmap]] |
| TD-05 | Chưa có CI — `.github/` hiện chỉ có `copilot-instructions.md`, chưa có workflow build/test tự động | Cao | [[CI_CD]], [[Milestones]] |

## Liên kết
[[KnownIssues]] · [[DevelopmentRoadmap]] · [[Milestones]] · [[RiskManagement]]
