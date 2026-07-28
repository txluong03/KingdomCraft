# Error Codes — KingdomCraft

## Mục đích
Định hướng bảng mã lỗi thống nhất cho toàn bộ API (Player, Inventory,
Kingdom, Crafting, NPC, Multiplayer, Save). **Định hướng tương lai**: hiện
chưa có API/lỗi thật nào để liệt kê — đây là khung quy ước chuẩn bị trước.

## Nội dung cần điền
- Quy ước format mã lỗi (namespace theo domain, VD: `PLAYER_001`,
  `KINGDOM_003`)
- Nhóm lỗi chung: xác thực (liên hệ [[Authentication]]), validate input,
  not found, conflict/xung đột trạng thái
- Lỗi đặc thù domain: không đủ tài nguyên khi craft/xây dựng, NPC đang bận,
  vượt giới hạn slot inventory
- Cách trả lỗi cho client (HTTP status + body chuẩn hóa, hay mã lỗi riêng
  cho kênh realtime)
- Đa ngôn ngữ hóa thông báo lỗi hiển thị cho người chơi
- Log lỗi phía server để debug (dùng `ILogger<T>` theo [[CodingConvention]])

## Câu hỏi mở
- Có chuẩn hóa theo convention lỗi sẵn có (RFC 7807 Problem Details) hay tự
  định nghĩa format riêng?
- Lỗi gameplay (VD: "không đủ gỗ") có nên tách khỏi lỗi hệ thống (500,
  timeout) về cách xử lý ở client không?

## Liên kết
- [[PlayerAPI]]
- [[KingdomAPI]]
- [[CraftingAPI]]
- [[CodingConvention]]
