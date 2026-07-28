# Ore Generation

## Mục đích
Quy tắc phân bố quặng và tài nguyên khai thác trong lòng đất — nguồn
nguyên liệu chính nuôi Crafting và Technology Tree.

## Nội dung cần điền
- Danh sách loại quặng theo độ hiếm (cần `BlockType` mới ngoài `Stone`
  hiện có, xem `Chunk.cs`)
- Độ sâu/vùng phân bố mỗi loại quặng, liên hệ [[CaveGeneration]]
- Liên hệ với thứ tự công nghệ trong [[TechnologyTree]] (Đá → Đồng → Sắt...)
- Tốc độ khai thác theo `SkillLevel` của Miner NPC
- Quặng có tái sinh theo thời gian hay hữu hạn, khai thác cạn thì sao
- Ảnh hưởng khan hiếm quặng tới [[Economy]] (giá cả, thương mại)

## Câu hỏi mở
- Quặng có tái sinh để NPC Miner tự động không cạn kiệt tài nguyên vĩnh
  viễn quanh vương quốc không?
- Độ hiếm/loại quặng mở khóa được có nên gắn trực tiếp với giai đoạn
  [[Progression]] hay chỉ phụ thuộc công nghệ đã nghiên cứu?

## Liên kết
[[TerrainGeneration]] · [[CaveGeneration]] · [[TechnologyTree]] · [[KingdomSystem]]
