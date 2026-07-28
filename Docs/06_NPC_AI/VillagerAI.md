# Villager AI

## Đã cài đặt trong code (2026-07-28, qua `KingdomAppService`)
- **Bổ nhiệm** (`AssignNpcRole`): gán `NpcRole` cho NPC đã tuyển
  (`RecruitNpc`).
- **Huấn luyện/thăng cấp** (`TrainNpc`): tăng `SkillLevel` thêm N (mặc
  định +1) — hiện thực hóa "Huấn luyện: tăng SkillLevel theo thời gian làm
  việc" đã phác thảo ở [[KingdomSystem]], nhưng **kích hoạt thủ công qua
  action của người chơi**, chưa tự động theo thời gian làm việc thật (cần
  tick/thời gian thực để làm đúng nghĩa "theo thời gian", xem câu hỏi mở).
- Sản xuất theo `Role` mỗi tick: vẫn là switch-case đơn giản trong
  `AutomationSystem.Tick` (Farmer→food, Lumberjack→wood, Miner→stone,
  Merchant→gold theo `SkillLevel`) — chưa đổi từ trước.

## Chưa cài đặt (giữ nguyên định hướng khung)
- Vòng lặp quyết định AI thật (di chuyển, chọn vị trí làm việc) — phụ
  thuộc [[PathFinding]], hiện NPC không di chuyển trong World voxel.
- Hành vi ngoài giờ làm việc — phụ thuộc [[Schedule]] (đang Blocked).
- Phản ứng khi thiếu nguyên liệu/công cụ/công trình cần thiết.
- Hành vi riêng của Steward (không sản xuất, quản lý/đề xuất) — hiện
  Steward chỉ ảnh hưởng công thức `AutomationLevel`, không có hành vi AI
  riêng.
- 3 mức độ phức tạp AI theo `AutomationLevel` (0-30/30-70/70-100, đề xuất
  ở [[KingdomSystem]]) — hiện tại chỉ có 1 mức (switch-case cố định).

## Câu hỏi mở
- `TrainNpc` nên tự động hóa theo tick (VD: mỗi N tick làm việc liên tục
  +1 `SkillLevel`) thay vì action thủ công — làm ở bước nào?
- Ở mức `AutomationLevel` 70-100, giới hạn nào cho việc NPC "tự đề xuất"
  xây công trình để tránh AI tự ý phá vỡ ý đồ người chơi?

## Liên kết
[[KingdomSystem]] · [[Schedule]] · [[BehaviourTree]] · [[PathFinding]] · [[NPCFlow]]
