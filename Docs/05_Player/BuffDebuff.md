# Buff / Debuff

## Mục đích
Hệ thống hiệu ứng tạm thời (buff có lợi, debuff bất lợi) tác động lên Stats
người chơi, xuất phát từ thực phẩm, thời tiết, hoặc tình hình vương quốc.

## Nội dung cần điền
- Nguồn gốc buff/debuff: thực phẩm, [[Weather]], `Happiness` vương quốc
  thấp, chiến đấu, vật phẩm đặc biệt
- Cách hiển thị buff/debuff trên UI (icon, thời lượng còn lại)
- Cơ chế thời lượng và stack (cộng dồn hay ghi đè)
- Buff cấp vương quốc (ảnh hưởng toàn NPC, VD "Uy tín Vua") khác với buff cá
  nhân người chơi
- Debuff cảnh báo khi Stats sinh tồn xuống thấp

## Câu hỏi mở
- Buff/debuff cấp vương quốc có thuộc phạm vi file này hay nên định nghĩa
  tại [[KingdomSystem]] và file này chỉ giữ phần cá nhân?
- Debuff sinh tồn có nên nặng hơn ở giai đoạn Người sống sót và nhẹ dần khi
  có NPC hỗ trợ, để phản ánh rõ quá trình "được giải phóng" không?

## Liên kết
[[Stats]] · [[Weather]] · [[KingdomSystem]] · [[Health]]
