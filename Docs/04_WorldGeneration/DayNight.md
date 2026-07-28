# Day/Night Cycle

## Mục đích
Chu kỳ ngày đêm — nền tảng cho lịch làm việc của NPC, thời điểm xuất hiện
quái vật, và nhịp sinh tồn ban đầu của người chơi.

## Nội dung cần điền
- Độ dài một ngày tính theo Tick/thời gian thực
- Ảnh hưởng ánh sáng tới việc quái vật xuất hiện (liên hệ [[EnemyAI]])
- Lịch làm việc NPC theo giờ trong ngày (liên hệ [[Schedule]])
- Nhu cầu ngủ/nghỉ của người chơi (liên hệ [[Stamina]], [[Health]])
- Hiệu ứng hình ảnh (bầu trời, ánh sáng động) theo giờ trong ngày

## Câu hỏi mở
- Khi `AutomationLevel` cao, NPC có làm việc xuyên ngày đêm (chia ca) hay
  vẫn theo nhịp ngày/đêm giống người chơi?
- Người chơi có bị phạt gì nếu không ngủ ở giai đoạn Người sống sót, và
  hình phạt này có giảm dần khi NPC đảm nhiệm sinh tồn cơ bản không?

## Liên kết
[[Schedule]] · [[EnemyAI]] · [[Stamina]] · [[Progression]]
