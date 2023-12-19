using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bai8
{
    class SinhVien
    {
        public string HoTen { get; set; }
        public int Tuoi { get; set; }
        public int Lop { get; set; }

        public SinhVien(string hoTen, int tuoi, int lop)
        {
            HoTen = hoTen;
            Tuoi = tuoi;
            Lop = lop;
        }
    }
    class TheMuon : SinhVien
    {
        public string MaPhieuMuon { get; set; }
        public DateTime NgayMuon { get; set; }
        public DateTime NgayTra { get; set; }
        public string SoHieuSach { get; set; }

        public TheMuon(string hoTen, int tuoi, int lop, string maPhieuMuon, DateTime ngayMuon, DateTime ngayTra, string soHieuSach) : base(hoTen, tuoi, lop)
        {
            MaPhieuMuon = maPhieuMuon;
            NgayMuon = ngayMuon;
            NgayTra = ngayTra;
            SoHieuSach = soHieuSach;
        }
    }
    class QuanLySinhVien
    {
        List<SinhVien> danhSachSinhVien = new List<SinhVien>();

        public void ThemSinhVien(SinhVien sv)
        {
            danhSachSinhVien.Add(sv);
        }

        public void XoaSinhVien(string maPhieuMuon)
        {
            TheMuon theMuonCanXoa = danhSachSinhVien.Find(sv => sv is TheMuon && ((TheMuon)sv).MaPhieuMuon == maPhieuMuon) as TheMuon;
            if (theMuonCanXoa != null)
            {
                danhSachSinhVien.Remove(theMuonCanXoa);
                Console.WriteLine("Xoa thanh cong");
            }
            else
            {
                Console.WriteLine("Khong tim thay phieu muon can xoa");
            }
        }

        public void HienThiThongTinSinhVien()
        {
            Console.WriteLine("Danh sach sinh vien:");
            foreach (SinhVien sv in danhSachSinhVien)
            {
                Console.WriteLine($"Ho ten: {sv.HoTen}, Tuoi: {sv.Tuoi}, Lop: {sv.Lop}");
            }
        }
    }
    public class Bai8
    {
        public static void Main()
        {
            QuanLySinhVien quanLySinhVien = new QuanLySinhVien();
            quanLySinhVien.ThemSinhVien(new TheMuon("Nguyen Van A", 20, 1, "PM001", DateTime.Now, DateTime.Now.AddDays(7), "S001"));
            quanLySinhVien.ThemSinhVien(new TheMuon("Nguyen Van B", 21, 2, "PM002", DateTime.Now, DateTime.Now.AddDays(7), "S002"));
            quanLySinhVien.ThemSinhVien(new TheMuon("Nguyen Van C", 22, 3, "PM003", DateTime.Now, DateTime.Now.AddDays(7), "S003"));

            quanLySinhVien.HienThiThongTinSinhVien();

            quanLySinhVien.XoaSinhVien("PM001");
            quanLySinhVien.HienThiThongTinSinhVien();
        }
    }
}