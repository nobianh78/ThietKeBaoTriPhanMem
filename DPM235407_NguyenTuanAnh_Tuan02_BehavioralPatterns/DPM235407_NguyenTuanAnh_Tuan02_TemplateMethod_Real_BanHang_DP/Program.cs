using System;

namespace DPM235407_NguyenTuanAnh_Tuan02_TemplateMethod_Real_BanHang_DP
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.WriteLine("================================================================================");
            Console.WriteLine(" CÔNG TY NÔNG DƯỢC AN GIANG - QUY TRÌNH BÁN HÀNG SỈ VÀ LẺ (TEMPLATE METHOD)");
            Console.WriteLine("================================================================================");

            // 1. Đơn hàng Bán sỉ cho Hợp tác xã
            var donSi = new DonHangNongDuoc(
                "DHS-2026-001",
                "Hợp tác xã Nông nghiệp Chợ Mới",
                "Thuốc trừ đạo ôn lúa Beam 75WP",
                200,
                110000,
                35.5 // 35.5 km
            );

            QuyTrinhBanHangTemplate quyTrinhSi = new QuyTrinhBanSi();
            quyTrinhSi.XuLyDonHang(donSi);

            // 2. Đơn hàng Bán lẻ cho nông dân
            var donLe = new DonHangNongDuoc(
                "DHL-2026-008",
                "Chú Bảy Lúa - Xã Phú Hưng",
                "Thuốc trừ sâu sinh học Radiant 60SC",
                6,
                95000,
                4.2, // 4.2 km (<= 5km nên freeship)
                "TRIANVUDONGXUAN"
            );

            QuyTrinhBanHangTemplate quyTrinhLe = new QuyTrinhBanLe();
            quyTrinhLe.XuLyDonHang(donLe);

            Console.WriteLine("\n================================================================================");
        }
    }
}
