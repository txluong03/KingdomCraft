# Development Roadmap — KingdomCraft

Lộ trình kỹ thuật (thứ tự module nên code), khác với [[ProductRoadmap]] là
lộ trình trải nghiệm người chơi. Thứ tự dưới đây phản ánh **hiện trạng repo**
(xem `F:\KingdomCraft\src`), không phải liệt kê lý tưởng chung chung.

## Bước 0 — Dọn nền tảng (ưu tiên trước mọi thứ khác)
Hiện code có **2 bộ model song song chưa hợp nhất**:
- `Models/` + `Services/GameEngine` (turn-based, dùng bởi `KingdomCraft.Game`
  — project này không nằm trong `.sln`)
- `Kingdom/` + `Entities/` + `Simulation/AutomationSystem` (role-based NPC,
  dùng bởi `KingdomCraft.Server`)

→ Quyết định: giữ hướng thứ 2 (role-based NPC + AutomationLevel) vì đây mới
đúng với [[ProjectVision]] (cơ chế "chuyển giao"), gộp các ý hay của bộ 1
(VD: `GetProductionPerTurn`, cơ chế turn) vào, rồi xóa phần trùng lặp và
project mồ côi `KingdomCraft.Game`.

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
