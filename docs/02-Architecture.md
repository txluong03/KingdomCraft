# Kiến trúc dự án — KingdomCraft

## Cấu trúc thư mục

```
KingdomCraft/
├── KingdomCraft.sln
├── src/
│   ├── KingdomCraft.Core/          # Class library: logic game thuần (không phụ thuộc UI)
│   │   ├── Models/                 # Kingdom, Resource, Building, Unit
│   │   └── Services/                # GameEngine (điều khiển turn, xây dựng, tuyển quân)
│   └── KingdomCraft.Game/          # Console app: entry point, dùng để chạy thử game
│       └── Program.cs
├── tests/
│   └── KingdomCraft.Tests/          # Unit test (xUnit) cho Core
└── docs/                            # Toàn bộ tài liệu thiết kế & kỹ thuật
```

## Nguyên tắc thiết kế
- **Tách logic khỏi giao diện**: `KingdomCraft.Core` không biết gì về console/UI.
- **Model đơn giản, dễ mở rộng**: cứ thêm field/method khi cần.
- **GameEngine là nơi chứa luật chơi**: mọi thay đổi trạng thái nên đi qua `GameEngine`.

## Build & chạy
Yêu cầu .NET 8 SDK.

```bash
dotnet build
dotnet run --project src/KingdomCraft.Game
dotnet test
```

## Gợi ý mở rộng kỹ thuật
- Thêm `KingdomCraft.Data` nếu cần lưu/tải save game (JSON, SQLite...)
- Thêm `KingdomCraft.Api` nếu muốn expose game qua REST API
- Thêm `KingdomCraft.UI` (Blazor/MAUI/Unity) khi có giao diện đồ họa
