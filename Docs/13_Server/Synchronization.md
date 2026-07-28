# Synchronization — KingdomCraft

## Mục đích
Định hướng cơ chế đồng bộ trạng thái giữa Server (authoritative) và nhiều
Client. **Định hướng tương lai**: hiện chưa có multiplayer thật nên chưa có
đồng bộ nào — `AutomationSystem.Tick` hiện chỉ chạy đơn lẻ trong 1 tiến
trình, không gửi gì ra ngoài.

## Nội dung cần điền
- Mô hình đồng bộ: server-authoritative hoàn toàn (client chỉ gửi input,
  server tính AutomationLevel/Resources) — đối chiếu nguyên tắc "mọi thay
  đổi trạng thái đi qua 1 điểm rõ ràng" ở [[CodingConvention]]
- Tần suất đồng bộ theo loại dữ liệu: Resources/AutomationLevel (chậm, theo
  tick) vs Position người chơi (nhanh, realtime)
- Delta sync (chỉ gửi phần thay đổi) thay vì gửi toàn bộ `KingdomState` mỗi
  lần
- Xử lý độ trễ: client-side prediction, interpolation cho di chuyển
- Đồng bộ khi 1 client mới join giữa phiên (full state snapshot ban đầu)
- Xung đột khi 2 client cùng thao tác 1 tài nguyên/công trình cùng lúc

## Câu hỏi mở
- Có cần client-side prediction cho di chuyển Player hay chấp nhận độ trễ
  để đơn giản hóa (phù hợp game xây dựng, không phải FPS nhanh)?
- Tick `AutomationSystem` hiện tại (1 giây, toàn cục) có nên tách theo từng
  Kingdom để đồng bộ độc lập giữa các phiên multiplayer khác nhau?

## Liên kết
- [[Network]]
- [[Architecture]]
- [[KingdomAPI]]
- [[Performance]]
