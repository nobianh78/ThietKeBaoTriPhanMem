using System;

namespace DPM235407_NguyenTuanAnh_Tuan02_Command_Real_HoaDon_DP
{
    // Lệnh nhập phí vận chuyển
    public class ThemPhiVanChuyenCommand : IHoaDonCommand
    {
        private readonly HoaDonBanHang _hoaDon;
        private readonly decimal _phiVanChuyenMoi;
        private decimal _phiVanChuyenCu;

        public ThemPhiVanChuyenCommand(HoaDonBanHang hoaDon, decimal phiVanChuyen)
        {
            _hoaDon = hoaDon;
            _phiVanChuyenMoi = phiVanChuyen;
        }

        public void Execute()
        {
            _phiVanChuyenCu = _hoaDon.ChiPhiVanChuyen;
            _hoaDon.ChiPhiVanChuyen = _phiVanChuyenMoi;
            Console.WriteLine($"   [THỰC THI] Nhập chi phí vận chuyển: {_phiVanChuyenMoi:N0} đ");
        }

        public void Undo()
        {
            _hoaDon.ChiPhiVanChuyen = _phiVanChuyenCu;
            Console.WriteLine($"   [HOÀN TÁC] Khôi phục phí vận chuyển về: {_phiVanChuyenCu:N0} đ");
        }

        public string GetMoTa() => $"Cập nhật phí vận chuyển: {_phiVanChuyenMoi:N0} đ";
    }
}
