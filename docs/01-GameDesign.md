# Game Design — KingdomCraft

## Tổng quan
KingdomCraft là game xây dựng & quản lý vương quốc (kingdom builder), nơi người chơi:
- Xây dựng công trình (Farm, Mine, Lumberyard, Barracks, Wall...)
- Thu thập tài nguyên (Gold, Wood, Stone, Food)
- Tuyển quân và chiến đấu (Peasant, Soldier, Archer, Knight)
- Tiến qua từng lượt (turn-based) để phát triển vương quốc

## Gameplay Loop cơ bản
1. Người chơi bắt đầu với một Town Hall và tài nguyên khởi điểm.
2. Mỗi turn, các công trình sản xuất tài nguyên tương ứng.
3. Người chơi dùng tài nguyên để xây thêm công trình hoặc tuyển quân.
4. (Tương lai) Chiến đấu với vương quốc khác hoặc quái vật, mở rộng lãnh thổ.

## Tài nguyên (Resources)
| Loại  | Nguồn gốc       | Dùng để             |
|-------|-----------------|---------------------|
| Gold  | Thương mại/thuế | Xây công trình      |
| Wood  | Lumberyard      | Xây công trình      |
| Stone | Mine            | Xây công trình      |
| Food  | Farm            | Tuyển quân, nuôi dân|

## Công trình (Buildings)
- **TownHall**: Trung tâm vương quốc, không sản xuất trực tiếp.
- **Farm**: Sản xuất Food.
- **Mine**: Sản xuất Stone.
- **Lumberyard**: Sản xuất Wood.
- **Barracks**: Cho phép tuyển quân mạnh hơn (mở rộng sau).
- **Wall**: Phòng thủ (mở rộng sau).

## Đơn vị quân (Units)
| Unit    | Attack | Defense | Health |
|---------|--------|---------|--------|
| Peasant | 1      | 1       | 5      |
| Soldier | 5      | 4       | 20     |
| Archer  | 7      | 2       | 15     |
| Knight  | 10     | 8       | 35     |

## Định hướng mở rộng (ý tưởng, chưa triển khai)
- Hệ thống công nghệ (Tech tree)
- Chiến tranh giữa các vương quốc (PvP/PvE)
- Sự kiện ngẫu nhiên (thiên tai, thương nhân, quái vật tấn công)
- Bản đồ thế giới (world map) với nhiều ô đất
- Hệ thống nhiệm vụ (quests)

> Ghi chú: đây là tài liệu khởi tạo, hãy chỉnh sửa/mở rộng theo ý tưởng thực tế của bạn.
