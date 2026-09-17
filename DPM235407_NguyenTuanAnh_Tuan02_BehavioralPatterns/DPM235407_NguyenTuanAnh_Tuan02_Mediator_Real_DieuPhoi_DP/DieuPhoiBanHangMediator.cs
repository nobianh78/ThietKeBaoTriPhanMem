using System;

namespace DPM235407_NguyenTuanAnh_Tuan02_Mediator_Real_DieuPhoi_DP
{
    // Concrete Mediator: Điều phối toàn bộ chu trình xử lý đơn hàng
    public class DieuPhoiBanHangMediator : ITrungTamDieuPhoi
    {
        private readonly BoPhanBanHang _banHang;
        private readonly BoPhanKhoHang _khoHang;
        private readonly BoPhanKeToan _keToan;
        private readonly BoPhanVanChuyen _vanChuyen;

        public DieuPhoiBanHangMediator(BoPhanBanHang banHang, BoPhanKhoHang khoHang, BoPhanKeToan keToan, BoPhanVanChuyen vanChuyen)
        {
            _banHang = banHang;
            _banHang.GanDieuPhoi(this);

            _khoHang = khoHang;
            _khoHang.GanDieuPhoi(this);

            _keToan = keToan;
            _keToan.GanDieuPhoi(this);

            _vanChuyen = vanChuyen;
            _vanChuyen.GanDieuPhoi(this);
        }

        public void ThongBao(object nguonPhat, string suKien, object? duLieu = null)
        {
            if (duLieu is not ThongTinDonHang donHang) return;

            switch (suKien)
            {
                case "DonHangMoi":
                    Console.WriteLine("\n--> [MEDIATOR] Nhận đơn mới từ Bán Hàng -> Yêu cầu Kho Hàng phân lô và xuất kho...");
                    _khoHang.KiemTraVaXuatKho(donHang);
                    break;

                case "XuatKhoThanhCong":
                    Console.WriteLine("\n--> [MEDIATOR] Kho Hàng đã xuất xong -> Yêu cầu Kế Toán lập hóa đơn và tính chiết khấu...");
                    _keToan.LapHoaDonTaiChinh(donHang);
                    break;

                case "HoaDonDaLap":
                    Console.WriteLine("\n--> [MEDIATOR] Kế Toán đã chốt số tiền -> Yêu cầu Vận Chuyển điều xe giao hàng...");
                    _vanChuyen.GiaoHang(donHang);
                    break;

                case "GiaoHangThanhCong":
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine($"\n--> [MEDIATOR] Đơn hàng {donHang.MaDon} đã khép lại thành công trọn vẹn!");
                    Console.ResetColor();
                    break;
            }
        }
    }
}
