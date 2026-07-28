# Multiplayer API — KingdomCraft

## Mục đích
Phác thảo API/giao thức cho tương tác multiplayer (nhiều Kingdom, nhiều
Player cùng server). **Định hướng tương lai — quan trọng**:
`KingdomCraft.Server` hiện CHƯA có networking thật (không socket, không
HTTP, chỉ vòng lặp Tick nội bộ trên 1 KingdomState mẫu duy nhất), toàn bộ
nội dung ở đây là định hướng.

## Nội dung cần điền
- Endpoint/kênh danh sách server, tham gia server (liên hệ [[Matchmaking]])
- Đồng bộ trạng thái nhiều Player trong cùng world (vị trí, hành động
  realtime)
- Tương tác giữa nhiều Kingdom: ngoại giao, thương mại, chiến tranh (liên
  hệ [[Economy]], [[MultiplayerFlow]])
- Giao thức truyền tải: REST cho thao tác không realtime (build, craft) vs
  WebSocket/UDP cho realtime (di chuyển, chiến đấu) — xem [[Network]]
- Quyền sở hữu Kingdom trong multiplayer: 1 Kingdom — nhiều Player (guild)
  hay chỉ 1 chủ
- Giới hạn số Player/Kingdom đồng thời trên 1 server instance

## Câu hỏi mở
- `KingdomCraft.Server` hiện chỉ chạy 1 `KingdomState` cứng trong code —
  kiến trúc multi-tenant (nhiều Kingdom/server) cần thiết kế lại thế nào?
- Chọn giao thức realtime nào (WebSocket, gRPC streaming, raw UDP) — đánh
  đổi độ trễ vs độ phức tạp triển khai?

## Liên kết
- [[Network]]
- [[Synchronization]]
- [[Matchmaking]]
- [[Architecture]]
