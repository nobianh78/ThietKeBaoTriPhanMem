using System;

namespace DPM235407_NguyenTuanAnh_Tuan02_Observer_Real_TonKho_DP
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.WriteLine("================================================================================");
            Console.WriteLine(" CÔNG TY NÔNG DƯỢC AN GIANG - PHÂN HỆ GIÁM SÁT TỒN KHO & HẠN DÙNG (OBSERVER)");
            Console.WriteLine("================================================================================");

            var khoSubject = new KhoNongDuocSubject();

            // Khởi tạo các bên quan sát (Subscribers)
            var thuKho = new BoPhanThuKhoObserver();
            var banHang = new NhanVienBanHangObserver();
            var quanLy = new QuanLyCuaHangObserver();

            // Đăng ký nhận thông báo
            khoSubject.DangKy(thuKho);
            khoSubject.DangKy(banHang);
            khoSubject.DangKy(quanLy);

            // Nạp dữ liệu lô hàng vào kho
            khoSubject.ThemLoHang(new LoHangInfo("LO-VIRT-01", "Thuốc trừ sâu cuốn lá Virtako 40WG", 60, DateTime.Now.AddMonths(18)));
            khoSubject.ThemLoHang(new LoHangInfo("LO-AMIST-02", "Thuốc trừ nấm Amistar Top 325SC", 18, DateTime.Now.AddDays(15))); // Cận date 15 ngày!

            Console.WriteLine("\n--- SỰ KIỆN 1: Bán hàng số lượng lớn dẫn đến tồn kho rơi xuống dưới mức an toàn ---");
            khoSubject.XuatKho("LO-VIRT-01", 50); // Còn 10 (<= 15)

            Console.WriteLine("\n--- SỰ KIỆN 2: Hệ thống tự động quét kiểm tra hạn sử dụng các lô thuốc BVTV ---");
            khoSubject.QuetKiemTraHanSuDung();

            Console.WriteLine("\n--- SỰ KIỆN 3: Công ty phát động chương trình khuyến mãi giảm giá mùa lúa mới ---");
            khoSubject.PhatDongKhuyenMai("Tri ân bà con nông dân trúng mùa An Giang", 12);

            Console.WriteLine("\n================================================================================");
        }
    }
}
