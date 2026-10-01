using System;
namespace DPM235407_NguyenTuanAnh_BaiTap03_01_ComposingMethods._06_SplitTemporaryVariable
{
    // AFTER: Split Temporary Variable
    public class KhoHang_After
    {
        public void TinhToan(double dai, double rong)
        {
            double chuVi = 2 * (dai + rong);
            Console.WriteLine($"Chu vi: {chuVi}");
            double dienTich = dai * rong;
            Console.WriteLine($"Diện tích: {dienTich}");
        }
    }
}
