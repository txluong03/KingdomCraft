# Building Flow — KingdomCraft

## Đã cài đặt (2026-07-28, `KingdomAppService`)
- `CreateBuilding(CreateBuildingInput{Type, Name?, Level?})` → `BuildingDto`
  — thêm công trình vào `KingdomState.Buildings` (mặc định `Level = 1`).
- Sản lượng công trình xem [[KingdomBuildings]] (`GetProductionPerTick`,
  vừa thêm `Market` → Gold).
- **Chưa có** chi phí tài nguyên khi tạo công trình — `CreateBuilding`
  hiện không trừ `ResourceStockpile` (khác `TryConstructBuilding` cũ ở bộ
  code turn-based đã xóa Bước 0, vốn có `TrySpend` gold). Đây là hạn chế
  cố ý để giữ Bước 2 tập trung vào luồng chức năng — thêm chi phí khi có
  UI xây dựng thật (xem câu hỏi mở).

## Nội dung cần điền (chưa cài đặt)
- Luồng đặt công trình trong world thật: chọn vị trí, trực quan hóa
  blueprint trước khi xây, kích thước thật trong voxel.
- Chi phí tài nguyên + thời gian xây/nâng cấp `Level`.
- Gán NPC quản lý công trình (`AssignedNpcId`) — field đã có trên
  `Building` nhưng **chưa có method trong `KingdomAppService`** để gán
  (khác với gán `Role` cho NPC qua `AssignNpcRole`) — cần thêm khi làm UI
  xây dựng.
- Loại `Custom` — phạm vi tự do tới đâu.
- Ràng buộc quy hoạch (khoảng cách, giới hạn lãnh thổ).

## Câu hỏi mở
- Chi phí xây dựng nên thêm ngay vào `CreateBuilding` (trừ
  `ResourceStockpile`, có thể fail nếu không đủ) hay để tới khi có UI mới
  thêm, tránh phải sửa lại chữ ký API 2 lần?
- Khi `AutomationLevel` đủ cao, Steward có được tự đề xuất/xây công trình
  mới qua `KingdomAppService` thay người chơi không (đã nêu ở
  [[KingdomSystem]])?

## Liên kết
[[KingdomSystem]] · [[KingdomBuildings]] · [[NPCFlow]] · [[Economy]]
