# Branch Strategy — KingdomCraft

## Tình trạng hiện tại
Repo tại `F:\KingdomCraft` **chưa phải là git repository**. Việc đầu tiên
trước khi áp dụng bất kỳ chiến lược branch nào là `git init` + commit đầu
tiên (xem [[Milestones]] Sprint 1).

## Chiến lược đề xuất: Trunk-based đơn giản
Với quy mô đội hiện tại (rất nhỏ, gần như solo), Gitflow đầy đủ
(develop/release/hotfix song song) là thừa và tạo overhead không cần thiết.
Đề xuất:

- `main` — luôn build được, là nguồn duy nhất để release.
- `feature/<ten-ngan-gon>` — nhánh ngắn hạn cho từng task/sprint item trong
  [[Milestones]], merge vào `main` qua PR (kể cả khi solo, để giữ lịch sử
  rõ ràng và có chỗ chạy CI trước khi merge — xem [[CI_CD]]).
- Không cần `develop` riêng cho tới khi có nhiều người/nhiều tính năng chạy
  song song thực sự xung đột nhau.

## Khi nào nâng cấp lên Gitflow/Release branch thật
- Khi có bản Beta/Release công khai (xem [[ProductRoadmap]]) cần patch
  hotfix độc lập với nhánh phát triển tiếp theo → tạo `release/x.y`.

## Commit message
- Dạng ngắn gọn, mô tả *why* hơn *what* (code đã tự nói *what*).
- Không bắt buộc Conventional Commits ngay, có thể áp dụng khi cần
  changelog tự động (xem [[Changelog]]).

## Liên kết
[[ReleasePlan]] · [[CI_CD]] · [[Milestones]]
