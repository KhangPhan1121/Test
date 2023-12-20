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
    }
    class CongNhan : CanBo
    {
        public int Bac { get; set; }
    }
    class KySu : CanBo
    {
        public string NganhDaoTao { get; set; }
    }
    class NhanVien : CanBo
    {
        public string CongViec { get; set; }

    }
    class QLCB
    {
        public List<CanBo> DanhSachCanBo = new List<CanBo>();
        public void ThemCanBo(CanBo canBo)
        {
            DanhSachCanBo.Add(canBo);
        }
        public void TimKiemTheoHoTen(string hoten)
        {
            Console.WriteLine($"Ket qua tim kiem ho ten: ");
            foreach (CanBo canBo in DanhSachCanBo)
            {
                if (canBo.HoTen.Contains(hoten))
                {
                    HienThiThongTin(canBo);
                    Console.WriteLine("---------------");
                }
            }
        }
        public void HienThiThongTinDanhSachCanBo()
        {
            Console.WriteLine("Danh sach can bo:");
            foreach (CanBo canBo in DanhSachCanBo)
            {
                HienThiThongTin(canBo);
                Console.WriteLine("--------------------");
            }
        }
        private void HienThiThongTin(CanBo canBo)
        {
            Console.WriteLine($"Ho ten: {canBo.HoTen} Tuoi: {canBo.Tuoi} Gioi tinh: {canBo.GioiTinh} Dia chi: {canBo.DiaChi}");
            if (canBo is CongNhan)
            {
                CongNhan congNhan = (CongNhan)canBo;
                Console.WriteLine($"Bac: {congNhan.Bac}");
            }
            else if (canBo is KySu)
            {
                KySu kySu = (KySu)canBo;
                Console.WriteLine($"Nganh dao tao: {kySu.NganhDaoTao}");
            }
            else if (canBo is NhanVien)
            {
                NhanVien nhanVien = (NhanVien)canBo;
                Console.WriteLine($"Cong viec: {nhanVien.CongViec}");
            }
        }
    }
    public static class Bai1
    {
        public static void Main()
        {
            QLCB qlcb = new QLCB();
            qlcb.ThemCanBo(new CongNhan { HoTen = "Nguyen Van A", Tuoi = 20, GioiTinh = "Nam", DiaChi = "Ha Noi", Bac = 5 });
            qlcb.ThemCanBo(new KySu { HoTen = "Nguyen Van B", Tuoi = 20, GioiTinh = "Nam", DiaChi = "Ha Noi", NganhDaoTao = "Cong nghe thong tin" });
            qlcb.ThemCanBo(new NhanVien { HoTen = "Nguyen Van C", Tuoi = 20, GioiTinh = "Nam", DiaChi = "Ha Noi", CongViec = "Lam viec" });
            qlcb.TimKiemTheoHoTen("Nguyen Van");
            qlcb.HienThiThongTinDanhSachCanBo();
        }
    }
}