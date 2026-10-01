using System;
namespace DPM235407_NguyenTuanAnh_BaiTap03_02_MovingFeatures._08_IntroduceLocalExtension
{
    // REAL: Extension methods kiểm tra lô nông dược cận date
    public static class LoNongDuocExtensions_Real
    {
        public static string LayTrangThaiHSD(this DateTime hsd)
        {
            int soNgay = (hsd.Date - DateTime.Today).Days;
            if (soNgay < 0) return "❌ ĐÃ HẾT HẠN";
            if (soNgay <= 30) return $"⚠️ CẬN DATE (Còn {soNgay} ngày)";
            return $"✅ AN TOÀN (Còn {soNgay} ngày)";
        }
    }
}
