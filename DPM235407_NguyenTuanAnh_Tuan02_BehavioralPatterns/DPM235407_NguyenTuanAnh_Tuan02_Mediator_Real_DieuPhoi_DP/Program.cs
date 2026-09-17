using System;

namespace DPM235407_NguyenTuanAnh_Tuan02_Mediator_Real_DieuPhoi_DP
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.WriteLine("================================================================================");
            Console.WriteLine(" CÔNG TY NÔNG DƯỢC AN GIANG - HỆ THỐNG ĐIỀU PHỐI LIÊN PHÒNG BAN (MEDIATOR)");
            Console.WriteLine("================================================================================");

            // Khởi tạo các phòng ban
            var banHang = new BoPhanBanHang();
            var khoHang = new BoPhanKhoHang();
            var keToan = new BoPhanKeToan();
            var vanChuyen = new BoPhanVanChuyen();

            // Khởi tạo trung tâm điều phối kết nối tất cả các phòng ban
            var mediator = new DieuPhoiBanHangMediator(banHang, khoHang, keToan, vanChuyen);

            // Bắt đầu một luồng bán sỉ cho nông dân/đại lý An Giang
            var don1 = new ThongTinDonHang(
                "DH-AG-9901",
                "Đại lý Nông Dược Sáu Râu - Thoại Sơn",
                "Thuốc trừ rầy bâu lúa Applaud 10WP",
                50,
                85000,
                "Ấp Tây Bình, Thoại Sơn, An Giang"
            );

            Console.WriteLine("--- KÍCH HOẠT QUY TRÌNH BÁN HÀNG TỰ ĐỘNG THÔNG QUA TRUNG TÂM ĐIỀU PHỐI ---");
            banHang.TiepNhanDonHang(don1);

            Console.WriteLine("\n================================================================================");
        }
    }
}
