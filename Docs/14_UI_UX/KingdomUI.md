# Kingdom UI — KingdomCraft

## Mục đích
Thiết kế giao diện tổng quan quản lý vương quốc — màn hình trung tâm thể
hiện trục "chuyển giao" (AutomationLevel, danh sách NPC và vai trò, các
trục quản lý: Population, Tax, Food, Army, Housing, Happiness...).

## Nội dung cần điền
- Bảng điều khiển tổng quan (dashboard) hiển thị AutomationLevel và các
  trục quản lý ở [[KingdomSystem]]
- Danh sách NPC: lọc theo Role, thao tác bổ nhiệm/đổi vai trò, xem
  SkillLevel
- Trực quan hóa tiến trình Progression hiện tại (giai đoạn đang ở, điều
  kiện lên giai đoạn tiếp theo)
- Giao diện đề xuất của Steward khi AutomationLevel cao (chờ người chơi
  phê duyệt/từ chối, theo nguyên tắc ở [[KingdomSystem]])
- Bản đồ/khu vực lãnh thổ khi mở rộng nhiều khu định cư (giai đoạn Vua/Đế
  quốc)
- Cảnh báo sự kiện tiêu cực (nổi loạn do Happiness thấp, thiên tai) nổi
  bật trên UI

## Câu hỏi mở
- Dashboard quản lý vương quốc có phải màn hình toàn màn hình riêng (tách
  khỏi gameplay 3D) hay overlay trong lúc vẫn di chuyển được?
- Cơ chế "phê duyệt đề xuất của Steward" hiển thị dạng thông báo chờ xử lý
  hay danh sách công việc (task list) riêng?

## Liên kết
- [[HUD]]
- [[BuildingUI]]
- [[KingdomSystem]]
- [[KingdomAPI]]
