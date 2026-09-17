namespace DPM235407_NguyenTuanAnh_BaiTap01_Decorator_Real_HoaDon_DP
{
    // [Base Decorator]: Lớp trừu tượng bọc IHoaDon
    public abstract class HoaDonDecorator : IHoaDon
    {
        protected readonly IHoaDon _hoaDonGoc;

        public HoaDonDecorator(IHoaDon hoaDon)
        {
            _hoaDonGoc = hoaDon;
        }

        public virtual string MaHoaDon => _hoaDonGoc.MaHoaDon;
        public virtual string TenKhachHang => _hoaDonGoc.TenKhachHang;

        public virtual decimal TinhTongTien()
        {
            return _hoaDonGoc.TinhTongTien();
        }

        public virtual string InChiTietHoaDon()
        {
            return _hoaDonGoc.InChiTietHoaDon();
        }
    }
}
