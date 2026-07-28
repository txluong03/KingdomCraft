# KingdomCraft — Tài liệu dự án

Bộ tài liệu đầy đủ cho KingdomCraft nếu phát triển thành game thương mại
cỡ trung. Thay thế cho `docs/` cũ (đã migrate toàn bộ nội dung sang đây).

> Xem [[ProjectVision]] và [[ProjectScope]] trước tiên nếu bạn mới tham gia
> dự án — đó là 2 file quan trọng nhất để hiểu game này là gì và không là
> gì.

## Trạng thái nội dung
- **00_Project** và **02_GDD** — đã viết nội dung đầy đủ, phản ánh các
  quyết định thiết kế đã thảo luận và hiện trạng code thật trong
  `src/KingdomCraft.Core`.
- **Các nhóm còn lại (01, 03–20)** — mỗi file là khung tham khảo (mục đích,
  nội dung cần điền, câu hỏi mở, liên kết), chưa có nội dung/số liệu cuối
  cùng. Điền trực tiếp vào file tương ứng khi có quyết định, không tạo file
  rời rạc mới.

## Cấu trúc
```
00_Project/         Tầm nhìn, phạm vi, roadmap, quy ước code, quản lý rủi ro
01_BRD/              Yêu cầu nghiệp vụ (góc nhìn BA)
02_GDD/              Game Design Document — linh hồn thiết kế game
03_Gameplay/         Chi tiết từng luồng gameplay
04_WorldGeneration/  Sinh thế giới
05_Player/           Nhân vật người chơi
06_NPC_AI/           NPC và AI
07_Items/            Vật phẩm
08_Crafting/         Chế tạo
09_Building/         Xây dựng
10_Combat/           Chiến đấu
11_Database/         Thiết kế dữ liệu
12_API/               API/giao tiếp client-server
13_Server/           Kiến trúc server, mạng, multiplayer
14_UI_UX/             Giao diện, trải nghiệm
15_TestCase/          Test case
16_Deployment/        CI/CD, phát hành, vận hành
17_Art/                Định hướng mỹ thuật
18_Audio/              Âm thanh
19_Lore/               Cốt truyện, thế giới quan
20_DevLogs/            Nhật ký phát triển, quyết định, technical debt
```

## Quy ước liên kết
Các file dùng cú pháp `[[TenFile]]` để trỏ tới file khác trong bộ tài liệu
(không phân biệt nhóm) — tra theo tên file, không theo đường dẫn đầy đủ.

## Liên hệ code hiện tại
Xem [[DevelopmentRoadmap]] để biết tài liệu này liên hệ thế nào với hiện
trạng thật của `src/KingdomCraft.Core` (bao gồm việc cần hợp nhất 2 bộ
model đang tồn tại song song).
