namespace DPM235407_NguyenTuanAnh_BaiTap03_01_ComposingMethods._05_ReplaceTempWithQuery
{
    // REAL: Tính toán hóa đơn bán sỉ nông dược frmBanSi.cs
    public class HoaDonBanSiNongDuoc_Real
    {
        public int SoLuongChai { get; set; } = 200;
        public decimal DonGia { get; set; } = 185000;
        public decimal TienGoc => SoLuongChai * DonGia;
        public decimal ChietKhau => (TienGoc >= 30000000) ? (TienGoc * 0.10m) : (TienGoc * 0.05m);
        public decimal ThueVAT => (TienGoc - ChietKhau) * 0.05m;
        public decimal TongThanhToan => TienGoc - ChietKhau + ThueVAT;
    }
}
