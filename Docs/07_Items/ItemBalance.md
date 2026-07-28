# Item Balance

## Mục đích
Định nghĩa khung cân bằng số liệu chung áp dụng cho toàn bộ vật phẩm trong
07_Items — để các file catalog (Weapons, Tools, Armor, Resources...) không
tự đặt số liệu tùy tiện, thiếu nhất quán giữa các thời đại công nghệ.

## Nội dung cần điền
- Công thức tăng chỉ số theo tier/thời đại (VD: mỗi tier tăng Damage/
  Durability theo hệ số cố định hay tùy chỉnh riêng từng loại).
- Khung giá trị Gold cơ bản theo rarity, dùng làm tham chiếu cho
  [[Economy]] (giá mua/bán tại Market).
- Quy tắc Durability chung: tốc độ hao mòn, ngưỡng vỡ, chi phí sửa
  ([[Upgrade]]).
- Giới hạn stacking (số lượng item gộp 1 ô inventory) theo loại vật phẩm.
- Nguyên tắc tránh power creep khi thêm tier/thời đại mới (mỗi thời đại
  tăng bao nhiêu % so với thời đại trước).
- Bảng đối chiếu chéo giữa các file catalog để đảm bảo không có 2 vật phẩm
  cùng tier nhưng lệch giá trị quá xa nhau.

## Câu hỏi mở
- Cân bằng có tính điểm số tổng hợp (item score) để so sánh nhanh giữa các
  vật phẩm khác loại không, hay đánh giá theo cảm tính playtest?
- PvP có dùng bộ số liệu riêng (damage giảm theo %) khác PvE để tránh vũ
  khí tier cao "one-shot" người chơi khác?

## Liên kết
[[ItemTypes]] · [[Economy]] · [[Damage]] · [[TechnologyTree]]
