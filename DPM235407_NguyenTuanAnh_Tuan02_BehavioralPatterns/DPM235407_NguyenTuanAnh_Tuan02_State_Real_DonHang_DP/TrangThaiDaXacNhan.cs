using System;

namespace DPM235407_NguyenTuanAnh_Tuan02_State_Real_DonHang_DP
{
    // State 2: Đã xác nhận & trừ kho
    public class TrangThaiDaXacNhan : ITrangThaiDonHang
    {
        public string TenTrangThai => "2. ĐÃ XÁC NHẬN (ĐÃ KHÓA SỐ LƯỢNG & TRỪ KHO)";

        public void ThemSanPham(DonHangNongDuoc donHang, string tenThuoc, int soLuong, decimal donGia)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("   [TỪ CHỐI] Đơn đã xác nhận và trừ lô kho! Không thể thêm bớt sản phẩm.");
            Console.ResetColor();
        }

        public void ThietLapChiPhi(DonHangNongDuoc donHang, decimal phiShip, decimal giamGia)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("   [TỪ CHỐI] Đơn đã chốt giá! Không thể thay đổi chiết khấu hoặc phí vận chuyển.");
            Console.ResetColor();
        }

        public void XacNhanDonHang(DonHangNongDuoc donHang) => Console.WriteLine("   [THÔNG BÁO] Đơn hàng đã được xác nhận trước đó rồi.");

        public void XuatKhoGiaoHang(DonHangNongDuoc donHang)
        {
            Console.WriteLine("   [HỆ THỐNG] Đã bốc thuốc lên xe tải, xuất phát giao hàng!");
            donHang.ChuyenTrangThai(new TrangThaiDangGiaoHang());
        }

        public void HoanTatThanhToan(DonHangNongDuoc donHang) => Console.WriteLine("   [TỪ CHỐI] Hàng chưa giao tới nơi!");

        public void HuyDonHang(DonHangNongDuoc donHang, string lyDo)
        {
            Console.WriteLine($"   [HỦY ĐƠN] Hủy đơn đã xác nhận. Tự động hoàn trả tồn kho thuốc BVTV!");
            donHang.ChuyenTrangThai(new TrangThaiDaHuy());
        }
    }
}
