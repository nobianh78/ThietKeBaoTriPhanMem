namespace DPM235407_NguyenTuanAnh_BaiTap03_02_MovingFeatures._04_InlineClass
{
    // BEFORE: Lớp quá nhỏ, không còn giá trị tồn tại độc lập
    public class MaVungDienThoai { public string MaVung { get; set; } = "0296"; }
    public class NhanVien_Before
    {
        public string Ten { get; set; } = "";
        public MaVungDienThoai Vung { get; set; } = new();
    }
}
