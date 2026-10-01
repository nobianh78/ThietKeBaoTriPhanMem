using System;

namespace DPM235407_NguyenTuanAnh_BaiTap03_01_ComposingMethods._01_Extract_Inline_Method
{
    // =========================================================================
    // AFTER: Áp dụng kỹ thuật Extract Method & Inline Method
    // Tách các đoạn mã có mục đích rõ ràng thành các phương thức nhỏ:
    // - InTieuDeBanner()
    // - TinhTongTienHang()
    // - InDanhSachChiTiet()
    // - InTongKetThanhToan()
    // Mã nguồn trở nên trong sáng, tự giải thích (Self-Documenting Code).
    // =========================================================================
    public class PhieuBanHang_After
    {
        public string MaPhieu { get; set; } = "PB001";
        public string TenKhachHang { get; set; } = "Đại lý Bảy Lúa - Chợ Mới";
        public double[] DanhSachGia { get; set; } = { 150000, 280000, 420000 };
        public int[] DanhSachSoLuong { get; set; } = { 10, 5, 8 };

        public void InThongTinPhieuBan()
        {
            InTieuDeBanner();
            InDanhSachChiTiet();
            
            double tongTienHang = TinhTongTienHang();
            double thueVAT = TinhThueVAT(tongTienHang);
            double tongThanhToan = tongTienHang + thueVAT;

            InTongKetThanhToan(tongTienHang, thueVAT, tongThanhToan);
        }

        private void InTieuDeBanner()
        {
            Console.WriteLine("***********************************************");
            Console.WriteLine("***** CÔNG TY CỔ PHẦN NÔNG DƯỢC AN GIANG *****");
            Console.WriteLine("*****      PHIẾU XUẤT KHO BÁN HÀNG       *****");
            Console.WriteLine("***********************************************");
            Console.WriteLine($"Mã phiếu: {MaPhieu} | Khách hàng: {TenKhachHang}");
            Console.WriteLine(new string('-', 47));
        }

        private double TinhTongTienHang()
        {
            double tong = 0;
            for (int i = 0; i < DanhSachGia.Length; i++)
            {
                tong += DanhSachGia[i] * DanhSachSoLuong[i];
            }
            return tong;
        }

        // Inline Method đơn giản: TinhThueVAT trực tiếp hoặc giữ lại nếu có nghiệp vụ riêng
        private double TinhThueVAT(double tienHang) => tienHang * 0.1;

        private void InDanhSachChiTiet()
        {
            for (int i = 0; i < DanhSachGia.Length; i++)
            {
                double thanhTien = DanhSachGia[i] * DanhSachSoLuong[i];
                Console.WriteLine($"Mặt hàng #{i + 1}: Đơn giá {DanhSachGia[i]:N0} đ x SL {DanhSachSoLuong[i]} = {thanhTien:N0} đ");
            }
        }

        private void InTongKetThanhToan(double tienHang, double thueVAT, double tongThanhToan)
        {
            Console.WriteLine(new string('-', 47));
            Console.WriteLine($"Tiền hàng: {tienHang:N0} đ");
            Console.WriteLine($"Thuế VAT (10%): {thueVAT:N0} đ");
            Console.WriteLine($"TỔNG CỘNG THANH TOÁN: {tongThanhToan:N0} đ");
            Console.WriteLine("***********************************************\n");
        }
    }
}
