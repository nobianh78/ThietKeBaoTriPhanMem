using System;

namespace DPM235407_NguyenTuanAnh_BaiTap03_01_ComposingMethods._02_Extract_Inline_Temp_Query
{
    // =========================================================================
    // AFTER: Áp dụng kỹ thuật:
    // 1. Replace Temp with Query (Thay biến tạm bằng phương thức truy vấn)
    // 2. Inline Temp (Loại bỏ các biến tạm trung gian không cần thiết)
    // 3. Extract Variable (Đặt tên rõ nghĩa cho các biểu thức điều kiện phức tạp)
    // =========================================================================
    public class TinhGiaDonHang_After
    {
        public int SoLuong { get; set; } = 50;
        public double DonGia { get; set; } = 120000;
        public bool KhachThanThiet { get; set; } = true;
        public double KhoangCachKm { get; set; } = 35;

        public double TinhTongTienPhaiTra()
        {
            // Thân hàm cực kỳ gọn gàng, rõ ràng logic kinh doanh
            return TienSauChietKhau + PhiVanChuyen + TienThueVAT;
        }

        // Query 1: Giá gốc
        public double GiaGoc => SoLuong * DonGia;

        // Query 2: Tỉ lệ chiết khấu (sử dụng Extract Variable cho điều kiện)
        public double TiLeChietKhau
        {
            get
            {
                bool duDieuKienKhachVip = KhachThanThiet && GiaGoc > 1000000;
                if (duDieuKienKhachVip) return 0.08;

                bool duDieuKienDonHangLon = GiaGoc > 5000000;
                if (duDieuKienDonHangLon) return 0.05;

                return 0.0;
            }
        }

        public double TienChietKhau => GiaGoc * TiLeChietKhau;

        public double TienSauChietKhau => GiaGoc - TienChietKhau;

        // Query 3: Phí vận chuyển
        public double PhiVanChuyen
        {
            get
            {
                const double phiCoBan = 30000;
                const double kmToiDaCoBan = 20;
                const double donGiaMoiKmVuot = 5000;

                if (KhoangCachKm > kmToiDaCoBan)
                {
                    double kmVuot = KhoangCachKm - kmToiDaCoBan;
                    return phiCoBan + (kmVuot * donGiaMoiKmVuot);
                }
                return phiCoBan;
            }
        }

        // Query 4: Tiền thuế VAT
        public double TienThueVAT => TienSauChietKhau * 0.1;
    }
}
