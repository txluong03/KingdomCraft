# Building UI — KingdomCraft

## Mục đích
Thiết kế giao diện đặt/quản lý công trình (Building) — chọn loại công
trình, xem chi phí, đặt vị trí, quản lý công trình đã xây. Đối chiếu
`BuildingType` thật trong code: TownHall, Farm, LumberMill, Mine, Barracks,
Market, House, Wall, Custom.

## Nội dung cần điền
- Menu chọn loại công trình để xây, hiển thị chi phí tài nguyên và điều
  kiện mở khóa
- Chế độ đặt công trình trong world (ghost preview, snap lưới, kiểm tra vị
  trí hợp lệ)
- Panel quản lý 1 công trình đã chọn: Level, NPC đang quản lý
  (`AssignedNpcId`), nâng cấp
- Hiển thị trạng thái công trình (đang hoạt động, thiếu NPC quản lý, cần
  nâng cấp)
- Danh sách tổng quan tất cả công trình trong Kingdom (lọc theo loại,
  trạng thái)
- Cảnh báo khi thiếu tài nguyên hoặc vị trí không hợp lệ khi đặt công
  trình

## Câu hỏi mở
- Đặt công trình dùng lưới voxel y hệt block (snap theo world) hay có
  footprint riêng linh hoạt hơn?
- Giao diện quản lý công trình có tích hợp luôn thao tác bổ nhiệm NPC hay
  chuyển sang màn hình NPC riêng ([[KingdomUI]])?

## Liên kết
- [[KingdomUI]]
- [[DesignSystem]]
- [[KingdomAPI]]
- [[KingdomSystem]]
