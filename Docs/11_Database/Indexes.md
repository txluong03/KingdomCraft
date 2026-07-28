# Indexes — KingdomCraft

## Mục đích
Định hướng index cần thiết cho các bảng ở [[Tables]] khi có truy vấn thật
(multiplayer, nhiều Kingdom đồng thời). **Định hướng tương lai**: chưa có DB
engine nào được chọn nên chưa thể định index cụ thể — file này chỉ phác
thảo nguyên tắc và các truy vấn dự kiến.

## Nội dung cần điền
- Truy vấn tần suất cao dự kiến: load Kingdom theo `OwnerPlayerId`, load
  Npcs/Buildings theo `KingdomId`
- Index candidate: `KingdomId` trên bảng Npcs/Buildings, `OwnerPlayerId`
  trên Kingdoms
- Composite index cho truy vấn theo `Role` trong 1 Kingdom (VD: đếm NPC
  active để tính `AutomationLevel`)
- Unique constraint: tên tài khoản/email khi có [[Authentication]]
- Cân nhắc index cho tìm kiếm theo `Position` (spatial) khi world lớn
- Trade-off giữa tốc độ đọc (nhiều index) và tốc độ ghi (tick liên tục cập
  nhật resource/NPC)

## Câu hỏi mở
- `AutomationSystem.Tick` hiện chạy mỗi giây và ghi Resources liên tục —
  nếu Resources persist vào DB thật, có cần batch/throttle ghi để tránh quá
  tải index?
- Có cần bảng time-series riêng cho lịch sử tài nguyên (phục vụ biểu đồ
  kinh tế) tách khỏi bảng trạng thái hiện tại?

## Liên kết
- [[Tables]]
- [[Performance]]
- [[SaveGame]]
