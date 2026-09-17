namespace DPM235407_NguyenTuanAnh_BaiTap01_Decorator_Real_HoaDon_DP
{
    // [Concrete Decorator 1]: Tính chi phí vận chuyển theo yêu cầu PDF
    public class PhiVanChuyenDecorator : HoaDonDecorator
    {
        private readonly decimal _phiVanChuyen;
        private readonly string _phuongThucGiao;

        public PhiVanChuyenDecorator(IHoaDon hoaDon, decimal phiVanChuyen, string phuongThucGiao = "Giao hàng tận ruộng")
            : base(hoaDon)
        {
            _phiVanChuyen = phiVanChuyen;
            _phuongThucGiao = phuongThucGiao;
        }

        public override decimal TinhTongTien()
        {
            return base.TinhTongTien() + _phiVanChuyen;
        }

        public override string InChiTietHoaDon()
        {
            return base.InChiTietHoaDon() + 
                   $"  [+] Chi phí vận chuyển ({_phuongThucGiao}): +{_phiVanChuyen:N0} VNĐ\n";
        }
    }
}
