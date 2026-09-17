namespace DPM235407_NguyenTuanAnh_BaiTap01_Decorator_Real_HoaDon_DP
{
    // [Concrete Decorator 3]: Chiết khấu và giảm giá khuyến mãi trên hóa đơn theo yêu cầu PDF
    public class GiamGiaKhuyenMaiDecorator : HoaDonDecorator
    {
        private readonly string _chuongTrinhKhuyenMai;
        private readonly decimal _soTienGiam;

        public GiamGiaKhuyenMaiDecorator(IHoaDon hoaDon, string chuongTrinh, decimal soTienGiam)
            : base(hoaDon)
        {
            _chuongTrinhKhuyenMai = chuongTrinh;
            _soTienGiam = soTienGiam;
        }

        public override decimal TinhTongTien()
        {
            decimal tong = base.TinhTongTien() - _soTienGiam;
            return tong > 0 ? tong : 0;
        }

        public override string InChiTietHoaDon()
        {
            return base.InChiTietHoaDon() + 
                   $"  [-] Giảm giá chiết khấu ({_chuongTrinhKhuyenMai}): -{_soTienGiam:N0} VNĐ\n";
        }
    }
}
