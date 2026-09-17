using System;

namespace DPM235407_NguyenTuanAnh_Tuan02_Command_Real_HoaDon_DP
{
    // Lệnh nhập dịch vụ phát sinh (bốc vác, kiểm nghiệm nồng độ thuốc, phun khảo nghiệm)
    public class ThemDichVuPhatSinhCommand : IHoaDonCommand
    {
        private readonly HoaDonBanHang _hoaDon;
        private readonly string _tenDichVu;
        private readonly decimal _chiPhiMoi;
        private decimal _chiPhiCu;
        private string _tenDichVuCu = string.Empty;

        public ThemDichVuPhatSinhCommand(HoaDonBanHang hoaDon, string tenDichVu, decimal chiPhi)
        {
            _hoaDon = hoaDon;
            _tenDichVu = tenDichVu;
            _chiPhiMoi = chiPhi;
        }

        public void Execute()
        {
            _chiPhiCu = _hoaDon.ChiPhiDichVuPhatSinh;
            _tenDichVuCu = _hoaDon.TenDichVuPhatSinh;
            _hoaDon.TenDichVuPhatSinh = _tenDichVu;
            _hoaDon.ChiPhiDichVuPhatSinh = _chiPhiMoi;
            Console.WriteLine($"   [THỰC THI] Thêm dịch vụ phụ '{_tenDichVu}': {_chiPhiMoi:N0} đ");
        }

        public void Undo()
        {
            _hoaDon.TenDichVuPhatSinh = _tenDichVuCu;
            _hoaDon.ChiPhiDichVuPhatSinh = _chiPhiCu;
            Console.WriteLine($"   [HOÀN TÁC] Khôi phục dịch vụ phụ về: '{_tenDichVuCu}' ({_chiPhiCu:N0} đ)");
        }

        public string GetMoTa() => $"Dịch vụ phát sinh: {_tenDichVu} ({_chiPhiMoi:N0} đ)";
    }
}
