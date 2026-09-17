using System;
using System.Collections.Generic;
using System.Linq;

namespace DPM235407_NguyenTuanAnh_Tuan02_Command_Real_HoaDon_DP
{
    // Receiver: Hóa đơn bán hàng nông dược An Giang
    public class HoaDonBanHang
    {
        public string MaHoaDon { get; set; }
        public string TenKhachHang { get; set; }
        public string NhanVienLap { get; set; }
        public DateTime NgayLap { get; set; }

        public List<SanPhamMua> DanhSachSanPham { get; } = new();
        public decimal ChiPhiVanChuyen { get; set; } = 0;
        public decimal ChiPhiDichVuPhatSinh { get; set; } = 0;
        public string TenDichVuPhatSinh { get; set; } = string.Empty;
        public decimal GiamGiaKhuyenMai { get; set; } = 0;

        public decimal TongTienHang => DanhSachSanPham.Sum(sp => sp.ThanhTien);
        public decimal TongThanhToan => Math.Max(0, TongTienHang + ChiPhiVanChuyen + ChiPhiDichVuPhatSinh - GiamGiaKhuyenMai);

        public HoaDonBanHang(string maHoaDon, string tenKhachHang, string nhanVienLap)
        {
            MaHoaDon = maHoaDon;
            TenKhachHang = tenKhachHang;
            NhanVienLap = nhanVienLap;
            NgayLap = DateTime.Now;
        }

        public void InHoaDon()
        {
            Console.WriteLine("\n--------------------------------------------------------------------------------");
            Console.WriteLine($" HOÁ ĐƠN BÁN HÀNG NÔNG DƯỢC - MÃ: {MaHoaDon}");
            Console.WriteLine($" Khách hàng: {TenKhachHang} | Nhân viên lập: {NhanVienLap} | Ngày: {NgayLap:dd/MM/yyyy HH:mm}");
            Console.WriteLine("--------------------------------------------------------------------------------");
            Console.WriteLine(string.Format("{0,-10} {1,-32} {2,8} {3,14} {4,14}", "Mã thuốc", "Tên nông dược", "SL", "Đơn giá", "Thành tiền"));
            foreach (var sp in DanhSachSanPham)
            {
                Console.WriteLine(string.Format("{0,-10} {1,-32} {2,8} {3,14:N0}đ {4,14:N0}đ", sp.MaThuoc, sp.TenThuoc, sp.SoLuong, sp.DonGia, sp.ThanhTien));
            }
            Console.WriteLine("--------------------------------------------------------------------------------");
            Console.WriteLine($"   Tổng tiền hàng gốc:          {TongTienHang,18:N0} đ");
            if (ChiPhiVanChuyen > 0)
                Console.WriteLine($"   + Phí vận chuyển tận ruộng:   {ChiPhiVanChuyen,18:N0} đ");
            if (ChiPhiDichVuPhatSinh > 0)
                Console.WriteLine($"   + Dịch vụ ({TenDichVuPhatSinh}): {ChiPhiDichVuPhatSinh,18:N0} đ");
            if (GiamGiaKhuyenMai > 0)
                Console.WriteLine($"   - Chiết khấu / Giảm giá KM:  {GiamGiaKhuyenMai,18:N0} đ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"   ===> TỔNG CỘNG THANH TOÁN:   {TongThanhToan,18:N0} đ");
            Console.ResetColor();
            Console.WriteLine("--------------------------------------------------------------------------------");
        }
    }
}
