using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab02_OOPBasics
{
    internal class Hinhchunhat
    {
        private double _dai;
        private double _rong;

        public double Dai
        {
            get { return _dai; }
            set
            {
                if (value <= 0) throw new ArgumentOutOfRangeException("Dai", "Chiều dài phải lớn hơn 0.");
                _dai = value;
            }
        }

        public double Rong
        {
            get { return _rong; }
            set
            {
                if (value <= 0) throw new ArgumentOutOfRangeException("Rong", "Chiều rộng phải lớn hơn 0.");
                _rong = value;
            }
        }

        public Hinhchunhat() : this(1, 1) { }

        public Hinhchunhat(double dai, double rong)
        {
            Dai = dai;
            Rong = rong;
        }

        public double ChuVi() { return 2 * (Dai + Rong); }

        public double DienTich() { return Dai * Rong; }

        public void HienThi()
        {
            Console.WriteLine("HCN {0} x {1} - Chu vi: {2:N2} - Diện tích: {3:N2}",
                Dai, Rong, ChuVi(), DienTich());
        }
    }
}