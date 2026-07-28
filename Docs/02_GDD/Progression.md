# Progression — KingdomCraft

Đây là tài liệu cụ thể hóa trục tiến trình nêu ở [[ProjectVision]]:
`Người sống sót → Thợ thủ công → Chủ trang trại → Trưởng làng → Lãnh chúa → Vua → Đế quốc`

Mỗi giai đoạn được mở khóa bằng điều kiện cụ thể, chủ yếu dựa trên
`AutomationLevel` (xem [[KingdomSystem]]) kết hợp số công trình/NPC — cần
tinh chỉnh số liệu thật khi playtest, đây là đề xuất khởi điểm.

| Giai đoạn | Điều kiện mở khóa (đề xuất) | Trọng tâm gameplay |
|---|---|---|
| Người sống sót | Bắt đầu game | Tự đào/thu thập, sinh tồn thô sơ |
| Thợ thủ công | Chế tạo công cụ đầu tiên (xem [[CraftingFlow]]) | Mở khóa bàn chế tạo, công cụ tốt hơn tay không |
| Chủ trang trại | Xây công trình sản xuất đầu tiên (Farm/Mine/Lumberyard) | Có nguồn thu tài nguyên ổn định, không phải đào/nhặt lẻ tẻ |
| Trưởng làng | Tuyển NPC đầu tiên, `AutomationLevel` > 0 | Bắt đầu giao việc, học cách quản lý thay vì tự làm |
| Lãnh chúa | Nhiều NPC + Steward đầu tiên, `AutomationLevel` ≈ 40–60 | Quản lý nhiều công trình, bắt đầu Economy/quy hoạch |
| Vua | Mở rộng lãnh thổ/nhiều khu định cư, `AutomationLevel` ≈ 70–90 | Ngoại giao, chiến tranh, chính trị (xem [[MultiplayerFlow]]) |
| Đế quốc | `AutomationLevel` ≈ 100, nhiều vùng lãnh thổ liên kết | Nội dung endgame, mở rộng vô hạn (xem [[EndGame]]) |

## Nguyên tắc thiết kế
- Người chơi **luôn có thể quay lại tự tay làm việc** (không khóa cứng),
  nhưng không còn cần thiết ở giai đoạn sau — đánh đổi là thời gian/cơ hội,
  không phải giới hạn cứng.
- Mỗi giai đoạn nên mở khóa ít nhất 1 hệ thống mới (Talent, Reputation,
  Technology...) để tránh cảm giác "chỉ số tăng dần" nhàm chán.

## Liên kết
[[KingdomSystem]] · [[TechnologyTree]] · [[LevelSystem]] · [[EndGame]]
