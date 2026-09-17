using System;

namespace DPM235407_NguyenTuanAnh_BaiTap01_Proxy_Real_BaoCao_DP
{
    // [Real Subject]: Dịch vụ xuất báo cáo thực tế tính toán từ cơ sở dữ liệu
    public class BaoCaoThongKeThucTeService : IBaoCaoThongKeService
    {
        public void XemBaoCaoDoanhThuVaKhuyenMai(NguoiDung user, DateTime tuNgay, DateTime denNgay)
        {
            Console.WriteLine($"\n--- BÁO CÁO DOANH SỐ & KHUYẾN MÃI (Từ {tuNgay:dd/MM/yyyy} đến {denNgay:dd/MM/yyyy}) ---");
            if (user.VaiTro == "NhanVienBanHang")
            {
                Console.WriteLine($"[Dữ liệu cá nhân] Nhân viên: {user.HoTen} (Mã: {user.MaNV})");
                Console.WriteLine("  * Tổng số hóa đơn đã lập: 18 hóa đơn");
                Console.WriteLine("  * Tổng doanh thu bán hàng: 48,500,000 VNĐ");
                Console.WriteLine("  * Tiền chiết khấu giảm giá đã tặng khách: 2,150,000 VNĐ");
            }
            else
            {
                Console.WriteLine($"[Dữ liệu toàn công ty] Người tra cứu: {user.HoTen} (Vai trò: Quản lý)");
                Console.WriteLine("  * Tổng số hóa đơn toàn chi nhánh: 142 hóa đơn");
                Console.WriteLine("  * Tổng doanh thu toàn công ty: 420,000,000 VNĐ");
                Console.WriteLine("  * Tổng chiết khấu & giảm giá khuyến mãi: 18,900,000 VNĐ");
            }
        }

        public void XemBaoCaoTonKhoVaChiPhi(NguoiDung user, DateTime tuNgay, DateTime denNgay)
        {
            Console.WriteLine($"\n--- BÁO CÁO TỒN KHO & CHI PHÍ TOÀN CÔNG TY NÔNG DƯỢC AN GIANG ---");
            Console.WriteLine($"Khoảng thời gian: {tuNgay:dd/MM/yyyy} -> {denNgay:dd/MM/yyyy}");
            Console.WriteLine("  * Tổng giá trị hàng tồn kho (thuốc BVTV & phân bón): 1,850,000,000 VNĐ");
            Console.WriteLine("  * Chi phí vận chuyển đã phát sinh: 14,200,000 VNĐ");
            Console.WriteLine("  * Chi phí dịch vụ phụ (bốc vác, kiểm nghiệm): 6,800,000 VNĐ");
            Console.WriteLine("  * Trạng thái các lô hàng: 95% lô còn hạn trên 1 năm, 5% lô cận date đang ưu tiên xuất.");
        }
    }
}
