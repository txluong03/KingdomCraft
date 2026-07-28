# Naming Convention — KingdomCraft

## C# chung
- Class, Method, Property, Enum, Namespace: `PascalCase` (VD: `KingdomState`,
  `AdvanceTurn`, `AutomationLevel`, `NpcRole`).
- Local variable, parameter: `camelCase` (VD: `goldCost`, `activeNpcCount`).
- Private field: `_camelCase` nếu cần backing field (hiện code ưu tiên
  auto-property, chỉ dùng field riêng khi có logic thêm).
- Interface: tiền tố `I` (VD: `IAutomationSystem` nếu sau này cần trừu
  tượng hóa để test/mock).
- Async method: hậu tố `Async` (VD: `SaveGameAsync`).
- Enum: số ít, không hậu tố `Type`/`Enum` trong tên giá trị (VD: `NpcRole.Farmer`
  không phải `NpcRoleFarmer`).

## Tên miền game (đồng nhất Anh-Việt)
Giữ tên **tiếng Anh cho code**, tiếng Việt chỉ dùng trong doc/comment giải
thích lý do. Bảng đối chiếu tham khảo — mở rộng khi thêm khái niệm mới:

| Khái niệm | Tên code | Ghi chú |
|---|---|---|
| Vương quốc | `Kingdom` / `KingdomState` | Xem [[KingdomSystem]] |
| Mức tự động hóa | `AutomationLevel` | 0–100 |
| Vai trò NPC | `NpcRole` | Farmer, Lumberjack, Miner, Merchant, Steward, Soldier |
| Công trình | `Building` / `BuildingType` | |
| Kho tài nguyên | `ResourceStockpile` | |
| Khối thế giới | `BlockType` / `Chunk` | |

## Tên file
- 1 file = 1 class/enum chính (enum phụ trợ liên quan có thể ở chung file
  như `BuildingType` trong `Building.cs`).
- Tên file trùng tên class: `KingdomState.cs` chứa `class KingdomState`.
- Test file: `<ClassName>Tests.cs`.

## Liên kết
[[CodingConvention]] · [[FolderConvention]] · [[Glossary]]
