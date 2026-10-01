using System;
namespace DPM235407_NguyenTuanAnh_BaiTap03_01_ComposingMethods._06_SplitTemporaryVariable
{
    // BEFORE: Tái sử dụng biến tạm temp cho 2 mục đích khác nhau
    public class KhoHang_Before
    {
        public void TinhToan(double dai, double rong)
        {
            double temp = 2 * (dai + rong);
            Console.WriteLine($"Chu vi: {temp}");
            temp = dai * rong;
            Console.WriteLine($"Diện tích: {temp}");
        }
    }
}
