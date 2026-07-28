# Animation Style — KingdomCraft

## Mục đích
Định hướng phong cách hoạt ảnh cho nhân vật và NPC (di chuyển, làm việc
theo vai trò, chiến đấu). Hiện **chưa có animation nào** — NPC trong code
mới dừng ở dữ liệu vai trò/lịch làm việc.

## Nội dung cần điền
- Phong cách animation tổng thể (cứng/blocky giống Minecraft hay mượt hơn)
- Animation riêng theo `NpcRole` thể hiện đúng công việc (Farmer cày ruộng, Miner đào mỏ...)
- Animation thể hiện `SkillLevel`/`AutomationLevel` tăng dần (NPC làm việc "chuyên nghiệp" hơn)
- Animation chiến đấu cơ bản (đánh, né, chết)
- Số lượng animation tối thiểu cho bản Prototype so với bản đầy đủ
- Công cụ/pipeline dựng animation (rig chung hay riêng từng NPC)

## Câu hỏi mở
- Có cần animation riêng cho từng `NpcRole` ngay ở Prototype hay dùng animation idle/walk chung trước?
- Animation có phản ánh trực quan `SkillLevel`/`AutomationLevel` hay chỉ là số liệu ẩn?

## Liên kết
- [[ArtStyle]]
- [[Characters]]
- [[KingdomSystem]]
- [[SkillSystem]]
