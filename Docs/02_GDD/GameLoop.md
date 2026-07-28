# Game Loop — KingdomCraft

## Quyết định thiết kế: real-time tick, không phải turn-based
Code hiện tại có 2 mô hình vòng lặp song song chưa hợp nhất:
- Turn-based (`GameEngine.AdvanceTurn`, dùng bởi `KingdomCraft.Game`)
- Real-time tick (`AutomationSystem.Tick`, dùng bởi `KingdomCraft.Server`,
  hiện chạy `Task.Delay(1000)` mỗi tick)

Vì thế giới là sandbox voxel khám phá tự do (không phải game chiến thuật
theo lượt), **real-time tick** phù hợp hơn với [[ProjectVision]] — người
chơi di chuyển/thao tác liên tục, còn vương quốc mô phỏng chạy nền theo
tick cố định (VD: 1 tick/giây hoặc chậm hơn để tránh tốn tài nguyên server).
Quyết định này kéo theo việc hợp nhất code theo [[DevelopmentRoadmap]] Bước 0.

## Vòng lặp tầng 1 — Moment-to-moment (client, mỗi frame)
- Input → di chuyển, tương tác, đặt/phá khối, chiến đấu
- Render thế giới, UI, hiệu ứng

## Vòng lặp tầng 2 — Simulation tick (server, định kỳ)
- `AutomationSystem.Tick(kingdom)`:
  1. Mỗi NPC theo `NpcRole` sản xuất tài nguyên tương ứng
  2. Tính lại `AutomationLevel`
  3. (Mở rộng) sự kiện ngẫu nhiên, tiêu thụ tài nguyên (dân số ăn food),
     thuế, sản xuất công trình không cần NPC trực tiếp

## Vòng lặp tầng 3 — Vòng đời phiên chơi
Spawn → sinh tồn → xây dựng → chuyển giao → quản lý → (endgame) mở rộng.
Xem chi tiết mốc chuyển giai đoạn ở [[Progression]].

## Liên kết
[[CoreGameplay]] · [[KingdomSystem]] · [[Progression]]
