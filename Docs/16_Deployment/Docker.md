# Docker — KingdomCraft

## Mục đích
Đóng gói `KingdomCraft.Server` bằng container để triển khai/nhân bản dễ
dàng. Hiện server mới là vòng lặp `Task.Delay` demo, **chưa có gì thật để
đóng gói** — đây là khung chuẩn bị cho khi networking thật hoàn thiện.

## Nội dung cần điền
- Dockerfile cho `KingdomCraft.Server` (base image .NET runtime phù hợp)
- Biến môi trường cấu hình server (port, connection string database)
- `docker-compose` cho môi trường dev (server + database cùng lúc)
- Tối ưu kích thước image, tối ưu layer build
- Container dùng cho môi trường nào (dev/staging) trước khi có hạ tầng production thật
- Liên hệ với [[Monitoring]] để theo dõi container khi chạy

## Câu hỏi mở
- Server production sẽ chạy trên VPS thường hay hạ tầng container hóa (Kubernetes) ngay từ đầu?
- Database đi kèm container hay dùng dịch vụ managed riêng?

## Liên kết
- [[Database]]
- [[Monitoring]]
- [[CI_CD]]
- [[DevelopmentRoadmap]]
