# PvE

## Mục đích
Định nghĩa nội dung chiến đấu giữa người chơi/NPC vương quốc với quái vật
và thế lực môi trường (bandit, quái vật hoang dã, sự kiện xâm lược) — một
trong các nguồn rủi ro cân bằng nhắc tới ở [[KingdomSystem]] khi
`AutomationLevel` cao.

## Nội dung cần điền
- Loại kẻ địch: quái vật hoang dã theo Biome, bandit/cướp tấn công vương
  quốc, quái vật boss riêng (liên hệ [[BossFight]]).
- Độ khó/aggro theo thời gian trong ngày, theo Biome, hoặc theo mức độ
  giàu có/AutomationLevel của vương quốc (vương quốc giàu bị nhắm nhiều
  hơn).
- Ai phòng thủ: NPC Soldier tự động (liên hệ `NpcRole`) hay bắt buộc người
  chơi tham gia trực tiếp.
- Phần thưởng: tài nguyên, vật phẩm hiếm ([[LegendaryItems]]), ảnh hưởng
  danh vọng ([[ReputationSystem]]).
- Tần suất/cơ chế kích hoạt sự kiện PvE (ngẫu nhiên theo tick, theo lịch cố
  định, hay theo hành động người chơi).
- Hậu quả khi thua (mất công trình, dân số, tài nguyên) và cách phục hồi.

## Câu hỏi mở
- Tấn công PvE có tăng dần theo độ giàu có/AutomationLevel của vương quốc
  (rủi ro tương xứng lợi ích tự động hóa, như đề cập ở [[KingdomSystem]])
  không?
- Người chơi có bắt buộc tham gia trực tiếp trận đánh hay có thể "auto-
  resolve" để giao hoàn toàn cho NPC Soldier khi AutomationLevel đủ cao?

## Liên kết
[[KingdomSystem]] · [[BossFight]] · [[Damage]] · [[Events]]
