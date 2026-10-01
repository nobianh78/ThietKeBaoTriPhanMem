namespace DPM235407_NguyenTuanAnh_BaiTap03_03_OrganizingData._08_ChangeBidirectionalToUnidirectional
{
    // REAL: Gỡ bỏ tham chiếu ngược từ Đơn Vị Tính về Sản Phẩm (DonViTinh.cs)
    public class DonViTinh_Real { public string TenDVT { get; set; } = "Chai"; }
    public class SanPhamNongDuoc_Real
    {
        public string TenThuoc { get; set; } = "Tilt Super";
        public DonViTinh_Real DVT { get; set; } = new();
    }
}
