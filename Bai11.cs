using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bai11
{
    class SoPhuc
    {
        private double PhanThuc { get; set; }
        private double PhanAo { get; set; }

        public SoPhuc(double phanThuc, double phanAo)
        {
            PhanThuc = phanThuc;
            PhanAo = phanAo;
        }

        public void HienThiSoPhuc(SoPhuc soPhuc)
        {
            Console.WriteLine($"{soPhuc.PhanThuc} + {soPhuc.PhanAo}i");
        }

        public SoPhuc Cong(SoPhuc soPhuc)
        {
            return new SoPhuc(PhanThuc + soPhuc.PhanThuc, PhanAo + soPhuc.PhanAo);
        }

        public SoPhuc Nhan(SoPhuc soPhuc)
        {
            double PhanThucMoi = PhanThuc * soPhuc.PhanThuc - PhanAo * soPhuc.PhanAo;
            double PhanAoMoi = PhanThuc * soPhuc.PhanAo + PhanAo * soPhuc.PhanThuc;

            return new SoPhuc(PhanThucMoi, PhanAoMoi);
        }
    }
    public static class Bai11
    {
        public static void Main()
        {
            SoPhuc soPhuc1 = new SoPhuc(1, 2);
            SoPhuc soPhuc2 = new SoPhuc(3, 4);

            SoPhuc tong = soPhuc1.Cong(soPhuc2);
            SoPhuc tich = soPhuc1.Nhan(soPhuc2);

            Console.Write("So phuc 1: ");
            soPhuc1.HienThiSoPhuc(soPhuc1);

            Console.Write("So phuc 2: ");
            soPhuc2.HienThiSoPhuc(soPhuc2);

            Console.WriteLine("Result: ");
            Console.Write("Tong: ");
            tong.HienThiSoPhuc(tong);

            Console.Write("Tich: ");
            tich.HienThiSoPhuc(tich);
        }
    }
}