# HUD — KingdomCraft

## Mục đích
Thiết kế lớp thông tin hiển thị liên tục trong lúc chơi (Heads-Up Display)
— chỉ số tức thời của Player (Health, Hunger) và tổng quan Kingdom
(AutomationLevel, tài nguyên chính) mà không cần mở menu riêng.

## Nội dung cần điền
- Thanh Health/Hunger của Player (đối chiếu `Player.Health`,
  `Player.Hunger` trong code)
- Chỉ số AutomationLevel rút gọn (thanh/số) luôn hiển thị để nhắc nhở trục
  tiến trình cốt lõi
- Tổng quan tài nguyên Kingdom (Food/Wood/Stone/Gold) dạng rút gọn, mở rộng
  khi cần
- Thanh hotbar vật phẩm/công cụ đang cầm (liên hệ [[Inventory]] UI)
- Thông báo tạm thời (toast) khi có sự kiện: NPC mới, công trình hoàn
  thành, tài nguyên cạn
- Mức độ ẩn/hiện HUD tùy chỉnh được (chế độ chụp ảnh, giảm rối mắt)
- Khác biệt hiển thị theo giai đoạn Progression (VD: HUD "Người sống sót"
  đơn giản hơn HUD "Vua")

## Câu hỏi mở
- HUD có thay đổi bố cục/độ phức tạp theo từng giai đoạn tiến trình (Người
  sống sót → Đế quốc) hay giữ cố định và chỉ thêm số liệu?
- AutomationLevel hiển thị dạng số phần trăm, thanh tiến trình, hay biểu
  tượng trực quan (VD: hình ảnh NPC dần thay thế người chơi)?

## Liên kết
- [[DesignSystem]]
- [[Inventory]]
- [[KingdomUI]]
- [[KingdomSystem]]
