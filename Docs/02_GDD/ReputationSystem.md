# Reputation System — KingdomCraft

## Mục đích
Đo lường quan hệ giữa người chơi/vương quốc với NPC và các vương quốc khác
(multiplayer), ảnh hưởng giá thương mại, khả năng liên minh, thăng cấp NPC
lên Steward (xem [[KingdomSystem]]).

## Nguồn tăng/giảm
- Tăng: hoàn thành quest cho NPC/vương quốc khác, giao thương công bằng,
  cứu trợ khi có sự kiện thiên tai.
- Giảm: tấn công vô cớ, thuế quá cao khiến `Happiness` thấp kéo dài, phá
  vỡ hiệp ước.

## Ảnh hưởng gameplay
- Reputation cao với dân trong vương quốc → dễ tuyển NPC giỏi hơn, NPC ít
  rời bỏ vai trò.
- Reputation với vương quốc khác → điều kiện liên minh/chiến tranh (xem
  [[MultiplayerFlow]]).

## Câu hỏi mở
- Reputation là 1 chỉ số toàn cục hay theo từng đối tượng (mỗi NPC/vương
  quốc một điểm số riêng)? Đề xuất: theo từng đối tượng để tránh cảm giác
  "1 số duy nhất quyết định tất cả".

## Liên kết
[[KingdomSystem]] · [[MultiplayerFlow]] · [[QuestFlow]]
