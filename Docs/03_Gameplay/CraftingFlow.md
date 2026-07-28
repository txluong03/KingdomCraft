# Crafting Flow — KingdomCraft

## Đã cài đặt (2026-07-28, `CraftingAppService`)
- `GetAllRecipes()` → danh sách `RecipeDto` (5 recipe, xem [[Recipes]]).
- `Craft(CraftInput{RecipeId, HasStationAccess})` → `CraftResultDto`
  (`Success`, `Message`, `InventorySnapshot`) — trừ nguyên liệu, cộng
  thành phẩm vào `Player.Inventory` nếu đủ điều kiện (nguyên liệu + trạm
  đúng theo [[CraftStations]]); thất bại không đổi Inventory.
- Vật phẩm đánh dấu mốc "Thợ thủ công" cụ thể: `wooden_axe` hoặc
  `wooden_pickaxe` (công cụ gỗ đầu tiên chế tạo được) — trùng điều kiện
  quest `quest_first_tool` ở [[QuestFlow]].

## Nội dung cần điền (chưa cài đặt)
- Bàn chế tạo/trạm chế tạo đặt được trong world (`Workbench` hiện chỉ là
  điều kiện logic, chưa phải vật thể — xem [[CraftStations]]).
- Luồng thao tác UI (kéo thả nguyên liệu, chế tạo hàng loạt).
- Cây tiến hóa vật liệu công cụ đầy đủ (Đồng → Sắt..., liên hệ
  [[TechnologyTree]]) — hiện chỉ có Đá (Stone Age tier).
- Chế tạo tự động khi có NPC/công trình sản xuất — hiện Craft luôn do
  người chơi gọi trực tiếp qua `CraftingAppService`.
- Blueprint/công thức chưa mở khóa (ẩn cho tới khi đủ điều kiện) — hiện
  `GetAllRecipes()` trả về tất cả, không có khái niệm khóa/mở khóa.

## Câu hỏi mở
- Khi vương quốc phát triển, chế tạo công cụ có giao cho NPC Blacksmith tự
  động sản xuất hàng loạt không, hay luôn giữ lại cho người chơi vì gắn
  với danh tính giai đoạn "Thợ thủ công"?
- Công thức có cần độ ngẫu nhiên/khám phá hay hiển thị rõ từ đầu (hiện tại
  là hiển thị rõ — `GetAllRecipes()` không ẩn gì)?

## Liên kết
[[Progression]] · [[Recipes]] · [[ItemTypes]] · [[TechnologyTree]] · [[BuildingFlow]]
