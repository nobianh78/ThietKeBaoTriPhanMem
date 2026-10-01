using System;

namespace DPM235407_NguyenTuanAnh_BaiTap03_01_ComposingMethods._04_Method_Object_Substitute_Algorithm
{
    // =========================================================================
    // BEFORE: Thuật toán phức tạp với quá nhiều biến cục bộ chằng chịt
    // Không thể dùng Extract Method thông thường vì các biến phụ thuộc lẫn nhau.
    // =========================================================================
    public class TinhToanPhucTap_Before
    {
        public double TinhThuongDoanhSoVaThue(int soLuongBan, double doanhSo, int thamNien, double heSoVungMien, bool datChiTieu)
        {
            double thuongCoBan = doanhSo * 0.02;
            double thuongThamNien = thamNien * 500000;
            double phuCapVung = doanhSo * heSoVungMien * 0.01;
            
            double tongThuongTruocThue = thuongCoBan + thuongThamNien + phuCapVung;
            if (datChiTieu)
            {
                tongThuongTruocThue *= 1.2;
            }
            if (soLuongBan > 1000)
            {
                tongThuongTruocThue += 2000000;
            }

            double thueTNCN = 0;
            if (tongThuongTruocThue > 10000000)
            {
                thueTNCN = (tongThuongTruocThue - 10000000) * 0.1;
            }

            return tongThuongTruocThue - thueTNCN;
        }
    }
}
