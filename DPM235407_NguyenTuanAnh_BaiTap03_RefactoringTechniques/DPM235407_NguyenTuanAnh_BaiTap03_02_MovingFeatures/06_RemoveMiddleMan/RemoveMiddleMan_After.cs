namespace DPM235407_NguyenTuanAnh_BaiTap03_02_MovingFeatures._06_RemoveMiddleMan
{
    // AFTER: Remove Middle Man cho phép truy cập trực tiếp PhongBan
    public class PhongBan_After { public string TenPhong { get; set; } = "Kinh Doanh"; public string TruongPhong { get; set; } = "Hùng"; }
    public class NhanVien_After
    {
        public PhongBan_After Phong { get; set; } = new();
    }
}
