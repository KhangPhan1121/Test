using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bai7
{
    class Nguoi
    {
        public string HoTen { get; set; }
        public int Tuoi { get; set; }
        public string QueQuan { get; set; }
        public string MaSoGiaoVien { get; set; }

        public Nguoi(string hoTen, int tuoi, string queQuan, string maSoGiaoVien)
        {
            HoTen = hoTen;
            Tuoi = tuoi;
            QueQuan = queQuan;
            MaSoGiaoVien = maSoGiaoVien;
        }
    }
    class CBGV : Nguoi
    {
        public decimal LuongCung { get; set; }
        public decimal LuongThuong { get; set; }
        public decimal TienPhat { get; set; }
        public decimal LuongThucLinh { get; set; }
        public CBGV(string hoTen, int tuoi, string queQuan, string maSoGiaoVien, decimal luongCung, decimal luongThuong, decimal tienPhat, decimal luongThucLinh) : base(hoTen, tuoi, queQuan, maSoGiaoVien)
        {
            LuongCung = luongCung;
            LuongThuong = luongThuong;
            TienPhat = tienPhat;
            LuongThucLinh = luongThucLinh;
        }

        public void TinhLuongThucLinh()
        {
            LuongThucLinh =  LuongCung + LuongThuong - TienPhat;
        }

    }
    class QuanLyCBGV
    {
        List<CBGV> danhSachCanBo = new List<CBGV>();

        public void ThemCanBo(CBGV cb)
        {
            danhSachCanBo.Add(cb);
        }

        public void XoaCanBo(string maSoGiaoVien)
        {
            CBGV canBoCanXoa = danhSachCanBo.Find(CBGV => CBGV.MaSoGiaoVien == maSoGiaoVien);
            if (canBoCanXoa != null)
            {
                danhSachCanBo.Remove(canBoCanXoa);
            }
            else
            {
                Console.WriteLine($"Khong tim thay giao vien co ma so {maSoGiaoVien}");
            }
        }
        public void HienThiThongTinCBGV()
        {
            Console.WriteLine("Danh sach giao vien:");
            foreach (CBGV cbgv in danhSachCanBo)
            {
                Console.WriteLine($"Ho ten: {cbgv.HoTen} Tuoi: {cbgv.Tuoi} Ma so giao vien: {cbgv.MaSoGiaoVien} Luong thuc linh: {cbgv.LuongThucLinh}");
            }
        }
    }
    public class Bai7
    {
        public static void Main()
        {
            QuanLyCBGV quanLyCBGV = new QuanLyCBGV();
            CBGV cbgv1 = new CBGV("Nguyen Van A", 20, "Ha Noi", "GV01", 1000000, 200000, 0, 1200000);
            CBGV cbgv2 = new CBGV("Nguyen Van B", 21, "Ha Noi", "GV02", 1000000, 200000, 0, 1200000);
            CBGV cbgv3 = new CBGV("Nguyen Van C", 22, "Ha Noi", "GV03", 1000000, 200000, 0, 1200000);
            CBGV cbgv4 = new CBGV("Nguyen Van D", 23, "Ha Noi", "GV04", 1000000, 200000, 0, 1200000);

            quanLyCBGV.ThemCanBo(cbgv1);
            quanLyCBGV.ThemCanBo(cbgv2);
            quanLyCBGV.ThemCanBo(cbgv3);
            quanLyCBGV.ThemCanBo(cbgv4);

            quanLyCBGV.HienThiThongTinCBGV();

            quanLyCBGV.XoaCanBo("GV01");

            quanLyCBGV.HienThiThongTinCBGV();
        }
    }
}