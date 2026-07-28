# Pathfinding

## Mục đích
Thuật toán tìm đường cho NPC di chuyển trong thế giới voxel dạng chunk —
nền tảng kỹ thuật bắt buộc để [[VillagerAI]], [[EnemyAI]], [[AnimalAI]]
hoạt động đúng.

## Nội dung cần điền
- Thuật toán đề xuất (A* trên lưới voxel, navmesh giản lược, hay khác)
- Xử lý địa hình 3D (leo, nhảy, bơi qua block Water)
- Tối ưu hiệu năng khi số lượng NPC lớn (hàng chục-hàng trăm NPC ở giai
  đoạn Lãnh chúa/Vua/Đế quốc)
- Pathfinding xuyên biên chunk (`Chunk.Size = 16`)
- Cache đường đi cho NPC di chuyển lặp lại (từ nhà tới nơi làm việc)

## Câu hỏi mở
- Có cần giới hạn số NPC tính pathfinding đồng thời mỗi tick để tránh nghẽn
  hiệu năng ở `AutomationLevel` cao, và nên đánh đổi độ chính xác đường đi
  ra sao?
- Pathfinding có cần server-authoritative đồng bộ multiplayer ngay từ đầu
  không, hay client có thể dự đoán cục bộ?

## Liên kết
[[VillagerAI]] · [[BehaviourTree]] · [[TerrainGeneration]] · [[EnemyAI]]
