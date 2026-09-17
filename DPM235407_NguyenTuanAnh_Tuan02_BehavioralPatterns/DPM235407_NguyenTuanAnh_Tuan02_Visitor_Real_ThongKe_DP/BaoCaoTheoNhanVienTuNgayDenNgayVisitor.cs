using System;
using System.Collections.Generic;

namespace DPM235407_NguyenTuanAnh_Tuan02_Visitor_Real_ThongKe_DP
{
    // Visitor 1: Thống kê hóa đơn bán giảm giá và khuyến mãi theo từng nhân viên đăng nhập, từ ngày đến ngày (Mục 4 PDF)
    public class BaoCaoTheoNhanVienTuNgayDenNgayVisitor : IBaoCaoVisitor
    {
        public DateTime TuNgay { get; set; }
        public DateTime DenNgay { get; set; }
        public string NhanVienCanXem { get; set; }

        private readonly List<HoaDonBanHangElement> _danhSachHoaDonHopLe = new();

        public BaoCaoTheoNhanVienTuNgayDenNgayVisitor(DateTime tuNgay, DateTime denNgay, string nhanVien)
        {
            TuNgay = tuNgay;
            DenNgay = denNgay;
            NhanVienCanXem = nhanVien;
        }

        public void VisitHoaDon(HoaDonBanHangElement hoaDon)
        {
            // Lọc hóa đơn theo nhân viên và khoảng ngày
            if (hoaDon.NhanVienLap.Equals(NhanVienCanXem, StringComparison.OrdinalIgnoreCase) &&
                hoaDon.NgayLap.Date >= TuNgay.Date && hoaDon.NgayLap.Date <= DenNgay.Date)
            {
                _danhSachHoaDonHopLe.Add(hoaDon);
            }
        }

        public void VisitLoHangTonKho(LoHangTonKhoElement loHang) { /* Báo cáo nhân viên không tính tồn kho */ }
        public void VisitDichVuPhatSinh(DichVuPhatSinhElement dichVu) { /* Báo cáo nhân viên chỉ tính hóa đơn bán */ }

        public void InKetQuaBaoCao()
        {
            Console.WriteLine("\n================================================================================");
            Console.WriteLine($" BÁO CÁO DOANH SỐ & KHUYẾN MÃI THEO NHÂN VIÊN ĐĂNG NHẬP: {NhanVienCanXem.ToUpper()}");
            Console.WriteLine($" Khoảng thời gian tra cứu: Từ {TuNgay:dd/MM/yyyy} Đến {DenNgay:dd/MM/yyyy}");
            Console.WriteLine("================================================================================");
            Console.WriteLine(string.Format("{0,-12} {1,-12} {2,16} {3,16} {4,16}", "Mã HĐ", "Ngày Lập", "Tiền Hàng", "Giảm Giá KM", "Thực Thu"));
            Console.WriteLine("--------------------------------------------------------------------------------");

            decimal tongTien = 0;
            decimal tongGiam = 0;
            decimal tongThucThu = 0;

            foreach (var hd in _danhSachHoaDonHopLe)
            {
                Console.WriteLine(string.Format("{0,-12} {1,-12:dd/MM/yyyy} {2,16:N0}đ {3,16:N0}đ {4,16:N0}đ",
                    hd.MaHoaDon, hd.NgayLap, hd.TongTienHang, hd.GiamGiaKhuyenMai, hd.TongThucThu));

                tongTien += hd.TongTienHang;
                tongGiam += hd.GiamGiaKhuyenMai;
                tongThucThu += hd.TongThucThu;
            }

            Console.WriteLine("--------------------------------------------------------------------------------");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($" TỔNG SỐ HÓA ĐƠN ĐÃ LẬP:            {_danhSachHoaDonHopLe.Count,10}");
            Console.WriteLine($" TỔNG TIỀN HÀNG DOANH SỐ:           {tongTien,18:N0} đ");
            Console.WriteLine($" TỔNG CHIẾT KHẤU / GIẢM GIÁ ĐÃ CẤP: {tongGiam,18:N0} đ");
            Console.WriteLine($" TỔNG DOANH SỐ THỰC THU:            {tongThucThu,18:N0} đ");
            Console.ResetColor();
            Console.WriteLine("================================================================================");
        }
    }
}
