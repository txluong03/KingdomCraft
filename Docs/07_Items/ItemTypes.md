# Item Types

## Quyết định (2026-07-28)
Item = vật phẩm cá nhân trong `Player.Inventory`, **tách biệt** khỏi
`KingdomState.Resources` (tài nguyên tập thể của vương quốc — Gold/Wood/
Stone/Food quản lý theo `ResourceStockpile`, key `string` khác namespace).
Hai hệ thống dùng chung kiểu `string` key nhưng không dùng chung dữ liệu ở
giai đoạn này — tránh nhầm lẫn "gỗ cá nhân nhặt được" với "gỗ tồn kho vương
quốc". Có thể hợp nhất sau nếu cần (xem [[Economy]]).

## Cấu trúc dữ liệu (đã cài đặt: `Core/Items/ItemDefinition.cs`)
```
ItemDefinition { Id: string, Name: string, Category: ItemCategory }
```
- Data-driven bằng **danh sách tĩnh trong code** (`ItemCatalog.All`), không
  phải enum cứng — dễ mở rộng hơn `BuildingType` mà không cần đổi chữ ký
  API. Chưa cần JSON/file ngoài ở quy mô hiện tại.
- Không có Rarity/Durability/weight ở giai đoạn này — mở khi có nhu cầu
  thật (xem [[ItemBalance]]).
- Giới hạn theo **số ô** (`Inventory.Capacity`, 1 ô = 1 loại item, xem
  [[Inventory]]), không giới hạn trọng lượng.

## Category (đã cài đặt: `Core/Items/ItemCategory.cs`)
`Material` (nguyên liệu thô/đã sơ chế) · `Tool` (công cụ) · `Food` ·
`Product` (thành phẩm khác). Mở rộng thêm Weapon/Armor khi làm [[Combat]].

## Danh mục tối thiểu (đã cài đặt: `Core/Items/ItemCatalog.cs`, 7 item)
| Id | Tên | Category | Nguồn gốc |
|---|---|---|---|
| `wood` | Gỗ | Material | Thu thập (chưa nối với World/Mining, xem [[Blocks]]) |
| `stone` | Đá | Material | Thu thập |
| `plank` | Ván gỗ | Material | Chế tạo từ `wood` (xem [[Recipes]]) |
| `wooden_axe` | Rìu gỗ | Tool | Chế tạo |
| `wooden_pickaxe` | Cuốc gỗ | Tool | Chế tạo |
| `stone_axe` | Rìu đá | Tool | Chế tạo |
| `stone_pickaxe` | Cuốc đá | Tool | Chế tạo |

Đây là danh mục **tối thiểu để Crafting chạy được** (mốc "chế tạo công cụ
đầu tiên" trong [[Progression]]) — mở rộng dần khi làm [[Mining]]/[[Farming]]/
[[Combat]] thật, không thêm item chưa có recipe/công dụng.

## Câu hỏi mở
- Rarity/tier có cần cho vũ khí/trang bị (Bước 4, [[Combat]]) hay chỉ Tool
  dùng phân loại đơn giản là đủ?
- Khi nối Mining/World thật, `wood`/`stone` item cá nhân có tự động cộng
  vào `KingdomState.Resources` khi mang về vương quốc không, hay là 2 bước
  tách biệt (người chơi phải "nộp kho" thủ công)?

## Liên kết
[[Recipes]] · [[CraftStations]] · [[Inventory]] · [[Blocks]] · [[Economy]]
