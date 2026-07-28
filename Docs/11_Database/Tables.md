# Tables (Bảng dữ liệu) — KingdomCraft

## Mục đích
Liệt kê chi tiết bảng/collection dữ liệu ứng với [[ERD]], ánh xạ từ entity
Core hiện có (`KingdomState`, `Npc`, `Building`, `ResourceStockpile`,
`Player`) sang schema lưu trữ thật. **Định hướng tương lai**: chưa có DB
engine nào được chọn hay triển khai trong repo hiện tại.

## Nội dung cần điền
- Bảng `Players` (Id, Name, Health, Hunger, Level, Experience, Position,
  Inventory)
- Bảng `Kingdoms` (Id, Name, AutomationLevel, OwnerPlayerId)
- Bảng `Npcs` (Id, KingdomId FK, Name, Role, SkillLevel, Position)
- Bảng `Buildings` (Id, KingdomId FK, Type, Name, Position, Level,
  AssignedNpcId FK)
- Bảng/cấu trúc cho `ResourceStockpile` (ResourceName, Amount theo Kingdom)
- Bảng cấu hình tĩnh chưa có trong code: định nghĩa BuildingType, định nghĩa
  NpcRole, Recipe
- Kiểu dữ liệu cho `Position (X,Y,Z)` — 3 cột riêng hay 1 cột JSON/struct
- Quy ước đặt tên bảng/cột đối chiếu [[NamingConvention]]

## Câu hỏi mở
- `Player.Inventory` hiện chỉ là `Dictionary<string,int>` (đếm số lượng) —
  có cần bảng item instance riêng (durability, enchant...) khi hệ thống Item
  mở rộng?
- Định nghĩa BuildingType/NpcRole khi balance thay đổi: lưu trong DB (chỉnh
  qua tool) hay giữ trong code/config file tĩnh?

## Liên kết
- [[ERD]]
- [[Indexes]]
- [[NamingConvention]]
- [[SeedData]]
