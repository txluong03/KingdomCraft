# Kingdom Buildings

## Mục đích
Định nghĩa chi tiết các công trình vương quốc (`BuildingType`) — cầu nối
trực tiếp giữa tài liệu thiết kế và code hiện có tại
`src/KingdomCraft.Core/Kingdom/Building.cs` (`TownHall, Farm, LumberMill,
Mine, Barracks, Market, House, Wall, Custom`, cùng `Position`, `Level`,
`AssignedNpcId`).

## Nội dung cần điền
- Vai trò/chức năng từng `BuildingType` hiện có: TownHall (trung tâm quản
  lý), Farm (sản xuất Food), LumberMill (Wood), Mine (Stone), Barracks
  (quân đội), Market (thương mại/Gold), House (Housing/Population), Wall
  (phòng thủ), Custom (mở rộng tự do).
- Công thức sản lượng theo `Level` mỗi loại công trình (liên hệ
  `GetProductionPerTurn`-style trong [[Economy]]).
- Chi phí xây dựng/nâng cấp Level (tài nguyên, thời gian) — tăng theo cấp
  số nhân nhẹ như đã đề cập ở [[Economy]].
- Quan hệ `AssignedNpcId` ↔ `NpcRole`: công trình nào bắt buộc gán đúng vai
  trò NPC tương ứng mới hoạt động (VD: Farm cần NPC Farmer).
- Công trình mới cần bổ sung ngoài danh sách hiện có (VD: Steward's Hall
  được nhắc tới trong [[KingdomSystem]] nhưng chưa có trong enum) và lộ
  trình thêm vào code.
- Giới hạn số lượng mỗi loại công trình theo Progression (VD: chỉ Vua trở
  lên mới xây được nhiều hơn 1 Barracks).
- Ảnh hưởng phá hủy công trình (chiến tranh, thiên tai) tới sản xuất và
  `AutomationLevel`.

## Câu hỏi mở
- Steward's Hall (nhắc tới trong [[KingdomSystem]] như công trình tăng
  `AutomationLevel`) có nên thêm thành `BuildingType` riêng trong code, hay
  gộp vào nâng cấp Level của TownHall?
- Mỗi công trình có giới hạn số NPC gán cùng lúc (`AssignedNpcId` hiện là
  1 NPC/công trình) hay cần mở rộng thành danh sách nhiều NPC mỗi công
  trình lớn (Barracks, Farm quy mô)?
- `Custom` building dùng để làm gì trong thiết kế thật (công trình do người
  chơi tự định nghĩa, hay chỗ trống kỹ thuật cho tương lai)?

## Liên kết
[[KingdomSystem]] · [[Economy]] · [[Blueprints]] · [[CraftStations]]
