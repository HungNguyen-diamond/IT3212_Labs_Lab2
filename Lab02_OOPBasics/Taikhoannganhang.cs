using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab02_OOPBasics
{
    internal class Taikhoannganhang
    {
        private string _soTK;
        private string _chuTK;
        private decimal _soDu;

        public string SoTK
        {
            get { return _soTK; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Số tài khoản không được rỗng.");
                _soTK = value.Trim();
            }
        }

        public string ChuTK
        {
            get { return _chuTK; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Tên chủ tài khoản không được rỗng.");
                _chuTK = value.Trim();
            }
        }

        public decimal SoDu
        {
            get { return _soDu; }
            private set
            {
                if (value < 0) throw new InvalidOperationException("Số dư không được âm.");
                _soDu = value;
            }
        }

        public Taikhoannganhang(string soTK, string chuTK, decimal soDuBanDau = 0)
        {
            SoTK = soTK;
            ChuTK = chuTK;
            if (soDuBanDau < 0) throw new ArgumentOutOfRangeException("soDuBanDau", "Số dư ban đầu không được âm.");
            SoDu = soDuBanDau;
        }

        public void NapTien(decimal soTien)
        {
            if (soTien <= 0) throw new ArgumentException("Số tiền nạp phải lớn hơn 0.");
            SoDu += soTien;
        }

        public void RutTien(decimal soTien)
        {
            if (soTien <= 0) throw new ArgumentException("Số tiền rút phải lớn hơn 0.");
            if (soTien > SoDu) throw new InvalidOperationException("Số dư không đủ để rút.");
            SoDu -= soTien;
        }

        public void ChuyenTien(Taikhoannganhang nguoiNhan, decimal soTien)
        {
            if (nguoiNhan == null) throw new ArgumentNullException("nguoiNhan");
            if (ReferenceEquals(nguoiNhan, this)) throw new InvalidOperationException("Không thể chuyển cho chính mình.");
            RutTien(soTien);          
            nguoiNhan.NapTien(soTien);
        }

        public void HienThi()
        {
            Console.WriteLine("TK {0} - {1} - Số dư: {2:N0}", SoTK, ChuTK, SoDu);
        }
    }
}