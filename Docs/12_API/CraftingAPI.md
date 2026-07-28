# Crafting API — KingdomCraft

## Mục đích
Phác thảo API chế tạo vật phẩm (Craft) từ nguyên liệu theo công thức.
**Định hướng tương lai**: Core hiện CHƯA có hệ thống Crafting/Recipe nào
được hiện thực (chỉ có khái niệm trong [[Glossary]]) — file này chuẩn bị
API song song với khi [[Recipes]]/CraftingSystem ra đời.

## Nội dung cần điền
- Endpoint lấy danh sách công thức khả dụng theo bàn chế tạo/level người
  chơi
- Endpoint thực hiện craft: kiểm tra nguyên liệu trong Inventory, trừ
  nguyên liệu, tạo item kết quả
- Craft tốn thời gian (progress bar) hay tức thời — ảnh hưởng thiết kế API
  (polling trạng thái)
- Validate server-side để tránh gian lận (đủ nguyên liệu, đúng công thức đã
  mở khóa)
- Liên hệ giai đoạn "Thợ thủ công" trong [[Progression]] — đây là API cho
  cột mốc chuyển tiếp đầu tiên
- Rollback khi craft thất bại giữa chừng (mất kết nối)

## Câu hỏi mở
- Craft có tốn thời gian thực (giống lò nung) hay tức thời theo lượt?
- Recipe là dữ liệu tĩnh trong code/config hay lưu DB có thể chỉnh qua
  tool?

## Liên kết
- [[InventoryAPI]]
- [[Progression]]
- [[ErrorCodes]]
- [[AntiCheat]]
