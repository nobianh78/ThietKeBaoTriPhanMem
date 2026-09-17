using System;

namespace DPM235407_NguyenTuanAnh_Tuan02_State_Real_DonHang_DP
{
    // State 5: Đã hủy
    public class TrangThaiDaHuy : ITrangThaiDonHang
    {
        public string TenTrangThai => "5. ĐÃ HỦY ĐƠN";

        public void ThemSanPham(DonHangNongDuoc donHang, string tenThuoc, int soLuong, decimal donGia)
            => Console.WriteLine("   [TỪ CHỐI] Đơn đã hủy!");

        public void ThietLapChiPhi(DonHangNongDuoc donHang, decimal phiShip, decimal giamGia)
            => Console.WriteLine("   [TỪ CHỐI] Đơn đã hủy!");

        public void XacNhanDonHang(DonHangNongDuoc donHang) => Console.WriteLine("   [TỪ CHỐI] Không thể kích hoạt đơn đã hủy!");
        public void XuatKhoGiaoHang(DonHangNongDuoc donHang) => Console.WriteLine("   [TỪ CHỐI] Không thể giao đơn đã hủy!");
        public void HoanTatThanhToan(DonHangNongDuoc donHang) => Console.WriteLine("   [TỪ CHỐI] Đơn đã hủy!");
        public void HuyDonHang(DonHangNongDuoc donHang, string lyDo) => Console.WriteLine("   [THÔNG BÁO] Đơn đã bị hủy rồi.");
    }
}
