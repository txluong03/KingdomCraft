# Behaviour Tree

## Mục đích
Kiến trúc kỹ thuật dùng chung (behaviour tree hoặc state machine) để định
nghĩa hành vi cho mọi loại AI (Villager, Enemy, Animal, Boss), tránh mỗi
loại AI viết logic rời rạc không tái sử dụng được.

## Nội dung cần điền
- Mô hình node đề xuất (Selector, Sequence, Action, Condition...)
- Cách [[VillagerAI]], [[EnemyAI]], [[AnimalAI]], [[BossAI]] cùng tái sử
  dụng một framework chung
- Kế hoạch thay thế/mở rộng logic switch-case hiện tại trong
  `AutomationSystem.Tick` bằng behaviour tree
- Công cụ debug/visualize hành vi NPC khi phát triển
- Hiệu năng khi hàng trăm NPC chạy tree mỗi tick cùng lúc

## Câu hỏi mở
- Có nên tách hẳn behaviour tree khỏi vòng lặp `AutomationSystem` hiện tại
  hay tích hợp chung một hệ thống tick duy nhất?
- Độ phức tạp behaviour tree có nên tăng dần theo `AutomationLevel` (NPC
  "thông minh" hơn khi vương quốc phát triển) để phản ánh đúng USP không?

## Liên kết
[[VillagerAI]] · [[PathFinding]] · [[KingdomSystem]] · [[Schedule]]
