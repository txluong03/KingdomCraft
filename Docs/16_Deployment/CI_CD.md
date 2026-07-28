# CI/CD — KingdomCraft

## Mục đích
Thiết lập tự động build + test khi push/merge code. Hiện dự án **chưa có
CI/CD nào được cấu hình**, và thư mục còn chưa phải git repository — đây là
việc cần làm ngay sau khi khởi tạo git (xem [[Milestones]] Sprint 1).

## Nội dung cần điền
- Nền tảng CI dự kiến (GitHub Actions, Azure Pipelines...) và lý do chọn
- Trigger chạy CI (mỗi push, mỗi PR vào `main`)
- Các bước tối thiểu: restore, build (xem [[BuildPipeline]]), chạy [[UnitTests]]
- Thông báo kết quả CI (Discord, email...)
- Mở rộng dần: thêm [[IntegrationTests]], báo cáo coverage
- Gate chặn merge khi CI fail để bảo vệ nhánh `main` (liên hệ [[BranchStrategy]])
- Chi phí vận hành CI có phù hợp quy mô đội hiện tại không

## Câu hỏi mở
- Chọn GitHub Actions hay nền tảng khác? Có cần tự host runner không?
- CI tối thiểu (build + unit test) có đủ cho Sprint 1 hay cần thêm ngay từ đầu?

## Liên kết
- [[BuildPipeline]]
- [[BranchStrategy]]
- [[UnitTests]]
- [[Milestones]]
