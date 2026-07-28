# Inventory API — KingdomCraft

## Mục đích
Phác thảo API cho thao tác inventory của Player (`Player.Inventory` là
`Dictionary<string,int>` — hiện chỉ đếm số lượng theo tên item, chưa có
item instance/durability). **Định hướng tương lai**: chưa có API/DB thật
nào tồn tại cho inventory.

## Nội dung cần điền
- Endpoint lấy toàn bộ inventory hiện tại của Player
- Endpoint thêm/bớt item (nhặt, tiêu thụ, mất khi chết)
- Endpoint chuyển item giữa Player Inventory và `ResourceStockpile` của
  Kingdom (khác biệt rõ 2 loại kho, xem [[Glossary]])
- Giới hạn sức chứa (slot/weight) — hiện `Dictionary` không có giới hạn nào
- Xử lý item instance (durability, enchant) khi hệ thống Item mở rộng khỏi
  model int đơn giản hiện tại
- Đồng bộ realtime khi nhiều client xem chung 1 inventory (trade,
  multiplayer)

## Câu hỏi mở
- Model hiện tại (`Dictionary<string,int>` — chỉ số lượng) có đủ khi thêm
  durability/enchant, hay cần đổi sang danh sách item instance có Id riêng?
- Giới hạn slot inventory là bao nhiêu, có phân loại theo item type không?

## Liên kết
- [[PlayerAPI]]
- [[CraftingAPI]]
- [[KingdomSystem]]
- [[ErrorCodes]]
