# Seed Data — KingdomCraft

## Mục đích
Định nghĩa dữ liệu khởi tạo (seed) cần có khi tạo Kingdom mới hoặc khởi
động server lần đầu. **Định hướng tương lai**: hiện `Program.cs` chỉ tạo 1
`KingdomState` cứng (`"Vương quốc mẫu"`) trong bộ nhớ, chưa có cơ chế seed
từ DB hay file cấu hình nào.

## Nội dung cần điền
- Dữ liệu cấu hình tĩnh cần seed: danh sách BuildingType, danh sách
  NpcRole, công thức chế tạo khởi điểm (liên hệ [[Recipes]])
- Kingdom mặc định cho người chơi mới (đúng tinh thần giai đoạn "Người sống
  sót" ở [[Progression]]): tài nguyên ban đầu, công trình ban đầu nếu có
- NPC mẫu ban đầu (nếu game cho sẵn 1 NPC thay vì phải tuyển)
- Dữ liệu demo/test riêng cho môi trường dev, tách khỏi seed production
- Chiến lược versioning seed data khi thêm BuildingType/NpcRole mới mà
  không phá vỡ save cũ

## Câu hỏi mở
- Người chơi mới bắt đầu với 0 tài nguyên tuyệt đối (đúng tinh thần "Người
  sống sót") hay có seed tối thiểu để tránh trải nghiệm quá khó?
- Seed data lưu ở file JSON tĩnh trong repo hay bảng DB chỉnh được qua công
  cụ admin?

## Liên kết
- [[Tables]]
- [[Progression]]
- [[KingdomSystem]]
- [[Migration]]
