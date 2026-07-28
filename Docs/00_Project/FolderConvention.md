# Folder Convention — KingdomCraft

## Cấu trúc gốc
```
KingdomCraft/
├── KingdomCraft.sln
├── src/
│   ├── KingdomCraft.Core/      # Logic game thuần .NET, không phụ thuộc engine
│   │   ├── World/              # Sinh thế giới, chunk, block
│   │   ├── Entities/           # Player, Npc
│   │   ├── Kingdom/            # Building, ResourceStockpile, KingdomState
│   │   └── Simulation/         # AutomationSystem — cơ chế NPC tự động
│   ├── KingdomCraft.Application/ # AppService + DTO (ranh giới dùng chung cho Server/Client)
│   │   └── Kingdom/            # KingdomAppService, KingdomStateDto, *Input
│   ├── KingdomCraft.Client/    # Client MonoGame (render, input)
│   └── KingdomCraft.Server/    # Server headless cho multiplayer
├── tests/
│   └── KingdomCraft.Tests/     # Unit test (xUnit)
└── Docs/                       # Toàn bộ tài liệu (thư mục này)
```

## Quy tắc thêm thư mục con trong `Core`
- Tổ chức theo **domain**, không theo layer kỹ thuật (không tạo lại
  `Models/`/`Services/` chung chung — xem lý do ở [[CodingConvention]]).
- Mỗi domain folder có thể chứa: entity, enum liên quan, và hệ thống xử lý
  domain đó (VD: `Kingdom/` chứa cả `Building.cs` lẫn `ResourceStockpile.cs`).
- Khi 1 domain phình to (VD: `Kingdom/` khi thêm Economy/Politics), tách
  thành sub-folder thay vì để phẳng: `Kingdom/Economy/`, `Kingdom/Politics/`.

## Quy tắc namespace
Namespace phản chiếu đúng đường dẫn thư mục:
`KingdomCraft.Core.Kingdom` ↔ `src/KingdomCraft.Core/Kingdom/`.

## Quy tắc project mới
- Không tạo project mà không thêm vào `KingdomCraft.sln`. Project mồ côi
  `KingdomCraft.Game` đã bị xóa khi xử lý [[DevelopmentRoadmap]] Bước 0
  (2026-07-28) — `KingdomCraft.Server` là entry point chạy thử duy nhất còn
  lại cho tới khi có Client thật.
- Project mới cần lý do rõ ràng gắn với tầng kiến trúc: `Core` (logic),
  `Application` (AppService/DTO), `Client`/`Server` (presentation), `Tests`.
  Chỉ thêm `EntityFrameworkCore`/`Api` khi thực sự cần lưu trữ/expose ra
  ngoài (xem [[Database]], [[API]]).
- `KingdomCraft.Application` (2026-07-28) — mượn convention `FooAppService`
  từ dự án OC-TXNG (ABP Boilerplate) nhưng **chỉ mượn khung**, không kèm
  EF Core/multi-tenant/RBAC vì chưa cần ở quy mô hiện tại — xem
  [[Decisions]] và [[DevelopmentRoadmap]].

## Liên kết
[[CodingConvention]] · [[NamingConvention]]
