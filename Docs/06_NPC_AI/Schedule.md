# Schedule

## Trạng thái: Blocked — chưa cài đặt (2026-07-28)
Lịch làm việc theo chu kỳ ngày/đêm **phụ thuộc [[DayNight]]**, hiện vẫn là
khung tài liệu, chưa có code (`04_WorldGeneration` chưa cài đặt chu kỳ thời
gian nào). Không thể cài Schedule thật trước khi có DayNight — ghi nhận
thứ tự phụ thuộc rõ ràng thay vì cố làm trước, tránh code không có gì để
gắn vào (xem [[TechnicalDebt]]).

## Mục đích (giữ nguyên định hướng)
Lịch làm việc/nghỉ ngơi của NPC theo chu kỳ ngày đêm — cơ chế then chốt cho
mốc `AutomationLevel` 30-70 đã đề xuất ở [[KingdomSystem]], nơi NPC bắt đầu
tự tối ưu ca làm việc.

## Nội dung cần điền (khi DayNight sẵn sàng)
- Cấu trúc lịch (giờ làm, giờ nghỉ, giờ ngủ) theo [[DayNight]]
- Cách nhiều NPC cùng vai trò tự phân bổ ca làm việc
- Ưu tiên công việc khi tài nguyên/nguyên liệu khan hiếm
- Ảnh hưởng `Happiness` khi lịch làm việc quá tải
- Giao diện cho người chơi can thiệp/ghi đè lịch khi cần

## Câu hỏi mở
- Người chơi có thể tự chỉnh lịch làm việc thủ công cho từng NPC ở
  `AutomationLevel` thấp, và mất dần quyền đó khi giao cho Steward tự quản
  không?
- NPC có cần "nghỉ lễ/nghỉ ốm" ảnh hưởng sản lượng để tránh cảm giác "máy
  móc vô hồn" không?

## Liên kết
[[DayNight]] · [[VillagerAI]] · [[KingdomSystem]] · [[BehaviourTree]]
