# Save Game — KingdomCraft

## Mục đích
Định hướng cơ chế lưu/tải trạng thái game (save/load). **Định hướng tương
lai — quan trọng**: hiện `KingdomState`/`Npc`/`Building` chỉ tồn tại trong
bộ nhớ khi Server chạy (vòng lặp `while(true)` trong `Program.cs`); tắt
server (kể cả Ctrl+C) làm mất toàn bộ tiến trình, chưa có bất kỳ cơ chế
persist nào.

## Nội dung cần điền
- Tần suất auto-save (theo tick, theo khoảng thời gian, theo sự kiện quan
  trọng)
- Định dạng lưu: JSON snapshot toàn bộ `KingdomState`, hay ghi liên tục
  từng bảng vào DB
- Save thủ công (người chơi bấm Save) vs auto-save vs save khi thoát đột
  ngột (Ctrl+C hiện chỉ dừng vòng lặp, không lưu gì)
- Khôi phục sau crash — cần transaction/checkpoint để tránh save dở dang
- Multiplayer: save theo từng Kingdom hay theo cả server (nhiều Kingdom
  cùng lúc)?
- Nén/versioning file save khi schema đổi (liên hệ [[Migration]])

## Câu hỏi mở
- Chọn kiến trúc "Server luôn ghi DB trực tiếp" (state = DB) hay "Server
  chạy in-memory rồi snapshot định kỳ" (giống hiện tại nhưng có thêm bước
  lưu)?
- Cloud save đồng bộ nhiều thiết bị có nằm trong Core Scope hay Extended
  Scope ([[ProjectScope]])?

## Liên kết
- [[Tables]]
- [[Migration]]
- [[Architecture]]
- [[ProjectScope]]
