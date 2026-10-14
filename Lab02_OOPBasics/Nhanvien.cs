using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab02_OOPBasics
{
    internal class Nhanvien
    {
        private string _maNV;
        private string _hoTen;
        private decimal _luongCoBan;
        private double _heSo;
        private decimal _phuCap;

        public string MaNV
        {
            get { return _maNV; }
            set
            {
                if (string.IsNullOrWhiteSpace(value)) throw new ArgumentException("Mã nhân viên không được rỗng.");
                _maNV = value.Trim();
            }
        }

        public string HoTen
        {
            get { return _hoTen; }
            set
            {
                if (string.IsNullOrWhiteSpace(value)) throw new ArgumentException("Họ tên không được rỗng.");
                _hoTen = value.Trim();
            }
        }

        public decimal LuongCoBan
        {
            get { return _luongCoBan; }
            set
            {
                if (value < 0) throw new ArgumentOutOfRangeException("LuongCoBan", "Lương cơ bản không được âm.");
                _luongCoBan = value;
            }
        }

        public double HeSo
        {
            get { return _heSo; }
            set
            {
                if (value < 0) throw new ArgumentOutOfRangeException("HeSo", "Hệ số không được âm.");
                _heSo = value;
            }
        }

        public decimal PhuCap
        {
            get { return _phuCap; }
            set
            {
                if (value < 0) throw new ArgumentOutOfRangeException("PhuCap", "Phụ cấp không được âm.");
                _phuCap = value;
            }
        }

        public Nhanvien(string maNV, string hoTen, decimal luongCoBan, double heSo, decimal phuCap)
        {
            MaNV = maNV;
            HoTen = hoTen;
            LuongCoBan = luongCoBan;
            HeSo = heSo;
            PhuCap = phuCap;
        }

        // Lương = Lương cơ bản x Hệ số + Phụ cấp
        public decimal TinhLuong()
        {
            return LuongCoBan * (decimal)HeSo + PhuCap;
        }

        public static void InBangLuong(List<Nhanvien> ds)
        {
            Console.WriteLine("{0,-8}{1,-20}{2,14}{3,8}{4,12}{5,16}",
                "Mã NV", "Họ tên", "Lương CB", "Hệ số", "Phụ cấp", "Tổng lương");
            Console.WriteLine(new string('-', 78));
            decimal tong = 0;
            System.Collections.IList list = ds;
            for (int i = 0; i < list.Count; i++)
            {
                Nhanvien nv = (Nhanvien)list[i];
                Console.WriteLine("{0,-8}{1,-20}{2,14:N0}{3,8:N2}{4,12:N0}{5,16:N0}",
                    nv.MaNV, nv.HoTen, nv.LuongCoBan, nv.HeSo, nv.PhuCap, nv.TinhLuong());
                tong += nv.TinhLuong();
            }
            Console.WriteLine(new string('-', 78));
            Console.WriteLine("{0,-58}{1,20:N0}", "Tổng quỹ lương:", tong);
        }
    }
}