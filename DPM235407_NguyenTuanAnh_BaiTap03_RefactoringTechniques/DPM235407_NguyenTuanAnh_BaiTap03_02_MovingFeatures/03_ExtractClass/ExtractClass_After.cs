namespace DPM235407_NguyenTuanAnh_BaiTap03_02_MovingFeatures._03_ExtractClass
{
    // AFTER: Tách lớp DiaChi
    public class DiaChi { public string SoNha { get; set; } = ""; public string PhuongXa { get; set; } = ""; }
    public class DaiLy_After
    {
        public string Ten { get; set; } = "";
        public string SoDienThoai { get; set; } = "";
        public DiaChi DiaChiTruSo { get; set; } = new();
    }
}
