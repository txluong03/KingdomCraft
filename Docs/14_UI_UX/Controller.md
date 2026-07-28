# Controller (Gamepad) — KingdomCraft

## Mục đích
Định hướng hỗ trợ điều khiển bằng tay cầm (gamepad) song song với bàn
phím/chuột — đối chiếu control scheme hiện có ở [[Controls]] (GDD), mở
rộng cho input device khác.

## Nội dung cần điền
- Sơ đồ ánh xạ nút gamepad tương ứng hành động (di chuyển, đặt/phá khối,
  mở Inventory/Crafting/KingdomUI)
- Điều hướng UI bằng D-pad/analog stick (focus, chọn, back) cho các màn
  hình dạng lưới (Inventory, Crafting)
- Rung phản hồi (haptic feedback) cho hành động quan trọng (mất máu, xây
  xong công trình)
- Tùy chỉnh lại phím (remapping) cho gamepad, lưu theo profile
- Hỗ trợ nhiều loại gamepad (Xbox, PlayStation, generic) và hiển thị icon
  nút tương ứng
- Chế độ chơi song song bàn phím + gamepad (chuyển đổi tức thời khi đổi
  input)

## Câu hỏi mở
- KingdomUI/BuildingUI vốn nhiều thao tác dạng chuột (kéo-thả, click chính
  xác vị trí xây) — có khả thi điều khiển tốt bằng gamepad hay cần thiết
  kế lại luồng riêng cho controller?
- Console port có nằm trong Core Scope sớm hay chỉ Extended Scope (xem
  [[ProjectScope]]), ảnh hưởng mức đầu tư cho file này?

## Liên kết
- [[Controls]]
- [[Settings]]
- [[Accessibility]]
- [[ProjectScope]]
