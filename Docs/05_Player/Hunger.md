# Hunger

## Mục đích
Cụ thể hóa chỉ số `Hunger` đã có trong `Player.cs` (mặc định 100) — cơ chế
tiêu hao/hồi phục, và là cầu nối rõ rệt giữa sinh tồn tự thân và việc
chuyển giao cho Farmer NPC.

## Nội dung cần điền
- Tốc độ giảm Hunger theo thời gian và theo loại hoạt động
- Ngưỡng Hunger ảnh hưởng tới Health/Stamina khi đói
- Nguồn hồi phục: thực phẩm tự trồng/tự săn vs lấy từ kho lương vương quốc
- Thứ tự ưu tiên tiêu thụ khi có nhiều loại thực phẩm
- Ranh giới giữa "ăn cá nhân" và Food resource của `KingdomState`

## Câu hỏi mở
- Khi vương quốc có Food dư dả nhờ Farmer NPC tự động, Hunger của người
  chơi có tự động được bù từ kho chung không, hay luôn phải tự ăn thủ công?
- Đây có phải điểm đầu tiên người chơi cảm nhận rõ việc "được giải phóng"
  khỏi sinh tồn khi bước sang giai đoạn Chủ trang trại không (xem
  [[Progression]])?

## Liên kết
[[Stats]] · [[KingdomSystem]] · [[Health]] · [[Progression]]
