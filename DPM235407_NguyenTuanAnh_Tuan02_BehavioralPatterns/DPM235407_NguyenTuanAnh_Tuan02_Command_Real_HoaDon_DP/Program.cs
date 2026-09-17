using System;

namespace DPM235407_NguyenTuanAnh_Tuan02_Command_Real_HoaDon_DP
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.WriteLine("================================================================================");
            Console.WriteLine(" CÔNG TY NÔNG DƯỢC AN GIANG - PHÂN HỆ QUẢN LÝ THAO TÁC HÓA ĐƠN (COMMAND PATTERN)");
            Console.WriteLine("================================================================================");

            // Khởi tạo hóa đơn bán hàng cho đại lý nông dân
            var hoaDon = new HoaDonBanHang("HD-2026-0018", "HTX Nông Nghiệp Tri Tôn - An Giang", "Nguyễn Tuấn Anh");
            var thuNgan = new NhanVienThuNganInvoker();

            Console.WriteLine("\n--- BƯỚC 1: Nhân viên thêm các sản phẩm thuốc bảo vệ thực vật ---");
            var cmdThuoc1 = new ThemSanPhamCommand(hoaDon, new SanPhamMua("ND01", "Thuốc trừ sâu cuốn lá Virtako 40WG", 50, 45000));
            var cmdThuoc2 = new ThemSanPhamCommand(hoaDon, new SanPhamMua("ND02", "Thuốc trừ đạo ôn Filia 525SE", 30, 120000));
            thuNgan.ThucHien(cmdThuoc1);
            thuNgan.ThucHien(cmdThuoc2);

            Console.WriteLine("\n--- BƯỚC 2: Nhập chi phí vận chuyển xe giao đến tận ruộng ---");
            var cmdShip = new ThemPhiVanChuyenCommand(hoaDon, 250000);
            thuNgan.ThucHien(cmdShip);

            Console.WriteLine("\n--- BƯỚC 3: Nhập dịch vụ phát sinh (phun thuốc thử nghiệm mẫu diện tích nhỏ) ---");
            var cmdDichVu = new ThemDichVuPhatSinhCommand(hoaDon, "Phun thử nghiệm mẫu phòng đạo ôn", 300000);
            thuNgan.ThucHien(cmdDichVu);

            Console.WriteLine("\n--- BƯỚC 4: Áp dụng chiết khấu khuyến mãi mùa vụ lúa Đông Xuân ---");
            var cmdGiamGia = new ApDungGiamGiaCommand(hoaDon, 500000);
            thuNgan.ThucHien(cmdGiamGia);

            // In hóa đơn hiện tại
            hoaDon.InHoaDon();

            Console.WriteLine("\n--- BƯỚC 5: KHÁCH HÀNG THAY ĐỔI Ý ĐỊNH - HOÀN TÁC (UNDO) CÁC THAO TÁC ---");
            // 1. Khách không cần dịch vụ phun mẫu nữa -> Hoàn tác giảm giá và dịch vụ
            thuNgan.HoanTac(); // Undo giảm giá
            thuNgan.HoanTac(); // Undo dịch vụ phát sinh

            // Khách đề nghị áp dụng lại khuyến mãi đặc biệt khác (400,000 đ)
            Console.WriteLine("\n--- BƯỚC 6: Áp dụng lại chương trình chiết khấu điều chỉnh (400,000 đ) ---");
            var cmdGiamGiaMoi = new ApDungGiamGiaCommand(hoaDon, 400000);
            thuNgan.ThucHien(cmdGiamGiaMoi);

            // In hóa đơn sau khi hoàn tác và điều chỉnh
            hoaDon.InHoaDon();

            thuNgan.InLichSu();

            Console.WriteLine("\n================================================================================");
        }
    }
}
