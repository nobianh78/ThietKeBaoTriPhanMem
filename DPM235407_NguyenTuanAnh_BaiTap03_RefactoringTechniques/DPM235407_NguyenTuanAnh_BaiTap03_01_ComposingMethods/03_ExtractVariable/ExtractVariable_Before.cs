using System;
namespace DPM235407_NguyenTuanAnh_BaiTap03_01_ComposingMethods._03_ExtractVariable
{
    // BEFORE: Biểu thức điều kiện phức tạp, khó hiểu
    public class DonHangKiemTra_Before
    {
        public void KiemTra(string nenTang, string trinhDuyet, int soLuong)
        {
            if (nenTang.ToUpper().IndexOf("WIN") > -1 && trinhDuyet.ToUpper().IndexOf("CHROME") > -1 && soLuong > 100)
            {
                Console.WriteLine("[BEFORE] Áp dụng ưu đãi đại lý số lượng lớn trên Windows/Chrome");
            }
        }
    }
}
