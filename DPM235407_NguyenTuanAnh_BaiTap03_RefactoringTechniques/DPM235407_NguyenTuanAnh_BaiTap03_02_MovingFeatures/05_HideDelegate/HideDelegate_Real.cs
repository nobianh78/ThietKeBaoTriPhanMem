namespace DPM235407_NguyenTuanAnh_BaiTap03_02_MovingFeatures._05_HideDelegate
{
    // REAL: Đóng gói truy xuất thông tin Lô thuốc bảo vệ thực vật
    public class ThuocGoc { public string Ten { get; set; } = "Tilt Super"; public decimal GiaLe { get; set; } = 240000; }
    public class LoHangNongDuoc_Real
    {
        private ThuocGoc _thuoc = new();
        public string TenThuoc => _thuoc.Ten;
        public decimal DonGia => _thuoc.GiaLe;
    }
}
