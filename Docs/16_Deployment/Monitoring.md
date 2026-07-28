# Monitoring — KingdomCraft

## Mục đích
Theo dõi sức khỏe server (tick rate, RAM, số kết nối) khi đã có networking
thật. Hiện **chưa cần thiết** vì chưa có server production nào chạy thật —
ghi lại đây làm khung chuẩn bị sớm.

## Nội dung cần điền
- Chỉ số cần theo dõi: tick rate `AutomationSystem`, RAM, CPU, số người chơi online
- Công cụ dự kiến (Grafana/Prometheus, hoặc log tập trung đơn giản trước)
- Cảnh báo tự động khi vượt ngưỡng (liên hệ rủi ro Server Lag ở [[RiskManagement]])
- Log lỗi tập trung, liên hệ [[KnownIssues]] khi phát hiện vấn đề lặp lại
- Thời điểm cần bắt đầu monitoring thật (khi server chạy liên tục cho nhiều người)

## Câu hỏi mở
- Monitoring có cần ngay từ bản multiplayer đầu tiên hay chỉ khi có người chơi thật ngoài đội dev?
- Ngân sách cho công cụ monitoring trả phí hay dùng open-source tự host?

## Liên kết
- [[RiskManagement]]
- [[PerformanceTests]]
- [[Docker]]
- [[KnownIssues]]
