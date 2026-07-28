# Functional Requirements — KingdomCraft

## Mục đích
Liệt kê yêu cầu chức năng ở mức nghiệp vụ ("hệ thống phải cho phép người
dùng làm gì") làm cầu nối giữa [[BusinessRequirements]] và thiết kế
gameplay chi tiết ở nhóm 03_Gameplay — không lặp lại số liệu cân bằng, chỉ
nêu chức năng phải tồn tại.

## Nội dung cần điền
- Yêu cầu chức năng cho vòng lặp sinh tồn cơ bản (đào, chặt, canh tác, đói/máu) — tham chiếu [[Survival]]
- Yêu cầu chức năng cho quản lý vương quốc (xây công trình, xem chỉ số Population/Tax/Food...) — tham chiếu [[KingdomSystem]]
- Yêu cầu chức năng cho bổ nhiệm/quản lý NPC (gán vai trò, xem kỹ năng, thăng Steward) — tham chiếu [[NPCFlow]]
- Yêu cầu chức năng cho multiplayer (tạo/tham gia vương quốc, tương tác giữa người chơi) — tham chiếu [[MultiplayerFlow]]
- Yêu cầu chức năng cho hệ thống lưu/tải trạng thái game (persist KingdomState, Npc, world)
- Yêu cầu chức năng tối thiểu cho UI hiển thị AutomationLevel và tiến trình giai đoạn
- Mức độ ưu tiên (must-have/should-have/nice-to-have) cho từng nhóm yêu cầu, đối chiếu [[ProjectScope]]

## Câu hỏi mở
- Yêu cầu chức năng nào là điều kiện tiên quyết bắt buộc phải có trước bản demo đầu tiên (MVP) so với các yêu cầu có thể trì hoãn?
- Việc "xem và can thiệp vào quyết định của NPC tự động" (khi AutomationLevel cao) có phải một yêu cầu chức năng riêng, độc lập với việc gán vai trò thủ công không?

## Liên kết
[[BusinessRequirements]] · [[KingdomSystem]] · [[NPCFlow]] · [[NonFunctionalRequirements]]
