# Migration — KingdomCraft

## Mục đích
Định hướng chiến lược migration schema DB khi cấu trúc dữ liệu thay đổi
theo thời gian. **Định hướng tương lai**: hiện chưa có DB nào tồn tại nên
chưa có migration thật — file này chuẩn bị quy ước cho khi lớp
Infrastructure được thêm vào (xem [[CodingConvention]]).

## Nội dung cần điền
- Công cụ migration dự kiến (EF Core Migrations là lựa chọn tự nhiên với
  .NET 8, hoặc công cụ khác nếu chọn ORM/ODM khác)
- Quy ước đặt tên migration, review trước khi merge
- Chiến lược không phá vỡ save game cũ (thêm cột có default, tránh xóa cột
  trực tiếp)
- Migration dữ liệu enum (VD: thêm `NpcRole` mới, đổi tên `BuildingType`)
  ảnh hưởng dữ liệu đã lưu ra sao
- Môi trường áp dụng migration: dev, staging, production — thứ tự và
  rollback plan
- Liên hệ CI/CD ([[Deployment]]) để chạy migration tự động khi release

## Câu hỏi mở
- Dự án dùng ORM nào (EF Core, hay raw SQL/Dapper) — ảnh hưởng trực tiếp
  tới cách viết migration?
- Có cần giữ tương thích ngược nhiều version save cùng lúc (server
  multiplayer có người chơi chưa update client) không?

## Liên kết
- [[SaveGame]]
- [[Tables]]
- [[Deployment]]
- [[CodingConvention]]
