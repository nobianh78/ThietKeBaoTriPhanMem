using System;

namespace DPM235407_NguyenTuanAnh_Tuan02_Command_Real_HoaDon_DP
{
    // Lệnh thêm mặt hàng thuốc vào hóa đơn
    public class ThemSanPhamCommand : IHoaDonCommand
    {
        private readonly HoaDonBanHang _hoaDon;
        private readonly SanPhamMua _sanPham;

        public ThemSanPhamCommand(HoaDonBanHang hoaDon, SanPhamMua sanPham)
        {
            _hoaDon = hoaDon;
            _sanPham = sanPham;
        }

        public void Execute()
        {
            _hoaDon.DanhSachSanPham.Add(_sanPham);
            Console.WriteLine($"   [THỰC THI] Thêm thuốc '{_sanPham.TenThuoc}' (SL: {_sanPham.SoLuong}) vào hóa đơn.");
        }

        public void Undo()
        {
            _hoaDon.DanhSachSanPham.Remove(_sanPham);
            Console.WriteLine($"   [HOÀN TÁC] Đã xóa thuốc '{_sanPham.TenThuoc}' khỏi hóa đơn.");
        }

        public string GetMoTa() => $"Thêm thuốc: {_sanPham.TenThuoc} ({_sanPham.SoLuong} x {_sanPham.DonGia:N0}đ)";
    }
}
