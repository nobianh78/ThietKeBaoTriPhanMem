using System;
using System.Collections.Generic;

namespace DPM235407_NguyenTuanAnh_Tuan02_Visitor_Real_ThongKe_DP
{
    // Visitor 2: Thống kê tồn kho hàng hóa, chi phí vận chuyển, dịch vụ phụ, giảm giá, khuyến mãi từ ngày đến ngày (Mục 4 PDF)
    public class BaoCaoTonKhoVaChiPhiPhuTuNgayDenNgayVisitor : IBaoCaoVisitor
    {
        public DateTime TuNgay { get; set; }
        public DateTime DenNgay { get; set; }

        private decimal _tongChiPhiVanChuyen = 0;
        private decimal _tongGiamGiaKhuyenMai = 0;
        private decimal _tongChiPhiDichVuPhu = 0;
        private int _tongSoLuongTonKho = 0;
        private decimal _tongGiaTriVonTonKho = 0;
        private int _soHoaDon = 0;
        private int _soLoHang = 0;

        public BaoCaoTonKhoVaChiPhiPhuTuNgayDenNgayVisitor(DateTime tuNgay, DateTime denNgay)
        {
            TuNgay = tuNgay;
            DenNgay = denNgay;
        }

        public void VisitHoaDon(HoaDonBanHangElement hoaDon)
        {
            if (hoaDon.NgayLap.Date >= TuNgay.Date && hoaDon.NgayLap.Date <= DenNgay.Date)
            {
                _soHoaDon++;
                _tongChiPhiVanChuyen += hoaDon.ChiPhiVanChuyen;
                _tongGiamGiaKhuyenMai += hoaDon.GiamGiaKhuyenMai;
            }
        }

        public void VisitLoHangTonKho(LoHangTonKhoElement loHang)
        {
            _soLoHang++;
            _tongSoLuongTonKho += loHang.SoLuongTon;
            _tongGiaTriVonTonKho += loHang.GiaTriTonKho;
        }

        public void VisitDichVuPhatSinh(DichVuPhatSinhElement dichVu)
        {
            if (dichVu.NgayThucHien.Date >= TuNgay.Date && dichVu.NgayThucHien.Date <= DenNgay.Date)
            {
                _tongChiPhiDichVuPhu += dichVu.ChiPhi;
            }
        }

        public void InKetQuaBaoCao()
        {
            Console.WriteLine("\n================================================================================");
            Console.WriteLine(" BÁO CÁO TỔNG HỢP: TỒN KHO, VẬN CHUYỂN, DỊCH VỤ PHỤ, GIẢM GIÁ KHUYẾN MÃI");
            Console.WriteLine($" Khoảng thời gian thống kê: Từ {TuNgay:dd/MM/yyyy} Đến {DenNgay:dd/MM/yyyy}");
            Console.WriteLine("================================================================================");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(" 1. THỐNG KÊ TỒN KHO HÀNG HÓA NÔNG DƯỢC:");
            Console.WriteLine($"    - Tổng số lô hàng đang lưu kho:   {_soLoHang,12} lô");
            Console.WriteLine($"    - Tổng số lượng sản phẩm tồn:     {_tongSoLuongTonKho,12:N0} chai/gói/bao");
            Console.WriteLine($"    - Tổng giá trị vốn hàng tồn kho:  {_tongGiaTriVonTonKho,18:N0} đ");
            Console.WriteLine();
            Console.WriteLine(" 2. THỐNG KÊ CÁC KHOẢN PHỤ PHÍ & CHIẾT KHẤU TRONG KỲ:");
            Console.WriteLine($"    - Tổng số hóa đơn phát sinh:      {_soHoaDon,12}");
            Console.WriteLine($"    - Tổng chi phí vận chuyển tận nơi:{_tongChiPhiVanChuyen,18:N0} đ");
            Console.WriteLine($"    - Tổng chi phí dịch vụ phụ trợ:   {_tongChiPhiDichVuPhu,18:N0} đ");
            Console.WriteLine($"    - Tổng giảm giá khuyến mãi hỗ trợ:{_tongGiamGiaKhuyenMai,18:N0} đ");
            Console.ResetColor();
            Console.WriteLine("================================================================================");
        }
    }
}
