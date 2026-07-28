# Skills (Player)

## Mục đích
Cụ thể hóa cơ chế vận hành của các kỹ năng người chơi (Mining, Farming,
Combat, Diplomacy, Leadership đã liệt kê ở [[SkillSystem]]) — file này tập
trung công thức tăng trưởng và tương tác runtime, [[SkillSystem]] giữ vai
trò định hướng thiết kế tổng quan.

## Nội dung cần điền
- Công thức tăng skill theo hành động lặp lại (learn-by-doing)
- Giới hạn cấp tối đa mỗi skill và cách hiển thị tiến độ cho người chơi
- Skill có suy giảm khi không sử dụng trong thời gian dài hay không
- Công thức cụ thể Leadership ảnh hưởng hiệu suất NPC (mở rộng từ
  `Npc.SkillLevel` hiện có trong code)
- Phân biệt rõ Player Skill và `Npc.SkillLevel` (hai khái niệm khác nhau,
  dễ nhầm lẫn — xem [[Glossary]])

## Câu hỏi mở
- Khi người chơi chuyển giao hoàn toàn một công việc cho NPC (VD Mining),
  skill tương ứng của người chơi có ngừng tăng, giảm dần, hay giữ nguyên
  vĩnh viễn?
- Leadership có yêu cầu người chơi ở gần NPC (giám sát trực tiếp) để phát
  huy hiệu lực, hay có tác dụng toàn vương quốc bất kể khoảng cách?

## Liên kết
[[SkillSystem]] · [[Attributes]] · [[TalentSystem]] · [[KingdomSystem]]
