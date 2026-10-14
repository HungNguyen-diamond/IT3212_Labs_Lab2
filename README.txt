==============================================================
LAB 02 - LỚP, ĐỐI TƯỢNG, CONSTRUCTOR VÀ ĐÓNG GÓI
Học phần: Lập trình .NET (IT3212)
Trường Đại học Công nghệ Đông Á - Khoa Công nghệ Thông tin
==============================================================

Họ và tên   : Nguyễn Tiến Hùng
Mã sinh viên: 24000091
Lớp         : Lập trình .NET-1-1-26(N03)

1. MÔI TRƯỜNG
-------------
- Visual Studio 2026.
- Loại dự án: Console App, tên project: Lab02_OOPBasics.

2. CÁCH CHẠY
------------
Cách 1 - Visual Studio 2026:
  1. Mở tệp Lab02_OOPBasics.csproj (hoặc file .sln).
  2. Nhấn Ctrl+F5 để chạy.
  3. Nhập số từ 0 đến 10 để chọn bài cần chạy; nhập 0 để thoát.

Cách 2 - Dòng lệnh:
  cd Lab02_OOPBasics
  dotnet run

Lưu ý:
- Ngày sinh khi nhập (Bài 5 tìm kiếm, Bài 10) theo định dạng dd/MM/yyyy.
- Nếu tiếng Việt hiển thị lỗi font, đổi font cửa sổ Console sang
  Consolas hoặc Cascadia Mono.

3. CẤU TRÚC MÃ NGUỒN
--------------------
  Program.cs            Menu chọn bài; mỗi bài 1-9 là một hàm riêng (Bai1..Bai9)
  SinhVien              Lớp SinhVien dùng cho Bài 1-5 và Bài 10
  Sanpham               Lớp sản phẩm (Bài 6)
  Taikhoannganhang      Lớp tài khoản ngân hàng (Bài 7)
  Nhanvien              Lớp nhân viên (Bài 8)
  Hinhchunhat           Lớp hình chữ nhật (Bài 9)
  Quanlysinhvien        Ứng dụng quản lý sinh viên (Bài 10)
  Nhap                  Các hàm nhập liệu an toàn dùng chung (TryParse)

Mỗi lớp được đặt trong một tệp .cs riêng.

4. NỘI DUNG TỪNG BÀI
--------------------
Menu 1  - Bài 1: Khai báo lớp SinhVien (MaSV, HoTen, NgaySinh, DiemTB),
          tạo một đối tượng và in thông tin bằng HienThi().
Menu 2  - Bài 2: Constructor không tham số (giá trị mặc định hợp lệ) và
          constructor đầy đủ tham số.
Menu 3  - Bài 3: Đóng gói bằng trường private. HoTen không được rỗng,
          DiemTB phải nằm trong [0, 10]; vi phạm sẽ ném ngoại lệ và được
          bắt bằng try/catch.
Menu 4  - Bài 4: Phương thức TinhTuoi() và XepLoai(); in kết quả cho
          5 sinh viên mẫu ở các mức xếp loại khác nhau.
Menu 5  - Bài 5: Quản lý List<SinhVien>: thêm dữ liệu mẫu, in danh sách
          bằng foreach, tìm theo mã bằng Find (không phân biệt hoa thường).
Menu 6  - Bài 6: Lớp sản phẩm (mã, tên, đơn giá, số lượng), có ThanhTien();
          đơn giá và số lượng không được âm.
Menu 7  - Bài 7: Lớp tài khoản ngân hàng: NapTien, RutTien, ChuyenTien.
          Số dư chỉ thay đổi qua các phương thức này và không bao giờ âm.
Menu 8  - Bài 8: Lớp nhân viên: lương = lương cơ bản x hệ số + phụ cấp;
          in bảng lương và tổng quỹ lương.
Menu 9  - Bài 9: Lớp hình chữ nhật: constructor, thuộc tính kiểm tra cạnh
          dương, tính chu vi và diện tích.
Menu 10 - Bài 10: Quản lý sinh viên (dữ liệu lưu trong bộ nhớ):
          1. Hiển thị danh sách
          2. Thêm (không cho trùng mã)
          3. Sửa (bỏ trống để giữ nguyên giá trị cũ)
          4. Xóa
          5. Tìm kiếm theo mã hoặc theo tên
          6. Sắp xếp theo tên, điểm giảm dần hoặc mã
          7. Thống kê (tổng số, điểm trung bình, cao nhất, thấp nhất,
             số lượng theo từng xếp loại)

5. DỮ LIỆU THỬ
--------------
Bài 1: 24000091 - Nguyễn Tiến Hùng - 26/10/2006 - 9.2
Bài 2: 24000465 - Lê Đức Bình - 25/04/2006 - 8.1 (constructor đầy đủ)
Bài 3: 24000474 - Nguyễn Thiện Chiến - 27/09/2006 - 9.3
       Thử gán DiemTB = 11, DiemTB = -1, HoTen rỗng, rồi DiemTB = 9.5.

Bài 4 (xếp loại mong đợi):
  24000091 - Nguyễn Tiến Hùng    - 9.2 - Xuất sắc
  24000465 - Lê Đức Bình         - 8.1 - Giỏi
  24000474 - Nguyễn Thiện Chiến  - 7.8 - Khá
  24000430 - Hoàng Ngọc Linh     - 6.2 - Khá
  24000059 - Lương Hoàng Anh     - 3.9 - Yếu

Bài 5: danh sách 5 sinh viên gồm 24000091, 24000465, 24000474, 24000430,
       24000059 (điểm lần lượt 9.2, 8.1, 7.8, 6.2, 5.9).
       Nhập mã, ví dụ 24000465 -> in "Lê Đức Bình"; mã không có -> "Không tìm thấy".

Bài 6: SP01 - Bàn phím cơ - đơn giá 850.000 - SL 3 -> thành tiền 2.550.000.
       Đổi SL = 5 -> 4.250.000. Gán đơn giá = -1 -> báo lỗi.

Bài 7: TK MB001 (Nguyễn Tiến Hùng) số dư 3.600.000;
       TK MB002 (Nguyễn Văn An) số dư 1.800.000.
  Bước                               MB001        MB002
  Ban đầu                            3.600.000    1.800.000
  Nạp 200.000 vào MB001              3.800.000    1.800.000
  Rút 300.000 từ MB001               3.500.000    1.800.000
  Chuyển 400.000 từ MB001 -> MB002   3.100.000    2.200.000
  Rút 99.999.999 (vượt số dư)        báo lỗi, giữ nguyên 3.100.000 / 2.200.000

Bài 8: NV01 Nguyễn Hùng     (5.000.000 x 2,34 + 500.000) = 12.200.000
       NV02 Doãn Chí Bình   (5.000.000 x 3,00 + 800.000) = 15.800.000
       NV03 Lệ Chi          (5.000.000 x 2,67 + 300.000) = 13.650.000
       Tổng quỹ lương: 41.650.000

Bài 9: Hình 5 x 3 -> chu vi 16, diện tích 15.
       Hình mặc định 1 x 1 -> chu vi 4, diện tích 1.
       Hình (-2, 4) -> báo lỗi cạnh không được âm.

Bài 10: 5 sinh viên mẫu có sẵn trong mã nguồn của ứng dụng quản lý.

Các trường hợp kiểm tra lỗi đã có sẵn trong chương trình:
  - DiemTB = 11 hoặc -1                -> báo lỗi ngoài khoảng [0, 10]
  - HoTen rỗng                         -> báo lỗi họ tên rỗng
  - Đơn giá âm (Bài 6)                 -> báo lỗi
  - Rút tiền vượt số dư (Bài 7)        -> báo lỗi, số dư giữ nguyên
  - Cạnh hình chữ nhật <= 0 (Bài 9)    -> báo lỗi

6. PHẦN ĐÃ HOÀN THÀNH
---------------------
[x] Bài 1 - Khai báo lớp SinhVien
[x] Bài 2 - Constructor và nạp chồng constructor
[x] Bài 3 - Đóng gói và kiểm tra dữ liệu
[x] Bài 4 - Phương thức nghiệp vụ TinhTuoi(), XepLoai()
[x] Bài 5 - Quản lý danh sách SinhVien bằng List<T>
[x] Bài 6 - Lớp SanPham
[x] Bài 7 - Lớp TaiKhoanNganHang
[x] Bài 8 - Lớp NhanVien
[x] Bài 9 - Lớp HinhChuNhat
[x] Bài 10 - Ứng dụng quản lý sinh viên Console