using System;

namespace DPM235407_NguyenTuanAnh_Tuan02_Mediator_Real_DieuPhoi_DP
{
    // Bộ phận Bán hàng: Tiếp nhận yêu cầu từ nông dân hoặc đại lý
    public class BoPhanBanHang : BoPhanBase
    {
        public void TiepNhanDonHang(ThongTinDonHang donHang)
        {
            Console.WriteLine($"\n[BỘ PHẬN BÁN HÀNG] Tiếp nhận đơn hàng {donHang.MaDon} từ khách: {donHang.TenKhachHang}");
            Console.WriteLine($"   Sản phẩm: {donHang.TenThuoc} | Số lượng: {donHang.SoLuong} | Địa chỉ: {donHang.DiaChiNhan}");
            
            // Thông báo sang trung tâm điều phối
            TrungTamDieuPhoi?.ThongBao(this, "DonHangMoi", donHang);
        }
    }
}
