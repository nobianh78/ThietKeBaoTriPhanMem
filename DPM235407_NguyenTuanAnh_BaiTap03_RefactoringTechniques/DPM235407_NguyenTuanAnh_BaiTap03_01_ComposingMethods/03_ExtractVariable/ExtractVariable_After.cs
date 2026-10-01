using System;
namespace DPM235407_NguyenTuanAnh_BaiTap03_01_ComposingMethods._03_ExtractVariable
{
    // AFTER: Extract Variable
    public class DonHangKiemTra_After
    {
        public void KiemTra(string nenTang, string trinhDuyet, int soLuong)
        {
            bool isWindowsOS = nenTang.ToUpper().Contains("WIN");
            bool isChromeBrowser = trinhDuyet.ToUpper().Contains("CHROME");
            bool isDonHangLon = soLuong > 100;

            if (isWindowsOS && isChromeBrowser && isDonHangLon)
            {
                Console.WriteLine("[AFTER] Áp dụng ưu đãi đại lý số lượng lớn trên Windows/Chrome");
            }
        }
    }
}
