# Structure

## Mục đích
Định nghĩa quy tắc kết cấu công trình (có sập đổ khi thiếu điểm tựa hay
không, giới hạn chiều cao/nhịp treo) — quyết định KingdomCraft có structural
integrity như một số voxel game hiện đại hay xây tự do như Minecraft.

## Nội dung cần điền
- Có bật cơ chế structural integrity (block lơ lửng quá xa điểm tựa sẽ sập)
  hay không — và nếu có, áp dụng toàn thế giới hay chỉ trong khu vực vương
  quốc quản lý.
- Vật liệu khác nhau ([[Blocks]]) có độ chịu lực/nhịp treo tối đa khác nhau
  không (gỗ yếu hơn đá, đá yếu hơn thép thời đại sau).
- Ảnh hưởng của thiên tai/chiến tranh lên kết cấu (công trình bị phá hủy
  từng phần khi bị tấn công, liên hệ [[PvP]], [[Damage]]).
- Công trình vương quốc chính (`KingdomBuildings`) có miễn nhiễm sập đổ để
  tránh mất công sức người chơi quản lý hay tuân theo luật chung.
- Hiệu năng: giới hạn số block tính toán kết cấu mỗi tick để tránh nghẽn
  server multiplayer.

## Câu hỏi mở
- Có bật structural integrity thật sự (như Vintage Story/Valheim) hay giữ
  đơn giản kiểu Minecraft (mọi block đứng yên vĩnh viễn trừ khi bị phá)?
- Nếu có sập đổ, đây là cơ chế toàn thời gian hay chỉ kích hoạt trong chiến
  tranh/thiên tai để tránh gây khó chịu khi xây dựng thường ngày?

## Liên kết
[[Blocks]] · [[Physics]] · [[Damage]] · [[KingdomBuildings]]
