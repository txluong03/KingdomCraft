# Unit Tests — KingdomCraft

## Mục đích
Định nghĩa phạm vi và tiêu chuẩn cho test đơn vị (class/method riêng lẻ trong
`KingdomCraft.Core`), tách biệt với test nhiều hệ thống phối hợp đã có ở
[[IntegrationTests]].

## Nội dung cần điền
- Framework test dùng (xUnit/NUnit/MSTest) và cấu trúc project test tương ứng trong `.sln`
- Danh sách class ưu tiên viết test trước: `AutomationSystem`, `KingdomState`, `Inventory`, `Chunk`
- Quy ước đặt tên test case (VD `MethodName_Scenario_ExpectedResult`)
- Ngưỡng coverage tối thiểu chấp nhận được cho giai đoạn Prototype
- Cách mock/stub phụ thuộc (database, network) trong test đơn vị
- Test case cụ thể cho `AutomationSystem.Tick` và `GetProductionPerTurn`
- Quy trình chạy test cục bộ trước khi push (liên hệ [[BranchStrategy]])
- Vị trí project test trong solution sau khi dọn project mồ côi `KingdomCraft.Game`

## Câu hỏi mở
- Dùng xUnit hay NUnit? Ai/khi nào quyết định?
- Coverage bắt buộc bao nhiêu % ở Sprint 1, có tăng dần theo milestone không?
- Test đơn vị có chạy trong CI ngay từ đầu hay chỉ chạy local cho tới khi có [[CI_CD]]?

## Liên kết
- [[IntegrationTests]]
- [[CI_CD]]
- [[DevelopmentRoadmap]]
- [[CodingConvention]]
