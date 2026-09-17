using System;

namespace DPM235407_NguyenTuanAnh_Tuan02_ChainOfResponsibility_Real_XacThuc_DP
{
    // Bước 1: Kiểm tra dữ liệu đăng nhập không được để trống
    public class KiemTraDuLieuTrongHandler : AbstractXacThucHandler
    {
        public override bool XuLy(YeuCauTruyCap yeuCau)
        {
            if (string.IsNullOrWhiteSpace(yeuCau.TenDangNhap) || string.IsNullOrWhiteSpace(yeuCau.MatKhau))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("   [LỖI BƯỚC 1] Tên đăng nhập và mật khẩu không được để trống!");
                Console.ResetColor();
                return false;
            }

            Console.WriteLine("   [BƯỚC 1 - HỢP LỆ] Dữ liệu nhập không rỗng.");
            return base.XuLy(yeuCau);
        }
    }
}
