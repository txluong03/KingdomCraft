# NPC Flow — KingdomCraft

## Đã cài đặt (2026-07-28, `KingdomAppService`)
| Hành động | Method | Input | Output |
|---|---|---|---|
| Tuyển NPC | `RecruitNpc` | `RecruitNpcInput{Name?, Role, SkillLevel?}` | `NpcDto` |
| Bổ nhiệm vai trò | `AssignNpcRole` | `AssignNpcRoleInput{NpcId, Role}` | `NpcDto` (lỗi nếu `NpcId` không tồn tại) |
| Huấn luyện/thăng cấp | `TrainNpc` | `TrainNpcInput{NpcId, SkillIncrease?}` | `NpcDto` (`SkillLevel` tăng thêm, mặc định +1) |

Đây là toàn bộ vòng đời NPC hiện có — **chưa có** luồng sa thải/thuyên
chuyển, chưa có UI thật (Application layer đã sẵn sàng để Client/Server
gọi khi có UI, xem [[NPC_AI]]).

## Nội dung cần điền (thiết kế UI/gameplay, chưa cài đặt)
- Luồng tuyển dụng NPC mới trong game thật: nguồn gốc (sinh ra từ
  Population, thuê từ thương nhân, giải cứu từ dungeon...) — hiện
  `RecruitNpc` chỉ là action trực tiếp, chưa gắn điều kiện/chi phí.
- Điều kiện và luồng thăng cấp lên `Steward` cụ thể (yêu cầu `SkillLevel`
  tối đa + danh vọng?) — `AssignNpcRole` hiện cho phép gán Steward tự do,
  không kiểm tra điều kiện.
- Hiển thị thông tin NPC cho người chơi (UI bảng thông tin).
- Luồng sa thải/thuyên chuyển NPC.
- Phản hồi trực quan khi NPC đang làm việc (animation, `Position`) — phụ
  thuộc [[VillagerAI]]/[[PathFinding]] chưa cài đặt.

## Câu hỏi mở
- Người chơi có thể đặt tên, tùy biến NPC để tăng gắn kết, hay NPC chỉ là
  đơn vị sản xuất trừu tượng?
- Khi thăng Steward, NPC còn hiển thị/di chuyển trong world hay chuyển
  sang trạng thái quản lý trừu tượng (chỉ trong UI vương quốc)?

## Liên kết
[[KingdomSystem]] · [[VillagerAI]] · [[Schedule]] · [[ReputationSystem]]
