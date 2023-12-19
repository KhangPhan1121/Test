using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bai3;

namespace Bai2
{
    class TaiLieu
    {
        public string MaTaiLieu { get; set; }
        public string TenNXB { get; set; }
        public int SoBanPhatHanh { get; set; }

        public virtual void HienThiThongTin()
        {
            Console.WriteLine($"Ma tai lieu: {MaTaiLieu} TenNXB: {TenNXB} So ban phat hanh: {SoBanPhatHanh}");
        }
    }
    class Sach : TaiLieu
    {
        public string TenTacGia { get; set; }
        public int SoTrang { get; set; }

        public override void HienThiThongTin()
        {
            base.HienThiThongTin();
            Console.WriteLine($"Ten tac gia: {TenTacGia} So trang: {SoTrang}");
        }
    }
    class TapChi : TaiLieu
    {
        public int SoBanPhatHanh { get; set; }
        public int ThangPhatHanh { get; set; }

        public override void HienThiThongTin()
        {
            base.HienThiThongTin();
            Console.WriteLine($"So ban phat hanh: {SoBanPhatHanh} Thang phat hanh: {ThangPhatHanh}");
        }
    }
    class Bao : TaiLieu
    {
        public DateTime NgayPhatHanh { get; set; }

        public override void HienThiThongTin()
        {
            base.HienThiThongTin();
            Console.WriteLine($"Ngay phat hanh: {NgayPhatHanh}");
        }
    }
    class QuanLySach
    {
        private List<TaiLieu> DanhSachTaiLieu = new List<TaiLieu>();
        public void ThemTaiLieu(TaiLieu taiLieu)
        {
            DanhSachTaiLieu.Add(taiLieu);
        }
        public void XoaTaiLieu(string maTaiLieu)
        {
            int index = DanhSachTaiLieu.FindIndex(t => t.MaTaiLieu == maTaiLieu);
            if (index >= 0)
            {
                DanhSachTaiLieu.RemoveAt(index);
                Console.WriteLine($"Đã xóa tài liệu có mã: {maTaiLieu}");
            }
            else
            {
                Console.WriteLine($"Không tìm kiếm tài liệu có mã: {maTaiLieu}");
            }
        }
        public void HienThiThongTinTaiLieu()
        {
            Console.WriteLine("Thông tin tài lệu: ");
            foreach (var taiLieu in DanhSachTaiLieu)
            {
                Console.WriteLine($"Mã tài liệu: {taiLieu.MaTaiLieu} Tên nhà xuất bản: {taiLieu.TenNXB} Số bản phát hành: {taiLieu.SoBanPhatHanh}");
                if (taiLieu is Sach)
                {
                    Console.WriteLine($"Tên tác giả: {(taiLieu as Sach).TenTacGia} Số trang: {(taiLieu as Sach).SoTrang}");
                }
                else if (taiLieu is TapChi)
                {
                    Console.WriteLine($"Số phát hành: {(taiLieu as TapChi).SoBanPhatHanh} Tháng phát hành: {(taiLieu as TapChi).ThangPhatHanh}");
                }
                else if (taiLieu is Bao)
                    Console.WriteLine($"Ngày phát hành: {(taiLieu as Bao).NgayPhatHanh}");
            }
        }
        public List<TaiLieu> TimKiemtaiLieuTheoLoai(int a)
        {
            List<TaiLieu> KetQua = new List<TaiLieu>();
            foreach (var taiLieu in DanhSachTaiLieu)
            {
                if (a == 1 && taiLieu is Sach)
                {
                    KetQua.Add(taiLieu);

                }
                else if (a == 2 && taiLieu is TapChi)
                {
                    KetQua.Add(taiLieu);
                }
                else if (a == 3 && taiLieu is Bao)
                {
                    KetQua.Add(taiLieu);
                }
            }
            return KetQua;
        }
        public void ThoatChuongtrinh()
        {
            Environment.Exit(0);
        }
    }
    public class Bai2
    {
        public static void Main()
        {
            
        }
    }
}