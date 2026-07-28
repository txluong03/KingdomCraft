# Server Architecture — KingdomCraft

## Mục đích
Định hướng kiến trúc server multiplayer thật cho KingdomCraft. **Định
hướng tương lai — quan trọng**: hiện `KingdomCraft.Server/Program.cs` CHỈ
là vòng lặp `while(true) { automation.Tick(kingdom); await
Task.Delay(1000); }` chạy 1 `KingdomState` cứng trong bộ nhớ, KHÔNG có
networking, chưa tách layer, chưa áp dụng Clean Architecture đề cập ở
[[CodingConvention]].

## Nội dung cần điền
- Áp dụng Clean Architecture: Core (đã có) → Application (use case, chưa
  có) → Infrastructure (DB/network, chưa có) → Presentation (Server entry
  point hiện tại)
- Mô hình chạy: 1 tiến trình server cho nhiều Kingdom (multi-tenant) hay
  mỗi Kingdom 1 instance riêng
- Vòng lặp Tick hiện tại (1 giây/lần, đơn luồng) có đủ khi số Kingdom/NPC
  tăng — cần tick theo từng Kingdom độc lập hay tick toàn cục
- Ranh giới giữa Server (authoritative simulation) và Client (render,
  input) — client không tự tính AutomationLevel
- Thành phần cần thêm: networking layer, connection manager, session theo
  từng player
- Khả năng mở rộng ngang (scale-out nhiều server instance) khi số lượng
  Kingdom lớn

## Câu hỏi mở
- Server chạy dạng monolith đơn giản (phù hợp team nhỏ) hay tách
  microservice (auth, game logic, save) ngay từ đầu?
- Vòng lặp Tick cố định 1000ms hiện tại có nên thay bằng tick rate cấu hình
  được / biến thiên theo tải?

## Liên kết
- [[Network]]
- [[Synchronization]]
- [[Performance]]
- [[DevelopmentRoadmap]]
