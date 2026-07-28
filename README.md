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
└── KingdomCraft-Docs/          # Tài liệu dự án đầy đủ (xem KingdomCraft-Docs/README.md)
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

## Tài liệu dự án
Xem thư mục `KingdomCraft-Docs/` — bộ tài liệu đầy đủ 21 nhóm (Project, BRD,
GDD, Gameplay, World Generation, Player, NPC/AI, Items, Crafting, Building,
Combat, Database, API, Server, UI/UX, TestCase, Deployment, Art, Audio, Lore,
DevLogs). `00_Project/ProjectVision.md` và `00_Project/ProjectScope.md` là
2 file nên đọc trước tiên. `00_Project` và `02_GDD` đã có nội dung đầy đủ;
các nhóm còn lại hiện là khung sườn (mục đích, nội dung cần điền, câu hỏi
mở) — điền trực tiếp vào file tương ứng khi có quyết định thiết kế mới,
không tạo file rời rạc.
