# Economy — KingdomCraft

## Tài nguyên cơ bản (hiện có trong code)
| Loại | Nguồn | Dùng để |
|---|---|---|
| Gold | Merchant, thuế, thương mại | Xây công trình, lương NPC |
| Wood | Lumberjack | Xây công trình |
| Stone | Miner | Xây công trình |
| Food | Farmer | Tuyển/nuôi NPC, dân số |

## Thị trường động (Dynamic Market)
- Giá dao động theo cung/cầu thực tế trong vương quốc (không cố định).
- `Merchant` NPC tạo ra Gold — cần định nghĩa rõ họ bán gì cho ai (xem câu
  hỏi mở bên dưới).
- Lạm phát: khi Gold dư thừa toàn hệ thống, giá hàng hóa tăng — cần cơ chế
  giảm phát ngược lại (sink: nâng cấp công trình, thuế, mua NPC/đất).

## Thuế & lương
- Tax thu từ dân số (`Population`), ảnh hưởng `Happiness` (xem
  [[KingdomSystem]]).
- NPC có cần trả lương không, hay chỉ cần Food để duy trì? → quyết định ảnh
  hưởng độ phức tạp kinh tế, nên bắt đầu đơn giản (chỉ cần Food) rồi mở
  rộng sang lương thật khi Economy đủ sâu.

## Chi phí sản xuất
`GetProductionPerTurn`-style: mỗi công trình có sản lượng/turn hoặc /tick
theo `Level`. Chi phí xây dựng tăng theo cấp số nhân nhẹ để tránh spam
công trình vô hạn.

## Câu hỏi mở
- Giao thương liên vương quốc (multiplayer) dùng chung 1 thị trường toàn
  cầu hay mỗi vương quốc có thị trường riêng kết nối qua Merchant/đoàn
  thương? (xem [[MultiplayerFlow]])

## Liên kết
[[KingdomSystem]] · [[MultiplayerFlow]] · [[ItemBalance]]
