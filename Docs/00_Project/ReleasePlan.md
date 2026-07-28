# Release Plan — KingdomCraft

## Versioning
Semantic Versioning `MAJOR.MINOR.PATCH`:
- `MAJOR` — thay đổi phá vỡ save game cũ hoặc thay đổi lớn cấu trúc dữ liệu.
- `MINOR` — thêm tính năng/nội dung mới, tương thích ngược (Season content).
- `PATCH` — sửa lỗi, cân bằng số liệu.

Trước bản 1.0 (Prototype/Alpha/Beta theo [[ProductRoadmap]]), dùng
`0.MINOR.PATCH`, không cam kết tương thích save giữa các bản.

## Kênh phát hành (khi có)
- **Dev** — build nội bộ, chạy từ `main` mỗi khi merge (xem [[CI_CD]]).
- **Internal/Beta** — chia sẻ hạn chế để playtest.
- **Public** — Steam/Epic (xem [[Steam]], [[Epic]]), chỉ sau khi đạt Core
  Scope trong [[ProjectScope]] và pass [[RegressionTests]].

## Nhịp phát hành
Chưa cố định lịch cụ thể ở giai đoạn Prototype/Alpha — ưu tiên chất lượng
vòng lặp chơi hơn deadline. Khi vào Beta trở đi, cân nhắc nhịp theo Season
(xem [[ProductRoadmap]]).

## Checklist trước mỗi release
- [ ] Toàn bộ test trong [[TestCase]] pass (đặc biệt [[RegressionTests]])
- [ ] Không có rủi ro mở nghiêm trọng trong [[RiskManagement]]
- [ ] Changelog cập nhật (xem [[Changelog]])
- [ ] Save game cũ vẫn load được hoặc có migration rõ ràng (xem [[Migration]])

## Liên kết
[[BranchStrategy]] · [[ProductRoadmap]] · [[CI_CD]]
