# Environment — KingdomCraft

## Mục đích
Định hướng mỹ thuật cho thế giới/địa hình (biome, công trình, cây cối).
Hiện thế giới trong code chỉ là khối màu cơ bản (`BlockType`: Air, Dirt,
Grass, Stone, Wood, Sand, Water...), **chưa có asset môi trường thật**.

## Nội dung cần điền
- Bảng texture cho từng `BlockType` hiện có và các loại sẽ thêm
- Phong cách kiến trúc công trình theo từng giai đoạn tiến trình (lều tạm → lâu đài)
- Thiết kế biome khác biệt về mỹ thuật, không chỉ khác dữ liệu (xem [[Biomes]])
- Hiệu ứng thời tiết/ánh sáng theo thời gian trong ngày
- Mật độ chi tiết môi trường (cây, đá, trang trí) ảnh hưởng hiệu năng (liên hệ [[PerformanceTests]])
- Nhất quán hình ảnh khi vương quốc mở rộng lãnh thổ

## Câu hỏi mở
- Kiến trúc công trình có thay đổi hình ảnh rõ rệt theo từng giai đoạn (Trưởng làng → Lãnh chúa → Vua) hay chỉ tăng số lượng?
- Có hỗ trợ texture pack tùy biến bởi người chơi (giống resource pack) không?

## Liên kết
- [[ArtStyle]]
- [[Biomes]]
- [[TerrainGeneration]]
- [[PerformanceTests]]
