using System;
using System.Collections.Generic;

namespace DPM235407_NguyenTuanAnh_Tuan02_ChainOfResponsibility_Real_XacThuc_DP
{
    // Bước 2: Kiểm tra xác thực tài khoản có tồn tại trong CSDL Nông Dược An Giang
    public class XacThucTaiKhoanHandler : AbstractXacThucHandler
    {
        // Giả lập danh mục tài khoản nhân viên từ CSDL Access
        private readonly Dictionary<string, (string Password, string Role, bool Locked)> _danhSachNhanVien = new()
        {
            { "quanly_ag", ("ql123", "QuanLy", false) },
            { "banhang_anh", ("bh123", "NhanVienBanHang", false) },
            { "banhang_khoa", ("bh456", "NhanVienBanHang", true) }, // Tài khoản bị khóa
            { "thukho_tam", ("tk123", "ThuKho", false) }
        };

        public override bool XuLy(YeuCauTruyCap yeuCau)
        {
            if (!_danhSachNhanVien.ContainsKey(yeuCau.TenDangNhap))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"   [LỖI BƯỚC 2] Tài khoản '{yeuCau.TenDangNhap}' không tồn tại trong hệ thống!");
                Console.ResetColor();
                return false;
            }

            var taiKhoan = _danhSachNhanVien[yeuCau.TenDangNhap];
            if (taiKhoan.Password != yeuCau.MatKhau)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("   [LỖI BƯỚC 2] Mật khẩu xác thực không chính xác!");
                Console.ResetColor();
                return false;
            }

            // Gán quyền và trạng thái
            yeuCau.VaiTro = taiKhoan.Role;
            yeuCau.DaKhoa = taiKhoan.Locked;
            Console.WriteLine($"   [BƯỚC 2 - HỢP LỆ] Đăng nhập thành công! Vai trò: {yeuCau.VaiTro}");
            return base.XuLy(yeuCau);
        }
    }
}
