using System;

namespace DPM235407_NguyenTuanAnh_Tuan02_Command_Real_HoaDon_DP
{
    // Lệnh nhập chiết khấu / giảm giá khuyến mãi
    public class ApDungGiamGiaCommand : IHoaDonCommand
    {
        private readonly HoaDonBanHang _hoaDon;
        private readonly decimal _giamGiaMoi;
        private decimal _giamGiaCu;

        public ApDungGiamGiaCommand(HoaDonBanHang hoaDon, decimal soTienGiamGia)
        {
            _hoaDon = hoaDon;
            _giamGiaMoi = soTienGiamGia;
        }

        public void Execute()
        {
            _giamGiaCu = _hoaDon.GiamGiaKhuyenMai;
            _hoaDon.GiamGiaKhuyenMai = _giamGiaMoi;
            Console.WriteLine($"   [THỰC THI] Áp dụng chiết khấu giảm giá khuyến mãi: {_giamGiaMoi:N0} đ");
        }

        public void Undo()
        {
            _hoaDon.GiamGiaKhuyenMai = _giamGiaCu;
            Console.WriteLine($"   [HOÀN TÁC] Khôi phục chiết khấu giảm giá về: {_giamGiaCu:N0} đ");
        }

        public string GetMoTa() => $"Áp dụng chiết khấu: {_giamGiaMoi:N0} đ";
    }
}
