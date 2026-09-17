using System;

namespace DPM235407_NguyenTuanAnh_Tuan02_State_Real_DonHang_DP
{
    // State 4: Hoàn thành
    public class TrangThaiHoanThanh : ITrangThaiDonHang
    {
        public string TenTrangThai => "4. HOÀN THÀNH (ĐÃ GIAO & ĐÃ THANH TOÁN)";

        public void ThemSanPham(DonHangNongDuoc donHang, string tenThuoc, int soLuong, decimal donGia)
            => Console.WriteLine("   [TỪ CHỐI] Đơn đã kết thúc thành công! Không được can thiệp.");

        public void ThietLapChiPhi(DonHangNongDuoc donHang, decimal phiShip, decimal giamGia)
            => Console.WriteLine("   [TỪ CHỐI] Đơn đã đóng sổ kế toán!");

        public void XacNhanDonHang(DonHangNongDuoc donHang) => Console.WriteLine("   [THÔNG BÁO] Đơn đã hoàn thành.");
        public void XuatKhoGiaoHang(DonHangNongDuoc donHang) => Console.WriteLine("   [THÔNG BÁO] Đơn đã giao xong.");
        public void HoanTatThanhToan(DonHangNongDuoc donHang) => Console.WriteLine("   [THÔNG BÁO] Đã thanh toán xong.");
        public void HuyDonHang(DonHangNongDuoc donHang, string lyDo)
            => Console.WriteLine("   [TỪ CHỐI] Không thể hủy đơn hàng đã hoàn tất giao nhận!");
    }
}
