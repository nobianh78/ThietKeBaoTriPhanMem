using System;

namespace DPM235407_NguyenTuanAnh_Tuan01_Builder_Real_HoaDon_DP
{
    // Concrete Builder: Xây dựng hóa đơn đầy đủ (có vận chuyển, có giảm giá)
    public class HoaDonDayDuBuilder : IHoaDonBuilder
    {
        private HoaDonBanHang _hoaDon = new HoaDonBanHang();

        public HoaDonDayDuBuilder() { this.Reset(); }
        public void Reset() { this._hoaDon = new HoaDonBanHang(); }

        public void TaoChiTietSanPham() { this._hoaDon.Add("Sản phẩm: Thuốc trừ sâu ABC (SL: 10)"); }
        public void ThemDichVuPhu() { this._hoaDon.Add("Dịch vụ phụ: Phun thuốc hộ"); }
        public void ThemChiPhiVanChuyen() { this._hoaDon.Add("Phí vận chuyển: 50.000 VNĐ"); }
        public void ThemGiamGiaKhuyenMai() { this._hoaDon.Add("Giảm giá: 10% (Chương trình Mùa Vụ)"); }

        public HoaDonBanHang GetHoaDon()
        {
            HoaDonBanHang result = this._hoaDon;
            this.Reset();
            return result;
        }
    }
}
