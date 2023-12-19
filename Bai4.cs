using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bai4
{
    class Nguoi
    {
        public string HoTen { get; set; }
        public int Tuoi { get; set; }
        public string NgheNghiep { get; set; }
        public string SoCMND { get; set; }

        public Nguoi(string hoTen, int tuoi, string ngheNghiep, string soCMND)
        {
            HoTen = hoTen;
            Tuoi = tuoi;
            NgheNghiep = ngheNghiep;
            SoCMND = soCMND;
        }
    }
    class HoGiaDinh : Nguoi
    {
        public List<Nguoi> DanhSachThanhVien { get; set; }
        public HoGiaDinh(string hoTen, int tuoi, string ngheNghiep, string soCMND) : base(hoTen, tuoi, ngheNghiep, soCMND)
        {
            DanhSachThanhVien = new List<Nguoi>();
        }
    }
    class KhuPho
    {
        public List<HoGiaDinh> DanhSachHoGiaDinh { get; set; }
        public KhuPho()
        {
            DanhSachHoGiaDinh = new List<HoGiaDinh>();
        }
    }
    public class Bai4
    {
        public static void Main()
        {
            KhuPho khuPho = new KhuPho();
            HoGiaDinh hoGiaDinh1 = new HoGiaDinh("Ho Gia Dinh 1", 30, "Nhan vien", "123456789");
            HoGiaDinh hoGiaDinh2 = new HoGiaDinh("Ho Gia Dinh 2", 25, "Nhan vien", "987654321");
            khuPho.DanhSachHoGiaDinh.Add(hoGiaDinh1);
            khuPho.DanhSachHoGiaDinh.Add(hoGiaDinh2);
            hoGiaDinh1.DanhSachThanhVien.Add(new Nguoi("Nguoi 1", 20, "Nhan vien", "111111111"));
            hoGiaDinh1.DanhSachThanhVien.Add(new Nguoi("Nguoi 2", 22, "Nhan vien", "222222222"));
            hoGiaDinh2.DanhSachThanhVien.Add(new Nguoi("Nguoi 3", 23, "Nhan vien", "333333333"));
            hoGiaDinh2.DanhSachThanhVien.Add(new Nguoi("Nguoi 4", 24, "Nhan vien", "444444444"));
            
            Console.WriteLine("Danh sach ho gia dinh:");
            foreach (HoGiaDinh hoGiaDinh in khuPho.DanhSachHoGiaDinh)
            {
                Console.WriteLine($"Ho gia dinh: {hoGiaDinh.HoTen}");
                Console.WriteLine("Danh sach thanh vien:");
                foreach (Nguoi nguoi in hoGiaDinh.DanhSachThanhVien)
                {
                    Console.WriteLine($"Ho ten: {nguoi.HoTen} Tuoi: {nguoi.Tuoi} Nghe nghiep {nguoi.NgheNghiep} SoCMND {nguoi.SoCMND} ");
                }
            }
        }
    }
}