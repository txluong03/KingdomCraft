# Multiplayer Flow — KingdomCraft

## Mục đích
Mô tả luồng chơi nhiều người trên kiến trúc client-server (Core Scope theo
[[ProjectScope]]), bao gồm cách nhiều vương quốc của nhiều người chơi cùng
tồn tại và tương tác — nền tảng cho phần "Politics" (ngoại giao, chiến
tranh) đã nêu ở [[KingdomSystem]] và thuộc Extended Scope (War/Diplomacy).

## Nội dung cần điền
- Mô hình phòng/server (mỗi server một thế giới chung, hay nhiều thế giới riêng biệt)
- Luồng tạo/tham gia vương quốc: một người chơi luôn có đúng một vương quốc, hay có thể tham gia vương quốc người khác làm NPC/thành viên
- Tương tác trực tiếp giữa người chơi (giao dịch, trade, PvP tự phát) — liên hệ [[Economy]], [[Combat]]
- Ngoại giao/chiến tranh giữa các vương quốc (liên minh, hiệp ước, tuyên chiến) — Extended Scope, cần mức độ chi tiết tối thiểu ở bản đầu
- Đồng bộ hóa trạng thái mô phỏng NPC giữa các người chơi (ai thấy `AutomationSystem.Tick` chạy, tần suất đồng bộ)
- Quyền quản trị/kiểm duyệt server (chủ vương quốc mời/kick thành viên)

## Câu hỏi mở
- Nhiều người chơi có thể cùng quản lý một vương quốc (co-op quản lý) hay mỗi người chơi bắt buộc một vương quốc riêng và chỉ tương tác qua ngoại giao/thương mại?
- Chiến tranh giữa vương quốc có ảnh hưởng tới AutomationLevel của bên thua (phá hủy công trình quản lý, giảm tự động hóa) không?

## Liên kết
[[KingdomSystem]] · [[Economy]] · [[Combat]] · [[ProjectScope]]
