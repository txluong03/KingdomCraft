# Recipes

## Cấu trúc (đã cài đặt: `Core/Crafting/Recipe.cs`)
```
Recipe { Id, OutputItemId, OutputQuantity, Ingredients: List<RecipeIngredient>, RequiredStation }
RecipeIngredient { ItemId, Quantity }
```

## Quyết định (2026-07-28)
- **Chế tạo tức thời** — không tốn tick/thời gian chờ ở giai đoạn này (đơn
  giản hóa tạm thời, khác city builder có hàng đợi sản xuất; cân nhắc thêm
  thời gian chờ khi có UI thật để craft "cảm" được).
- **Người chơi tự thao tác** (đúng tinh thần giai đoạn Người sống sót/Thợ
  thủ công trong [[Progression]]) — NPC tự chế tạo hàng loạt là việc tương
  lai, chưa cài đặt (xem câu hỏi mở ở [[CraftingFlow]]).
- **Thất bại không tiêu hao gì** — `CraftingSystem.TryCraft` chỉ trừ
  nguyên liệu khi đủ điều kiện (đủ nguyên liệu + đúng trạm), nếu không đủ
  trả về `false`, Inventory không đổi.
- Chưa có yêu cầu `SkillLevel`/Progression tối thiểu cho recipe — chỉ phụ
  thuộc nguyên liệu + trạm.

## Danh mục recipe tối thiểu (đã cài đặt: `Core/Crafting/RecipeBook.cs`, 5 công thức)
| Id | Nguyên liệu | Sản phẩm | Trạm yêu cầu |
|---|---|---|---|
| `craft_plank` | `wood` x1 | `plank` x4 | Không (tay không) |
| `craft_wooden_axe` | `plank` x3 | `wooden_axe` x1 | Workbench |
| `craft_wooden_pickaxe` | `plank` x3 | `wooden_pickaxe` x1 | Workbench |
| `craft_stone_axe` | `plank` x2 + `stone` x3 | `stone_axe` x1 | Workbench |
| `craft_stone_pickaxe` | `plank` x2 + `stone` x3 | `stone_pickaxe` x1 | Workbench |

Đây là chuỗi tối thiểu để trải nghiệm được mốc "chế tạo công cụ đầu tiên":
đốn gỗ (giả định) → `plank` (tay không) → rìu/cuốc gỗ (Workbench) → rìu/
cuốc đá khi có đá. Mở rộng recipe khi có thêm item/công trình thật.

## Câu hỏi mở
- Khi nào cần recipe tốn thời gian thực (hàng đợi) thay vì tức thời — mốc
  nào trong Progression nên chuyển đổi?
- Recipe có nên phân nhóm hiển thị UI (Tool/Weapon/Food...) ngay từ cấu
  trúc dữ liệu, hay để UI tự lọc theo `ItemCategory` của output?

## Liên kết
[[ItemTypes]] · [[CraftStations]] · [[CraftingFlow]] · [[Unlocking]]
