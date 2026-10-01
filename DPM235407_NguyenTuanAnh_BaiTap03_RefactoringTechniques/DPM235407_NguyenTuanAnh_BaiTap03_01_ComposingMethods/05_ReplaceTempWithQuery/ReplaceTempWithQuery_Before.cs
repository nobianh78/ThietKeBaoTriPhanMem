namespace DPM235407_NguyenTuanAnh_BaiTap03_01_ComposingMethods._05_ReplaceTempWithQuery
{
    // BEFORE: Dùng biến tạm lưu kết quả tính toán
    public class HoaDon_Before
    {
        private int _soLuong = 50;
        private double _donGia = 120000;

        public double TinhTongTien()
        {
            double giaGoc = _soLuong * _donGia;
            double tiLeGiam = (giaGoc > 5000000) ? 0.05 : 0.02;
            return giaGoc * (1 - tiLeGiam);
        }
    }
}
