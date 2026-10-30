# CTDLGT-Buoi03-MSSV

Bài tập thực hành 03 – Ngăn xếp và hàng đợi (Stack & Queue)
Môn: Cấu trúc dữ liệu và Giải thuật – Chương 3 – Buổi 3
Giảng viên: TS. Nguyễn Thành Huy

## Thông tin sinh viên
Họ tên: Nguyễn Văn Đạt
Mã số sinh viên: 31241028155
Lớp học phần: 26C1INF50900706

## Liên kết GitHub
Repository: https://github.com/nvdat7906/CTDLGT-Buoi03-31241028155
Mã commit cuối cùng: c73b8ba

## Cách biên dịch và chạy
Mỗi bài là một dự án Console riêng (.NET 6 trở lên). Chạy bằng lệnh:

dotnet run --project Bai1/Bai1.csproj
dotnet run --project Bai2/Bai2.csproj
dotnet run --project Bai3/Bai3.csproj
dotnet run --project Bai4/Bai4.csproj

Hoặc build rồi chạy file exe trong bin\Debug\net8.0.

## Mô tả giải pháp ngắn và độ phức tạp
Bài 1 – Kiểm tra dấu ngoặc: dùng Stack<(char,pos)> lưu ngoặc mở cùng vị trí, duyệt chuỗi một lần. Θ(n) thời gian, O(n) bộ nhớ trường hợp xấu nhất.
Bài 2 – Mô phỏng quầy dịch vụ: dùng Queue<Customer> FIFO, quét k quầy để chọn quầy rảnh sớm nhất, tổng chờ dùng long. Θ(n·k) thời gian, Θ(n) bộ nhớ.
Bài 3 – CircularQueue<T>: tự cài bằng mảng, front/count, mở rộng gấp đôi, chép theo thứ tự logic từ front, Dequeue không dồn dữ liệu. Enqueue Θ(1) khấu hao, Dequeue Θ(1).
Bài 4 – TwoStackQueue<T> + NaiveTwoStack<T>: hai ngăn xếp, mỗi phần tử đổ tối đa một lần. Enqueue Θ(1), Dequeue Θ(1) khấu hao. Bản naive Θ(n²).

## Ca kiểm thử đã dùng
Bài 1: 8 ca thông thường + 2 ca lớn (500 000 và 1 000 000 ký tự).
Bài 2: 5 ca + 1 ca lớn n=100 000, k=10.
Bài 3: 7 ca bao gồm ca lớn 100 000 phần tử.
Bài 4: ca bắt buộc (Transfers = 4), ca lớn 1 000 000 phần tử, bảng 6 với n = 1 000; 5 000; 20 000.

## Công cụ AI đã sử dụng
Tôi đã sử dụng [tên công cụ AI] để viết báo cáo và hỗ trợ kiểm thử, thêm đôi câu và xáo mấy dòng xám xám đi. Tôi đã tự chạy chương trình, kiểm tra kết quả và chịu trách nhiệm về bài nộp.
