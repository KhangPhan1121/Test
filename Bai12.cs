using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bai12
{
    class PTGT
    {
        public int ID { get; set; }
        public string HangSanXuat { get; set; }
        public int NamSanXuat { get; set; }
        public double GiaBan { get; set; }
        public string MauXe { get; set; }

        public PTGT(int iD, string hangSanXuat, int namSanXuat, double giaBan, string mauXe)
        {
            ID = iD;
            HangSanXuat = hangSanXuat;
            NamSanXuat = namSanXuat;
            GiaBan = giaBan;
            MauXe = mauXe;
        }
    }
    class OTo : PTGT
    {
        public int SoChoNgoi { get; set; }
        public string KieuDongCo { get; set; }

        public OTo(int iD, string hangSanXuat, int namSanXuat, double giaBan, string mauXe, int soChoNgoi, string kieuDongCo) : base(iD, hangSanXuat, namSanXuat, giaBan, mauXe)
        {
            SoChoNgoi = soChoNgoi;
            KieuDongCo = kieuDongCo;
        }
    }
    class XeMay : PTGT
    {
        public string CongXuat { get; set; }

        public XeMay(int iD, string hangSanXuat, int namSanXuat, double giaBan, string mauXe, string congXuat) : base(iD, hangSanXuat, namSanXuat, giaBan, mauXe)
        {
            CongXuat = congXuat;
        }
    }
    class XeTai : PTGT
    {
        public string TrongTai { get; set; }

        public XeTai(int iD, string hangSanXuat, int namSanXuat, double giaBan, string mauXe, string trongTai) : base(iD, hangSanXuat, namSanXuat, giaBan, mauXe)
        {
            TrongTai = trongTai;
        }
    }
    class QLPTGT
    {
        public List<PTGT> danhSachPTGT = new List<PTGT>();

        public void ThemPTGT(PTGT ptgt)
        {
            danhSachPTGT.Add(ptgt);
        }

        public void XoaPTGT(int id)
        {
            PTGT pTGTXoa = danhSachPTGT.Find(p => p.ID == id);
            if (pTGTXoa != null)
            {
                danhSachPTGT.Remove(pTGTXoa);
                Console.WriteLine($"Xoa thanh cong {pTGTXoa.HangSanXuat} co ID {pTGTXoa.ID}.");
            }
            else
            {
                Console.WriteLine($"Khong tim thay phuong tien ID {id}.");
            }
        }

        public void TimPTGT<T>() where T : PTGT
        {
            List<T> danhSachTimKiem = danhSachPTGT.OfType<T>().ToList();
            if (danhSachTimKiem.Count > 0)
            {
                Console.WriteLine("Danh sach phuong tien:");
                foreach (T ptgt in danhSachTimKiem)
                {
                    HienThiThongTin(ptgt);
                    Console.WriteLine($"---------------");
                }
            }
            else
            {
                Console.WriteLine($"Khong tim thay phuong tien co kieu {typeof(T).Name}.");
            }
        }
        public void HienThiThongTin(PTGT ptgt)
        {
            Console.WriteLine($"ID: {ptgt.ID} Hang San Xuat: {ptgt.HangSanXuat} Nam san xuat: {ptgt.NamSanXuat} Gia ban: {ptgt.GiaBan} Mau xe: {ptgt.MauXe}");
            if (ptgt is OTo)
            {
                OTo oTo = (OTo)ptgt;
                Console.WriteLine($"So cho ngoi: {oTo.SoChoNgoi} Kieu dong co: {oTo.KieuDongCo}");
            }
            else if (ptgt is XeMay)
            {
                XeMay xeMay = (XeMay)ptgt;
                Console.WriteLine($"Cong xuat: {xeMay.CongXuat}");
            }
            else if (ptgt is XeTai)
            {
                XeTai xeTai = (XeTai)ptgt;
                Console.WriteLine($"Trong tai: {xeTai.TrongTai}");
            }
        }
    }
    public static class Bai12
    {
        public static void Main()
        {
            QLPTGT qlptgt = new QLPTGT();
            qlptgt.ThemPTGT(new OTo(1, "Honda", 2021, 2000000, "Xanh", 4, "Manual"));
            qlptgt.ThemPTGT(new XeMay(2, "Toyota", 2022, 3000000, "Do", "Diesel"));
            qlptgt.ThemPTGT(new XeTai(3, "BMW", 2020, 5000000, "Vang", "20 Ton"));
            qlptgt.HienThiThongTin(qlptgt.danhSachPTGT[0]);
            qlptgt.HienThiThongTin(qlptgt.danhSachPTGT[1]);
            qlptgt.HienThiThongTin(qlptgt.danhSachPTGT[2]);
            qlptgt.XoaPTGT(2);
            qlptgt.TimPTGT<OTo>();
            qlptgt.TimPTGT<XeMay>();
            qlptgt.TimPTGT<XeTai>();
        }
    }
}