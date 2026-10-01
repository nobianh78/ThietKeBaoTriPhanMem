using System;

namespace DPM235407_NguyenTuanAnh_BaiTap03_02_MovingFeatures._04_Foreign_Method_Local_Extension
{
    // =========================================================================
    // AFTER: Áp dụng kỹ thuật:
    // 1. Introduce Foreign Method (Tạo phương thức đối ngoại tại client)
    // 2. Introduce Local Extension / C# Extension Methods (Mở rộng kiểu dữ liệu có sẵn)
    // Trong C#, Extension Methods là kỹ thuật chuẩn mực hiện đại nhất của Local Extension.
    // =========================================================================
    public static class DateTimeNongDuocExtensions
    {
        public const int SoNgayCanhBaoCanDate = 30;

        public static int SoNgayConLaiDenHan(this DateTime hanSuDung)
        {
            return (hanSuDung.Date - DateTime.Today).Days;
        }

        public static bool IsDaHetHan(this DateTime hanSuDung)
        {
            return hanSuDung.SoNgayConLaiDenHan() < 0;
        }

        public static bool IsCanDate(this DateTime hanSuDung, int soNgayNguong = SoNgayCanhBaoCanDate)
        {
            int soNgay = hanSuDung.SoNgayConLaiDenHan();
            return soNgay >= 0 && soNgay <= soNgayNguong;
        }
    }

    public class KiemTraHanSuDung_After
    {
        public void KiemTraThuoc(DateTime hsdThuoc)
        {
            if (hsdThuoc.IsDaHetHan())
            {
                Console.WriteLine($"[AFTER] Thuốc đã hết hạn sử dụng cách đây {Math.Abs(hsdThuoc.SoNgayConLaiDenHan())} ngày!");
            }
            else if (hsdThuoc.IsCanDate())
            {
                Console.WriteLine($"[AFTER] CẢNH BÁO: Thuốc cận date, chỉ còn {hsdThuoc.SoNgayConLaiDenHan()} ngày!");
            }
            else
            {
                Console.WriteLine($"[AFTER] Thuốc an toàn sử dụng ({hsdThuoc.SoNgayConLaiDenHan()} ngày).");
            }
        }
    }
}
