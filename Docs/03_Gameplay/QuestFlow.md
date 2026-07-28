# Quest Flow — KingdomCraft

## Đã cài đặt (2026-07-28, `QuestAppService`)
3 quest khởi đầu, mỗi quest gắn trực tiếp với 1 mốc đầu của [[Progression]]
(đúng mục tiêu "dẫn dắt người chơi qua các cột mốc"):

| QuestId | Tiêu đề | Điều kiện hoàn thành (`QuestObjectiveType`) | Mốc Progression |
|---|---|---|---|
| `quest_first_tool` | Chế tạo công cụ đầu tiên | Có ≥1 item `Tool` trong `Player.Inventory` | Thợ thủ công |
| `quest_first_building` | Xây công trình sản xuất đầu tiên | `KingdomState.Buildings` có ≥1 công trình khác `TownHall` | Chủ trang trại |
| `quest_first_npc` | Tuyển NPC đầu tiên | `KingdomState.Npcs.Count` ≥ 1 | Trưởng làng |

Cơ chế: `QuestAppService.EvaluateQuests()` chấm lại toàn bộ quest chưa
hoàn thành mỗi lần gọi (không phải event-driven), đánh dấu hoàn thành vào
`Player.QuestLog`, trả về danh sách quest **vừa mới** hoàn thành lần gọi
này. `GetQuestLog()` trả toàn bộ trạng thái (hoàn thành/chưa) để hiển thị.

## Nội dung cần điền (chưa cài đặt)
- Nhiệm vụ chính đầy đủ cho các mốc Lãnh chúa → Đế quốc (hiện chỉ có 3
  mốc đầu).
- Nhiệm vụ phụ (side quest) từ NPC/thương nhân/sự kiện.
- Nhiệm vụ lặp lại/hàng ngày (daily).
- Cấu trúc phần thưởng nhiệm vụ (tài nguyên, NPC mới, danh vọng — liên hệ
  [[ReputationSystem]]) — hiện hoàn thành quest không có phần thưởng gì.
- Giao diện theo dõi nhiệm vụ (nhật ký, chỉ dẫn).
- Nhiệm vụ phân nhánh theo lựa chọn quản lý vương quốc.

## Câu hỏi mở
- `EvaluateQuests()` chấm theo kiểu "poll mỗi lần gọi" có đủ hay cần
  event-driven (VD: chấm ngay khi Craft/RecruitNpc/CreateBuilding thành
  công) khi tích hợp UI thật?
- Nhiệm vụ chính có nên ép buộc "giao việc cho NPC" hay để tự nhiên xuất
  hiện từ nhu cầu quản lý?

## Liên kết
[[Progression]] · [[NPCFlow]] · [[CraftingFlow]] · [[BuildingFlow]] · [[ReputationSystem]]
