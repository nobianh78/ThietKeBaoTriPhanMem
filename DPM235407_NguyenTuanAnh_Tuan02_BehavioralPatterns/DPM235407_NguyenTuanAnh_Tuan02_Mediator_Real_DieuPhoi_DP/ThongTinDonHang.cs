using System;

namespace DPM235407_NguyenTuanAnh_Tuan02_Mediator_Real_DieuPhoi_DP
{
    // Dữ liệu đơn hàng giao dịch
    public class ThongTinDonHang
    {
        public string MaDon { get; set; }
        public string TenKhachHang { get; set; }
        public string TenThuoc { get; set; }
        public int SoLuong { get; set; }
        public decimal DonGia { get; set; }
        public string DiaChiNhan { get; set; }
        public decimal PhiVanChuyen { get; set; }
        public decimal ChietKhau { get; set; }
        public string MaLoXuat { get; set; } = string.Empty;

        public decimal TongTienHang => SoLuong * DonGia;
        public decimal TongThanhToan => TongTienHang + PhiVanChuyen - ChietKhau;

        public ThongTinDonHang(string maDon, string tenKhach, string tenThuoc, int soLuong, decimal donGia, string diaChi)
        {
            MaDon = maDon;
            TenKhachHang = tenKhach;
            TenThuoc = tenThuoc;
            SoLuong = soLuong;
            DonGia = donGia;
            DiaChiNhan = diaChi;
        }
    }
}
