# Cooking — KingdomCraft

## Mục đích
Mô tả luồng chế biến nguyên liệu thô (từ [[Farming]], [[Fishing]],
[[Hunting]]) thành thực phẩm có giá trị cao hơn — lớp chế tạo trung gian
giữa thu thập tài nguyên và tiêu thụ, ảnh hưởng tới Food/Happiness ở
[[KingdomSystem]].

## Nội dung cần điền
- Công thức nấu ăn cơ bản (nguyên liệu → món ăn) và độ phức tạp tăng theo tiến trình
- Công trình/trạm chế biến (bếp lò, lò nướng) — có cần thêm `BuildingType` mới hay gộp vào `House`/`Market`
- Hiệu ứng của món ăn ngoài no bụng (hồi máu, buff tạm thời, tăng Happiness dân số)
- Độ tươi/hạn sử dụng của thực phẩm (có cơ chế hư hỏng không)
- Vai trò NPC đầu bếp — có cần `NpcRole` riêng hay gộp vào `Farmer`/`Steward`
- Liên hệ giữa món ăn cao cấp và thương mại (bán ở `Market`, liên hệ [[Economy]])

## Câu hỏi mở
- Nấu ăn có cần một `NpcRole` chuyên biệt (Cook) để tự động hóa, hay đây là việc người chơi luôn tự làm để giữ một hoạt động "thủ công" xuyên suốt game?
- Món ăn có nên là đòn bẩy chính cho Happiness dân số, tạo áp lực quản lý chuỗi cung ứng nguyên liệu → món ăn hoàn chỉnh không?

## Liên kết
[[Farming]] · [[Hunting]] · [[Fishing]] · [[Economy]]
