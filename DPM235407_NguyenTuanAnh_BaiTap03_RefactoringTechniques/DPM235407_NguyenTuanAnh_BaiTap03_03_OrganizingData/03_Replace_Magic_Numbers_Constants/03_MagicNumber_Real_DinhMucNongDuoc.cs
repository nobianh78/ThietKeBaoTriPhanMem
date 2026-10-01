using System;

namespace DPM235407_NguyenTuanAnh_BaiTap03_03_OrganizingData._03_Replace_Magic_Numbers_Constants
{
    // =========================================================================
    // REAL APPLICATION (Hệ thống Nông Dược An Giang):
    // Quản lý các quy định định mức của đề tài đồ án môn học:
    // - Tồn kho an toàn tối thiểu (15 đơn vị)
    // - Ngưỡng cảnh báo cận hạn sử dụng (< 30 ngày)
    // - Mức chiết khấu đơn hàng lớn (> 5.000.000đ được giảm 5%)
    // - Phụ phí bốc dỡ xe tải (50.000đ/tấn)
    // =========================================================================

    public static class QuyDinhNongDuocAnGiang
    {
        public const int TonKhoAnToanToiThieu = 15;
        public const int SoNgayCanhBaoCanDate = 30;
        public const decimal DoanhSoApDungChietKhauLon = 5000000m;
        public const decimal TiLeChietKhauDonHangLon = 0.05m;
        public const decimal PhiBocVacMoiTan = 50000m;
        public const decimal ThueVATBaoVeThucVat = 0.05m;
    }

    public class QuanLyDinhMucKhoNongDuoc_Real
    {
        public void KiemTraLoHangTon(string tenThuoc, int soLuongTon, int soNgayConHSD)
        {
            Console.WriteLine($"--- KIỂM TRA ĐỊNH MỨC CHO SẢN PHẨM: {tenThuoc} ---");

            if (soLuongTon <= QuyDinhNongDuocAnGiang.TonKhoAnToanToiThieu)
            {
                Console.WriteLine($"⚠️ [CẢNH BÁO TỒN KHO] Tồn hiện tại {soLuongTon} <= Ngưỡng an toàn ({QuyDinhNongDuocAnGiang.TonKhoAnToanToiThieu}). Cần nhập thêm hàng!");
            }
            else
            {
                Console.WriteLine($"✅ Tồn kho an toàn: {soLuongTon} sản phẩm.");
            }

            if (soNgayConHSD <= QuyDinhNongDuocAnGiang.SoNgayCanhBaoCanDate)
            {
                Console.WriteLine($"⚠️ [CẢNH BÁO HẠN DÙNG] Còn {soNgayConHSD} ngày <= Ngưỡng cận date ({QuyDinhNongDuocAnGiang.SoNgayCanhBaoCanDate} ngày). Ưu tiên xuất FEFO!");
            }
            else
            {
                Console.WriteLine($"✅ Hạn dùng đảm bảo: Còn {soNgayConHSD} ngày.");
            }
            Console.WriteLine();
        }

        public decimal TinhChiPhiXuatDonHang(decimal tienHang, int soTanHang)
        {
            decimal tienChietKhau = 0;
            if (tienHang >= QuyDinhNongDuocAnGiang.DoanhSoApDungChietKhauLon)
            {
                tienChietKhau = tienHang * QuyDinhNongDuocAnGiang.TiLeChietKhauDonHangLon;
            }

            decimal phiBocDoz = soTanHang * QuyDinhNongDuocAnGiang.PhiBocVacMoiTan;
            decimal tienSauGiam = tienHang - tienChietKhau;
            decimal thueVAT = tienSauGiam * QuyDinhNongDuocAnGiang.ThueVATBaoVeThucVat;

            return tienSauGiam + phiBocDoz + thueVAT;
        }
    }
}
