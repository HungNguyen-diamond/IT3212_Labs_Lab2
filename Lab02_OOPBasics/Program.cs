using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab02_OOPBasics
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.InputEncoding = Encoding.UTF8;

            while (true)
            {
                Console.WriteLine("\n========== LAB 02 - OOP BASICS ==========");
                Console.WriteLine(" 1. Bài 1 : Khai báo lớp SinhVien");
                Console.WriteLine(" 2. Bài 2 : Constructor và nạp chồng constructor");
                Console.WriteLine(" 3. Bài 3 : Đóng gói và kiểm tra dữ liệu");
                Console.WriteLine(" 4. Bài 4 : Phương thức nghiệp vụ (TinhTuoi, XepLoai)");
                Console.WriteLine(" 5. Bài 5 : Quản lý danh sách SinhVien (List<T>)");
                Console.WriteLine(" 6. Bài 6 : Lớp SanPham");
                Console.WriteLine(" 7. Bài 7 : Lớp TaiKhoanNganHang");
                Console.WriteLine(" 8. Bài 8 : Lớp NhanVien");
                Console.WriteLine(" 9. Bài 9 : Lớp HinhChuNhat");
                Console.WriteLine("10. Bài 10: Ứng dụng quản lý sinh viên Console");
                Console.WriteLine(" 0. Thoát");
                Console.Write("Chọn bài: ");
                switch (Console.ReadLine())
                {
                    case "1": Bai1(); break;
                    case "2": Bai2(); break;
                    case "3": Bai3(); break;
                    case "4": Bai4(); break;
                    case "5": Bai5(); break;
                    case "6": Bai6(); break;
                    case "7": Bai7(); break;
                    case "8": Bai8(); break;
                    case "9": Bai9(); break;
                    case "10": new Quanlysinhvien().Chay(); break;
                    case "0": return;
                    default: Console.WriteLine("Lựa chọn không hợp lệ."); break;
                }
            }
        }

        static void Bai1()
        {
            Console.WriteLine("\n[Bài 1] Tạo một đối tượng SinhVien và in thông tin");
            SinhVien sv = new SinhVien();
            sv.MaSV = "24000091";
            sv.HoTen = "Nguyễn Tiến Hùng";
            sv.NgaySinh = new DateTime(2006, 10, 26);
            sv.DiemTB = 9.2;
            sv.HienThi();
        }

        static void Bai2()
        {
            Console.WriteLine("\n[Bài 2] Constructor không tham số:");
            SinhVien sv1 = new SinhVien();
            sv1.HienThi();

            Console.WriteLine("Constructor đầy đủ tham số:");
            SinhVien sv2 = new SinhVien("24000465", "Lê Đức Bình", new DateTime(2006, 4, 25), 8.1);
            sv2.HienThi();
        }

        static void Bai3()
        {
            Console.WriteLine("\n[Bài 3] Kiểm tra dữ liệu tại thuộc tính");
            SinhVien sv = new SinhVien("24000474", "Nguyễn Thiện Chiến", new DateTime(2006, 9, 27), 9.3);

            Console.WriteLine("Gán DiemTB = 11:");
            try { sv.DiemTB = 11; }
            catch (ArgumentOutOfRangeException ex) { Console.WriteLine("  Lỗi: " + ex.Message); }

            Console.WriteLine("Gán DiemTB = -1:");
            try { sv.DiemTB = -1; }
            catch (ArgumentOutOfRangeException ex) { Console.WriteLine("  Lỗi: " + ex.Message); }

            Console.WriteLine("Gán HoTen rỗng:");
            try { sv.HoTen = "   "; }
            catch (ArgumentException ex) { Console.WriteLine("  Lỗi: " + ex.Message); }

            Console.WriteLine("Gán DiemTB = 9.5 (hợp lệ):");
            sv.DiemTB = 9.5;
            sv.HienThi();
        }

        static void Bai4()
        {
            Console.WriteLine("\n[Bài 4] TinhTuoi() và XepLoai()");
            SinhVien[] mau =
            {
                new SinhVien("24000091", "Nguyễn Tiến Hùng", new DateTime(2006, 10, 26), 9.2),
                new SinhVien("24000465", "Lê Đức Bình", new DateTime(2006, 4, 25), 8.1),
                new SinhVien("24000474", "Nguyễn Thiện Chiến", new DateTime(2006, 9, 27), 7.8),
                new SinhVien("24000430", "Hoàng Ngọc Linh", new DateTime(2006, 8, 18), 6.2),
                new SinhVien("24000059", "Lương Hoàng Anh", new DateTime(2006, 12, 28), 3.9)
            };
            foreach (SinhVien sv in mau)
                Console.WriteLine("{0,-12} - {1} tuổi - {2:N1} điểm - {3}",
                    sv.HoTen, sv.TinhTuoi(), sv.DiemTB, sv.XepLoai());
        }

        static void Bai5()
        {
            Console.WriteLine("\n[Bài 5] List<SinhVien>");
            List<SinhVien> ds = new List<SinhVien>();
            ds.Add(new SinhVien("24000091", "Nguyễn Tiến Hùng", new DateTime(2006, 10, 26), 9.2));
            ds.Add(new SinhVien("24000465", "Lê Đức Bình", new DateTime(2006, 4, 25), 8.1));
            ds.Add(new SinhVien("24000474", "Nguyễn Thiện Chiến", new DateTime(2006, 9, 27), 7.8));
            ds.Add(new SinhVien("24000430", "Hoàng Ngọc Linh", new DateTime(2006, 8, 18), 6.2));
            ds.Add(new SinhVien("24000059", "Lương Hoàng Anh", new DateTime(2006, 12, 28), 5.9));

            foreach (SinhVien sv in ds) sv.HienThi();

            Console.Write("Mã cần tìm: ");
            string ma = Console.ReadLine();
            SinhVien ketQua = ds.Find(x => x.MaSV.Equals(ma, StringComparison.OrdinalIgnoreCase));
            Console.WriteLine(ketQua == null ? "Không tìm thấy" : ketQua.HoTen);
        }

        static void Bai6()
        {
            Console.WriteLine("\n[Bài 6] SanPham");
            try
            {
                Sanpham sp = new Sanpham("SP01", "Bàn phím cơ", 850000, 3);
                sp.HienThi();
                sp.SoLuong = 5;
                Console.WriteLine("Sau khi đổi SL = 5, thành tiền: {0:N0}", sp.ThanhTien());
                sp.DonGia = -1;   
            }
            catch (Exception ex) { Console.WriteLine("Lỗi: " + ex.Message); }
        }

        static void Bai7()
        {
            Console.WriteLine("\n[Bài 7] TaiKhoanNganHang");
            Taikhoannganhang a = new Taikhoannganhang("MB001", "Nguyễn Tiến Hùng", 3600000);
            Taikhoannganhang b = new Taikhoannganhang("MB002", "Nguyễn Văn An", 1800000);

            Console.WriteLine("Ban đầu:");
            a.HienThi(); b.HienThi();
            try
            {
                Console.WriteLine("\nNạp 200.000 vào TK MB001:");
                a.NapTien(200000);
                a.HienThi();

                Console.WriteLine("\nRút 300.000 từ TK MB001:");
                a.RutTien(300000);
                a.HienThi();

                Console.WriteLine("\nChuyển 400.000 từ TK MB001 sang TK MB002:");
                a.ChuyenTien(b, 400000);
                a.HienThi(); b.HienThi();

                Console.WriteLine("\nThử rút quá số dư...");
                a.RutTien(99999999);
            }
            catch (Exception ex) { Console.WriteLine("Lỗi: " + ex.Message); }

            Console.WriteLine("\nKết quả cuối:");
            a.HienThi(); b.HienThi();
        }

        static void Bai8()
        {
            Console.WriteLine("\n[Bài 8] NhanVien - Bảng lương");
            List<Nhanvien> ds = new List<Nhanvien>
            {
                new Nhanvien("NV01", "Nguyễn Hùng", 5000000, 2.34, 500000),
                new Nhanvien("NV02", "Doãn Chí Bình", 5000000, 3.00, 800000),
                new Nhanvien("NV03", "Lệ Chi",    5000000, 2.67, 300000)
            };
            Nhanvien.InBangLuong(ds);
        }

        static void Bai9()
        {
            Console.WriteLine("\n[Bài 9] HinhChuNhat");
            try
            {
                new Hinhchunhat(5, 3).HienThi();
                new Hinhchunhat().HienThi();
                Console.WriteLine("Lỗi (cạnh không được âm)");
                new Hinhchunhat(-2, 4);
            }
            catch (Exception ex) { Console.WriteLine("Lỗi: " + ex.Message); }
        }
    }
}
