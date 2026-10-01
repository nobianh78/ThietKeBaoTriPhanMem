using System;

namespace DPM235407_NguyenTuanAnh_BaiTap03_02_MovingFeatures._03_Hide_Delegate_Remove_MiddleMan
{
    // =========================================================================
    // REAL APPLICATION (Hệ thống Nông Dược An Giang):
    // Trong mã nguồn cũ `frmBanLe.cs`, để lấy tên thuốc và giá bán từ chi tiết phiếu:
    // `chiTiet.MaSanPham.SanPham.GiaBanLe` hoặc `masp.SanPham.DonGiaNhap`.
    // REFACTOR: `ChiTietPhieuBan` và `MaSanPham` tự đóng gói việc ủy nhiệm (Hide Delegate)
    // cung cấp các phương thức `TenThuoc`, `GiaBanLe`, `GiaBanSi` trực tiếp.
    // =========================================================================

    public class ThongTinThuocBVTV
    {
        public string TenThuoc { get; set; } = "Tilt Super 300EC";
        public string HoatChatChinh { get; set; } = "Difenoconazole 150g/l + Propiconazole 150g/l";
        public decimal GiaBanLeChuan { get; set; } = 240000;
        public decimal GiaBanSiChuan { get; set; } = 215000;
    }

    public class LoMaSanPhamNongDuoc
    {
        public string MaLoVach { get; set; } = "LOT-2026-TIL-01";
        public DateTime HanSuDung { get; set; } = DateTime.Today.AddMonths(18);
        private ThongTinThuocBVTV ThuocBVTV { get; set; } = new();

        public LoMaSanPhamNongDuoc(string maLo, DateTime hsd, ThongTinThuocBVTV thuoc)
        {
            MaLoVach = maLo;
            HanSuDung = hsd;
            ThuocBVTV = thuoc;
        }

        // Hide Delegate: Cung cấp trực tiếp các thông tin thuốc mà không để lộ đối tượng ThuocBVTV
        public string TenThuoc => ThuocBVTV.TenThuoc;
        public string HoatChat => ThuocBVTV.HoatChatChinh;
        public decimal GiaBanLe => ThuocBVTV.GiaBanLeChuan;
        public decimal GiaBanSi => ThuocBVTV.GiaBanSiChuan;
    }

    public class DongBanHangChiTiet
    {
        private LoMaSanPhamNongDuoc LoSanPham { get; set; }
        public int SoLuong { get; set; }

        public DongBanHangChiTiet(LoMaSanPhamNongDuoc lo, int soLuong)
        {
            LoSanPham = lo;
            SoLuong = soLuong;
        }

        // Hide Delegate: Ủy quyền truy xuất giá và tên thuốc
        public string TenThuoc => LoSanPham.TenThuoc;
        public string SoLo => LoSanPham.MaLoVach;
        public decimal DonGia => LoSanPham.GiaBanLe;
        public decimal ThanhTien => SoLuong * DonGia;

        public void InThongTinChiTiet()
        {
            Console.WriteLine($" -> Thuốc: {TenThuoc} (Lô: {SoLo}) | SL: {SoLuong} chai | Đơn giá: {DonGia:N0} đ | Thành tiền: {ThanhTien:N0} đ");
        }
    }
}
