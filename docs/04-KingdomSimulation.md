# 04 - Kingdom Simulation (cơ chế "chuyển giao")

Đây là mảng khác biệt cốt lõi của KingdomCraft — cần tài liệu chi tiết nhất.

## Nội dung cần bổ sung
- Công thức/điều kiện tăng AutomationLevel.
- Vai trò NPC đầy đủ (hiện có: Farmer, Lumberjack, Miner, Soldier, Merchant, Steward).
- Cách bổ nhiệm, huấn luyện, thăng cấp NPC.
- NPC ra quyết định tự động ở mức nào (chỉ sản xuất, hay cả xây dựng/mở rộng lãnh thổ)?
- Sự kiện ngẫu nhiên trong vương quốc (nổi loạn, thiên tai, xâm lược) khi tự động hóa cao.

*(Khung tham chiếu code: `src/KingdomCraft.Core/Simulation/AutomationSystem.cs`,
`src/KingdomCraft.Core/Kingdom/KingdomState.cs`)*
