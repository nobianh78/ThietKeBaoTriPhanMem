using System;

namespace DPM235407_NguyenTuanAnh_BaiTap03_02_MovingFeatures._02_Extract_Inline_Class
{
    // =========================================================================
    // AFTER: Áp dụng kỹ thuật Extract Class
    // Tách các nhóm thuộc tính có tính gắn kết thành các lớp chuyên biệt:
    // - `ThongTinLienHe`: Quản lý người liên hệ, SĐT, Email
    // - `DiaChi`: Quản lý cấu trúc địa chỉ hành chính
    // - `ThongTinNganHang`: Quản lý tài khoản thanh toán
    // Có thể tái sử dụng cho Khách Hàng, Đại Lý, Nhà Cung Cấp.
    // =========================================================================
    public class ThongTinLienHe
    {
        public string NguoiDaiDien { get; set; } = string.Empty;
        public string SoDienThoai { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
    }

    public class DiaChi
    {
        public string SoNhaDuong { get; set; } = string.Empty;
        public string PhuongXa { get; set; } = string.Empty;
        public string QuanHuyen { get; set; } = string.Empty;
        public string TinhThanh { get; set; } = string.Empty;

        public override string ToString()
        {
            return $"{SoNhaDuong}, {PhuongXa}, {QuanHuyen}, {TinhThanh}";
        }
    }

    public class ThongTinNganHang
    {
        public string SoTaiKhoan { get; set; } = string.Empty;
        public string TenNganHang { get; set; } = string.Empty;
        public string ChiNhanh { get; set; } = string.Empty;
    }

    public class NhaCungCap_After
    {
        public string MaNCC { get; set; } = "NCC01";
        public string TenNCC { get; set; } = "Tập đoàn Lộc Trời An Giang";
        public ThongTinLienHe LienHe { get; set; } = new();
        public DiaChi DiaChiTruSo { get; set; } = new();
        public ThongTinNganHang TaiKhoanNganHang { get; set; } = new();
    }
}
