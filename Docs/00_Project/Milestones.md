# Milestones — KingdomCraft

Chia theo sprint, bám [[DevelopmentRoadmap]]. Điền ngày thật khi có kế hoạch
cụ thể — hiện để dạng thứ tự tương đối.

## Sprint 1 — Dọn nền tảng
- [x] Khởi tạo git repository, push/pull với remote (2026-07-28)
- [x] Hợp nhất 2 bộ model (xem [[DevelopmentRoadmap]] Bước 0) (2026-07-28)
- [x] Xóa project mồ côi `KingdomCraft.Game`, cập nhật `.sln` (2026-07-28)
- [ ] CI tối thiểu: build + test tự động (xem [[CI_CD]]) — `.github/` hiện chỉ có `copilot-instructions.md`, chưa có workflow

## Sprint 2 — Core Loop
- [ ] `Player` + `Inventory` cơ bản
- [ ] `Chunk` render ở Client, đặt/phá khối
- [ ] Test cho `AutomationSystem` (đã có khung, mở rộng thêm case)

## Sprint 3 — Building & NPC
- [ ] Mở rộng `Building` (nhiều loại, level)
- [ ] Bổ nhiệm/thăng cấp NPC, `Schedule` cơ bản

## Sprint 4 — Crafting & Quest
- [ ] Recipe tối thiểu (5-10 recipe đầu)
- [ ] Quest cơ bản (main quest tuyến tính)

## Sprint 5 — Economy & Save
- [ ] Thị trường tài nguyên đơn giản
- [ ] Save/Load (JSON hoặc SQLite, xem [[SaveGame]])

## Sprint 6+ — Multiplayer
- [ ] Networking thật cho `KingdomCraft.Server` (thay vòng lặp demo)
- [ ] Đồng bộ nhiều vương quốc

## Liên kết
[[DevelopmentRoadmap]] · [[ProductRoadmap]] · [[RiskManagement]]
