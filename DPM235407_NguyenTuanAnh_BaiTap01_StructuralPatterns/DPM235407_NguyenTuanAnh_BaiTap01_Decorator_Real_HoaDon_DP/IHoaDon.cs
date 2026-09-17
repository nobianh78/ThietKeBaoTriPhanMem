namespace DPM235407_NguyenTuanAnh_BaiTap01_Decorator_Real_HoaDon_DP
{
    // [Component Interface]
    // Giao diện chung của Hóa đơn bán hàng Công ty Nông Dược An Giang
    public interface IHoaDon
    {
        string MaHoaDon { get; }
        string TenKhachHang { get; }
        decimal TinhTongTien();
        string InChiTietHoaDon();
    }
}
