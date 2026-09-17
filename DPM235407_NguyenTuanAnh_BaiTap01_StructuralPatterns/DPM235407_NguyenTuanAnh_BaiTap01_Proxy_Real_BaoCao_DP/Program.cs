using System;
using System.Text;

namespace DPM235407_NguyenTuanAnh_BaiTap01_Proxy_Real_BaoCao_DP
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.WriteLine("================================================================================");
            Console.WriteLine(" CÔNG TY NÔNG DƯỢC AN GIANG - PHẦN MỀM THỐNG KÊ BÁO CÁO BÁN HÀNG");
            Console.WriteLine(" MẪU THIẾT KẾ PROXY: KIỂM SOÁT PHÂN QUYỀN, BỘ ĐỆM CACHE & NHẬT KÝ TRUY CẬP");
            Console.WriteLine("================================================================================\n");

            // Khởi tạo Real Service và Proxy
            var realService = new BaoCaoThongKeThucTeService();
            IBaoCaoThongKeService proxyService = new BaoCaoThongKeProxy(realService);

            // 1. Tạo 2 tài khoản: Quản lý và Nhân viên bán hàng
            var quanLy = new NguoiDung("QL01", "Trần Văn Quản Lý", "QuanLy");
            var nhanVien = new NguoiDung("NV02", "Lê Thị Thu Ngân", "NhanVienBanHang");

            DateTime tuNgay = new DateTime(2026, 9, 1);
            DateTime denNgay = new DateTime(2026, 9, 30);

            // KỊCH BẢN 1: Quản lý xem báo cáo tồn kho & chi phí toàn công ty (Thành công)
            Console.WriteLine("=== KỊCH BẢN 1: TÀI KHOẢN QUẢN LÝ TRUY CẬP BÁO CÁO ===");
            proxyService.XemBaoCaoTonKhoVaChiPhi(quanLy, tuNgay, denNgay);

            // KỊCH BẢN 2: Nhân viên bán hàng xem báo cáo doanh số cá nhân (Thành công)
            Console.WriteLine("\n=== KỊCH BẢN 2: NHÂN VIÊN BÁN HÀNG XEM DOANH SỐ CÁ NHÂN ===");
            proxyService.XemBaoCaoDoanhThuVaKhuyenMai(nhanVien, tuNgay, denNgay);

            // KỊCH BẢN 3: Tra cứu lại cùng khoảng ngày -> Proxy sử dụng Cache
            Console.WriteLine("\n--- Tra cứu lại lần 2 (Kiểm tra Caching Proxy) ---");
            proxyService.XemBaoCaoDoanhThuVaKhuyenMai(nhanVien, tuNgay, denNgay);

            // KỊCH BẢN 4: Nhân viên bán hàng cố tình truy cập báo cáo tài chính mật (Proxy chặn)
            Console.WriteLine("\n=== KỊCH BẢN 4: NHÂN VIÊN BÁN HÀNG CỐ TRUY CẬP BÁO CÁO MẬT ===");
            proxyService.XemBaoCaoTonKhoVaChiPhi(nhanVien, tuNgay, denNgay);

            Console.WriteLine("\n--> Mẫu Proxy bảo vệ an toàn dữ liệu hệ thống, tự động phân quyền");
            Console.WriteLine("    và ghi nhật ký kiểm toán theo đúng yêu cầu nghiệp vụ file PDF!");
        }
    }
}
