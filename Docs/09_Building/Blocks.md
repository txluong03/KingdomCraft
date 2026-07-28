# Blocks

## Mục đích
Định nghĩa hệ thống khối voxel (`BlockType`) dùng để xây dựng tự do trong
thế giới — nền tảng kỹ thuật giống Minecraft mà KingdomCraft kế thừa, làm
cơ sở cho [[Structure]], [[Physics]] và [[KingdomBuildings]].

## Nội dung cần điền
- Danh sách đầy đủ `BlockType` (hiện có: Air, Dirt, Grass, Stone, Wood,
  Sand, Water...) và các loại cần bổ sung theo thời đại công nghệ (gạch,
  bê tông, kính, kim loại...).
- Thuộc tính mỗi block: độ cứng (thời gian phá), công cụ yêu cầu để khai
  thác hiệu quả (liên hệ [[Tools]]), có rơi vật phẩm khi phá không.
- Block trong suốt/không rắn (Water, Air, kính) và ảnh hưởng tới
  [[Physics]] (chảy, ánh sáng xuyên qua).
- Block chức năng đặc biệt (phát sáng, dẫn điện thời đại Electricity) khác
  block trang trí thuần túy.
- Quy tắc đặt/phá block: giới hạn tầm với, giới hạn theo lãnh thổ vương
  quốc hay tự do như Minecraft.
- Ánh xạ block ↔ tài nguyên khi phá (VD: phá Stone rơi item Stone trong
  [[Resources]]).

## Câu hỏi mở
- Thế giới có giới hạn xây dựng theo lãnh thổ vương quốc (không xây được
  ngoài biên giới) hay tự do toàn bản đồ như Minecraft thuần?
- Block có hệ thống ánh sáng/dẫn điện phức tạp (redstone-like) cho thời đại
  Electricity/Automation hay giữ đơn giản?

## Liên kết
[[Structure]] · [[Physics]] · [[Resources]] · [[Tools]]
