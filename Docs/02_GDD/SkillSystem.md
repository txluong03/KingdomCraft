# Skill System — KingdomCraft

## Player Skills
Kỹ năng người chơi tăng theo hành động lặp lại (learn-by-doing), tách biệt
với `LevelSystem` (kinh nghiệm tổng quát):
- Mining — tăng tốc độ đào, giảm hỏng công cụ
- Farming — tăng sản lượng nông sản tự tay trồng
- Combat — sát thương/phòng thủ cận chiến/tầm xa
- Diplomacy — ảnh hưởng đàm phán, giá thương mại (liên hệ
  [[ReputationSystem]])
- Leadership — ảnh hưởng hiệu suất NPC khi người chơi trực tiếp giám sát
  (liên hệ [[KingdomSystem]])

## NPC Skill (đã có trong code: `Npc.SkillLevel`)
- Hiện là 1 chỉ số chung ảnh hưởng sản lượng theo vai trò
  (`kingdom.Resources.Add(type, npc.SkillLevel)`).
- Mở rộng: `SkillLevel` nên tăng dần theo thời gian NPC làm việc, không cố
  định từ lúc tạo.

## Liên hệ Talent
Skill là "luyện tập lặp lại", còn [[TalentSystem]] là lựa chọn định hướng
chủ động (chọn nhánh). Hai hệ thống bổ trợ, không trùng lặp.

## Liên kết
[[TalentSystem]] · [[LevelSystem]] · [[KingdomSystem]]
