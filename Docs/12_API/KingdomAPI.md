# Kingdom API — KingdomCraft

## Mục đích
Phác thảo API thao tác với `KingdomState` (Name, AutomationLevel,
Buildings, Npcs, Resources). **Định hướng tương lai**: hiện các thao tác
này chỉ chạy nội bộ qua `AutomationSystem.Tick` trong vòng lặp Server, chưa
có endpoint nào để client gọi.

## Nội dung cần điền
- Endpoint lấy trạng thái Kingdom hiện tại (AutomationLevel, Resources,
  danh sách Buildings/Npcs)
- Endpoint xây dựng công trình mới (tạo `Building`, trừ tài nguyên tương
  ứng)
- Endpoint bổ nhiệm/đổi vai trò NPC (set `Npc.Role`, liên hệ [[NPCAPI]])
- Endpoint đổi tên Kingdom, xem lịch sử AutomationLevel theo thời gian
- Cơ chế server-authoritative: mọi thay đổi AutomationLevel phải qua
  `AutomationSystem`, client không tự set trực tiếp
- Phân trang/lọc khi Kingdom có nhiều Building/Npc (multiplayer, late game)

## Câu hỏi mở
- Client có cần subscribe realtime khi AutomationLevel/Resources thay đổi
  (mỗi tick) thay vì poll REST không (xem [[Synchronization]])?
- 1 request "xây công trình" xử lý đồng bộ ngay hay đưa vào hàng đợi xử lý
  ở tick tiếp theo?

## Liên kết
- [[NPCAPI]]
- [[Synchronization]]
- [[KingdomSystem]]
- [[ErrorCodes]]
