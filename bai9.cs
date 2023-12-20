using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bai9
{
    class KhachHang
    {
        public string HoTen { get; set; }
        public string SoNha { get; set; }
        public string MaSoCongToDien { get; set; }
    }
    class BienLai
    {
        private List<KhachHang> danhSachKhachHang = new List<KhachHang>();
        public List<KhachHang> DanhSachKhachHang => danhSachKhachHang;
        public void ThemKhachHang(KhachHang khachHang)
        {
            danhSachKhachHang.Add(khachHang);
        }
        public void XoaKhachHang(string maSoCongToDien)
        {
            KhachHang khachHangCanXoa = danhSachKhachHang.Find(k => k.MaSoCongToDien == maSoCongToDien);
            if (khachHangCanXoa != null)
            {
                danhSachKhachHang.Remove(khachHangCanXoa);
                Console.WriteLine($"Da xoa thong tin khach hang co ma so cong to dien {maSoCongToDien}");
            }
            else
            {
                Console.WriteLine($"Khong tim thay khach hang co ma so cong to dien {maSoCongToDien}");
            }
        }
        public void SuaThongTinKhachHang(string maSoCongToDien, KhachHang thongTinMoi)
        {
            KhachHang khachHangCanSua = danhSachKhachHang.Find(k => k.MaSoCongToDien == maSoCongToDien);
            if (khachHangCanSua != null)
            {
                khachHangCanSua.HoTen = thongTinMoi.HoTen;
                khachHangCanSua.SoNha = thongTinMoi.SoNha;
                Console.WriteLine($"Da cap nhat thong tin khach hang co ma so cong to dien {maSoCongToDien}");
            }
            else
            {
                Console.WriteLine($"Khong tim thay khach hang co ma so cong to dien {maSoCongToDien}");

            }
        }
        public double TinhTienDien(string maSoCongToDien, int chiSoDienCu, int chiSoDienMoi)
        {
            KhachHang khachHang = danhSachKhachHang.Find(k => k.MaSoCongToDien == maSoCongToDien);
            if (khachHang != null)
            {
                int soDienSuDung = chiSoDienMoi - chiSoDienCu;
                double tienDien = soDienSuDung * 5;
                Console.WriteLine($"So tien dien phai tra cho khach hang {khachHang.HoTen} ({khachHang.MaSoCongToDien}: {tienDien} dong");
                return tienDien;
            }
            else
            {
                Console.WriteLine($"Khong tim thay khach hang co ma so cong to dien {maSoCongToDien}");
                return 0;
            }
        }
    }
    public static class Bai9
    {
        public static void Main()
        {
            BienLai bienLai = new BienLai();

            KhachHang khach1 = new KhachHang { HoTen = "Nguyen Van A", SoNha = "123", MaSoCongToDien = "CTD001" };
            KhachHang khach2 = new KhachHang { HoTen = "Nguyen Van B", SoNha = "456", MaSoCongToDien = "CTD002" };

            bienLai.ThemKhachHang(khach1);
            bienLai.ThemKhachHang(khach2);

            Console.WriteLine("Danh sach khach hang trong bien lai:");
            foreach (KhachHang khachHang in bienLai.DanhSachKhachHang)
            {
                Console.WriteLine($"Họ tên chủ hộ: {khachHang.HoTen}, Số nhà: {khachHang.SoNha}, Mã số công tơ điện: {khachHang.MaSoCongToDien}");
            }
            Console.WriteLine("----------------------");

            bienLai.XoaKhachHang("CTD002");

            Console.WriteLine("Danh sach khach hang sau khi xoa:");
            foreach (KhachHang khachHang in bienLai.DanhSachKhachHang)
            {
                Console.WriteLine($"Họ tên chủ hộ: {khachHang.HoTen}, Số nhà: {khachHang.SoNha}, Mã số công tơ điện: {khachHang.MaSoCongToDien}");
            }
            Console.WriteLine("----------------------");

            KhachHang khach3 = new KhachHang { HoTen = "Nguyen Van C", SoNha = "789", MaSoCongToDien = "CTD003" };
            bienLai.SuaThongTinKhachHang("CTD001", khach3);

            Console.WriteLine("Danh sach khach hang sau khi sua thong tin:");
            foreach (KhachHang khachHang in bienLai.DanhSachKhachHang)
            {
                Console.WriteLine($"Họ tên chủ hộ: {khachHang.HoTen}, Số nhà: {khachHang.SoNha}, Mã số công tơ điện: {khachHang.MaSoCongToDien}");
            }
            Console.WriteLine("----------------------");

            bienLai.TinhTienDien("CTD003", 1000, 1200);
        }
    }
}