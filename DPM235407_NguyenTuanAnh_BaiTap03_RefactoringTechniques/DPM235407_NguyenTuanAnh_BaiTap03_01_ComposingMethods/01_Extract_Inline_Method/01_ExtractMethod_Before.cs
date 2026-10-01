using System;

namespace DPM235407_NguyenTuanAnh_BaiTap03_01_ComposingMethods._01_Extract_Inline_Method
{
    // =========================================================================
    // BEFORE: Long Method Smell
    // Phương thức InThongTinPhieuBan() quá dài, làm quá nhiều việc:
    // tính tiền, in tiêu đề, in chi tiết và in chân trang.
    // Khó đọc, khó tái sử dụng và khó viết unit test.
    // =========================================================================
    public class PhieuBanHang_Before
    {
        public string MaPhieu { get; set; } = "PB001";
        public string TenKhachHang { get; set; } = "Đại lý Bảy Lúa - Chợ Mới";
        public double[] DanhSachGia { get; set; } = { 150000, 280000, 420000 };
        public int[] DanhSachSoLuong { get; set; } = { 10, 5, 8 };

        public void InThongTinPhieuBan()
        {
            // 1. In Banner tiêu đề
            Console.WriteLine("***********************************************");
            Console.WriteLine("***** CÔNG TY CỔ PHẦN NÔNG DƯỢC AN GIANG *****");
            Console.WriteLine("*****      PHIẾU XUẤT KHO BÁN HÀNG       *****");
            Console.WriteLine("***********************************************");
            Console.WriteLine($"Mã phiếu: {MaPhieu} | Khách hàng: {TenKhachHang}");
            Console.WriteLine(new string('-', 47));

            // 2. Tính toán tổng tiền
            double tongTien = 0;
            for (int i = 0; i < DanhSachGia.Length; i++)
            {
                tongTien += DanhSachGia[i] * DanhSachSoLuong[i];
            }
            double thueVAT = tongTien * 0.1;
            double tongThanhToan = tongTien + thueVAT;

            // 3. In chi tiết từng dòng
            for (int i = 0; i < DanhSachGia.Length; i++)
            {
                Console.WriteLine($"Mặt hàng #{i + 1}: Đơn giá {DanhSachGia[i]:N0} đ x SL {DanhSachSoLuong[i]} = {DanhSachGia[i] * DanhSachSoLuong[i]:N0} đ");
            }

            // 4. In thông tin tổng kết & chân trang
            Console.WriteLine(new string('-', 47));
            Console.WriteLine($"Tiền hàng: {tongTien:N0} đ");
            Console.WriteLine($"Thuế VAT (10%): {thueVAT:N0} đ");
            Console.WriteLine($"TỔNG CỘNG THANH TOÁN: {tongThanhToan:N0} đ");
            Console.WriteLine("***********************************************\n");
        }
    }
}
