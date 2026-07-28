# Stats

## Mục đích
Tổng hợp các chỉ số runtime của người chơi (đã có `Health`, `Hunger` trong
`Player.cs`), mô tả cách chúng phái sinh từ Attributes và tương tác với
nhau — các chỉ số chi tiết từng cái có file riêng ([[Health]], [[Hunger]],
[[Stamina]], [[Temperature]]).

## Nội dung cần điền
- Danh sách đầy đủ Stats runtime và vai trò của từng chỉ số
- Công thức phái sinh Stats từ [[Attributes]]
- Ngưỡng cảnh báo/nguy hiểm cho mỗi Stat
- Tương tác chéo giữa các Stats (VD Hunger thấp làm giảm tốc độ hồi
  Stamina)
- Cách hiển thị Stats trên UI (thanh, số, cảnh báo)
- Thay đổi mức độ quan trọng của Stats khi người chơi chuyển sang vai trò
  quản lý ít thao tác tay chân hơn

## Câu hỏi mở
- Các Stats sinh tồn có giảm áp lực khi lên giai đoạn Vua/Đế quốc hay luôn
  giữ nguyên mức độ quan trọng xuyên suốt game?
- Có cần bộ Stats riêng cho trạng thái "giám sát từ xa" (không trực tiếp
  điều khiển nhân vật) ở giai đoạn cuối không?

## Liên kết
[[Attributes]] · [[Health]] · [[Hunger]] · [[Stamina]]
