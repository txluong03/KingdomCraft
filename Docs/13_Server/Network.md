# Network — KingdomCraft

## Mục đích
Định hướng giao thức mạng cho giao tiếp client-server thật. **Định hướng
tương lai**: hiện `Program.cs` không mở bất kỳ socket/port nào, toàn bộ
chạy nội bộ 1 tiến trình — đây là định hướng khi thêm multiplayer thật.

## Nội dung cần điền
- Lựa chọn giao thức: TCP/WebSocket cho dữ liệu quan trọng (build, craft,
  save), UDP cho dữ liệu realtime tần suất cao (vị trí, chiến đấu)
- Định dạng message (JSON, Protobuf, MessagePack) — đánh đổi dễ debug vs
  hiệu năng
- Cấu trúc packet: header (type, timestamp, sequence) + payload
- Xử lý mất gói/độ trễ (đặc biệt với UDP) — liên hệ [[Synchronization]]
- Nén dữ liệu khi truyền trạng thái Kingdom lớn (nhiều Building/Npc)
- Giới hạn băng thông/tần suất gửi theo client để chống spam (liên hệ
  [[AntiCheat]])

## Câu hỏi mở
- Dùng thư viện networking có sẵn (ENet, LiteNetLib, SignalR) hay tự viết
  giao thức trên raw socket?
- Client MonoGame (`KingdomCraft.Client`) và Server headless giao tiếp qua
  cùng 1 giao thức, hay Server còn expose thêm HTTP API riêng cho
  tool/admin?

## Liên kết
- [[Architecture]]
- [[Synchronization]]
- [[MultiplayerAPI]]
- [[Performance]]
