# Development Roadmap — KingdomCraft

Lộ trình kỹ thuật (thứ tự module nên code), khác với [[ProductRoadmap]] là
lộ trình trải nghiệm người chơi. Thứ tự dưới đây phản ánh **hiện trạng repo**
(xem `F:\KingdomCraft\src`), không phải liệt kê lý tưởng chung chung.

## Bước 0 — Dọn nền tảng ✅ Đã xong (2026-07-28)
Trước đây code có **2 bộ model song song chưa hợp nhất** (`Models/`+
`Services/GameEngine` turn-based vs `Kingdom/`+`Entities/`+
`Simulation/AutomationSystem` role-based). Đã xử lý theo đúng quyết định ở
[[Decisions]]:
- Giữ hướng `Kingdom/`+`Entities/`+`Simulation` (role-based NPC +
  `AutomationLevel`) — đúng tinh thần [[ProjectVision]].
- Gộp ý hay của bộ cũ: `Building.GetProductionPerTurn()` →
  `Building.GetProductionPerTick()` (namespace `Kingdom`), gọi trong
  `AutomationSystem.Tick` song song với sản xuất theo `NpcRole` — công
  trình (Farm/Mine/LumberMill) giờ tự sản xuất thụ động theo `Level`, độc
  lập với NPC được gán.
- Xóa `Models/`, `Services/`, project mồ côi `KingdomCraft.Game`,
  `GameEngineTests.cs`; thêm test `Tick_FarmBuildingProducesFoodIndependentlyOfNpc`.
- `dotnet build` + `dotnet test` pass (3/3).

Còn để ngỏ (không thuộc Bước 0): liên kết `Building.AssignedNpcId` với sản
lượng thực tế (hiện 2 nguồn sản xuất — building và NPC theo role — độc lập
nhau, xem [[KingdomSystem]]); CI tối thiểu (`.github/` đã có nhưng chưa xác
nhận workflow build/test tự động — xem [[Milestones]] Sprint 1, [[CI_CD]]).

## Bước 1 — Core Loop tối thiểu
1. `Player` — thực thể người chơi trong Core (hiện đã có file nhưng gần trống)
2. `Inventory` cơ bản
3. World/Chunk render được ở Client (đặt/phá khối)
4. `KingdomState` + `AutomationSystem` chạy ổn định, có test

## Bước 2 — Gameplay cốt lõi
5. Crafting (recipe tối thiểu)
6. Building (mở rộng `Building`/`KingdomBuildings`)
7. NPC: bổ nhiệm, thăng cấp, lịch làm việc (`Schedule`, `VillagerAI`)
8. Quest cơ bản

## Bước 3 — Kinh tế & multiplayer
9. Economy (thị trường, thuế)
10. Multiplayer đồng bộ (`KingdomCraft.Server` + networking thật, hiện chỉ
    là vòng lặp `Task.Delay` demo)
11. Guild

## Bước 4 — Chiều sâu & PvP
12. War/Diplomacy giữa vương quốc
13. Boss/Dungeon nâng cao
14. Cây công nghệ đầy đủ

## Liên kết
[[ProductRoadmap]] · [[Milestones]] · [[CodingConvention]]
