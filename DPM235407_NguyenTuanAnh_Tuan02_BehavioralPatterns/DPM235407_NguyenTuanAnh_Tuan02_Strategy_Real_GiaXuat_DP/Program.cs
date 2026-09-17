using System;

namespace DPM235407_NguyenTuanAnh_Tuan02_Strategy_Real_GiaXuat_DP
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.WriteLine("================================================================================");
            Console.WriteLine(" CÔNG TY NÔNG DƯỢC AN GIANG - PHÂN HỆ TÍNH GIÁ XUẤT KHO TÙY CHỌN (STRATEGY)");
            Console.WriteLine(" (Mục 3 PDF: Giá xuất sản phẩm tính theo Bình quân gia quyền / Nhập trước xuất trước)");
            Console.WriteLine("================================================================================");

            // Khởi tạo context ban đầu với chiến lược Bình quân gia quyền
            var context = new QuanLyKhoNongDuocContext(new TinhGiaBinhQuanGiaQuyenStrategy());

            // Nhập 3 lô thuốc trừ sâu cuốn lá Virtako 40WG ở các đợt khác nhau với giá nhập biến động
            context.NhapLo(new LoThuocNhap("LO-01/2026", "Virtako 40WG", new DateTime(2026, 1, 10), 100, 40000));
            context.NhapLo(new LoThuocNhap("LO-02/2026", "Virtako 40WG", new DateTime(2026, 2, 15), 80, 46000));
            context.NhapLo(new LoThuocNhap("LO-03/2026", "Virtako 40WG", new DateTime(2026, 3, 20), 120, 50000));

            Console.WriteLine("\n[TỒN KHO THUỐC VIRTAKO 40WG HIỆN TẠI]");
            Console.WriteLine(" - Lô LO-01/2026: Nhập 10/01/2026 | Tồn: 100 gói | Giá nhập: 40,000 đ/gói");
            Console.WriteLine(" - Lô LO-02/2026: Nhập 15/02/2026 | Tồn:  80 gói | Giá nhập: 46,000 đ/gói");
            Console.WriteLine(" - Lô LO-03/2026: Nhập 20/03/2026 | Tồn: 120 gói | Giá nhập: 50,000 đ/gói");
            Console.WriteLine("   => Tổng tồn: 300 gói | Tổng giá trị vốn tồn: 13,680,000 đ");

            int soLuongXuat = 150;

            // Kịch bản 1: Cửa hàng đang chọn cấu hình phương pháp Bình quân gia quyền
            Console.WriteLine("\n>>> CẤU HÌNH 1: SỬ DỤNG PHƯƠNG PHÁP BÌNH QUÂN GIA QUYỀN <<<");
            context.XuatKhoTinhGia(soLuongXuat);

            // Kịch bản 2: Người dùng đổi cấu hình tại runtime sang Nhập trước xuất trước (FIFO)
            Console.WriteLine("\n>>> CẤU HÌNH 2: CHUYỂN SANG PHƯƠNG PHÁP NHẬP TRƯỚC XUẤT TRƯỚC (FIFO) <<<");
            context.SetStrategy(new TinhGiaNhapTruocXuatTruocStrategy());
            context.XuatKhoTinhGia(soLuongXuat);

            Console.WriteLine("\n================================================================================");
        }
    }
}
