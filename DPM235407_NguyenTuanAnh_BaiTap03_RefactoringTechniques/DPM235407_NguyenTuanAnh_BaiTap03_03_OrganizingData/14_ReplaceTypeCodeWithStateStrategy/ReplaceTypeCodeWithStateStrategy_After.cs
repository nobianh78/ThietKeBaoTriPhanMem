namespace DPM235407_NguyenTuanAnh_BaiTap03_03_OrganizingData._14_ReplaceTypeCodeWithStateStrategy
{
    // AFTER: Áp dụng State Pattern
    public interface ITrangThaiDonHang { string LayTrangThai(); }
    public class TrangThaiMoiTao : ITrangThaiDonHang { public string LayTrangThai() => "Mới tạo"; }
    public class TrangThaiDaGiao : ITrangThaiDonHang { public string LayTrangThai() => "Đã giao hàng"; }
    public class DonHang_After
    {
        public ITrangThaiDonHang TrangThai { get; set; } = new TrangThaiMoiTao();
    }
}
