using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bai3
{
    class ThiSinh
    {
        public string SoBaoDanh { get; set; }
        public string HoTen { get; set; }
        public string DiaChi { get; set; }
        public int MucUuTien { get; set; }

        public ThiSinh(string soBaoDanh, string hoTen, string diaChi, int mucUuTien)
        {
            SoBaoDanh = soBaoDanh;
            HoTen = hoTen;
            DiaChi = diaChi;
            MucUuTien = mucUuTien;
        }
    }
    class ThiSinhThiKhoiA : ThiSinh
    {
        public int Diem_Toan { get; set; }
        public int Diem_Ly { get; set; }
        public int Diem_Hoa { get; set; }

        public ThiSinhThiKhoiA(string soBaoDanh, string hoTen, string diaChi, int mucUuTien, int diem_Toan, int diem_Ly, int diem_Hoa) : base(soBaoDanh, hoTen, diaChi, mucUuTien)
        {
            Diem_Toan = diem_Toan;
            Diem_Ly = diem_Ly;
            Diem_Hoa = diem_Hoa;
        }
    }
    class ThiSinhThiKhoiB : ThiSinh
    {
        public int Diem_Toan { get; set; }
        public int Diem_Hoa { get; set; }
        public int Diem_Sinh { get; set; }

        public ThiSinhThiKhoiB(string soBaoDanh, string hoTen, string diaChi, int mucUuTien, int diem_Toan, int diem_Hoa, int diem_Sinh) : base(soBaoDanh, hoTen, diaChi, mucUuTien)
        {
            Diem_Toan = diem_Toan;
            Diem_Hoa = diem_Hoa;
            Diem_Sinh = diem_Sinh;
        }
    }
    class ThiSinhThiKhoiC : ThiSinh
    {
        public int Diem_Van { get; set; }
        public int Diem_Su { get; set; }
        public int Diem_Dia { get; set; }

        public ThiSinhThiKhoiC(string soBaoDanh, string hoTen, string diaChi, int mucUuTien, int diem_Van, int diem_Su, int diem_Dia) : base(soBaoDanh, hoTen, diaChi, mucUuTien)
        {
            Diem_Van = diem_Van;
            Diem_Su = diem_Su;
            Diem_Dia = diem_Dia;
        }
    }
    class TuyenSinh
    {
        List<ThiSinh> danhSachThiSinh = new List<ThiSinh>();

        public void ThemThiSinh(ThiSinh thiSinh)
        {
            danhSachThiSinh.Add(thiSinh);
        }

        public void HienThiThongTinThiSinhVaKhoiThi()
        {
            foreach(ThiSinh thiSinh in danhSachThiSinh)
            Console.WriteLine($"So bao danh: {thiSinh.SoBaoDanh}, Ho ten: {thiSinh.HoTen}, Dia chi: {thiSinh.DiaChi}, Muc uu tien: {thiSinh.MucUuTien}");
        }

        public void TimKiemTheoSoBaoDanh(string soBaoDanh)
        {
            foreach(ThiSinh thiSinh in danhSachThiSinh)
            {
                if(thiSinh.SoBaoDanh == soBaoDanh)
                {
                    Console.WriteLine($"So bao danh: {thiSinh.SoBaoDanh}, Ho ten: {thiSinh.HoTen}, Dia chi: {thiSinh.DiaChi}, Muc uu tien: {thiSinh.MucUuTien}");
                    break;
                }
            }
        }
        
        public void ThoatChuongTrinh()
        {
            Environment.Exit(0);
        }
    }
    public class Bai3
    {
        public static void Main()
        {
            ThiSinh thiSinh = new ThiSinh("001", "Nguyen Van A", "Ha Noi", 1);
            ThiSinhThiKhoiA thiSinhThiKhoiA = new ThiSinhThiKhoiA("002", "Nguyen Van B", "Ha Noi", 2, 8, 9, 10);
            ThiSinhThiKhoiB thiSinhThiKhoiB = new ThiSinhThiKhoiB("003", "Nguyen Van C", "Ha Noi", 3, 8, 9, 10);
            ThiSinhThiKhoiC thiSinhThiKhoiC = new ThiSinhThiKhoiC("004", "Nguyen Van D", "Ha Noi", 4, 8, 9, 10);
            TuyenSinh tuyenSinh = new TuyenSinh();
            tuyenSinh.ThemThiSinh(thiSinh);
            tuyenSinh.ThemThiSinh(thiSinhThiKhoiA);
            tuyenSinh.ThemThiSinh(thiSinhThiKhoiB);
            tuyenSinh.ThemThiSinh(thiSinhThiKhoiC);
            tuyenSinh.HienThiThongTinThiSinhVaKhoiThi();
            Console.WriteLine("Nhap so bao danh can tim kiem: ");
            tuyenSinh.TimKiemTheoSoBaoDanh("002");
            tuyenSinh.ThoatChuongTrinh();

        }
    }
}