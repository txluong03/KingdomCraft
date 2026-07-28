# Matchmaking — KingdomCraft

## Mục đích
Định hướng cơ chế ghép nối/tham gia server cho multiplayer. **Định hướng
tương lai**: hiện chưa có khái niệm "phòng"/"server list" nào trong code —
Server chỉ chạy 1 world cứng, file này chuẩn bị hướng khi có nhiều
server/world.

## Nội dung cần điền
- Mô hình multiplayer: dedicated server công cộng, server riêng do người
  chơi tự host, hay cả hai (xem [[DedicatedServer]])
- Danh sách server công khai, tìm theo tên/region/số người chơi
- Điều kiện tham gia: mời riêng (private), công khai, mật khẩu
- Ghép nối theo tiêu chí (VD: cùng giai đoạn Progression, cùng region để
  giảm độ trễ)
- Giới hạn số Player tối đa/1 world, hàng đợi khi đầy
- Tương tác với hệ thống Kingdom multiplayer: join vào Kingdom có sẵn hay
  luôn tạo Kingdom mới

## Câu hỏi mở
- KingdomCraft có multiplayer kiểu "server chung nhiều Kingdom cạnh tranh"
  (như MMO) hay "mỗi nhóm bạn 1 server riêng" (như Minecraft realms) — ảnh
  hưởng toàn bộ thiết kế matchmaking?
- Có cần cross-play/cross-region hay giới hạn theo khu vực địa lý để tối ưu
  độ trễ?

## Liên kết
- [[DedicatedServer]]
- [[MultiplayerAPI]]
- [[Architecture]]
