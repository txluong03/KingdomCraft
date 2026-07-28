# Terrain Generation

## Mục đích
Quy định thuật toán sinh địa hình theo chunk (`Size=16`, `Height=128`, xem
`src/KingdomCraft.Core/World/Chunk.cs`) — nền tảng kỹ thuật cho toàn bộ
world generation khác (hang, quặng, cấu trúc).

## Nội dung cần điền
- Thuật toán noise dùng để sinh height map (Perlin/Simplex hay khác)
- Quy tắc xếp lớp block theo độ cao (Stone ở đáy, Dirt/Grass phía trên,
  Sand ven nước, Water ở mực nước biển) dựa trên `BlockType` hiện có
- Cách đảm bảo địa hình liền mạch giữa các chunk lân cận
- Seed và tính xác định (determinism) của world generation
- Ảnh hưởng của giới hạn `Height=128` tới núi cao và hang sâu
- Kế hoạch bổ sung `BlockType` mới (quặng, tuyết...) không phá vỡ dữ liệu cũ

## Câu hỏi mở
- Thế giới có sinh vô hạn hay giới hạn theo lãnh thổ vương quốc (xem
  [[Biomes]])?
- Hiệu năng sinh chunk có đủ đáp ứng khi vương quốc mở rộng và nhiều NPC tự
  động khai thác đồng thời trong môi trường multiplayer không?
- Có cần pregen địa hình theo lãnh thổ khi người chơi lên giai đoạn Vua/Đế
  quốc (mở rộng nhiều khu định cư) không?

## Liên kết
[[Biomes]] · [[CaveGeneration]] · [[OreGeneration]] · [[Glossary]]
