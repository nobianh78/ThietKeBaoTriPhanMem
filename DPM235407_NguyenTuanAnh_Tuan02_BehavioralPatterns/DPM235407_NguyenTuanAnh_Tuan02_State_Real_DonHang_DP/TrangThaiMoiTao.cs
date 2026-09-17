using System;

namespace DPM235407_NguyenTuanAnh_Tuan02_State_Real_DonHang_DP
{
    // State 1: Mới tạo đơn
    public class TrangThaiMoiTao : ITrangThaiDonHang
    {
        public string TenTrangThai => "1. MỚI TẠO (ĐANG SOẠN ĐƠN)";

        public void ThemSanPham(DonHangNongDuoc donHang, string tenThuoc, int soLuong, decimal donGia)
        {
            donHang.DanhSachMatHang.Add(new MatHangMua(tenThuoc, soLuong, donGia));
            Console.WriteLine($"   [THÀNH CÔNG] Đã thêm: {tenThuoc} (SL: {soLuong}) vào đơn.");
        }

        public void ThietLapChiPhi(DonHangNongDuoc donHang, decimal phiShip, decimal giamGia)
        {
            donHang.PhiVanChuyen = phiShip;
            donHang.GiamGiaKhuyenMai = giamGia;
            Console.WriteLine($"   [THÀNH CÔNG] Đã cập nhật phí vận chuyển: {phiShip:N0}đ | Chiết khấu: {giamGia:N0}đ");
        }

        public void XacNhanDonHang(DonHangNongDuoc donHang)
        {
            if (donHang.DanhSachMatHang.Count == 0)
            {
                Console.WriteLine("   [LỖI] Đơn hàng chưa có sản phẩm nào, không thể xác nhận!");
                return;
            }
            Console.WriteLine("   [HỆ THỐNG] Kiểm tra dữ liệu hợp lệ -> Chốt đơn hàng!");
            donHang.ChuyenTrangThai(new TrangThaiDaXacNhan());
        }

        public void XuatKhoGiaoHang(DonHangNongDuoc donHang) => Console.WriteLine("   [TỪ CHỐI] Đơn chưa được xác nhận, không thể xuất kho!");
        public void HoanTatThanhToan(DonHangNongDuoc donHang) => Console.WriteLine("   [TỪ CHỐI] Đơn chưa giao hàng, không thể hoàn tất!");
        public void HuyDonHang(DonHangNongDuoc donHang, string lyDo)
        {
            Console.WriteLine($"   [HỦY ĐƠN] Hủy đơn mới tạo: {lyDo}");
            donHang.ChuyenTrangThai(new TrangThaiDaHuy());
        }
    }
}
