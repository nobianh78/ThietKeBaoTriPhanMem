using System;

namespace DPM235407_NguyenTuanAnh_Tuan02_TemplateMethod_Real_BanHang_DP
{
    public class DonHangNongDuoc
    {
        public string MaDon { get; set; }
        public string TenKhachHang { get; set; }
        public string TenThuoc { get; set; }
        public int SoLuong { get; set; }
        public decimal DonGiaGoc { get; set; }
        public double KhoangCachKm { get; set; }
        public string MaVoucher { get; set; } = string.Empty;

        // Các trường được tính toán trong quy trình
        public decimal TienHangGoc => SoLuong * DonGiaGoc;
        public decimal ChietKhau { get; set; } = 0;
        public decimal PhiVanChuyen { get; set; } = 0;
        public decimal PhiDichVu { get; set; } = 0;
        public string TenDichVu { get; set; } = string.Empty;
        public string MaLoXuat { get; set; } = string.Empty;
        public DateTime NgayHetHan { get; set; }

        public decimal TongThanhToan => TienHangGoc - ChietKhau + PhiVanChuyen + PhiDichVu;

        public DonHangNongDuoc(string maDon, string tenKhach, string tenThuoc, int soLuong, decimal donGia, double km, string voucher = "")
        {
            MaDon = maDon;
            TenKhachHang = tenKhach;
            TenThuoc = tenThuoc;
            SoLuong = soLuong;
            DonGiaGoc = donGia;
            KhoangCachKm = km;
            MaVoucher = voucher;
        }
    }
}
