# Build Pipeline — KingdomCraft

## Mục đích
Định nghĩa quy trình build project (`.sln` → artifact chạy được) cho Client
và Server. Hiện dự án **chưa có pipeline build tự động nào** — mọi build
đều thủ công qua IDE/`dotnet` CLI ở giai đoạn Prototype hiện tại.

## Nội dung cần điền
- Lệnh build chuẩn cho từng project (`KingdomCraft.Core`, Client, Server) sau khi dọn project mồ côi `KingdomCraft.Game`
- Cấu hình Debug/Release và khác biệt giữa 2 cấu hình
- Output artifact mong muốn (thư mục, tên file, versioning theo [[ReleasePlan]])
- Phụ thuộc bên ngoài cần đóng gói cùng (runtime .NET, tài nguyên game)
- Bước build client có tách riêng server hay chung một pipeline
- Điều kiện build phải pass trước khi cho phép merge (liên hệ [[BranchStrategy]], [[CI_CD]])

## Câu hỏi mở
- Build thủ công qua `dotnet` CLI là đủ ở giai đoạn Prototype, hay cần script build ngay từ Sprint 1?
- Build server và client có tách pipeline riêng hay dùng chung?

## Liên kết
- [[CI_CD]]
- [[BranchStrategy]]
- [[ReleasePlan]]
- [[Milestones]]
