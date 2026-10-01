namespace DPM235407_NguyenTuanAnh_BaiTap03_02_MovingFeatures._03_ExtractClass
{
    // REAL: Tách thông tin GiaoHangTanRuong cho Khách hàng nông dược
    public class DiaDiemGiaoHangRuong_Real
    {
        public string TenCanhDong { get; set; } = "Cánh đồng mẫu lớn Tri Tôn";
        public string ToaDoGPS { get; set; } = "10.4289, 105.0124";
    }
    public class KhachHangNongDan_Real
    {
        public string HoTen { get; set; } = "Nông dân Nguyễn Văn Lúa";
        public DiaDiemGiaoHangRuong_Real DiaDiemGiao { get; set; } = new();
    }
}
