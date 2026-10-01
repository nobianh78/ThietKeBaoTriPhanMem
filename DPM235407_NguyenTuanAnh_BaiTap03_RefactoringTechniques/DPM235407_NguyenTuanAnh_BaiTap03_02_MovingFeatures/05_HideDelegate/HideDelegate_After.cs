namespace DPM235407_NguyenTuanAnh_BaiTap03_02_MovingFeatures._05_HideDelegate
{
    // AFTER: Hide Delegate
    public class TruongPhong_After { public string Ten { get; set; } = "Kỹ sư Hùng"; }
    public class PhongBan_After { private TruongPhong_After Truong { get; set; } = new(); public string LayTenTruong() => Truong.Ten; }
    public class NhanVien_After
    {
        private PhongBan_After Phong { get; set; } = new();
        public string LayTenTruongPhong() => Phong.LayTenTruong();
    }
}
