# KingdomCraft

Game lấy cảm hứng từ Minecraft nhưng với trục tiến trình riêng: người chơi
chuyển dần từ tự làm mọi việc sang quản lý một vương quốc vận hành bởi NPC
tự động. Thể loại: Sandbox, Survival, City Builder, Kingdom Simulation, RPG,
Multiplayer.

## Cấu trúc dự án

```
KingdomCraft/
├── KingdomCraft.sln
├── src/
│   ├── KingdomCraft.Core/      # Logic game thuần .NET, không phụ thuộc engine
│   │   ├── World/              # Thế giới voxel/sandbox
│   │   ├── Entities/           # Player, Npc
│   │   ├── Kingdom/            # Building, ResourceStockpile, KingdomState
│   │   └── Simulation/         # AutomationSystem - cơ chế NPC tự động
│   ├── KingdomCraft.Client/    # Client MonoGame (render, input)
│   └── KingdomCraft.Server/    # Server headless cho multiplayer
├── tests/
│   └── KingdomCraft.Tests/     # Unit test (xUnit)
└── docs/                       # Tài liệu thiết kế game (xem docs/README.md)
```

## Yêu cầu
- .NET SDK 8.0+
- (Client) MonoGame — gói NuGet sẽ tự tải khi `dotnet restore` với internet.

## Bắt đầu
```bash
dotnet restore
dotnet build
dotnet run --project src/KingdomCraft.Server
```

## Tài liệu thiết kế
Xem thư mục `docs/` — đã dựng sẵn khung mục cho từng mảng (Sandbox, Survival,
City Builder, Kingdom Simulation, RPG, Multiplayer, Roadmap). Gửi thêm thông
tin chi tiết, mình sẽ điền trực tiếp vào các file tương ứng.
