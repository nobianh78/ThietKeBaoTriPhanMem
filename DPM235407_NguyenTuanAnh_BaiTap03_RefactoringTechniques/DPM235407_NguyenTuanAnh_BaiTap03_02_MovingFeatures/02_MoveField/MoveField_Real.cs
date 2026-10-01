namespace DPM235407_NguyenTuanAnh_BaiTap03_02_MovingFeatures._02_MoveField
{
    // REAL: Chuyển trường QuyCachDongGoi từ DonHang vào DanhMucThuocBVTV
    public class DanhMucThuocBVTV_Real
    {
        public string TenThuoc { get; set; } = "Tilt Super 300EC";
        public string QuyCach { get; set; } = "Chai 250ml (40 chai/thùng)";
    }
    public class ChiTietDonHang_Real
    {
        public DanhMucThuocBVTV_Real Thuoc { get; set; } = new();
        public int SoLuong { get; set; } = 10;
    }
}
