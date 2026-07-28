# Controls — KingdomCraft

## Trạng thái hiện tại
Client (`KingdomCraft.Client`) hiện chỉ là placeholder console, chưa có
input thật. Nội dung dưới đây là khung thiết kế cho khi tích hợp MonoGame.

## PC (chuẩn tham khảo, giống thể loại sandbox voxel)
- WASD: di chuyển · Space: nhảy · Chuột: nhìn/tương tác
- Chuột trái: phá khối/tấn công · Chuột phải: đặt khối/tương tác NPC
- E: mở Inventory · Tab: mở Kingdom Overview (xem [[KingdomUI]])
- 1-9: hotbar

## Gamepad
- Analog trái: di chuyển · Analog phải: camera
- Trigger trái/phải: phá/đặt khối · Face button: tương tác/nhảy/inventory

## Mobile (nếu làm — xem quyết định phạm vi ở [[ProjectScope]])
- Virtual joystick + nút chạm cho hotbar/tương tác
- Cân nhắc riêng do không nằm trong Core Scope hiện tại

## Câu hỏi mở
- Có cần chế độ điều khiển riêng cho "chế độ quản lý vương quốc" (giống
  RTS/city builder, dùng chuột nhiều hơn) khi `AutomationLevel` cao không?

## Liên kết
[[HUD]] · [[KingdomUI]] · [[Accessibility]]
