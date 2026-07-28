# Risk Management — KingdomCraft

## Rủi ro kỹ thuật
| Rủi ro | Ảnh hưởng | Giảm thiểu |
|---|---|---|
| Server Lag | Trải nghiệm multiplayer kém | Profiling sớm, giới hạn tick rate, tối ưu `AutomationSystem.Tick` |
| Memory Leak | Server crash sau thời gian dài chạy | Load test dài hạn (xem [[PerformanceTests]]) |
| Chunk quá lớn | Tốn RAM, sinh world chậm | Giới hạn `Chunk.Size`/`Height`, lazy load theo khoảng cách người chơi |
| Deadlock / Database Lock | Server treo khi nhiều truy vấn đồng thời | Review kỹ transaction trong [[Database]], tránh lock lồng nhau |
| Dup Item / Rollback | Mất cân bằng kinh tế, mất lòng tin người chơi | Giao dịch atomic, log đầy đủ để rollback (xem [[SaveGame]]) |
| Hack / Cheat | Phá game multiplayer | Validate phía server, không tin client (xem [[AntiCheat]]) |

## Rủi ro sản phẩm/dự án
| Rủi ro | Ảnh hưởng | Giảm thiểu |
|---|---|---|
| **Scope creep** — cấu trúc tài liệu mô tả quy mô ~140 file, 180+ bảng DB, 250+ API cho quy mô đội hiện tại rất nhỏ | Không bao giờ ra được bản chơi được | Bám chặt [[ProjectScope]] Core Scope, không code phần Extended Scope trước khi Core ổn định |
| ~~2 bộ model song song chưa hợp nhất~~ | Nhầm lẫn, code thừa, bug khó debug | **Đã xử lý (2026-07-28)**, xem [[Decisions]], [[KnownIssues]] |
| ~~Chưa có git repository~~ | Không rollback được, dễ mất code | **Đã xử lý** — đã init + push/pull, còn thiếu áp dụng đầy đủ [[BranchStrategy]] (feature branch/PR) |
| Tài liệu đi trước code quá xa | Tài liệu lỗi thời so với thực tế | Cập nhật doc song song với mỗi sprint, không viết một lần rồi bỏ quên |

## Liên kết
[[ProjectScope]] · [[DevelopmentRoadmap]] · [[AntiCheat]] · [[SaveGame]]
