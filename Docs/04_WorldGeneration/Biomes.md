# Biomes

## Mục đích
Định nghĩa các vùng địa lý (biome) được sinh ra trong thế giới voxel của
KingdomCraft — nền tảng cho phân bố tài nguyên, thời tiết theo vùng, và lựa
chọn vị trí đặt vương quốc.

## Nội dung cần điền
- Danh sách biome đề xuất (Đồng cỏ, Rừng, Sa mạc, Núi, Đầm lầy, Tuyết...)
- Block chủ đạo mỗi biome dựa trên `BlockType` hiện có (Grass/Dirt/Stone/
  Sand/Water) và block mới cần bổ sung nếu có
- Quy tắc phân bố biome (noise nhiệt độ/độ ẩm, kích thước vùng)
- Tài nguyên đặc trưng theo biome (liên hệ [[OreGeneration]])
- Ảnh hưởng biome tới nơi NPC có thể định cư/canh tác/chăn nuôi
- Biome hiếm/đặc biệt dành cho nội dung cuối game

## Câu hỏi mở
- Thế giới sinh vô hạn theo chunk như Minecraft, hay giới hạn dần theo lãnh
  thổ vương quốc mở rộng (xem câu hỏi tương tự ở [[ProjectVision]])?
- Biome có ảnh hưởng tới cách AI NPC tự chọn nơi làm nông/khai thác khi
  `AutomationLevel` tăng không, hay khu vực làm việc luôn do người chơi
  chỉ định thủ công?
- Có cần biome riêng cho "vùng chưa khai phá" nằm ngoài lãnh thổ vương quốc
  đang kiểm soát không?

## Liên kết
[[TerrainGeneration]] · [[OreGeneration]] · [[VillageGeneration]] · [[ProjectVision]]
