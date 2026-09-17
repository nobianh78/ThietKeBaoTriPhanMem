using System;

namespace DPM235407_NguyenTuanAnh_Tuan02_Visitor_Real_ThongKe_DP
{
    // Element 1: Hóa đơn bán hàng
    public class HoaDonBanHangElement : IDoiTuongDuLieuElement
    {
        public string MaHoaDon { get; set; }
        public string NhanVienLap { get; set; }
        public DateTime NgayLap { get; set; }
        public decimal TongTienHang { get; set; }
        public decimal GiamGiaKhuyenMai { get; set; }
        public decimal ChiPhiVanChuyen { get; set; }
        public decimal ChiPhiDichVu { get; set; }

        public decimal TongThucThu => TongTienHang - GiamGiaKhuyenMai + ChiPhiVanChuyen + ChiPhiDichVu;

        public HoaDonBanHangElement(string ma, string nv, DateTime ngay, decimal tienHang, decimal giamGia, decimal ship, decimal dv)
        {
            MaHoaDon = ma;
            NhanVienLap = nv;
            NgayLap = ngay;
            TongTienHang = tienHang;
            GiamGiaKhuyenMai = giamGia;
            ChiPhiVanChuyen = ship;
            ChiPhiDichVu = dv;
        }

        public void Accept(IBaoCaoVisitor visitor) => visitor.VisitHoaDon(this);
    }
}
