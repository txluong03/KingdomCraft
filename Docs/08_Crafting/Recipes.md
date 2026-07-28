# Recipes

## Mục đích
Định nghĩa cấu trúc dữ liệu và quy tắc chung cho công thức chế tạo (input
→ output) áp dụng cho mọi trạm chế tạo trong game — nền tảng để
[[Smelting]], [[Cooking]], [[Brewing]] tham chiếu thay vì định nghĩa lại
từ đầu.

## Nội dung cần điền
- Cấu trúc 1 recipe: nguyên liệu đầu vào (loại + số lượng), sản phẩm đầu
  ra, trạm chế tạo yêu cầu ([[CraftStations]]), thời gian chế tạo.
- Recipe có yêu cầu `SkillLevel` NPC tối thiểu hay Progression tối thiểu
  của người chơi không.
- Cách recipe được mở khóa (liên hệ [[Unlocking]]) — theo tech tree, theo
  NPC học nghề, hay theo quest.
- Ai thực hiện recipe: người chơi thao tác trực tiếp (giai đoạn Người sống
  sót/Thợ thủ công) hay NPC tự thực hiện theo hàng đợi khi `AutomationLevel`
  đủ cao.
- Tỷ lệ thành công/thất bại hoặc chất lượng đầu ra thay đổi theo kỹ năng
  (có hay không).
- Danh mục nhóm recipe (Weapon, Tool, Armor, Food, Potion, Building
  Material...) để tổ chức UI chế tạo.

## Câu hỏi mở
- Recipe chế tạo tức thời hay tốn thời gian thực/tick chờ (giống hàng đợi
  sản xuất của city builder)?
- Khi NPC tự chế tạo thay người chơi, hàng đợi recipe do người chơi định
  cấu hình trước hay NPC tự quyết theo nhu cầu kho?
- Recipe thất bại (thiếu nguyên liệu chất lượng) có tiêu hao một phần
  nguyên liệu hay hoàn toàn không mất gì?

## Liên kết
[[ItemTypes]] · [[CraftStations]] · [[Unlocking]] · [[KingdomSystem]]
