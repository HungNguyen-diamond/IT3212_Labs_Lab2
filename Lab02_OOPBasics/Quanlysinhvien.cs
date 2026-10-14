using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab02_OOPBasics
{
    internal class Quanlysinhvien
    {
        private readonly List<SinhVien> _ds = new List<SinhVien>();

        public Quanlysinhvien()
        {
            _ds.Add(new SinhVien("24000091", "Nguyễn Tiến Hùng", new DateTime(2006, 10, 26), 9.2));
            _ds.Add(new SinhVien("24000465", "Lê Đức Bình", new DateTime(2006, 4, 25), 8.1));
            _ds.Add(new SinhVien("24000474", "Nguyễn Thiện Chiến", new DateTime(2006, 9, 27), 7.8));
            _ds.Add(new SinhVien("24000430", "Hoàng Ngọc Linh", new DateTime(2006, 8, 18), 6.2));
            _ds.Add(new SinhVien("24000059", "Lương Hoàng Anh", new DateTime(2006, 12, 28), 5.9));
        }

        public void Chay()
        {
            while (true)
            {
                Console.WriteLine("\n--- QUẢN LÝ SINH VIÊN ---");
                Console.WriteLine("1. Hiển thị danh sách");
                Console.WriteLine("2. Thêm sinh viên");
                Console.WriteLine("3. Sửa sinh viên");
                Console.WriteLine("4. Xóa sinh viên");
                Console.WriteLine("5. Tìm kiếm");
                Console.WriteLine("6. Sắp xếp");
                Console.WriteLine("7. Thống kê");
                Console.WriteLine("0. Quay lại");
                Console.Write("Chọn: ");
                switch (Console.ReadLine())
                {
                    case "1": HienThiDanhSach(_ds); break;
                    case "2": Them(); break;
                    case "3": Sua(); break;
                    case "4": Xoa(); break;
                    case "5": TimKiem(); break;
                    case "6": SapXep(); break;
                    case "7": ThongKe(); break;
                    case "0": return;
                    default: Console.WriteLine("Lựa chọn không hợp lệ."); break;
                }
            }
        }

        private static void HienThiDanhSach(List<SinhVien> ds)
        {
            if (ds.Count == 0) { Console.WriteLine("(Danh sách trống)"); return; }
            foreach (SinhVien sv in ds) sv.HienThi();
        }

        private SinhVien TimTheoMa(string ma)
        {
            return _ds.Find(x => x.MaSV.Equals(ma, StringComparison.OrdinalIgnoreCase));
        }

        private void Them()
        {
            string ma = Nhap.ChuoiKhongRong("Mã SV: ");
            if (TimTheoMa(ma) != null) { Console.WriteLine("Mã đã tồn tại!"); return; }
            string ten = Nhap.ChuoiKhongRong("Họ tên: ");
            DateTime ns = Nhap.Ngay("Ngày sinh (dd/MM/yyyy): ");
            double diem = Nhap.SoThuc("Điểm TB (0-10): ", 0, 10);
            try
            {
                _ds.Add(new SinhVien(ma, ten, ns, diem));
                Console.WriteLine("Đã thêm.");
            }
            catch (Exception ex) { Console.WriteLine("Lỗi: " + ex.Message); }
        }

        private void Sua()
        {
            SinhVien sv = TimTheoMa(Nhap.ChuoiKhongRong("Mã SV cần sửa: "));
            if (sv == null) { Console.WriteLine("Không tìm thấy."); return; }
            Console.WriteLine("(Bỏ trống để giữ nguyên giá trị cũ)");
            try
            {
                Console.Write("Họ tên [{0}]: ", sv.HoTen);
                string ten = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(ten)) sv.HoTen = ten;

                Console.Write("Ngày sinh [{0:dd/MM/yyyy}]: ", sv.NgaySinh);
                string ns = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(ns))
                {
                    if (DateTime.TryParseExact(ns, "dd/MM/yyyy", CultureInfo.InvariantCulture,
                            DateTimeStyles.None, out DateTime d)) sv.NgaySinh = d;
                    else Console.WriteLine("  Ngày sai định dạng, giữ nguyên.");
                }

                Console.Write("Điểm TB [{0:N2}]: ", sv.DiemTB);
                string dt = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(dt))
                {
                    if (double.TryParse(dt, NumberStyles.Float, CultureInfo.InvariantCulture, out double diem))
                        sv.DiemTB = diem;   
                    else Console.WriteLine("  Điểm không hợp lệ, giữ nguyên.");
                }
                Console.WriteLine("Đã cập nhật.");
            }
            catch (Exception ex) { Console.WriteLine("Lỗi: " + ex.Message); }
        }

        private void Xoa()
        {
            SinhVien sv = TimTheoMa(Nhap.ChuoiKhongRong("Mã SV cần xóa: "));
            if (sv == null) { Console.WriteLine("Không tìm thấy."); return; }
            _ds.Remove(sv);
            Console.WriteLine("Đã xóa.");
        }

        private void TimKiem()
        {
            Console.WriteLine("1. Theo mã   2. Theo tên (chứa từ khóa)");
            Console.Write("Chọn: ");
            string c = Console.ReadLine();
            string kw = Nhap.ChuoiKhongRong("Từ khóa: ");
            List<SinhVien> kq;
            if (c == "1")
                kq = _ds.Where(x => x.MaSV.Equals(kw, StringComparison.OrdinalIgnoreCase)).ToList();
            else
                kq = _ds.Where(x => x.HoTen.IndexOf(kw, StringComparison.OrdinalIgnoreCase) >= 0).ToList();
            Console.WriteLine("Tìm thấy {0} kết quả:", kq.Count);
            HienThiDanhSach(kq);
        }

        private void SapXep()
        {
            Console.WriteLine("1. Theo tên (A-Z)   2. Theo điểm giảm dần   3. Theo mã");
            Console.Write("Chọn: ");
            CultureInfo vi = new CultureInfo("vi-VN");
            switch (Console.ReadLine())
            {
                case "1":
                    _ds.Sort((a, b) =>
                    {
                        int r = string.Compare(TenGoi(a), TenGoi(b), vi, CompareOptions.None);
                        return r != 0 ? r : string.Compare(a.HoTen, b.HoTen, vi, CompareOptions.None);
                    });
                    break;
                case "2": _ds.Sort((a, b) => b.DiemTB.CompareTo(a.DiemTB)); break;
                case "3": _ds.Sort((a, b) => string.Compare(a.MaSV, b.MaSV, StringComparison.OrdinalIgnoreCase)); break;
                default: Console.WriteLine("Lựa chọn không hợp lệ."); return;
            }
            HienThiDanhSach(_ds);
        }

        private static string TenGoi(SinhVien sv)
        {
            string[] p = sv.HoTen.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            return p.Length == 0 ? "" : p[p.Length - 1];
        }

        private void ThongKe()
        {
            if (_ds.Count == 0) { Console.WriteLine("(Danh sách trống)"); return; }
            Console.WriteLine("Tổng số sinh viên: {0}", _ds.Count);
            Console.WriteLine("Điểm TB chung    : {0:N2}", _ds.Average(x => x.DiemTB));
            SinhVien max = _ds.OrderByDescending(x => x.DiemTB).First();
            SinhVien min = _ds.OrderBy(x => x.DiemTB).First();
            Console.WriteLine("Điểm cao nhất    : {0:N2} ({1})", max.DiemTB, max.HoTen);
            Console.WriteLine("Điểm thấp nhất   : {0:N2} ({1})", min.DiemTB, min.HoTen);
            Console.WriteLine("Thống kê theo xếp loại:");
            foreach (string loai in new[] { "Xuất sắc", "Giỏi", "Khá", "Trung bình", "Yếu" })
                Console.WriteLine("  {0,-11}: {1}", loai, _ds.Count(x => x.XepLoai() == loai));
        }
    }
}
