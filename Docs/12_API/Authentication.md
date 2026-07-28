# Authentication — KingdomCraft

## Mục đích
Định hướng cơ chế xác thực người chơi khi kết nối server multiplayer thật.
**Định hướng tương lai**: hiện `KingdomCraft.Server` chưa có bất kỳ
networking/API nào (chỉ vòng lặp `Tick` nội bộ), nên chưa có đăng nhập/token
thật — file này chuẩn bị hướng thiết kế.

## Nội dung cần điền
- Cơ chế đăng nhập (tài khoản riêng, hay liên kết Steam/Epic/OAuth)
- Token/session (JWT, refresh token) dùng cho request API và kết nối
  realtime
- Phân biệt tài khoản (User/Account) và entity `Player` trong Core hiện tại
  (`Player` hiện chưa có liên kết account nào)
- Bảo vệ kết nối tới server headless khỏi truy cập trái phép
- Quy tắc hết hạn phiên, đăng xuất, đổi mật khẩu/liên kết lại
- Phân quyền cơ bản (người chơi thường vs admin/GM)

## Câu hỏi mở
- Game có bắt buộc tài khoản online ngay cả ở chế độ chơi đơn hay chỉ
  multiplayer mới cần?
- Có tích hợp nền tảng thứ 3 (Steam) hay tự xây hệ thống tài khoản riêng?

## Liên kết
- [[PlayerAPI]]
- [[MultiplayerAPI]]
- [[Architecture]]
- [[AntiCheat]]
