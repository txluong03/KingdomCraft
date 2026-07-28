# NPC API — KingdomCraft

## Mục đích
Phác thảo API quản lý NPC (`Npc.Id`, `Name`, `Role`, `SkillLevel`,
`Position`). **Định hướng tương lai**: hiện các thao tác bổ nhiệm/thăng cấp
NPC chưa có endpoint nào — chỉ tồn tại như thay đổi field trực tiếp trong
object bộ nhớ qua `AutomationSystem`.

## Nội dung cần điền
- Endpoint lấy danh sách NPC của 1 Kingdom, lọc theo Role
- Endpoint bổ nhiệm vai trò (đổi `NpcRole` từ Idle sang vai trò cụ thể)
- Endpoint huấn luyện/tăng SkillLevel (nếu có công trình đào tạo)
- Endpoint thăng cấp NPC lên Steward (điều kiện đặc biệt, xem
  [[KingdomSystem]])
- Endpoint xem lịch làm việc (Schedule) khi NPC tự tối ưu ca làm
  (AutomationLevel 30–70 theo [[KingdomSystem]])
- Tách rõ API "người chơi ra lệnh" và trạng thái NPC "tự quyết định" (khi
  AutomationLevel cao, NPC/Steward tự đề xuất)

## Câu hỏi mở
- Ở AutomationLevel cao, NPC tự đề xuất xây dựng — có cần endpoint riêng
  cho "đề xuất chờ duyệt" (approve/reject) không?
- SkillLevel tăng qua API riêng hay tự động trong Tick, API chỉ để đọc?

## Liên kết
- [[KingdomAPI]]
- [[KingdomSystem]]
- [[Schedule]]
- [[ErrorCodes]]
