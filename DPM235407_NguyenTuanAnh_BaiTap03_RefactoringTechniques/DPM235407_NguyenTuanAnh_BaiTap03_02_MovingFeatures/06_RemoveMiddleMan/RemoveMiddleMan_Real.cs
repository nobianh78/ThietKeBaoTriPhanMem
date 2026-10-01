namespace DPM235407_NguyenTuanAnh_BaiTap03_02_MovingFeatures._06_RemoveMiddleMan
{
    // REAL: Truy cập trực tiếp ChiTietKho từ PhieuBanLe
    public class KhoHangReal { public string ViTriDay { get; set; } = "Kệ A-03"; }
    public class PhieuBanLe_Real
    {
        public KhoHangReal Kho { get; set; } = new();
    }
}
