namespace DPM235407_NguyenTuanAnh_BaiTap03_03_OrganizingData._08_ChangeBidirectionalToUnidirectional
{
    // AFTER: Đơn giản hóa thành quan hệ 1 chiều (Sản phẩm tham chiếu NCC)
    public class NhaCungCap_After { public string TenNCC { get; set; } = "Lộc Trời"; }
    public class SanPham_After { public NhaCungCap_After? NCC { get; set; } }
}
