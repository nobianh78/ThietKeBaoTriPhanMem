namespace DPM235407_NguyenTuanAnh_BaiTap01_Adapter_Real_VanChuyen_DP
{
    // Giao diện chuẩn (Target) hệ thống Quản lý Bán hàng Nông Dược An Giang yêu cầu
    public interface IDichVuVanChuyen
    {
        string LayTenDoiTac();
        decimal TinhPhiVanChuyen(DonHangNongDuoc donHang);
    }
}
