namespace DPM235407_NguyenTuanAnh_Tuan02_Memento_Real_HoaDon_DP
{
    // Chi tiết sản phẩm thuốc bảo vệ thực vật trong hóa đơn
    public class ChiTietThuoc
    {
        public string TenThuoc { get; set; }
        public int SoLuong { get; set; }
        public decimal DonGia { get; set; }

        public decimal ThanhTien => SoLuong * DonGia;

        public ChiTietThuoc(string tenThuoc, int soLuong, decimal donGia)
        {
            TenThuoc = tenThuoc;
            SoLuong = soLuong;
            DonGia = donGia;
        }

        public ChiTietThuoc Clone() => new(TenThuoc, SoLuong, DonGia);
    }
}
