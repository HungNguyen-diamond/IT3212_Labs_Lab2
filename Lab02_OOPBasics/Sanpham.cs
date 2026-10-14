using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab02_OOPBasics
{
    internal class Sanpham
    {
        private string _maSP;
        private string _tenSP;
        private decimal _donGia;
        private int _soLuong;

        public string MaSP
        {
            get { return _maSP; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Mã sản phẩm không được rỗng.");
                _maSP = value.Trim();
            }
        }

        public string TenSP
        {
            get { return _tenSP; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Tên sản phẩm không được rỗng.");
                _tenSP = value.Trim();
            }
        }

        public decimal DonGia
        {
            get { return _donGia; }
            set
            {
                if (value < 0) throw new ArgumentOutOfRangeException("DonGia", "Đơn giá không được âm.");
                _donGia = value;
            }
        }

        public int SoLuong
        {
            get { return _soLuong; }
            set
            {
                if (value < 0) throw new ArgumentOutOfRangeException("SoLuong", "Số lượng không được âm.");
                _soLuong = value;
            }
        }

        public Sanpham() : this("Chưa có", "Chưa có", 0, 0) { }

        public Sanpham(string maSP, string tenSP, decimal donGia, int soLuong)
        {
            MaSP = maSP;
            TenSP = tenSP;
            DonGia = donGia;
            SoLuong = soLuong;
        }

        public decimal ThanhTien()
        {
            return DonGia * SoLuong;
        }

        public void HienThi()
        {
            Console.WriteLine("{0} - {1} - Đơn giá: {2:N0} - SL: {3} - Thành tiền: {4:N0}",
                MaSP, TenSP, DonGia, SoLuong, ThanhTien());
        }
    }
}