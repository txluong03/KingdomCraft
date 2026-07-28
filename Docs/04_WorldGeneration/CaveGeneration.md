# Cave Generation

## Mục đích
Quy tắc sinh hang động dưới lòng đất trong giới hạn `Height=128`, tạo không
gian cho khai thác tài nguyên, dungeon, và nơi quái vật xuất hiện.

## Nội dung cần điền
- Thuật toán sinh hang (cellular automata, noise 3D, hoặc kết hợp)
- Giới hạn độ sâu và tần suất hang theo từng biome
- Cách hang kết nối với vùng quặng (liên hệ [[OreGeneration]])
- Quy tắc ánh sáng/an toàn và điều kiện quái vật xuất hiện (liên hệ
  [[EnemyAI]])
- Phân biệt miệng hang lộ thiên vs hang ngầm hoàn toàn
- Ảnh hưởng cấu trúc hang tới cách Miner NPC tự động di chuyển và đào

## Câu hỏi mở
- NPC Miner tự động có tự đi sâu vào hang để khai thác hay chỉ đào trong
  khu vực an toàn gần vương quốc?
- Hang có chứa dungeon/kho báu lồng bên trong hay tách hẳn phạm vi với
  [[DungeonGeneration]]?

## Liên kết
[[TerrainGeneration]] · [[OreGeneration]] · [[DungeonGeneration]] · [[EnemyAI]]
