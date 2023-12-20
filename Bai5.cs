using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bai5
{
    class Nguoi
    {
        public string HoTen { get; set; }
        public int Tuoi { get; set; }
        public string SoCMND { get; set; }
    }
    class KhachSan
    {
        private List<Nguoi> danhSachKhach = new List<Nguoi>();
        private Dictionary<string, int> GiaPhong = new Dictionary<string, int>()
        {
            {"A", 500},
            {"B", 300},
            {"C", 100}
        };
        public List<Nguoi> DanhSachKhach => danhSachKhach;
        public int SoNgayThue { get; set; }
        public char LoaiPhong { get; set; }

        public void ThemKhach(Nguoi khach)
        {
            danhSachKhach.Add(khach);
        }

        public void XoaKhach(string soCMND)
        {
            Nguoi KhachcanXoa = danhSachKhach.Find(k => k.SoCMND == soCMND);
            if (KhachcanXoa != null)
            {
                danhSachKhach.Remove(KhachcanXoa);
                Console.WriteLine($"Da xoa thong tin khach co so CMND {soCMND}");
            }
            else
            {
                Console.WriteLine($"Khong tim thay khach co so CMND {soCMND}");
            }
        }
        public double TinhTienThuePhong(string soCMND)
        {
            if (GiaPhong.ContainsKey(LoaiPhong.ToString()))
            {
                int gia = GiaPhong[LoaiPhong.ToString()];
                Nguoi khach = danhSachKhach.Find(k => k.SoCMND == soCMND);
                if (khach != null)
                {
                    double tienThue = gia * SoNgayThue;
                    Console.WriteLine($"Tien thue phong cua khach {khach.HoTen} {khach.SoCMND} loai {LoaiPhong} trong {SoNgayThue} ngay la: {tienThue} $");
                    return tienThue;
                }
                else
                {
                    Console.WriteLine($"Khong tim thay khach co so CMND {soCMND} de tinh tien thue phong");
                    return 0;
                }
            }
            else
            {
                Console.WriteLine($"Loai phong {LoaiPhong} khong hop le.");
                return 0;
            }
        }
    }
    public class Bai5
    {
        public static void Main()
        {
            KhachSan khachSan = new KhachSan();

            Nguoi Khach1 = new Nguoi{HoTen = "Nguyen Van A", Tuoi = 20, SoCMND = "123456789"};
            Nguoi Khach2 = new Nguoi{HoTen = "Nguyen Van B", Tuoi = 30, SoCMND = "987654321"};
            Nguoi Khach3 = new Nguoi{HoTen = "Nguyen Van C", Tuoi = 40, SoCMND = "111111111"};
            Nguoi Khach4 = new Nguoi{HoTen = "Nguyen Van D", Tuoi = 50, SoCMND = "222222222"};
            Nguoi Khach5 = new Nguoi{HoTen = "Nguyen Van E", Tuoi = 60, SoCMND = "333333333"};

            khachSan.ThemKhach(Khach1);
            khachSan.ThemKhach(Khach2);
            khachSan.ThemKhach(Khach3);
            khachSan.ThemKhach(Khach4);
            khachSan.ThemKhach(Khach5);

            Console.WriteLine("Danh sach khach trong khach san:");
            foreach (Nguoi khach in khachSan.DanhSachKhach)
            {
                Console.WriteLine($"Ho ten: {khach.HoTen}, Tuoi: {khach.Tuoi}, So CMND: {khach.SoCMND}");
            }
            Console.WriteLine("----------------------");

            khachSan.XoaKhach("987654321");
            
            Console.WriteLine("Danh sach khach san sau khi xoa:");
            foreach (Nguoi khach in khachSan.DanhSachKhach)
            {
                Console.WriteLine($"Ho ten: {khach.HoTen}, Tuoi: {khach.Tuoi}, So CMND: {khach.SoCMND}");
            }
            Console.WriteLine("----------------------");

            khachSan.SoNgayThue = 7;
            khachSan.LoaiPhong = 'A';
            khachSan.TinhTienThuePhong("123456789");

            khachSan.SoNgayThue = 5;
            khachSan.LoaiPhong = 'B';
            khachSan.TinhTienThuePhong("111111111");

            khachSan.SoNgayThue = 3;
            khachSan.LoaiPhong = 'C';
            khachSan.TinhTienThuePhong("222222222");
        }
    }
}