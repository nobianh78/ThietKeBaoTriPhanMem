using System;

namespace DPM235407_NguyenTuanAnh_Tuan01_Factory_Real_NhanVien_DP
{
    // Concrete Product 1: Cung cấp chi tiết quyền hạn của nhân viên bán hàng
    public class NhanVienBanHang : INhanVien
    {
        public string HienThiQuyenHan()
        {
            return "{Nhân viên Bán hàng} - Được phép lập hóa đơn, nhập dịch vụ phát sinh và xem thống kê hóa đơn do mình lập.";
        }
    }
}
