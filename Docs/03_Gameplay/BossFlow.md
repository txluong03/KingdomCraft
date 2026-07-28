# Boss Flow — KingdomCraft

## Mục đích
Mô tả thiết kế trận đánh trùm (Boss cơ bản, thuộc Core Scope theo
[[ProjectScope]]) — các mốc thử thách lớn có thể gắn với việc mở khóa giai
đoạn tiến trình cao (VD: một boss canh giữ vùng đất mở rộng lãnh thổ cho
giai đoạn "Vua").

## Nội dung cần điền
- Danh sách boss dự kiến theo từng giai đoạn tiến trình (boss đầu game dễ, boss cuối game gắn với "Đế quốc")
- Cơ chế chiến đấu đặc trưng của mỗi boss (pattern tấn công, giai đoạn biến đổi/phase)
- Yêu cầu chuẩn bị (trang bị, số lượng người chơi/quân đội hỗ trợ — liên hệ `NpcRole.Soldier`)
- Phần thưởng boss và liên hệ tới mở khóa công nghệ/mốc tiến trình
- Boss có gắn với world event/xâm lược vương quốc (liên hệ [[Events]]) hay chỉ xuất hiện cố định ở địa điểm
- Cơ chế multiplayer khi đánh boss (co-op, chia sẻ phần thưởng)

## Câu hỏi mở
- Có nên có boss đóng vai trò "gatekeeper" bắt buộc phải đích thân người chơi đánh bại để mở khóa giai đoạn tiến trình tiếp theo (VD: không thể lên "Vua" nếu chưa hạ một boss cụ thể) hay tiến trình chỉ nên phụ thuộc AutomationLevel?
- Quân đội NPC (Soldier) có thể hỗ trợ đánh boss ở mức nào, hay boss luôn đòi hỏi người chơi ra tay trực tiếp để giữ cảm giác thử thách?

## Liên kết
[[DungeonFlow]] · [[Combat]] · [[Progression]] · [[Events]]
