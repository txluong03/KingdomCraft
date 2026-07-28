# Crafting UI — KingdomCraft

## Mục đích
Thiết kế giao diện chế tạo vật phẩm (chọn công thức, xem nguyên liệu cần,
xác nhận craft). Core hiện CHƯA có hệ thống Crafting/Recipe nào được hiện
thực — file này chuẩn bị UI song song với [[CraftingAPI]] khi hệ thống đó
ra đời.

## Nội dung cần điền
- Danh sách công thức khả dụng, phân loại theo bàn chế tạo/level
- Hiển thị nguyên liệu cần vs nguyên liệu đang có (đủ/thiếu, tô màu cảnh
  báo)
- Phản hồi khi craft: tức thời hay có progress bar (tùy quyết định thiết
  kế ở [[CraftingAPI]])
- Trạng thái công thức chưa mở khóa (khóa/mờ, gợi ý điều kiện mở khóa)
- Xác nhận số lượng craft hàng loạt (craft x1, x5, x tối đa theo nguyên
  liệu)
- Liên kết trực quan tới giai đoạn "Thợ thủ công" trong [[Progression]] —
  cột mốc chuyển tiếp đầu tiên

## Câu hỏi mở
- Crafting UI mở dạng cửa sổ riêng hay tích hợp trực tiếp trong Inventory
  (giống lưới 2x2/3x3 kiểu Minecraft)?
- Có hiển thị gợi ý công thức sắp mở khóa để định hướng người chơi tiến bộ
  không?

## Liên kết
- [[Inventory]]
- [[CraftingAPI]]
- [[DesignSystem]]
- [[Progression]]
