using System;

namespace DPM235407_NguyenTuanAnh_BaiTap03_02_MovingFeatures._04_Foreign_Method_Local_Extension
{
    // =========================================================================
    // BEFORE: Client cần các phương thức tiện ích cho một lớp của thư viện (ví dụ DateTime),
    // nhưng không thể sửa đổi mã nguồn lớp đó. Code tiện ích bị viết lặp đi lặp lại
    // rải rác ở khắp các màn hình / controller.
    // =========================================================================
    public class KiemTraHanSuDung_Before
    {
        public void KiemTraThuoc(DateTime hsdThuoc)
        {
            // Mã kiểm tra rải rác
            int soNgayConLai = (hsdThuoc.Date - DateTime.Today).Days;
            bool daHetHan = soNgayConLai < 0;
            bool canDate = soNgayConLai >= 0 && soNgayConLai <= 30;

            if (daHetHan)
            {
                Console.WriteLine($"[BEFORE] Thuốc đã hết hạn sử dụng cách đây {Math.Abs(soNgayConLai)} ngày!");
            }
            else if (canDate)
            {
                Console.WriteLine($"[BEFORE] CẢNH BÁO: Thuốc cận date, chỉ còn {soNgayConLai} ngày nữa là hết hạn!");
            }
            else
            {
                Console.WriteLine($"[BEFORE] Thuốc còn an toàn sử dụng ({soNgayConLai} ngày).");
            }
        }
    }
}
