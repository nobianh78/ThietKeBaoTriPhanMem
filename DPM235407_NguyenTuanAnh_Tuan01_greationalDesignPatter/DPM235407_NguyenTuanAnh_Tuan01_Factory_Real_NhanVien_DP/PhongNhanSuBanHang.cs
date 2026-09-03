using System;

namespace DPM235407_NguyenTuanAnh_Tuan01_Factory_Real_NhanVien_DP
{
    // Concrete Creator 1: Xử lý tuyển dụng/tạo tài khoản cho nhân viên bán hàng
    public class PhongNhanSuBanHang : PhongNhanSu
    {
        public override INhanVien TaoNhanVien()
        {
            return new NhanVienBanHang();
        }
    }
}
