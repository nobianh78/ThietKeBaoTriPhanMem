using System;

namespace DPM235407_NguyenTuanAnh_Tuan02_State_Real_DonHang_DP
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.WriteLine("================================================================================");
            Console.WriteLine(" CÔNG TY NÔNG DƯỢC AN GIANG - PHÂN HỆ QUẢN LÝ VÒNG ĐỜI ĐƠN HÀNG (STATE PATTERN)");
            Console.WriteLine("================================================================================");

            // Khởi tạo đơn hàng mới
            var donHang = new DonHangNongDuoc("DH-2026-7799", "Nông trường Lúa Vàng An Giang");

            Console.WriteLine("\n--- GIAI ĐOẠN 1: MỚI TẠO - Thêm thuốc BVTV và phụ phí ---");
            donHang.ThemSanPham("Thuốc trừ rầy nâu Chess 50WG", 40, 65000);
            donHang.ThemSanPham("Thuốc trừ sâu cuốn lá Virtako 40WG", 25, 45000);
            donHang.ThietLapChiPhi(150000, 300000);
            donHang.InThongTin();

            Console.WriteLine("\n--- GIAI ĐOẠN 2: XÁC NHẬN ĐƠN HÀNG VÀ CHỐT KHO ---");
            donHang.XacNhanDonHang();

            Console.WriteLine("\n--- THỬ NGHIỆM: Cố ý sửa giá / thêm sản phẩm sau khi đã xác nhận ---");
            donHang.ThemSanPham("Thuốc trừ nấm Tilt Super 300EC", 10, 150000); // Bị từ chối!
            donHang.ThietLapChiPhi(200000, 500000); // Bị từ chối!

            Console.WriteLine("\n--- GIAI ĐOẠN 3: XUẤT KHO VÀ VẬN CHUYỂN ---");
            donHang.XuatKhoGiaoHang();

            Console.WriteLine("\n--- GIAI ĐOẠN 4: GIAO HÀNG THÀNH CÔNG VÀ HOÀN TẤT THANH TOÁN ---");
            donHang.HoanTatThanhToan();
            donHang.InThongTin();

            Console.WriteLine("\n--- THỬ NGHIỆM: Cố ý hủy đơn hàng khi đã hoàn tất giao hàng ---");
            donHang.HuyDonHang("Khách đổi ý trả lại"); // Bị từ chối!

            Console.WriteLine("\n================================================================================");
        }
    }
}
