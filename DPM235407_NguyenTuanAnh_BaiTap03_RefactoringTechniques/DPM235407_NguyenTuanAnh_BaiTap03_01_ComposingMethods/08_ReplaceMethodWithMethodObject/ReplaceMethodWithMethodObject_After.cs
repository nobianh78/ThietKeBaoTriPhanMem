namespace DPM235407_NguyenTuanAnh_BaiTap03_01_ComposingMethods._08_ReplaceMethodWithMethodObject
{
    // AFTER: Replace Method with Method Object
    public class TinhToanPhucTap_After
    {
        public double TinhThuong(double doanhSo, int thamNien, double heSo)
            => new TinhThuongCalculator(doanhSo, thamNien, heSo).Compute();
    }
    public class TinhThuongCalculator
    {
        private readonly double _doanhSo;
        private readonly int _thamNien;
        private readonly double _heSo;
        public TinhThuongCalculator(double doanhSo, int thamNien, double heSo)
        {
            _doanhSo = doanhSo; _thamNien = thamNien; _heSo = heSo;
        }
        public double Compute() => TinhCoBan() + TinhThamNien() + TinhVung();
        private double TinhCoBan() => _doanhSo * 0.05;
        private double TinhThamNien() => _thamNien * 200000;
        private double TinhVung() => _doanhSo * _heSo * 0.01;
    }
}
