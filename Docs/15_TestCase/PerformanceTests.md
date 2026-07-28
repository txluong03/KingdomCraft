# Performance Tests — KingdomCraft

## Mục đích
Đo và kiểm soát hiệu năng client/server (tick rate, RAM, thời gian sinh
chunk) — giảm thiểu trực tiếp các rủi ro Server Lag/Memory Leak đã nêu ở
[[RiskManagement]].

## Nội dung cần điền
- Kịch bản load test: số NPC đồng thời, số chunk load, số người chơi giả lập
- Ngưỡng chấp nhận cho tick rate của `AutomationSystem.Tick`
- Test chạy dài hạn (soak test) để phát hiện memory leak
- Công cụ profiling dự kiến (dotnet-trace, BenchmarkDotNet...)
- Kiểm chứng bằng số liệu thực tế giới hạn `Chunk.Size`/`Height` thay vì lý thuyết
- Baseline hiệu năng hiện tại (chưa đo lần nào) để so sánh sau mỗi sprint
- Ngưỡng cảnh báo khi hiệu năng giảm giữa các build (liên hệ [[Monitoring]])

## Câu hỏi mở
- Ngưỡng tick rate/FPS tối thiểu chấp nhận được là bao nhiêu?
- Có cần môi trường test trên máy cấu hình thấp hơn máy dev để mô phỏng người chơi thật không?

## Liên kết
- [[RiskManagement]]
- [[Monitoring]]
- [[DevelopmentRoadmap]]
- [[MultiplayerTests]]
