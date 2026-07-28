# Player API — KingdomCraft

## Mục đích
Phác thảo API thao tác với entity `Player`
(`src/KingdomCraft.Core/Entities/Player.cs`: Health, Hunger, Level,
Experience, Position, Inventory). **Định hướng tương lai**: hiện KHÔNG có
endpoint REST/RPC nào tồn tại — `Player` chỉ là object trong bộ nhớ dùng
nội bộ bởi Core.

## Nội dung cần điền
- Endpoint lấy thông tin Player hiện tại (Health, Hunger, Level,
  Experience, Position)
- Endpoint cập nhật Position (di chuyển) — tần suất gọi rất cao, cân nhắc
  REST hay giao thức realtime khác (xem [[Network]])
- Endpoint tăng Experience/Level — server authoritative, client không tự
  set giá trị
- Endpoint tương tác Hunger/Health (ăn uống, hồi máu), liên hệ hệ thống
  sinh tồn
- Quan hệ với [[InventoryAPI]] (`Player.Inventory` hiện là
  `Dictionary<string,int>` đơn giản)
- Validate ở biên: giới hạn giá trị hợp lệ (Health không âm, Position trong
  world bounds)

## Câu hỏi mở
- Position của Player nên đồng bộ qua REST (poll) hay kênh riêng tốc độ cao
  ([[Network]], [[Synchronization]])?
- `Player` hiện chưa liên kết tới `KingdomState` nào — API cần thêm quan hệ
  PlayerId ↔ KingdomId ở đâu?

## Liên kết
- [[InventoryAPI]]
- [[Network]]
- [[Authentication]]
- [[ErrorCodes]]
