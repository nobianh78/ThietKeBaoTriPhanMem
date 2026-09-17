namespace DPM235407_NguyenTuanAnh_BaiTap01_Adapter_Real_VanChuyen_DP
{
    // Lớp chứa thông tin đơn hàng nông dược cần giao
    public class DonHangNongDuoc
    {
        public string MaDonHang { get; set; } = string.Empty;
        public string TenKhachHang { get; set; } = string.Empty;
        public string DiaChiNhanHang { get; set; } = string.Empty; // Ví dụ: "Châu Thành, An Giang"
        public double TrongLuongKg { get; set; } // Khối lượng thuốc/phân bón
        public decimal GiaTriDonHang { get; set; }

        public DonHangNongDuoc(string maDon, string khachHang, string diaChi, double trongLuong, decimal giaTri)
        {
            MaDonHang = maDon;
            TenKhachHang = khachHang;
            DiaChiNhanHang = diaChi;
            TrongLuongKg = trongLuong;
            GiaTriDonHang = giaTri;
        }
    }
}
