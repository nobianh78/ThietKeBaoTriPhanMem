namespace DPM235407_NguyenTuanAnh_BaiTap03_02_MovingFeatures._06_RemoveMiddleMan
{
    // BEFORE: Lớp NhanVien làm quá nhiều việc ủy nhiệm rỗng
    public class PhongBan_Before { public string TenPhong { get; set; } = "Kinh Doanh"; public string TruongPhong { get; set; } = "Hùng"; }
    public class NhanVien_Before
    {
        private PhongBan_Before _phong = new();
        public string LayTenPhong() => _phong.TenPhong;
        public string LayTruongPhong() => _phong.TruongPhong;
    }
}
