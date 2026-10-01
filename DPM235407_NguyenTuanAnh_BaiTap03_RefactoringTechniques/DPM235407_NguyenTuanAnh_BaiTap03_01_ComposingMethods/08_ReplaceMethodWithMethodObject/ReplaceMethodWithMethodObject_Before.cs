namespace DPM235407_NguyenTuanAnh_BaiTap03_01_ComposingMethods._08_ReplaceMethodWithMethodObject
{
    // BEFORE: Hàm phức tạp nhiều biến cục bộ
    public class TinhToanPhucTap_Before
    {
        public double TinhThuong(double doanhSo, int thamNien, double heSo)
        {
            double thuongCoBan = doanhSo * 0.05;
            double thuongTN = thamNien * 200000;
            double thuongVung = doanhSo * heSo * 0.01;
            return thuongCoBan + thuongTN + thuongVung;
        }
    }
}
