namespace DPM235407_NguyenTuanAnh_BaiTap03_01_ComposingMethods._05_ReplaceTempWithQuery
{
    // AFTER: Replace Temp with Query
    public class HoaDon_After
    {
        private int _soLuong = 50;
        private double _donGia = 120000;

        public double GiaGoc => _soLuong * _donGia;
        public double TiLeGiam => (GiaGoc > 5000000) ? 0.05 : 0.02;
        public double TinhTongTien() => GiaGoc * (1 - TiLeGiam);
    }
}
