namespace DPM235407_NguyenTuanAnh_BaiTap01_Facade_Real_BanHang_DP
{
    // [Subsystem 3]: Phân hệ tính toán tài chính hóa đơn theo yêu cầu PDF
    public class PhanHeTinhTien
    {
        public decimal TinhTien(decimal tienHang, decimal phiVanChuyen, decimal phiDichVuPhu, decimal giamGiaKhuyenMai)
        {
            decimal tong = tienHang + phiVanChuyen + phiDichVuPhu - giamGiaKhuyenMai;
            return tong > 0 ? tong : 0;
        }
    }
}
