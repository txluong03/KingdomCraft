# Building Flow — KingdomCraft

## Mục đích
Mô tả luồng xây dựng công trình vương quốc (đặt, nâng cấp, gán NPC quản
lý), dùng trực tiếp `Building`/`BuildingType` trong
`src/KingdomCraft.Core/Kingdom/Building.cs` — khác với xây tự do bằng khối
kiểu Minecraft (thuộc phạm vi world/voxel), file này tập trung vào công
trình có chức năng kinh tế/quản lý.

## Nội dung cần điền
- Danh sách `BuildingType` hiện có (TownHall, Farm, LumberMill, Mine, Barracks, Market, House, Wall, Custom) và chức năng từng loại
- Luồng đặt công trình: chọn vị trí, yêu cầu tài nguyên (`ResourceStockpile`), thời gian xây/tức thời
- Cơ chế nâng cấp `Level` của Building — chi phí và lợi ích tăng theo cấp
- Gán NPC quản lý công trình (`AssignedNpcId`) — luồng thao tác cụ thể, giới hạn số NPC mỗi công trình
- Loại `Custom` — phạm vi cho phép người chơi tự thiết kế công trình tự do đến đâu
- Ràng buộc quy hoạch (khoảng cách giữa các công trình, giới hạn theo lãnh thổ)
- Trực quan hóa công trình trong world voxel (kích thước thật, blueprint đặt trước khi xây)

## Câu hỏi mở
- Khi AutomationLevel đủ cao, Steward có được phép tự đề xuất/xây công trình mới thay người chơi không (đã nêu là câu hỏi mở ở [[KingdomSystem]]) — nếu có, luồng phê duyệt của người chơi diễn ra thế nào trong UI?
- Công trình `Custom` (tự do) có tương tác gì với hệ thống sản lượng tự động, hay chỉ mang tính thẩm mỹ?

## Liên kết
[[KingdomSystem]] · [[NPCFlow]] · [[TechnologyTree]] · [[Economy]]
