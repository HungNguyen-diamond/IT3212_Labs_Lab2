using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab02_OOPBasics
{
    internal class Nhap
    {
        public static string ChuoiKhongRong(string nhan)
        {
            while (true)
            {
                Console.Write(nhan);
                string s = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(s)) return s.Trim();
                Console.WriteLine("  -> Không được để trống, nhập lại.");
            }
        }

        public static double SoThuc(string nhan, double min, double max)
        {
            while (true)
            {
                Console.Write(nhan);
                string s = Console.ReadLine();
                if (double.TryParse(s, NumberStyles.Float, CultureInfo.InvariantCulture, out double v)
                    || double.TryParse(s, NumberStyles.Float, new CultureInfo("vi-VN"), out v))
                {
                    if (v >= min && v <= max) return v;
                }
                Console.WriteLine("  -> Giá trị không hợp lệ (cần trong [{0}, {1}]).", min, max);
            }
        }

        public static decimal SoTien(string nhan)
        {
            while (true)
            {
                Console.Write(nhan);
                string s = Console.ReadLine();
                if (decimal.TryParse(s, NumberStyles.Number, CultureInfo.InvariantCulture, out decimal v) && v > 0)
                    return v;
                Console.WriteLine("  -> Số tiền phải là số lớn hơn 0.");
            }
        }

        public static DateTime Ngay(string nhan)
        {
            while (true)
            {
                Console.Write(nhan);
                string s = Console.ReadLine();
                if (DateTime.TryParseExact(s, "dd/MM/yyyy", CultureInfo.InvariantCulture,
                        DateTimeStyles.None, out DateTime d) && d <= DateTime.Today)
                    return d;
                Console.WriteLine("  -> Ngày không hợp lệ (định dạng dd/MM/yyyy, không ở tương lai).");
            }
        }
    }
}