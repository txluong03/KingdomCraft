# Dedicated Server — KingdomCraft

## Mục đích
Định hướng vận hành server chuyên dụng (dedicated) cho KingdomCraft.
**Định hướng tương lai**: hiện `KingdomCraft.Server` mới là bản demo
console app chạy vòng lặp Tick, chưa đóng gói/triển khai như một dịch vụ
thật — file này phác thảo yêu cầu vận hành.

## Nội dung cần điền
- Đóng gói server (Docker container, systemd service, Windows Service)
  thay vì chạy `dotnet run` thủ công
- Cấu hình qua file/biến môi trường (port, tick rate, giới hạn Player) thay
  vì hard-code như hiện tại (`"Vương quốc mẫu"` cứng trong `Program.cs`)
- Giám sát sức khỏe server (health check, log tập trung) — hiện chỉ
  `Console.WriteLine` mỗi tick
- Khả năng chạy nhiều instance song song (nhiều world/Kingdom trên cùng
  máy chủ vật lý)
- Quy trình restart/update server không mất dữ liệu người chơi đang online
  (liên hệ [[SaveGame]])
- Yêu cầu tài nguyên phần cứng ước tính theo số Player/Kingdom đồng thời

## Câu hỏi mở
- Server tự host bởi người chơi (community server) có được hỗ trợ chính
  thức hay chỉ dedicated server do đội ngũ vận hành?
- Chi phí vận hành server liên tục (24/7) có phù hợp với mô hình doanh thu
  đã chọn ở [[BusinessRequirements]] không?

## Liên kết
- [[Architecture]]
- [[Deployment]]
- [[Matchmaking]]
- [[SaveGame]]
