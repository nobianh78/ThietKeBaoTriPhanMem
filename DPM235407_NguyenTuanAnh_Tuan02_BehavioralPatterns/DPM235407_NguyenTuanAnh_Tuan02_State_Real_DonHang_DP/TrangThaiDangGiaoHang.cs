using System;

namespace DPM235407_NguyenTuanAnh_Tuan02_State_Real_DonHang_DP
{
    // State 3: Đang giao hàng
    public class TrangThaiDangGiaoHang : ITrangThaiDonHang
    {
        public string TenTrangThai => "3. ĐANG VẬN CHUYỂN ĐẾN ĐẠI LÝ/RUỘNG";

        public void ThemSanPham(DonHangNongDuoc donHang, string tenThuoc, int soLuong, decimal donGia)
            => Console.WriteLine("   [TỪ CHỐI] Hàng đang trên đường giao!");

        public void ThietLapChiPhi(DonHangNongDuoc donHang, decimal phiShip, decimal giamGia)
            => Console.WriteLine("   [TỪ CHỐI] Không thể sửa giá khi đang giao hàng!");

        public void XacNhanDonHang(DonHangNongDuoc donHang) => Console.WriteLine("   [THÔNG BÁO] Đơn đã xác nhận.");
        public void XuatKhoGiaoHang(DonHangNongDuoc donHang) => Console.WriteLine("   [THÔNG BÁO] Đang trong quá trình giao hàng.");

        public void HoanTatThanhToan(DonHangNongDuoc donHang)
        {
            Console.WriteLine("   [HỆ THỐNG] Khách đã nhận đủ hàng và thanh toán đủ tiền mặt!");
            donHang.ChuyenTrangThai(new TrangThaiHoanThanh());
        }

        public void HuyDonHang(DonHangNongDuoc donHang, string lyDo)
        {
            Console.WriteLine($"   [CẢNH BÁO] Khách từ chối nhận hàng ({lyDo}). Xe tải chở hàng quay về kho.");
            donHang.ChuyenTrangThai(new TrangThaiDaHuy());
        }
    }
}
