using System;

namespace DPM235407_NguyenTuanAnh_Tuan02_ChainOfResponsibility_Real_XacThuc_DP
{
    // Bước 3: Kiểm tra trạng thái hoạt động của nhân viên
    public class KiemTraKhoaTaiKhoanHandler : AbstractXacThucHandler
    {
        public override bool XuLy(YeuCauTruyCap yeuCau)
        {
            if (yeuCau.DaKhoa)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"   [LỖI BƯỚC 3] Tài khoản '{yeuCau.TenDangNhap}' hiện đang bị KHÓA! Vui lòng liên hệ quản lý.");
                Console.ResetColor();
                return false;
            }

            Console.WriteLine("   [BƯỚC 3 - HỢP LỆ] Tài khoản đang hoạt động bình thường.");
            return base.XuLy(yeuCau);
        }
    }
}
