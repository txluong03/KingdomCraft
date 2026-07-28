# NPC Flow — KingdomCraft

## Mục đích
Mô tả luồng thao tác cụ thể của người chơi khi tương tác với NPC (tuyển
dụng, bổ nhiệm, huấn luyện, thăng cấp Steward) — hiện thực hóa phần
"Bổ nhiệm, huấn luyện, thăng cấp NPC" đã phác thảo ở [[KingdomSystem]]
thành luồng UI/gameplay cụ thể, bám theo `Npc.cs` (`Role`, `SkillLevel`,
`Position`).

## Nội dung cần điền
- Luồng tuyển dụng NPC mới: nguồn gốc (sinh ra từ Population, thuê từ thương nhân, giải cứu từ dungeon...)
- Luồng bổ nhiệm: chọn NPC đang `Idle`, gán `NpcRole`, xác nhận nơi làm việc/công trình
- Luồng huấn luyện tăng `SkillLevel` (qua thời gian làm việc, công trình đào tạo, hay item huấn luyện)
- Điều kiện và luồng thăng cấp lên `Steward` (yêu cầu kỹ năng tối đa + danh vọng, theo đề xuất ở [[KingdomSystem]])
- Hiển thị thông tin NPC cho người chơi (UI bảng thông tin: vai trò, kỹ năng, trạng thái hiện tại)
- Luồng sa thải/thuyên chuyển NPC giữa các vai trò hoặc công trình
- Phản hồi trực quan khi NPC đang làm việc (animation, di chuyển theo `Position`)

## Câu hỏi mở
- Người chơi có thể đặt tên, tùy biến NPC (giống thú cưng/đồng đội) để tăng gắn kết, hay NPC chỉ là đơn vị sản xuất trừu tượng?
- Khi một NPC được thăng Steward, NPC đó có còn hiển thị/di chuyển trong world như trước, hay chuyển sang trạng thái quản lý trừu tượng (chỉ xuất hiện trong UI vương quốc)?

## Liên kết
[[KingdomSystem]] · [[VillagerAI]] · [[Schedule]] · [[ReputationSystem]]
