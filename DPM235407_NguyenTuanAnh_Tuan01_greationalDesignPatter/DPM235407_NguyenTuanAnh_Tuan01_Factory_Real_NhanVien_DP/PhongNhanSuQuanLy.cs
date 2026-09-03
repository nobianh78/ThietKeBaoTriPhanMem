using System;

namespace DPM235407_NguyenTuanAnh_Tuan01_Factory_Real_NhanVien_DP
{
    // Concrete Creator 2: Xử lý tuyển dụng/tạo tài khoản cho nhân viên quản lý
    public class PhongNhanSuQuanLy : PhongNhanSu
    {
        public override INhanVien TaoNhanVien()
        {
            return new NhanVienQuanLy();
        }
    }
}
