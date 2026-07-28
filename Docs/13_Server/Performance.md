# Performance (Server) — KingdomCraft

## Mục đích
Định hướng yêu cầu và kỹ thuật tối ưu hiệu năng server khi số lượng
Kingdom/NPC/Player tăng. **Định hướng tương lai**: hiện vòng lặp Tick trong
`Program.cs` chạy đơn giản, tuần tự qua toàn bộ `Npcs` của 1 Kingdom mỗi
giây — chưa được đo đạc hay tối ưu vì chưa có tải thật.

## Nội dung cần điền
- Benchmark vòng lặp `AutomationSystem.Tick` khi số lượng NPC/Building lớn
  (foreach tuần tự hiện tại có là bottleneck?)
- Chiến lược multi-threading/song song hóa tick giữa nhiều Kingdom độc lập
- Giới hạn tick rate cấu hình được, có thể giảm khi tải cao (graceful
  degradation)
- Bộ nhớ: kích thước `KingdomState` tăng theo Building/Npc/Resources — ước
  tính giới hạn thực tế 1 instance server chịu được
- Profiling và log hiệu năng (thời gian mỗi tick, độ trễ network) — liên
  hệ [[Network]]
- Tối ưu truy vấn DB khi [[Tables]]/[[Indexes]] được hiện thực (tránh
  query trong vòng lặp tick)

## Câu hỏi mở
- Ngưỡng chấp nhận được là bao nhiêu Player/NPC đồng thời trên 1 server
  instance trước khi cần scale-out?
- Tick loop hiện tại (foreach đơn luồng mỗi giây) đã đủ cho early game,
  nhưng ngưỡng nào buộc phải song song hóa/tối ưu thuật toán?

## Liên kết
- [[Architecture]]
- [[Synchronization]]
- [[Indexes]]
- [[DevelopmentRoadmap]]
