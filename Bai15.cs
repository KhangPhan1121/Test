using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Threading.Tasks;

namespace Bai15
{
    class SinhVien : IComparable<SinhVien>
    {
        public string MaSV { get; set; }
        public string HoTen { get; set; }
        public DateTime NgaySinh { get; set; }
        public int NamVaoHoc { get; set; }
        public double DiemDauVao { get; set; }
        public List<KetQuaHocTap> DanhSachKetQua { get; set; }

        public SinhVien()
        {
            DanhSachKetQua = new List<KetQuaHocTap>();
        }

        public SinhVien(string maSV, string hoTen, DateTime ngaySinh, int namVaoHoc, double diemDauVao) : this()
        {
            MaSV = maSV;
            HoTen = hoTen;
            NgaySinh = ngaySinh;
            NamVaoHoc = namVaoHoc;
            DiemDauVao = diemDauVao;
        }

        public SinhVien(SinhVien sinhVien) : this(sinhVien.MaSV, sinhVien.HoTen, sinhVien.NgaySinh, sinhVien.NamVaoHoc, sinhVien.DiemDauVao)
        {

        }

        public double DiemTrungBinhTheoHocKy(string tenHocKy)
        {
            double tongDiem = 0;
            int soMonHoc = 0;

            foreach (var ketQua in DanhSachKetQua)
            {
                if (ketQua.TenHocKy == tenHocKy)
                {
                    tongDiem += ketQua.DiemTB;
                    soMonHoc++;
                }
            }

            if (soMonHoc > 0)
            {
                return tongDiem / soMonHoc;
            }
            else
            {
                Console.WriteLine($"Khong tim thay ket qua cho hoc ky {tenHocKy}");
                return 0;
            }
        }

        public double LayDiemTrungBinhHocKyGanNhat()
        {
            if (DanhSachKetQua.Count == 0)
            {
                Console.WriteLine("Sinh viên chưa có kết quả học tập.");
                return 0;
            }

            // Tìm học kỳ gần nhất
            var hockyGanNhat = DanhSachKetQua.MaxBy(kq => kq.TenHocKy)?.TenHocKy;

            if (hockyGanNhat == null)
            {
                Console.WriteLine("Không tìm thấy học kỳ nào.");
                return 0;
            }

            // Tính điểm trung bình cho học kỳ gần nhất
            double tongDiem = 0;
            int soMonHoc = 0;

            foreach (var ketQua in DanhSachKetQua)
            {
                if (ketQua.TenHocKy == hockyGanNhat)
                {
                    tongDiem += ketQua.DiemTB;
                    soMonHoc++;
                }
            }

            if (soMonHoc > 0)
            {
                return tongDiem / soMonHoc;
            }
            else
            {
                Console.WriteLine($"Không tìm thấy kết quả cho học kỳ {hockyGanNhat}");
                return 0;
            }
        }

        public virtual bool LaSinhVienChinhQuy()
        {
            return true;
        }

        public int CompareTo(SinhVien other)
        {
            // Sắp xếp tăng dần theo loại (đặt ưu tiên chính quy trước)
            int compareResult = this.LaSinhVienChinhQuy().CompareTo(other.LaSinhVienChinhQuy());

            // Nếu loại giống nhau, sắp xếp giảm dần theo năm vào học
            if (compareResult == 0)
            {
                compareResult = other.NamVaoHoc.CompareTo(this.NamVaoHoc);
            }

            return compareResult;
        }
    }

    class SinhVienChinhQuy : SinhVien
    {
        public SinhVienChinhQuy() : base()
        {
        }

        public SinhVienChinhQuy(string maSV, string hoTen, DateTime ngaySinh, int namVaoHoc, double diemDauVao)
            : base(maSV, hoTen, ngaySinh, namVaoHoc, diemDauVao)
        {
        }

        public SinhVienChinhQuy(SinhVien sinhVien) : base(sinhVien)
        {
        }

        public void InputSinhVienChinhQuy()
        {
            try
            {
                Console.WriteLine("Nhap thong tin Sinh Vien Chinh Quy:");

                Console.Write("Ma SV: ");
                MaSV = Console.ReadLine();
                if (string.IsNullOrEmpty(MaSV))
                {
                    throw new ArgumentException("Ma SV khong duoc bo trong");
                }

                Console.Write("Ho Ten: ");
                HoTen = Console.ReadLine();
                if (string.IsNullOrEmpty(HoTen))
                {
                    throw new ArgumentException("Ho Ten khong duoc bo trong");
                }

                Console.Write("Ngay Sinh (yyyy/MM/dd): ");
                if (DateTime.TryParseExact(Console.ReadLine(), "yyyy/MM/dd", null, System.Globalization.DateTimeStyles.None, out DateTime ngaySinhResult))
                {
                    NgaySinh = ngaySinhResult;
                }
                else
                {
                    throw new ArgumentException("Ngay Sinh khong dung dinh dang");
                }

                Console.Write("Nam Vao Hoc: ");
                if (int.TryParse(Console.ReadLine(), out int namVaoHocResult))
                {
                    NamVaoHoc = namVaoHocResult;
                }
                else
                {
                    throw new ArgumentException("Nam Vao Hoc phai la mot so nguyen");
                }

                Console.Write("Diem Dau Vao: ");
                if (double.TryParse(Console.ReadLine(), out double diemDauVaoResult))
                {
                    DiemDauVao = diemDauVaoResult;
                }
                else
                {
                    throw new ArgumentException("Diem Dau Vao phai la mot so thuc");
                }

                Console.WriteLine("Nhap thong tin thanh cong.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Loi: {ex.Message}");
                // Xử lý exception tại đây (ghi log, thông báo người dùng, v.v.)
            }
        }

        public bool LaSinhVienChinhQuy()
        {
            return true;
        }
    }

    class SinhVienTaiChuc : SinhVien
    {
        public string NoiLienKetDaoTao { get; set; }

        public SinhVienTaiChuc() : base()
        {
        }

        public SinhVienTaiChuc(string maSV, string hoTen, DateTime ngaySinh, int namVaoHoc, double diemDauVao, string noiLienKetDaoTao)
            : base(maSV, hoTen, ngaySinh, namVaoHoc, diemDauVao)
        {
            NoiLienKetDaoTao = noiLienKetDaoTao;
        }

        public SinhVienTaiChuc(SinhVien sinhVien) : base(sinhVien)
        {
        }

        public void InputSinhVienTaiChuc()
        {
            Console.WriteLine("Nhap thong tin Sinh Vien Tai Chuc:");

            try
            {
                Console.Write("Ma SV: ");
                MaSV = Console.ReadLine();
                if (string.IsNullOrEmpty(MaSV))
                {
                    throw new ArgumentException("Ma SV khong duoc bo trong");
                }

                Console.Write("Ho Ten: ");
                HoTen = Console.ReadLine();
                if (string.IsNullOrEmpty(HoTen))
                {
                    throw new ArgumentException("Ho Ten khong duoc bo trong");
                }

                Console.Write("Ngay Sinh (yyyy/MM/dd): ");
                NgaySinh = DateTime.ParseExact(Console.ReadLine(), "yyyy/MM/dd", null);

                Console.Write("Nam Vao Hoc: ");
                NamVaoHoc = int.Parse(Console.ReadLine());

                Console.Write("Diem Dau Vao: ");
                DiemDauVao = double.Parse(Console.ReadLine());

                Console.Write("Noi Lien Ket Dao Tao: ");
                NoiLienKetDaoTao = Console.ReadLine();

                Console.WriteLine("Nhap thong tin thanh cong.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Loi: {ex.Message}");
            }
        }

        public bool LaSinhVienChinhQuy()
        {
            return false;
        }
    }

    class KetQuaHocTap
    {
        public string TenHocKy { get; set; }
        public double DiemTB { get; set; }

        public KetQuaHocTap(string tenHocKy, double diemTB)
        {
            TenHocKy = tenHocKy;
            DiemTB = diemTB;
        }
    }

    class Khoa
    {
        public string TenKhoa { get; set; }
        public List<SinhVien> DanhSachSinhVien { get; set; }

        public Khoa(string tenKhoa)
        {
            TenKhoa = tenKhoa;
            DanhSachSinhVien = new List<SinhVien>();
        }

        public int TongSinhVienChinhQuy()
        {
            int soLuongSinhVienChinhQuy = 0;

            foreach (var sinhVien in DanhSachSinhVien)
            {
                if (sinhVien is SinhVienChinhQuy)
                {
                    soLuongSinhVienChinhQuy++;
                }
            }

            return soLuongSinhVienChinhQuy;
        }

        public SinhVien TimSinhVienDiemCaoNhat()
        {
            Dictionary<string, double> diemCaoNhatTheoKhoa = new Dictionary<string, double>();

            foreach (var sinhVien in DanhSachSinhVien)
            {
                if (!diemCaoNhatTheoKhoa.ContainsKey(sinhVien.MaSV))
                {
                    diemCaoNhatTheoKhoa[sinhVien.MaSV] = sinhVien.DiemDauVao;
                }
                else
                {
                    if (sinhVien.DiemDauVao > diemCaoNhatTheoKhoa[sinhVien.MaSV])
                    {
                        diemCaoNhatTheoKhoa[sinhVien.MaSV] = sinhVien.DiemDauVao;
                    }
                }
            }

            List<SinhVien> sinhVienDiemCaoNhatTheoKhoa = new List<SinhVien>();
            foreach (var sinhVien in DanhSachSinhVien)
            {
                if (sinhVien.DiemDauVao == diemCaoNhatTheoKhoa[sinhVien.MaSV])
                {
                    sinhVienDiemCaoNhatTheoKhoa.Add(sinhVien);
                }
            }

            return sinhVienDiemCaoNhatTheoKhoa.Count > 0 ? sinhVienDiemCaoNhatTheoKhoa[0] : null;
        }

        public Dictionary<string, List<SinhVienTaiChuc>> LayDanhSachSinhVienTaiChucTheoNoiDaoTao()
        {
            Dictionary<string, List<SinhVienTaiChuc>> danhSachSinhVienTaiChucTheoNoiDaoTao = new Dictionary<string, List<SinhVienTaiChuc>>();

            foreach (var sinhVien in DanhSachSinhVien)
            {
                if (sinhVien is SinhVienTaiChuc svTaiChuc)
                {
                    if (!danhSachSinhVienTaiChucTheoNoiDaoTao.ContainsKey(svTaiChuc.NoiLienKetDaoTao))
                    {
                        danhSachSinhVienTaiChucTheoNoiDaoTao[svTaiChuc.NoiLienKetDaoTao] = new List<SinhVienTaiChuc>();
                    }

                    danhSachSinhVienTaiChucTheoNoiDaoTao[svTaiChuc.NoiLienKetDaoTao].Add(svTaiChuc);
                }
            }

            return danhSachSinhVienTaiChucTheoNoiDaoTao;
        }

        public List<SinhVien> LayDanhSachSinhVienDiemCaoHocKyGanNhat(double diemToiThieu)
        {
            List<SinhVien> danhSachSinhVienDiemCao = new List<SinhVien>();

            foreach (var sinhVien in DanhSachSinhVien)
            {
                double diemTrungBinhHocKyGanNhat = sinhVien.LayDiemTrungBinhHocKyGanNhat();

                if (diemTrungBinhHocKyGanNhat >= diemToiThieu)
                {
                    danhSachSinhVienDiemCao.Add(sinhVien);
                }
            }

            return danhSachSinhVienDiemCao;
        }

        public SinhVien TimSinhVienDiemCaoNhatTheoHocKy()
        {
            SinhVien sinhVienDiemCaoNhat = null;
            double diemCaoNhat = 0;

            foreach (var sinhVien in DanhSachSinhVien)
            {
                foreach (var ketQua in sinhVien.DanhSachKetQua)
                {
                    if (ketQua.DiemTB > diemCaoNhat)
                    {
                        diemCaoNhat = ketQua.DiemTB;
                        sinhVienDiemCaoNhat = sinhVien;
                    }
                }
            }

            return sinhVienDiemCaoNhat;
        }

        public void SapXepDanhSachSinhVien()
        {
            // Sắp xếp danh sách sinh viên
            DanhSachSinhVien.Sort();
        }

        public void ThongKeSinhVienTheoNam()
        {
            Dictionary<int, int> thongKeNamVaoHoc = new Dictionary<int, int>();

            foreach (var sinhVien in DanhSachSinhVien)
            {
                int namVaoHoc = sinhVien.NamVaoHoc;

                if (thongKeNamVaoHoc.ContainsKey(namVaoHoc))
                {
                    thongKeNamVaoHoc[namVaoHoc]++;
                }
                else
                {
                    thongKeNamVaoHoc[namVaoHoc] = 1;
                }
            }

            Console.WriteLine($"Thống kê số lượng sinh viên theo năm vào học:");
            foreach (var entry in thongKeNamVaoHoc)
            {
                Console.WriteLine($"{entry.Key}: {entry.Value}");
            }
        }
    }
    public static class Bai15
    {
        public static void Main()
        {
            // Tạo một đối tượng Khoa
            Khoa khoa = new Khoa("Khoa ABC");

            // Tạo và thêm sinh viên chính quy
            SinhVienChinhQuy svChinhQuy1 = new SinhVienChinhQuy("SV001", "Nguyen Van A", new DateTime(2000, 1, 1), 2020, 8.5);
            svChinhQuy1.DanhSachKetQua.Add(new KetQuaHocTap("Hoc Ky 1", 8.0));
            svChinhQuy1.DanhSachKetQua.Add(new KetQuaHocTap("Hoc Ky 2", 9.0));
            khoa.DanhSachSinhVien.Add(svChinhQuy1);

            // Tạo và thêm sinh viên tài chức
            SinhVienTaiChuc svTaiChuc1 = new SinhVienTaiChuc("SV002", "Tran Thi B", new DateTime(1999, 5, 5), 2019, 7.5, "Cong ty XYZ");
            svTaiChuc1.DanhSachKetQua.Add(new KetQuaHocTap("Hoc Ky 1", 7.0));
            svTaiChuc1.DanhSachKetQua.Add(new KetQuaHocTap("Hoc Ky 2", 8.0));
            khoa.DanhSachSinhVien.Add(svTaiChuc1);


            // Hiển thị thông tin các sinh viên
            Console.WriteLine("Danh sach sinh vien trong khoa:");
            foreach (var sinhVien in khoa.DanhSachSinhVien)
            {
                Console.WriteLine($"{sinhVien.MaSV} - {sinhVien.HoTen} - {sinhVien.NamVaoHoc}");
            }

            // Tính tổng số sinh viên chính quy
            int tongSVChinhQuy = khoa.TongSinhVienChinhQuy();
            Console.WriteLine($"Tong so sinh vien chinh quy: {tongSVChinhQuy}");

            // Tìm sinh viên có điểm cao nhất
            SinhVien svDiemCaoNhat = khoa.TimSinhVienDiemCaoNhat();
            Console.WriteLine($"Sinh vien co diem cao nhat: {svDiemCaoNhat?.HoTen} - Diem: {svDiemCaoNhat?.DiemDauVao}");

            // Lấy danh sách sinh viên tài chức theo nơi đào tạo
            Dictionary<string, List<SinhVienTaiChuc>> danhSachSVTaiChucTheoNoiDaoTao = khoa.LayDanhSachSinhVienTaiChucTheoNoiDaoTao();
            Console.WriteLine("Danh sach sinh vien tai chuc theo noi dao tao:");
            foreach (var kvp in danhSachSVTaiChucTheoNoiDaoTao)
            {
                Console.WriteLine($"{kvp.Key}: {kvp.Value.Count} sinh vien");
            }

            // Lấy danh sách sinh viên có điểm cao hơn một ngưỡng nào đó
            double diemToiThieu = 8.0;
            List<SinhVien> danhSachSVDiemCao = khoa.LayDanhSachSinhVienDiemCaoHocKyGanNhat(diemToiThieu);
            Console.WriteLine($"Danh sach sinh vien co diem cao hon {diemToiThieu}:");
            foreach (var sinhVien in danhSachSVDiemCao)
            {
                Console.WriteLine($"{sinhVien.MaSV} - {sinhVien.HoTen} - Diem: {sinhVien.LayDiemTrungBinhHocKyGanNhat()}");
            }

            // Tìm sinh viên có điểm cao nhất theo học kỳ
            SinhVien svDiemCaoNhatTheoHocKy = khoa.TimSinhVienDiemCaoNhatTheoHocKy();
            Console.WriteLine($"Sinh vien co diem cao nhat theo hoc ky: {svDiemCaoNhatTheoHocKy?.HoTen} - Diem: {svDiemCaoNhatTheoHocKy?.LayDiemTrungBinhHocKyGanNhat()}");

            // Sắp xếp danh sách sinh viên
            khoa.SapXepDanhSachSinhVien();
            Console.WriteLine("Danh sach sinh vien sau khi sap xep:");
            foreach (var sinhVien in khoa.DanhSachSinhVien)
            {
                Console.WriteLine($"{sinhVien.MaSV} - {sinhVien.HoTen} - {sinhVien.NamVaoHoc}");
            }

            // Thống kê số lượng sinh viên theo năm vào học
            khoa.ThongKeSinhVienTheoNam();
        }
    }
}