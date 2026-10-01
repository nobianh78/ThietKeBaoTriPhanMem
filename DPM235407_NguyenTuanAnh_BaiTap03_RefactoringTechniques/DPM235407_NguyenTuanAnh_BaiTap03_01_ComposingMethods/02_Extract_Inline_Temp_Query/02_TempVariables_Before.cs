using System;

namespace DPM235407_NguyenTuanAnh_BaiTap03_01_ComposingMethods._02_Extract_Inline_Temp_Query
{
    // =========================================================================
    // BEFORE: Lạm dụng biến tạm (Temporary Variables) & biểu thức phức tạp
    // Sử dụng nhiều biến tạm `giaGoc`, `chietKhau`, `phiVanChuyen`, `thueVAT`
    // làm thân hàm cồng kềnh, khó trích xuất phương thức khác.
    // =========================================================================
    public class TinhGiaDonHang_Before
    {
        public int SoLuong { get; set; } = 50;
        public double DonGia { get; set; } = 120000;
        public bool KhachThanThiet { get; set; } = true;
        public double KhoangCachKm { get; set; } = 35;

        public double TinhTongTienPhaiTra()
        {
            // Biến tạm tính giá gốc
            double giaGoc = SoLuong * DonGia;

            // Biến tạm tính chiết khấu
            double tiLeChietKhau = 0.0;
            if (KhachThanThiet && giaGoc > 1000000)
            {
                tiLeChietKhau = 0.08;
            }
            else if (giaGoc > 5000000)
            {
                tiLeChietKhau = 0.05;
            }
            double tienChietKhau = giaGoc * tiLeChietKhau;

            // Biến tạm tính phí ship
            double phiShip = 0;
            if (KhoangCachKm > 20)
            {
                phiShip = (KhoangCachKm - 20) * 5000 + 30000;
            }
            else
            {
                phiShip = 30000;
            }

            // Biến tạm tính VAT
            double tienSauChietKhau = giaGoc - tienChietKhau;
            double vat = tienSauChietKhau * 0.1;

            double ketQuaCuoiCung = tienSauChietKhau + phiShip + vat;
            return ketQuaCuoiCung;
        }
    }
}
