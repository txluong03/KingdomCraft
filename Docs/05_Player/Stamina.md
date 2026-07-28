# Stamina

## Mục đích
Chỉ số thể lực — chưa có trong `Player.cs` hiện tại — chi phối khả năng
thực hiện liên tục các hành động tay chân (đào, chạy, chiến đấu).

## Nội dung cần điền
- Danh sách hành động tiêu hao Stamina và mức tiêu hao mỗi loại
- Tốc độ hồi phục Stamina (nghỉ ngơi, ngủ theo [[DayNight]])
- Hậu quả khi cạn Stamina (giảm hiệu suất, không thể chạy/tấn công)
- Liên hệ Skill Mining/Farming tới mức tiêu hao Stamina khi thao tác
- Vai trò của Stamina như đòn bẩy thiết kế khuyến khích chuyển giao công
  việc cho NPC (tự làm thì mệt, NPC thì không)

## Câu hỏi mở
- Stamina có nên là cơ chế chính thúc đẩy người chơi chuyển giao công việc
  (USP cốt lõi), hay chỉ là chi tiết sinh tồn phụ không ảnh hưởng quyết
  định lớn?
- Có cần thêm field `Stamina` vào `Player.cs` ngay, hay chờ chốt xong thiết
  kế công thức trước khi đưa vào code?

## Liên kết
[[Health]] · [[DayNight]] · [[Skills]] · [[Progression]]
