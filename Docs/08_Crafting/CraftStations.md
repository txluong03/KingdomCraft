# Craft Stations

## Quyết định (2026-07-28)
Giai đoạn này chỉ có **2 trạm** (`Core/Crafting/CraftStation.cs`):
- `None` — chế tạo tay không, mọi lúc mọi nơi.
- `Workbench` — yêu cầu bàn thợ.

## Giản lược tạm thời — CHƯA gắn với vị trí thế giới thực
`CraftingSystem.TryCraft` nhận tham số `bool hasStationAccess` do người
gọi (Client/Game) tự xác định — **chưa** kiểm tra người chơi có thật sự
đứng gần 1 Workbench đã đặt trong world hay không, vì world-placement cho
vật phẩm đặt được ([[Furniture]]) chưa cài đặt. Đây là nợ kỹ thuật đã ghi
ở [[TechnicalDebt]], cần xử lý khi làm [[BuildingFlow]]/[[Furniture]] thật.

## Chưa có (để sau, tránh over-engineer ở quy mô hiện tại)
- Trạm hao mòn/bảo trì theo thời gian.
- Nhiều recipe chạy song song trên 1 trạm (hiện Craft là 1 hành động tức
  thời, không có hàng đợi — xem [[Recipes]]).
- Giới hạn số lượng trạm theo dân số/diện tích.
- Trạm cấp lớn hơn gắn với `KingdomBuildings` (VD: lò rèn quy mô trong
  Barracks) — Workbench hiện là khái niệm cá nhân, không phải `Building`.

## Câu hỏi mở
- Khi world-placement có Workbench thật, kiểm tra "gần trạm" nên theo bán
  kính (VD: 3 block) hay theo chunk hiện tại?
- `Smelting`/`Cooking`/`Brewing` có nên là `CraftStation` riêng (Furnace,
  Oven, Barrel) hay dùng chung `Workbench` với recipe khác nhau?

## Liên kết
[[Recipes]] · [[KingdomBuildings]] · [[Furniture]] · [[TechnicalDebt]]
