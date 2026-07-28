# Coding Convention — KingdomCraft

Stack: .NET 8, C#. Xem [[NamingConvention]] cho quy tắc đặt tên chi tiết,
[[FolderConvention]] cho cấu trúc thư mục.

## Nguyên tắc kiến trúc
- **`KingdomCraft.Core` không phụ thuộc engine/UI** — không reference
  MonoGame, không `Console.WriteLine` trong logic game (chỉ ở entry point).
- **Domain trước, layer sau**: tổ chức theo domain (`World/`, `Entities/`,
  `Kingdom/`, `Simulation/`) chứ không theo tầng kỹ thuật chung chung
  (`Models/`, `Services/`, `Helpers/`) — đây là lý do cần hợp nhất 2 bộ
  model hiện tại theo hướng domain (xem [[DevelopmentRoadmap]]).
- **Mọi thay đổi trạng thái quan trọng đi qua 1 điểm rõ ràng**, tương tự vai
  trò `GameEngine`/`AutomationSystem` hiện tại — tránh sửa trực tiếp field
  của entity từ nhiều nơi rải rác.
- Chuẩn bị cho Clean Architecture khi thêm `Database`/`API`: Core (domain) →
  Application (use case) → Infrastructure (DB, network) → Presentation
  (Client/Server entry point). Chưa cần áp dụng đầy đủ CQRS/DDD khi project
  còn nhỏ — thêm khi độ phức tạp thực sự đòi hỏi.

## Quy tắc code
- Nullable reference types: bật, xử lý rõ ràng thay vì `!` bừa bãi.
- Ưu tiên `record`/`readonly` cho dữ liệu bất biến (VD: cấu hình loại
  building, loại item).
- Async: hậu tố `Async`, không `async void` trừ event handler.
- Logging: dùng `ILogger<T>` (Microsoft.Extensions.Logging) khi thêm Server
  thật, không `Console.WriteLine` ngoài demo/CLI.
- Validation: chỉ validate ở biên (input người chơi, API, dữ liệu load từ
  DB) — không validate lại dữ liệu nội bộ đã được đảm bảo đúng.

## Test
- Mỗi hệ thống gameplay (`AutomationSystem`, tương lai: `CraftingSystem`,
  `CombatSystem`...) phải có unit test tương ứng trong
  `tests/KingdomCraft.Tests`, đặt tên `<ClassName>Tests.cs`.

## Liên kết
[[NamingConvention]] · [[FolderConvention]] · [[UnitTests]]
