# Design System — KingdomCraft

## Mục đích
Định hướng hệ thống thiết kế UI chung (màu sắc, typography, component tái
sử dụng) làm nền tảng cho các màn hình cụ thể (HUD, Inventory, Crafting,
Building, Kingdom...).

## Nội dung cần điền
- Bảng màu chủ đạo và ý nghĩa (VD: màu cảnh báo Happiness/Health thấp, màu
  vàng cho Gold/tài nguyên)
- Typography: font chữ, kích thước theo cấp độ (tiêu đề, nhãn, số liệu)
- Component tái sử dụng: nút bấm, thanh progress (Health/Hunger/
  AutomationLevel), tooltip, panel/modal chung
- Icon set cho tài nguyên (Food, Wood, Stone, Gold...), vai trò NPC, loại
  công trình — đối chiếu đúng enum thật trong code (`BuildingType`,
  `NpcRole`)
- Quy tắc bố cục lưới (grid/spacing) áp dụng chung cho mọi màn hình
- Style guide cho trạng thái (hover, disabled, selected, error)
- Định hướng phong cách hình ảnh tổng thể (liên hệ [[ArtDirection]])

## Câu hỏi mở
- Phong cách UI hướng theo tối giản/hiện đại hay theo phong cách trung
  cổ/fantasy phù hợp chủ đề "vương quốc"?
- Design system có tách riêng theo nền tảng (PC/Console) hay dùng chung 1
  bộ scale theo màn hình?

## Liên kết
- [[HUD]]
- [[KingdomUI]]
- [[Accessibility]]
- [[ProjectVision]]
