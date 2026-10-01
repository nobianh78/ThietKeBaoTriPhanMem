using System;

namespace DPM235407_NguyenTuanAnh_BaiTap03_02_MovingFeatures._02_Extract_Inline_Class
{
    // =========================================================================
    // BEFORE: Lớp quá lớn (Large Class Smell / Divergent Change)
    // Lớp `NhaCungCap_Before` chứa lẫn lộn: thông tin doanh nghiệp, thông tin liên hệ,
    // thông tin ngân hàng và địa chỉ kho bãi. Khi thay đổi cách quản lý địa chỉ
    // hoặc tài khoản ngân hàng, lớp này đều phải sửa đổi.
    // =========================================================================
    public class NhaCungCap_Before
    {
        public string MaNCC { get; set; } = "NCC01";
        public string TenNCC { get; set; } = "Tập đoàn Lộc Trời An Giang";
        
        // Thông tin liên hệ
        public string NguoiDaiDien { get; set; } = "Nguyễn Văn Lộc";
        public string SoDienThoai { get; set; } = "0918123456";
        public string Email { get; set; } = "loctroi.angiang@loctroi.vn";

        // Thông tin địa chỉ
        public string SoNhaDuong { get; set; } = "Số 23 Trần Hưng Đạo";
        public string PhuongXa { get; set; } = "Phường Mỹ Bình";
        public string QuanHuyen { get; set; } = "TP. Long Xuyên";
        public string TinhThanh { get; set; } = "An Giang";

        // Thông tin ngân hàng
        public string SoTaiKhoan { get; set; } = "6700201012345";
        public string TenNganHang { get; set; } = "Agribank An Giang";
        public string ChiNhanh { get; set; } = "Chi nhánh TP Long Xuyên";

        public string LayDiaChiDayDu()
        {
            return $"{SoNhaDuong}, {PhuongXa}, {QuanHuyen}, {TinhThanh}";
        }
    }
}
