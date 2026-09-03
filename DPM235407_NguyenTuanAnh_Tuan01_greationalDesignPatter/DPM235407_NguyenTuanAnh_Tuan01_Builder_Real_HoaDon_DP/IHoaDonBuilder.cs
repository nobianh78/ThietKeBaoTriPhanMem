using System;

namespace DPM235407_NguyenTuanAnh_Tuan01_Builder_Real_HoaDon_DP
{
    // Builder Interface
    public interface IHoaDonBuilder
    {
        void TaoChiTietSanPham();
        void ThemDichVuPhu();
        void ThemChiPhiVanChuyen();
        void ThemGiamGiaKhuyenMai();
        HoaDonBanHang GetHoaDon();
    }
}
