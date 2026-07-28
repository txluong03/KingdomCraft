# Kingdom System — KingdomCraft

> Đây là mảng khác biệt cốt lõi của KingdomCraft so với Minecraft — tài
> liệu chi tiết nhất trong toàn bộ GDD. Tham chiếu code:
> `src/KingdomCraft.Core/Kingdom/KingdomState.cs`,
> `src/KingdomCraft.Core/Simulation/AutomationSystem.cs`,
> `src/KingdomCraft.Core/Entities/Npc.cs`.

## AutomationLevel
Chỉ số 0 (tự làm 100%) → 100 (NPC tự vận hành hoàn toàn). Công thức hiện
tại trong code (tạm thời, cần tinh chỉnh khi playtest):

```
AutomationLevel = min(100, activeNpcCount * 5 + stewardCount * 10)
```

trong đó `activeNpcCount` là số NPC có `Role != Idle`. Hướng tinh chỉnh cần
cân nhắc:
- Trọng số nên phụ thuộc `SkillLevel` của NPC, không chỉ đếm đầu người.
- Công trình quản lý (Steward's Hall, Town Hall nâng cấp) nên cộng thêm hệ
  số riêng ngoài số lượng NPC.
- Cần độ trễ/quán tính (không tăng/giảm tức thời) để cảm giác "xây dựng bộ
  máy" thay vì bật công tắc.

## Vai trò NPC (NpcRole)
| Vai trò | Sản xuất | Ghi chú |
|---|---|---|
| Idle | Không | Chưa được giao việc |
| Farmer | Food | |
| Lumberjack | Wood | |
| Miner | Stone | |
| Merchant | Gold | Liên hệ [[Economy]] |
| Soldier | — | Chiến đấu, phòng thủ (xem [[Combat]]) |
| Steward | — | Không sản xuất trực tiếp, tăng `AutomationLevel` mạnh nhất — đại diện cho "quản gia" giúp người chơi rút khỏi công việc tay chân |

## Bổ nhiệm, huấn luyện, thăng cấp NPC
- Bổ nhiệm: gán `Role` cho NPC đang `Idle`.
- Huấn luyện: tăng `SkillLevel` theo thời gian làm việc hoặc qua công trình
  đào tạo (đề xuất, chưa có trong code).
- Thăng cấp lên Steward: yêu cầu điều kiện đặc biệt (VD: kỹ năng tối đa ở
  1 vai trò + danh vọng, xem [[ReputationSystem]]) — cần quyết định cụ thể.

## Các trục quản lý vương quốc
- **Population** — dân số, tăng theo nhà ở (`Housing`) và Food dư.
- **Tax** — thu từ dân số/thương mại, ảnh hưởng `Happiness`.
- **Food** — sản xuất bởi Farmer, tiêu thụ bởi dân số + quân đội.
- **Army** — đơn vị quân, xem [[Combat]].
- **Housing** — giới hạn dân số tối đa.
- **Happiness** — ảnh hưởng hiệu suất NPC và nguy cơ sự kiện tiêu cực.
- **Production** — tổng sản lượng công trình + NPC.
- **Research** — tiến độ [[TechnologyTree]].
- **Trade** — giao thương với NPC/vương quốc khác, xem [[Economy]].
- **Politics** — ngoại giao, liên minh, chiến tranh giữa vương quốc (xem
  [[MultiplayerFlow]]).

## NPC tự ra quyết định ở mức nào? (câu hỏi mở, cần chốt)
Đề xuất chia theo `AutomationLevel`:
- 0–30: NPC chỉ sản xuất theo vai trò được gán thủ công.
- 30–70: NPC tự tối ưu ca làm việc (Schedule) nhưng người chơi vẫn quyết
  định xây gì.
- 70–100: NPC (qua Steward) có thể tự đề xuất/xây công trình mới, người
  chơi chỉ phê duyệt hoặc để mặc định.

## Sự kiện ngẫu nhiên khi tự động hóa cao
Rủi ro cần có để tránh late-game nhàm chán: nổi loạn (Happiness thấp),
thiên tai, thương nhân/quân xâm lược. Xem [[Events]], [[RiskManagement]].

## Liên kết
[[Progression]] · [[Economy]] · [[NPCFlow]] · [[VillagerAI]] · [[Schedule]]
