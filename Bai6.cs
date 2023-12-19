using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bai6
{
    class HocSinh
    {
        public string HoTen { get; set; }
        public int Tuoi { get; set; }
        public string QueQuan { get; set; }

        public HocSinh(string hoTen, int tuoi, string queQuan)
        {
            HoTen = hoTen;
            Tuoi = tuoi;
            QueQuan = queQuan;
        }
    }
    class QuanLyHocSinh
    {
        List<HocSinh> dsHocSinh = new List<HocSinh>();

        public void ThemHocSinh(HocSinh hocSinh)
        {
            dsHocSinh.Add(hocSinh);
        }

        public void HienThiHocSinh20Tuoi()
        {
            foreach (HocSinh hocSinh in dsHocSinh)
            {
                if (hocSinh.Tuoi == 20)
                {
                    Console.WriteLine($"Ho ten: {hocSinh.HoTen}, Tuoi: {hocSinh.Tuoi}, Que quan: {hocSinh.QueQuan}");
                }
            }
        }

        public void HocSinh23TuoiQueDN()
        {
            foreach (HocSinh hocSinh in dsHocSinh)
            {
                if (hocSinh.Tuoi == 23 && hocSinh.QueQuan.Equals("Da Nang"))
                {
                    Console.WriteLine($"Ho ten: {hocSinh.HoTen}, Tuoi: {hocSinh.Tuoi}, Que quan: {hocSinh.QueQuan}");
                }
            }
        }
    }
    public class Bai6
    {
        public static void Main()
        {
            QuanLyHocSinh quanLyHocSinh = new QuanLyHocSinh();
            quanLyHocSinh.ThemHocSinh(new HocSinh("Nguyen Văn A", 20, "Ha Noi"));
            quanLyHocSinh.ThemHocSinh(new HocSinh("Nguyen Văn B", 21, "Ha Noi"));
            quanLyHocSinh.ThemHocSinh(new HocSinh("Nguyen Văn C", 20, "Da Nang"));
            quanLyHocSinh.ThemHocSinh(new HocSinh("Nguyen Văn D", 23, "Da Nang"));
            quanLyHocSinh.ThemHocSinh(new HocSinh("Nguyen Văn E", 23, "Ha Noi"));

            Console.WriteLine("Danh sach hoc sinh 20 tuoi:");
            quanLyHocSinh.HienThiHocSinh20Tuoi();

            Console.WriteLine("Danh sach hoc sinh 23 tuoi va que quan Da Nang:");
            quanLyHocSinh.HocSinh23TuoiQueDN();
        }
    }
}