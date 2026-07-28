# Villager AI

## Mục đích
AI cho NPC dân thường (`NpcRole`: Farmer, Lumberjack, Miner, Merchant,
Steward) — trái tim kỹ thuật của cơ chế chuyển giao công việc, mở rộng từ
`AutomationSystem.Tick` hiện có trong `src/KingdomCraft.Core/Simulation/`.

## Nội dung cần điền
- Vòng lặp quyết định của NPC theo `Role` (hiện là switch-case đơn giản
  cộng tài nguyên theo `SkillLevel` mỗi tick — cần mở rộng thành hành vi
  thật)
- Cách NPC chọn vị trí làm việc và di chuyển tới đó (liên hệ [[PathFinding]])
- Hành vi ngoài giờ làm việc (liên hệ [[Schedule]])
- Phản ứng khi thiếu nguyên liệu/công cụ/công trình cần thiết
- Hành vi riêng của Steward (không sản xuất, quản lý/đề xuất)
- Mức độ phức tạp AI tăng dần theo `AutomationLevel` (0-30/30-70/70-100 đã
  đề xuất ở [[KingdomSystem]])

## Câu hỏi mở
- Cơ chế NPC tự tăng `SkillLevel` qua thời gian làm việc (đề xuất ở
  [[SkillSystem]] nhưng chưa có trong code) tính theo tick hay theo sản
  lượng tích lũy?
- Ở mức `AutomationLevel` 70-100, giới hạn nào cho việc NPC "tự đề xuất"
  xây công trình để tránh AI tự ý phá vỡ ý đồ người chơi?

## Liên kết
[[KingdomSystem]] · [[Schedule]] · [[BehaviourTree]] · [[PathFinding]]
