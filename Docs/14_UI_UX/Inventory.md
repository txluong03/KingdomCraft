# Inventory UI — KingdomCraft

## Mục đích
Thiết kế giao diện và tương tác cho inventory người chơi (layout, kéo-thả,
phản hồi). Khác với `05_Player/Inventory.md` (dữ liệu/logic inventory,
`Player.Inventory` dạng `Dictionary<string,int>`) — file này CHỈ tập trung
góc nhìn UI/UX, không lặp lại thiết kế dữ liệu.

## Nội dung cần điền
- Bố cục lưới slot (số cột/hàng, cuộn khi vượt giới hạn)
- Tương tác kéo-thả (drag-drop) giữa slot, gộp stack, tách stack
- Phản hồi hình ảnh khi thêm/bớt item (animation nhặt đồ, số lượng nhảy
  số)
- Hiển thị thông tin item khi hover (tooltip: tên, số lượng, mô tả cơ bản)
- Phân loại/lọc nhanh (tất cả, công cụ, nguyên liệu, vật phẩm chế tạo)
- Trạng thái rỗng/đầy inventory và cảnh báo khi gần đầy
- Truy cập nhanh từ HUD (hotbar) và liên kết mở màn hình Crafting/Kingdom
  stockpile

## Câu hỏi mở
- Inventory hiển thị dạng lưới cố định slot hay danh sách cuộn không giới
  hạn (phản ánh việc `Dictionary` hiện tại không giới hạn số loại item)?
- Có phân biệt trực quan giữa Inventory cá nhân và `ResourceStockpile` của
  Kingdom khi người chơi thao tác chuyển đồ giữa 2 kho không?

## Liên kết
- [[DesignSystem]]
- [[CraftingUI]]
- [[HUD]]
- [[InventoryAPI]]
