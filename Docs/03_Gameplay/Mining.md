# Mining — KingdomCraft

## Mục đích
Mô tả luồng đào khoáng sản của người chơi (giai đoạn Người sống sót/Thợ
thủ công) và cách công việc này được chuyển giao dần cho NPC vai trò
`Miner` khi vương quốc hình thành, tham chiếu `NpcRole.Miner` trong
`Entities/Npc.cs` và sản lượng "stone" trong `AutomationSystem`.

## Nội dung cần điền
- Loại khối khai thác được và công cụ tương ứng (tay không, cuốc đá/đồng/sắt...)
- Độ sâu/tầng địa chất và độ hiếm khoáng sản theo tầng
- Tốc độ đào, độ bền công cụ khi đào (liên hệ [[Durability]] trong Glossary)
- Rủi ro khi đào (sập hầm, quái hầm mỏ, thiếu ánh sáng) — liên hệ [[Combat]]
- Công trình `Mine` (đã có trong `BuildingType`): sản lượng, cấp độ nâng cấp, số NPC Miner tối đa gán vào
- Cách người chơi chuyển từ tự đào sang giao việc cho NPC Miner — điểm mốc và cảm giác mong muốn đạt được
- Khoáng sản đầu vào cho công nghệ/chế tạo về sau (liên hệ [[TechnologyTree]], [[Recipes]])

## Câu hỏi mở
- Khi đã có NPC Miner tự động, người chơi còn lý do gì để tự tay đào nữa (VD: khoáng sản hiếm chỉ tìm được ở xa, không thuộc phạm vi khai thác tự động của NPC)?
- Hiệu suất đào của NPC Miner nên scale theo `SkillLevel` như thế nào so với tốc độ đào tay của người chơi có công cụ tốt?

## Liên kết
[[KingdomSystem]] · [[Survival]] · [[TechnologyTree]] · [[CraftingFlow]]
