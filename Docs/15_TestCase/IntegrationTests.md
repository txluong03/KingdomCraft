# Integration Tests — KingdomCraft

## Mục đích
Kiểm tra nhiều thành phần phối hợp đúng với nhau (VD `AutomationSystem` +
`KingdomState` + database), phát hiện lỗi ở ranh giới giữa các module mà
[[UnitTests]] đơn lẻ không thấy.

## Nội dung cần điền
- Kịch bản tích hợp ưu tiên: người chơi thao tác → `KingdomState` cập nhật → NPC phản ứng
- Tích hợp giữa Core và Server (giao tiếp qua [[API]])
- Tích hợp database thật (không mock) cho luồng save/load (liên hệ [[Database]], [[SaveGame]])
- Test luồng tăng `AutomationLevel` qua nhiều tick liên tiếp
- Môi trường chạy test tích hợp (DB test riêng, container tạm...)
- Dữ liệu seed/fixture dùng chung cho test tích hợp
- Ranh giới giữa Integration test và [[GameplayTests]] (test luồng chơi đầy đủ)

## Câu hỏi mở
- Test tích hợp có cần database thật (SQLite file tạm) hay dùng in-memory?
- Chạy test tích hợp mỗi lần commit hay chỉ trước khi merge vào `main`?

## Liên kết
- [[UnitTests]]
- [[Database]]
- [[API]]
- [[CI_CD]]
