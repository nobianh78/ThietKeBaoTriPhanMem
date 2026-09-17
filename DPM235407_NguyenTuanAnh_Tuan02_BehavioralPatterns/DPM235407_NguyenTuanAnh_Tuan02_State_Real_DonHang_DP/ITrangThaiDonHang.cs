namespace DPM235407_NguyenTuanAnh_Tuan02_State_Real_DonHang_DP
{
    public interface ITrangThaiDonHang
    {
        string TenTrangThai { get; }
        void ThemSanPham(DonHangNongDuoc donHang, string tenThuoc, int soLuong, decimal donGia);
        void ThietLapChiPhi(DonHangNongDuoc donHang, decimal phiShip, decimal giamGia);
        void XacNhanDonHang(DonHangNongDuoc donHang);
        void XuatKhoGiaoHang(DonHangNongDuoc donHang);
        void HoanTatThanhToan(DonHangNongDuoc donHang);
        void HuyDonHang(DonHangNongDuoc donHang, string lyDo);
    }
}
