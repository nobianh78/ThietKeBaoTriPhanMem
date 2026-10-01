using System;

namespace DPM235407_NguyenTuanAnh_BaiTap03_03_OrganizingData._03_Replace_Magic_Numbers_Constants
{
    // =========================================================================
    // AFTER: Áp dụng kỹ thuật Replace Magic Number with Symbolic Constant
    // Định nghĩa các hằng số tường minh (`const` / `static readonly`),
    // có ý nghĩa ngữ cảnh cụ thể và quản lý tập trung.
    // =========================================================================
    public class KiemTraKhoVaGia_After
    {
        public const int NguongTonKhoToiThieuAnToan = 15;
        public const int NguongNgayCanhBaoCanDate = 30;

        public const double TiLeChietKhauDaiLyCap1 = 0.12;
        public const double TiLeChietKhauDaiLyCap2 = 0.07;
        public const double ThueSuatVATNongNghiep = 0.05;

        public void KiemTraTonKho(int tonKho, int soNgayConLai)
        {
            if (tonKho <= NguongTonKhoToiThieuAnToan)
            {
                Console.WriteLine($"[AFTER] CẢNH BÁO: Tồn kho chạm ngưỡng tối thiểu (<= {NguongTonKhoToiThieuAnToan})!");
            }

            if (soNgayConLai <= NguongNgayCanhBaoCanDate)
            {
                Console.WriteLine($"[AFTER] CẢNH BÁO: Thuốc cận date (<= {NguongNgayCanhBaoCanDate} ngày)!");
            }
        }

        public double TinhTienHoaDon(double tienHang, int capDaiLy)
        {
            double tiLeChietKhau = capDaiLy switch
            {
                1 => TiLeChietKhauDaiLyCap1,
                2 => TiLeChietKhauDaiLyCap2,
                _ => 0.0
            };

            double tienChietKhau = tienHang * tiLeChietKhau;
            double tienSauChietKhau = tienHang - tienChietKhau;
            double tienThueVAT = tienSauChietKhau * ThueSuatVATNongNghiep;

            return tienSauChietKhau + tienThueVAT;
        }
    }
}
