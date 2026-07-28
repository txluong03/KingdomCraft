# Tools

## Mục đích
Định nghĩa các công cụ lao động (đào, chặt, canh tác...) — vật phẩm gắn
trực tiếp với giai đoạn "Người sống sót" và "Thợ thủ công" trong trục tiến
trình, trước khi công việc được chuyển giao cho NPC.

## Nội dung cần điền
- Danh sách công cụ cơ bản: rìu (Wood), cuốc (Mine), cuốc xẻng nông nghiệp
  (Farm), cần câu, bình tưới... và chất liệu/tier theo `TechnologyTree`.
- Chỉ số mỗi công cụ: tốc độ khai thác, Durability, loại tài nguyên tương
  thích (VD: rìu không đào được đá).
- Công cụ nào có bản nâng cấp "tự động hóa" (VD: máy chặt gỗ) đánh dấu mốc
  chuyển giao sang NPC/công trình (liên hệ `AutomationLevel`).
- Công cụ NPC dùng khi được gán `NpcRole` (Farmer/Lumberjack/Miner) có phải
  cùng loại với công cụ người chơi hay là biến thể riêng.
- Cách công cụ hết Durability: biến mất, cần sửa ([[Upgrade]]), hay tự hồi
  phục theo thời gian.

## Câu hỏi mở
- Người chơi có bắt buộc cầm đúng công cụ mới khai thác được không, hay
  tay không vẫn làm được (chậm hơn)?
- Khi giao việc cho NPC, NPC có cần được trang bị công cụ từ kho vương
  quốc hay tự có sẵn theo vai trò?
- Công cụ có tier trần theo thời đại hiện tại của vương quốc không (không
  thể có công cụ Thép khi vương quốc còn ở Stone Age)?

## Liên kết
[[ItemTypes]] · [[KingdomSystem]] · [[TechnologyTree]] · [[Recipes]]
