# Enemy AI

## Mục đích
AI cho quái vật thù địch (chưa có class riêng trong code) — chi phối áp
lực chiến đấu đe dọa cả người chơi và một vương quốc đã tự động hóa cao.

## Nội dung cần điền
- Phân loại quái theo môi trường xuất hiện (hang động, ban đêm, dungeon)
- Cơ chế Aggro (xem [[Glossary]]) và phạm vi phát hiện mục tiêu
- Hành vi tấn công vs tuần tra khi chưa phát hiện mục tiêu
- Độ khó scale theo [[Progression]]/`AutomationLevel` (quái mạnh hơn khi
  vương quốc lớn hơn)
- Tương tác với Soldier NPC khi phòng thủ (ai giao tranh trước, ai được ưu
  tiên tấn công)
- Điều kiện spawn liên hệ [[DayNight]] và [[CaveGeneration]]

## Câu hỏi mở
- Quái vật có tấn công trực tiếp công trình/NPC của vương quốc (đòi hỏi
  phòng thủ chủ động) hay chỉ nhắm vào Player?
- Đây có phải nguồn chính cho "sự kiện ngẫu nhiên khi tự động hóa cao" (quân
  xâm lược) đã nêu ở [[KingdomSystem]], và tần suất nên tăng theo
  `AutomationLevel` ra sao?

## Liên kết
[[KingdomSystem]] · [[Combat]] · [[BossAI]] · [[DayNight]]
