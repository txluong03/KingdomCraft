# Item Types

## Mục đích
File này định nghĩa hệ phân loại (taxonomy) tổng quát cho toàn bộ vật phẩm
trong KingdomCraft — nền tảng để các file con trong nhóm 07_Items (Weapons,
Tools, Armor, Resources, Consumables, Food, Furniture, Decorations,
LegendaryItems) không trùng lặp hoặc mâu thuẫn nhau.

## Nội dung cần điền
- Danh sách các nhóm vật phẩm cấp cao (VD: Equipment, Resource, Consumable,
  Placeable, Quest Item, Currency) và file con tương ứng của từng nhóm.
- Cấu trúc dữ liệu chung cho 1 Item (Id, Name, Stack size, Rarity, giá trị
  Gold cơ bản, có Durability hay không...).
- Quy tắc rarity/tier áp dụng chung (VD: Common → Rare → Epic → Legendary)
  và liên hệ với `TechnologyTree` (thời đại nào mở khóa tier nào).
- Cách item liên hệ với Inventory/Hotbar của người chơi (số ô, giới hạn
  trọng lượng nếu có).
- Quy ước đặt tên/ID vật phẩm để đồng bộ với code (namespace, enum hay
  data-driven catalog).
- Vật phẩm nào chỉ tồn tại trong tay NPC (nguyên liệu sản xuất nội bộ)
  so với vật phẩm người chơi thấy trong inventory.

## Câu hỏi mở
- Item định nghĩa bằng enum cứng trong code (như `BuildingType`) hay bằng
  data-driven catalog (JSON/ScriptableObject-like) để dễ mở rộng?
- Có hệ thống trọng lượng (weight limit) giới hạn mang vác hay chỉ giới hạn
  theo số ô inventory?
- Rarity có ảnh hưởng cơ chế (stat ngẫu nhiên, affix) hay chỉ là nhãn hiển
  thị?

## Liên kết
[[ItemBalance]] · [[Recipes]] · [[TechnologyTree]] · [[Economy]]
