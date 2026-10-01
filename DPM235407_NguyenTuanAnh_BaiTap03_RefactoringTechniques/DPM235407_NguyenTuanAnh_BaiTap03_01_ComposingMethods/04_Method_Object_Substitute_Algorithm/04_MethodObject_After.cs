using System;

namespace DPM235407_NguyenTuanAnh_BaiTap03_01_ComposingMethods._04_Method_Object_Substitute_Algorithm
{
    // =========================================================================
    // AFTER: Áp dụng kỹ thuật:
    // 1. Replace Method with Method Object (Chuyển phương thức thành Lớp Đối Tượng Tính Toán)
    // 2. Substitute Algorithm (Thay thế thuật toán sạch sẽ, từng bước)
    // Biến toàn bộ tham số và biến cục bộ thành các trường của lớp mới.
    // =========================================================================
    public class TinhToanPhucTap_After
    {
        public double TinhThuongDoanhSoVaThue(int soLuongBan, double doanhSo, int thamNien, double heSoVungMien, bool datChiTieu)
        {
            return new BangTinhThuongCalculator(soLuongBan, doanhSo, thamNien, heSoVungMien, datChiTieu).Compute();
        }
    }

    public class BangTinhThuongCalculator
    {
        private readonly int _soLuongBan;
        private readonly double _doanhSo;
        private readonly int _thamNien;
        private readonly double _heSoVungMien;
        private readonly bool _datChiTieu;

        public BangTinhThuongCalculator(int soLuongBan, double doanhSo, int thamNien, double heSoVungMien, bool datChiTieu)
        {
            _soLuongBan = soLuongBan;
            _doanhSo = doanhSo;
            _thamNien = thamNien;
            _heSoVungMien = heSoVungMien;
            _datChiTieu = datChiTieu;
        }

        public double Compute()
        {
            double tongThuong = TinhTongThuongTruocThue();
            double thue = TinhThueTNCN(tongThuong);
            return tongThuong - thue;
        }

        private double TinhTongThuongTruocThue()
        {
            double tong = TinhThuongCoBan() + TinhThuongThamNien() + TinhPhuCapVung();
            if (_datChiTieu) tong *= 1.2;
            if (_soLuongBan > 1000) tong += 2000000;
            return tong;
        }

        private double TinhThuongCoBan() => _doanhSo * 0.02;
        private double TinhThuongThamNien() => _thamNien * 500000;
        private double TinhPhuCapVung() => _doanhSo * _heSoVungMien * 0.01;

        private double TinhThueTNCN(double thuongTruocThue)
        {
            const double nguongMienThue = 10000000;
            if (thuongTruocThue > nguongMienThue)
            {
                return (thuongTruocThue - nguongMienThue) * 0.1;
            }
            return 0;
        }
    }
}
