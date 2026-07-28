# Anti-Cheat — KingdomCraft

## Mục đích
Định hướng cơ chế chống gian lận khi multiplayer thật được triển khai.
**Định hướng tương lai**: hiện mọi logic (`AutomationSystem`, tài nguyên)
chạy hoàn toàn phía server trong 1 tiến trình duy nhất nên chưa có bề mặt
gian lận nào cần chống — file này chuẩn bị nguyên tắc khi client thật kết
nối.

## Nội dung cần điền
- Nguyên tắc server-authoritative: mọi thay đổi Resources/AutomationLevel/
  Inventory chỉ tính trên server, client không tự gửi giá trị cuối cùng
- Validate input ở biên API (liên hệ nguyên tắc validate ở
  [[CodingConvention]]) — chặn giá trị bất thường (âm, vượt giới hạn)
- Phát hiện bất thường: tốc độ hành động vượt khả năng người chơi thường
  (spam request craft/build)
- Rate limiting theo Player/kết nối
- Kiểm tra tính toàn vẹn gói tin (chống sửa gói giữa đường truyền)
- Xử lý vi phạm: cảnh báo, kick, ban tạm/vĩnh viễn — liên hệ
  [[Authentication]]

## Câu hỏi mở
- Mức đầu tư chống cheat nên tương xứng thế nào với quy mô đội hiện tại
  (rất nhỏ) — ưu tiên server-authoritative đơn giản trước, hay cần hệ
  thống phát hiện phức tạp ngay từ đầu?
- Game có thành phần PvP/cạnh tranh (xem [[EndGame]], chiến tranh giữa
  vương quốc) đủ để biện minh chi phí đầu tư AntiCheat nặng không?

## Liên kết
- [[Authentication]]
- [[Network]]
- [[ErrorCodes]]
- [[CodingConvention]]
