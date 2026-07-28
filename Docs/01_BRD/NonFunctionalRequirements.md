# Non-Functional Requirements — KingdomCraft

## Mục đích
Ghi lại các yêu cầu phi chức năng (hiệu năng, khả năng mở rộng, độ ổn
định) mà kiến trúc thế giới voxel vô hạn theo chunk và hệ mô phỏng NPC
(`AutomationSystem.Tick`) phải đáp ứng, để không bị bỏ sót cho tới khi có
vấn đề hiệu năng thật khi số lượng NPC/công trình tăng lên ở giai đoạn Đế
quốc.

## Nội dung cần điền
- Yêu cầu hiệu năng client (FPS mục tiêu, số chunk render cùng lúc) trong thế giới vô hạn
- Yêu cầu hiệu năng mô phỏng server khi số NPC mỗi vương quốc lớn (Tick loop trong `AutomationSystem`) — giới hạn NPC/công trình mỗi tick
- Yêu cầu về độ trễ mạng chấp nhận được cho multiplayer (đối chiếu [[MultiplayerFlow]], [[Server]] nếu có)
- Yêu cầu về khả năng mở rộng dữ liệu (số vương quốc, số người chơi đồng thời trên một server)
- Yêu cầu về độ ổn định lưu trữ (world save không bị hỏng khi crash giữa tick mô phỏng)
- Yêu cầu về nền tảng hỗ trợ (cấu hình máy tối thiểu/đề xuất)
- Yêu cầu bảo mật cơ bản cho multiplayer (chống gian lận tài nguyên, chống duplicate item)

## Câu hỏi mở
- Mô phỏng NPC nên chạy đồng bộ theo Tick cố định hay theo thời gian thực (đối chiếu ghi chú "2 khái niệm Tick/Turn song song" ở [[Glossary]]) — quyết định này ảnh hưởng trực tiếp tới yêu cầu hiệu năng server?
- Giới hạn NPC tối đa mỗi vương quốc nên được quyết định bởi yêu cầu hiệu năng hay bởi cân bằng gameplay trước?

## Liên kết
[[FunctionalRequirements]] · [[KingdomSystem]] · [[MultiplayerFlow]] · [[RiskManagement]]
