# Characters — KingdomCraft

## Mục đích
Định hướng thiết kế hình dáng nhân vật người chơi và NPC theo vai trò
(Farmer, Miner, Steward...). Hiện **chưa có thiết kế/asset nhân vật nào** —
NPC trong code chỉ là dữ liệu (`NpcRole`, `SkillLevel`), chưa có hình ảnh.

## Nội dung cần điền
- Thiết kế hình dáng cơ bản người chơi (tùy biến ngoại hình hay cố định)
- Phân biệt hình ảnh giữa các `NpcRole` để người chơi nhận diện từ xa
- Ngoại hình có thay đổi theo cấp bậc tiến trình (Người sống sót → Vua) hay không
- Trang phục/trang bị hiển thị trên nhân vật (liên hệ hệ thống Item)
- Số lượng rig/animation cần cho mỗi loại NPC (liên hệ [[AnimationStyle]])
- Nhân vật có tùy biến được ở multiplayer hay dùng chung một bộ model

## Câu hỏi mở
- Mỗi `NpcRole` có model riêng hay dùng chung model + màu/phụ kiện phân biệt?
- Người chơi có tùy biến ngoại hình (character creator) hay dùng nhân vật cố định như Minecraft?

## Liên kết
- [[ArtStyle]]
- [[AnimationStyle]]
- [[Glossary]]
- [[KingdomSystem]]
