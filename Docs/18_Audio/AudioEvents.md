# Audio Events — KingdomCraft

## Mục đích
Tổng hợp danh sách sự kiện gameplay cần trigger âm thanh và cách hệ thống
audio kết nối với code (event-driven). Hiện **chưa có hệ thống audio nào**
trong code — đây là khung thiết kế kỹ thuật trước khi có asset thật.

## Nội dung cần điền
- Danh sách event cần âm thanh (đặt khối, thu hoạch, chiến đấu, thăng cấp giai đoạn...)
- Cách `AutomationSystem.Tick` hoặc các event gameplay khác trigger audio (observer/event bus)
- Ưu tiên âm thanh khi nhiều sự kiện xảy ra cùng lúc (tránh hỗn loạn âm thanh)
- Audio pooling để tối ưu hiệu năng khi nhiều NPC hoạt động cùng lúc
- Cấu hình âm lượng riêng theo nhóm (nhạc, SFX, ambient, voice)
- Liên hệ giữa audio event và [[UIAssets]] (phản hồi âm thanh cho thao tác UI)

## Câu hỏi mở
- Hệ thống audio dùng engine tích hợp sẵn hay thư viện audio riêng (FMOD/Wwise)?
- Có cần audio event bus tách biệt khỏi logic gameplay ngay từ đầu để dễ mở rộng không?

## Liên kết
- [[Music]]
- [[SFX]]
- [[Voice]]
- [[KingdomSystem]]
