# Kingdom Buildings

## Bảng công trình (khớp `src/KingdomCraft.Core/Kingdom/Building.cs`)
| BuildingType | Vai trò | Sản lượng/tick (`GetProductionPerTick`) |
|---|---|---|
| TownHall | Trung tâm quản lý, không sản xuất | — |
| Farm | Nông sản | `food`, `10 * Level` |
| Mine | Khai khoáng | `stone`, `8 * Level` |
| LumberMill | Khai thác gỗ | `wood`, `8 * Level` |
| Market | Thương mại | `gold`, `6 * Level` **(mới thêm 2026-07-28)** |
| Barracks | Quân đội | — (chưa có hệ thống Army/Unit ở kiến trúc hiện tại, xem [[Combat]]) |
| House | Nhà ở / Housing | — (chưa có field `Population` trên `KingdomState`, xem câu hỏi mở) |
| Wall | Phòng thủ | — |
| Custom | Mở rộng tự do | — |

`Market` được chọn bổ sung production vì đã có sẵn khái niệm "Gold" trong
`ResourceStockpile`/`NpcRole.Merchant`, và khớp đúng vai trò thương mại đã
mô tả — không thêm `BuildingType` mới để tránh mở rộng enum khi chưa có
nhu cầu dùng thật.

## Quyết định (2026-07-28)
- **Không thêm `Steward's Hall`** thành `BuildingType` riêng ở giai đoạn
  này — vai trò tăng `AutomationLevel` mạnh hiện đã có qua `NpcRole.Steward`
  (không cần công trình). Sẽ xét lại khi làm sâu [[KingdomSystem]] Economy.
- `AssignedNpcId` vẫn là 1 NPC/công trình, **chưa validate** đúng
  `NpcRole` tương ứng (VD: Farm gán NPC role Miner vẫn được chấp nhận về
  mặt kỹ thuật) — ghi nhận là hạn chế đã biết, chưa phải bug vì
  `GetProductionPerTick()` không phụ thuộc `AssignedNpcId` (2 nguồn sản
  xuất độc lập, xem KI-06 ở [[KnownIssues]]).
- Chi phí xây dựng/nâng cấp Level: **chưa định số liệu chính thức** — để
  ngỏ tới khi có UI xây dựng thật, tránh chốt số liệu sớm rồi phải đổi.

## Câu hỏi mở
- `House` cần field `Population`/`Housing` mới trên `KingdomState` để có
  ý nghĩa — thêm khi nào (liên hệ [[Economy]])?
- Giới hạn số lượng mỗi loại công trình theo Progression — áp dụng từ giai
  đoạn nào?

## Liên kết
[[KingdomSystem]] · [[Economy]] · [[BuildingFlow]] · [[CraftStations]]
