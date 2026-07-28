# Multiplayer Tests — KingdomCraft

## Mục đích
Kiểm tra networking và đồng bộ trạng thái nhiều người chơi/nhiều vương
quốc — hiện chưa áp dụng được đầy đủ vì `KingdomCraft.Server` mới là vòng
lặp `Task.Delay` demo, chưa có networking thật (xem [[DevelopmentRoadmap]]).

## Nội dung cần điền
- Kịch bản test khi có networking thật: 2+ client kết nối cùng server
- Test đồng bộ `KingdomState` giữa các client
- Test độ trễ (latency) chấp nhận được cho hành động đặt/phá khối
- Test disconnect/reconnect giữa chừng
- Test race condition khi nhiều người chơi thao tác cùng tài nguyên/công trình
- Test validate phía server, không tin dữ liệu client (liên hệ [[AntiCheat]])
- Điều kiện tiên quyết trước khi viết test này (Sprint 6+, xem [[Milestones]])

## Câu hỏi mở
- Có cần giả lập nhiều client tự động (bot) hay test thủ công là đủ ở giai đoạn đầu?
- Ngưỡng số người chơi đồng thời mục tiêu ban đầu là bao nhiêu?

## Liên kết
- [[Milestones]]
- [[AntiCheat]]
- [[PerformanceTests]]
- [[DevelopmentRoadmap]]
