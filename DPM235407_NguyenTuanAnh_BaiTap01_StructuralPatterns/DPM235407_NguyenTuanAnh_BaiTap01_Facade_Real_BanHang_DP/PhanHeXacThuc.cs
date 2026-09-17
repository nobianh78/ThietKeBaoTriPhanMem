using System;

namespace DPM235407_NguyenTuanAnh_BaiTap01_Facade_Real_BanHang_DP
{
    // [Subsystem 1]: Phân hệ xác thực đăng nhập và phân quyền nhân viên theo PDF
    public class PhanHeXacThuc
    {
        public bool KiemTraDangNhap(string maNV, string matKhau)
        {
            // Kiểm tra thông tin tài khoản nhân viên bán hàng
            if (maNV == "NV01" && matKhau == "123456")
            {
                Console.WriteLine("[Xác Thực] Nhân viên: Nguyễn Văn An (Mã: NV01) đăng nhập thành công!");
                return true;
            }
            Console.WriteLine("[Xác Thực] Đăng nhập thất bại: Sai tài khoản hoặc mật khẩu.");
            return false;
        }
    }
}
