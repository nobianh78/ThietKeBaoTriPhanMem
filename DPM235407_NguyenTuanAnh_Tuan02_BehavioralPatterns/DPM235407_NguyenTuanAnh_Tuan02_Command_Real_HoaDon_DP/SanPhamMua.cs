namespace DPM235407_NguyenTuanAnh_Tuan02_Command_Real_HoaDon_DP
{
    // Lớp thông tin mặt hàng thuốc bảo vệ thực vật
    public class SanPhamMua
    {
        public string MaThuoc { get; set; }
        public string TenThuoc { get; set; }
        public int SoLuong { get; set; }
        public decimal DonGia { get; set; }

        public decimal ThanhTien => SoLuong * DonGia;

        public SanPhamMua(string maThuoc, string tenThuoc, int soLuong, decimal donGia)
        {
            MaThuoc = maThuoc;
            TenThuoc = tenThuoc;
            SoLuong = soLuong;
            DonGia = donGia;
        }
    }
}
