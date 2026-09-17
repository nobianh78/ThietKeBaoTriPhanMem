using System;

namespace DPM235407_NguyenTuanAnh_Tuan02_Mediator_Real_DieuPhoi_DP
{
    // Bộ phận Vận chuyển: Giao thuốc bảo vệ thực vật đến tận đồng ruộng/đại lý
    public class BoPhanVanChuyen : BoPhanBase
    {
        public void GiaoHang(ThongTinDonHang donHang)
        {
            Console.WriteLine($"\n[BỘ PHẬN VẬN CHUYỂN] Bốc xếp hàng từ kho (Lô: {donHang.MaLoXuat}) lên xe tải...");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"   Xe tải AG-67B xuất phát giao {donHang.SoLuong} đơn vị thuốc đến: {donHang.DiaChiNhan}.");
            Console.WriteLine($"   Hoàn thành giao hàng và thu hộ tiền mặt: {donHang.TongThanhToan:N0} đ!");
            Console.ResetColor();

            TrungTamDieuPhoi?.ThongBao(this, "GiaoHangThanhCong", donHang);
        }
    }
}
