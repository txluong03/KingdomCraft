# Save API — KingdomCraft

## Mục đích
Phác thảo API kích hoạt lưu/tải trạng thái game từ client hoặc công cụ vận
hành server. **Định hướng tương lai**: phụ thuộc cơ chế persist thật ở
[[SaveGame]]/[[Tables]], hiện chưa tồn tại — server hiện tại không lưu gì
cả, tắt đi là mất dữ liệu.

## Nội dung cần điền
- Endpoint yêu cầu save thủ công (người chơi bấm nút Save)
- Endpoint/luồng tải lại Kingdom đã lưu khi người chơi vào lại
- Endpoint dành cho admin/vận hành: backup, liệt kê các bản save
- Xử lý xung đột khi nhiều thiết bị cùng load 1 save (cloud save)
- Giới hạn tần suất gọi save API để tránh spam ảnh hưởng hiệu năng DB

## Câu hỏi mở
- Save API có expose cho client trực tiếp gọi hay chỉ server tự gọi nội bộ
  theo lịch (xem [[SaveGame]])?
- Có hỗ trợ nhiều save slot cho 1 tài khoản (nhiều Kingdom song song)
  không?

## Liên kết
- [[SaveGame]]
- [[Migration]]
- [[Authentication]]
- [[ErrorCodes]]
