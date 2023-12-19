using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bai1
{
    class CanBo
    {
        public string HoTen { get; set; }
        public int Tuoi { get; set; }
        public string GioiTinh { get; set; }
        public string DiaChi { get; set; }

        public CanBo(string hoTen, int tuoi, string gioiTinh, string diaChi)
        {
            HoTen = hoTen;
            Tuoi = tuoi;
            GioiTinh = gioiTinh;
            DiaChi = diaChi;
            NhapThongTin(HoTen, Tuoi, GioiTinh, DiaChi);
        }

        public void NhapThongTin(string hoTen, int tuoi, string gioiTinh, string diaChi)
        {
            HoTen = hoTen;
            Tuoi = tuoi;
            GioiTinh = gioiTinh;
            DiaChi = diaChi;
        }
    }
    class CongNhan : CanBo
    {
        public int Bac { get; set; }

        public CongNhan(string hoTen, int tuoi, string gioiTinh, string diaChi, int bac) : base(hoTen, tuoi, gioiTinh, diaChi)
        {
            HoTen = hoTen;
            Tuoi = tuoi;
            GioiTinh = gioiTinh;
            DiaChi = diaChi;
            Bac = bac;
        }

        public void NhapThongTin(string hoTen, int tuoi, string gioiTinh, string diaChi, int bac)
        {
            base.NhapThongTin(hoTen, tuoi, gioiTinh, diaChi);
            Bac = bac;
        }
    }
    class KySu : CanBo
    {
        public string NganhDaoTao { get; set; }

        public KySu(string hoTen, int tuoi, string gioiTinh, string diaChi, string nganhDaoTao) : base(hoTen, tuoi, gioiTinh, diaChi)
        {
            NganhDaoTao = nganhDaoTao;
            NhapThongTin(hoTen, tuoi, gioiTinh, diaChi, nganhDaoTao);
        }

        public void NhapThongTin(string hoTen, int tuoi, string gioiTinh, string diaChi, string nganhDaoTao)
        {
            HoTen = hoTen;
            Tuoi = tuoi;
            GioiTinh = gioiTinh;
            DiaChi = diaChi;
            NganhDaoTao = nganhDaoTao;
        }
    }
    class NhanVien : CanBo
    {
        public string CongViec { get; set; }

        public NhanVien(string hoTen, int tuoi, string gioiTinh, string diaChi, string congViec) : base(hoTen, tuoi, gioiTinh, diaChi)
        {
            CongViec = congViec;
            NhapThongTin(hoTen, tuoi, gioiTinh, diaChi, congViec);
        }

        public void NhapThongTin(string hoTen, int tuoi, string gioiTinh, string diaChi, string congViec)
        {
            HoTen = hoTen;
            Tuoi = tuoi;
            GioiTinh = gioiTinh;
            DiaChi = diaChi;
            CongViec = congViec;
        }
    }
    class QuanLyCanBo
    {
        List<CanBo> DanhSachCanBo = new List<CanBo>();

        public void ThemCanBo(CanBo canBo)
        {
            DanhSachCanBo.Add(canBo);
        }

        // public void TimKiemCanBo(string hoTen)
        // {
        //     foreach (CanBo canBo in DanhSachCanBo)
        //     {
        //         if (canBo.HoTen.ToLower().Contains(hoTen.ToLower()))
        //         {
        //             Console.WriteLine($"Ho ten: {canBo.HoTen} Tuoi: {canBo.Tuoi} Gioi tinh: {canBo.GioiTinh} Dia chi: {canBo.DiaChi}");
        //         }
        //     }
        // }

        public List<CanBo> TimKiemCanBo(string hoTen)
        {
            return DanhSachCanBo
            .Where(canBo => canBo.HoTen.ToLower().Contains(hoTen.ToLower()))
            .ToList();
        }

        public void HienThiThongTinCanBo()
        {
            foreach (CanBo canBo in DanhSachCanBo)
            {
                Console.WriteLine($"Ho ten: {canBo.HoTen} Tuoi: {canBo.Tuoi} Gioi tinh: {canBo.GioiTinh} Dia chi: {canBo.DiaChi}");
            }
        }

        public void ThoatChuongTrinh()
        {
            Environment.Exit(0);
        }
    }
    public class Bai1
    {
        public static void Main()
        {
            QuanLyCanBo qlcb = new QuanLyCanBo();
            CongNhan congnhan1 = new CongNhan("Pham Van Phuong ", 25, "Nam ", "HCM", 5);
            KySu kysu1 = new KySu("Nguyen Van A ", 30, "Nam ", "HCM", "Kinh te");
            NhanVien nhanvien1 = new NhanVien("Nguyen Van B ", 35, "Nam ", "HCM", "Nhan vien");
            qlcb.ThemCanBo(congnhan1);
            qlcb.ThemCanBo(kysu1);
            qlcb.ThemCanBo(nhanvien1);
            qlcb.HienThiThongTinCanBo();
            
            Console.WriteLine("Nhap ho ten can tim kiem: ");
            string hoTen = Console.ReadLine();
            List<CanBo> ketQuaTimKiem = qlcb.TimKiemCanBo(hoTen);
            foreach (CanBo canBo in ketQuaTimKiem)
            {
                Console.WriteLine($"Ho ten: {canBo.HoTen} Tuoi: {canBo.Tuoi} Gioi tinh: {canBo.GioiTinh} Dia chi: {canBo.DiaChi}");
            }
            qlcb.ThoatChuongTrinh();
        }
    }
}