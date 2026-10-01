namespace DPM235407_NguyenTuanAnh_BaiTap03_02_MovingFeatures._02_MoveField
{
    // BEFORE: Trường TiLeLaiSuat đặt ở TaiKhoan thay vì LoaiTaiKhoan
    public class TaiKhoan_Before
    {
        public double TiLeLaiSuat { get; set; } = 0.05;
        public LoaiTaiKhoan_Before Loai { get; set; } = new();
    }
    public class LoaiTaiKhoan_Before { }
}
