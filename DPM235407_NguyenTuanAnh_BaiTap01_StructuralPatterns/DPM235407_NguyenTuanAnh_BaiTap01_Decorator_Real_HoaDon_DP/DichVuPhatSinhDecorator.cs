namespace DPM235407_NguyenTuanAnh_BaiTap01_Decorator_Real_HoaDon_DP
{
    // [Concrete Decorator 2]: Dịch vụ phụ phát sinh (bốc vác, thử nghiệm, xịt thuốc mẫu) theo PDF
    public class DichVuPhatSinhDecorator : HoaDonDecorator
    {
        private readonly string _tenDichVu;
        private readonly decimal _phiDichVu;

        public DichVuPhatSinhDecorator(IHoaDon hoaDon, string tenDichVu, decimal phiDichVu)
            : base(hoaDon)
        {
            _tenDichVu = tenDichVu;
            _phiDichVu = phiDichVu;
        }

        public override decimal TinhTongTien()
        {
            return base.TinhTongTien() + _phiDichVu;
        }

        public override string InChiTietHoaDon()
        {
            return base.InChiTietHoaDon() + 
                   $"  [+] Dịch vụ phát sinh ({_tenDichVu}): +{_phiDichVu:N0} VNĐ\n";
        }
    }
}
