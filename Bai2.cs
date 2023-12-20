using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace Bai2
{
    class TaiLieu
    {
        public string MaTaiLieu { get; set; }
        public string TenNXB { get; set; }
        public int SoBanPhatHanh { get; set; }
    }
    class Sach : TaiLieu
    {
        public string TenTacGia { get; set; }
        public int SoTrang { get; set; }
    }
    class TapChi : TaiLieu
    {
        public int SoPhatHanh { get; set; }
        public int ThangPhatHanh { get; set; }
    }
    class Bao : TaiLieu
    {
        public int NgayPhatHanh { get; set; }
    }
    class QLS
    {
        public List<TaiLieu> taiLieu = new List<TaiLieu>();

        public void ThemTaiLieu<T>(T taiLieu) where T : TaiLieu
        {
            this.taiLieu.Add(taiLieu);
        }

        public void XoaTaiLieu(string maTaiLieu)
        {
            TaiLieu taiLieuCanXoa = taiLieu.FirstOrDefault(tl => tl.MaTaiLieu == maTaiLieu);
            if (taiLieuCanXoa != null)
            {
                taiLieu.Remove(taiLieuCanXoa);
                Console.WriteLine($"Da xoa tai lieu co ma {maTaiLieu}");
            }
            else
            {
                Console.WriteLine($"Khong tim thay tai lieu co ma {maTaiLieu} de xoa");
            }
        }
        public void HienThiThongTinTaiLieu()
        {
            foreach (TaiLieu tl in taiLieu)
            {
                HienThiThongTin(tl);
                Console.WriteLine("-----------------");
            }
        }
        public void TimKiemTaiLieuTheoLoai<T>() where T : TaiLieu
        {
            List<T> KetQuaTimkiem = taiLieu.OfType<T>().ToList();
            if (KetQuaTimkiem.Count > 0)
            {
                Console.WriteLine($"Danh sach tai lieu loai {typeof(T).Name}");
                foreach (T tl in KetQuaTimkiem)
                {
                    HienThiThongTin(tl);
                    Console.WriteLine("------------");
                }
            }
            else
            {
                Console.WriteLine($"Khong tim thay tai lieu loai {typeof(T).Name}");
            }
        }
        private void HienThiThongTin(TaiLieu tl)
        {
            Console.WriteLine($"Ma tai lieu: {tl.MaTaiLieu} TenNXB: {tl.TenNXB} So ban phat hanh: {tl.SoBanPhatHanh}");
            if (tl is Sach)
            {
                Sach sach = (Sach)tl;
                Console.WriteLine($"Ten tac gia: {sach.TenTacGia} So trang: {sach.SoTrang}");
            }
            else if (tl is TapChi)
            {
                TapChi tapChi = (TapChi)tl;
                Console.WriteLine($"So phat hanh: {tapChi.SoPhatHanh} Thang phat hanh: {tapChi.ThangPhatHanh}");
            }
            else if (tl is Bao)
            {
                Bao bao = (Bao)tl;
                Console.WriteLine($"Ngay phat hanh: {bao.NgayPhatHanh}");
            }
        }
    }
    public static class Bai2
    {
        public static void Main()
        {
            QLS qls = new QLS();

            
            Sach sach1 = new Sach { MaTaiLieu = "S001", TenNXB = "NXB A", SoBanPhatHanh = 100, TenTacGia = "Tac Gia A", SoTrang = 200 };
            TapChi tapChi1 = new TapChi { MaTaiLieu = "T001", TenNXB = "NXB B", SoBanPhatHanh = 50, SoPhatHanh = 5, ThangPhatHanh = 12 };
            Bao bao1 = new Bao { MaTaiLieu = "B001", TenNXB = "NXB C", SoBanPhatHanh = 30, NgayPhatHanh = 25 };

            qls.ThemTaiLieu(sach1);
            qls.ThemTaiLieu(tapChi1);
            qls.ThemTaiLieu(bao1);

            Console.WriteLine("Danh sach tai lieu:");
            qls.HienThiThongTinTaiLieu();

            string maTaiLieuCanXoa = "S001";
            qls.XoaTaiLieu(maTaiLieuCanXoa);
            Console.WriteLine("----------------------------");

            Console.WriteLine("Danh sach tai lieu sau khi xóa:");
            qls.HienThiThongTinTaiLieu();

            Console.WriteLine("Tim kiem tai lieu theo loai:");
            qls.TimKiemTaiLieuTheoLoai<Bao>();
        }
    }
}