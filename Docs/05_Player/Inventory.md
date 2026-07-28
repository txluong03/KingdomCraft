# Inventory

## Mục đích
Định hình đầy đủ hệ thống túi đồ người chơi — hiện chỉ là
`Dictionary<string, int>` đơn giản trong `Player.cs` — làm nền trước khi mở
rộng [[Equipment]] và hệ thống chế tạo.

## Nội dung cần điền
- Giới hạn số ô/khối lượng mang theo (có giới hạn hay không)
- Cách stack vật phẩm cùng loại
- Phân loại vật phẩm (nguyên liệu, công cụ, trang bị, vật phẩm quý)
- Ranh giới giữa túi đồ cá nhân và kho tài nguyên chung của vương quốc
  (`KingdomState.Resources`)
- Lộ trình chuyển từ mô hình `Dictionary<string,int>` hiện tại sang item
  instance (durability, thuộc tính riêng) nếu cần trong tương lai
- Giao diện quản lý túi đồ

## Câu hỏi mở
- Khi `AutomationLevel` cao, tài nguyên NPC sản xuất có đổ thẳng vào kho
  vương quốc (bỏ qua Inventory cá nhân) không — ranh giới hai kho nằm ở đâu?
- Có cần giới hạn slot để tạo áp lực sinh tồn ở giai đoạn đầu, hay bỏ giới
  hạn ngay từ đầu vì đây không phải trọng tâm gameplay của KingdomCraft?

## Liên kết
[[Equipment]] · [[KingdomSystem]] · [[Recipes]] · [[Stats]]
