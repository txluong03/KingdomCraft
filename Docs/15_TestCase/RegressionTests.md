# Regression Tests — KingdomCraft

## Mục đích
Đảm bảo tính năng cũ không hỏng khi thêm tính năng mới hoặc khi hợp nhất 2
bộ model — bộ test bắt buộc trong checklist trước mỗi release ở
[[ReleasePlan]].

## Nội dung cần điền
- Bộ test regression tối thiểu chạy trước mỗi release (theo checklist [[ReleasePlan]])
- Danh sách tính năng "không được phép hỏng" theo từng mốc ở [[Milestones]]
- Test regression riêng cho việc hợp nhất 2 bộ model (`Models/Services` vs `Kingdom/Entities/Simulation`)
- Tự động hóa regression trong CI khi có (xem [[CI_CD]])
- Quy trình khi phát hiện regression (rollback, hotfix, ghi vào [[KnownIssues]])
- Tần suất chạy full regression suite so với smoke test nhanh

## Câu hỏi mở
- Regression suite có chạy full mỗi lần merge vào `main` hay chỉ trước release?
- Ai chịu trách nhiệm duyệt/maintain bộ test regression khi đội còn nhỏ?

## Liên kết
- [[ReleasePlan]]
- [[CI_CD]]
- [[KnownIssues]]
- [[UnitTests]]
