using System;

namespace DPM235407_NguyenTuanAnh_Tuan02_TemplateMethod_Real_BanHang_DP
{
    // Bán lẻ: Phục vụ trực tiếp hộ nông dân canh tác ruộng lúa
    public class QuyTrinhBanLe : QuyTrinhBanHangTemplate
    {
        public override string GetLoaiHinh() => "BÁN LẺ NÔNG DÂN";

        protected override void ApDungChietKhau(DonHangNongDuoc donHang)
        {
            // Bán lẻ áp dụng mã giảm giá voucher khuyến mãi
            if (!string.IsNullOrEmpty(donHang.MaVoucher))
            {
                donHang.ChietKhau = 50000; // Giảm 50k
                Console.WriteLine($"3. [KHUYẾN MÃI BÁN LẺ] Áp dụng mã Voucher '{donHang.MaVoucher}': -{donHang.ChietKhau:N0} đ");
            }
            else
            {
                Console.WriteLine("3. [KHUYẾN MÃI BÁN LẺ] Không có mã giảm giá.");
            }
        }

        protected override void TinhChiPhiVanChuyen(DonHangNongDuoc donHang)
        {
            // Bán lẻ giao bằng xe máy / shipper: Dưới 5km miễn phí, trên 5km tính 25,000đ
            if (donHang.KhoangCachKm <= 5.0)
            {
                donHang.PhiVanChuyen = 0;
                Console.WriteLine($"4. [VẬN CHUYỂN SHIPPER] Cự ly {donHang.KhoangCachKm} km <= 5km: MIỄN PHÍ GIAO HÀNG.");
            }
            else
            {
                donHang.PhiVanChuyen = 25000;
                Console.WriteLine($"4. [VẬN CHUYỂN SHIPPER] Cự ly {donHang.KhoangCachKm} km > 5km: Phí giao hàng xe máy +{donHang.PhiVanChuyen:N0} đ");
            }
        }

        protected override void HookDichVuPhatSinh(DonHangNongDuoc donHang)
        {
            // Bán lẻ: Miễn phí dịch vụ tư vấn kỹ sư nông nghiệp
            donHang.TenDichVu = "Tư vấn kỹ thuật pha thuốc miễn phí";
            donHang.PhiDichVu = 0;
            Console.WriteLine("4.1 [DỊCH VỤ PHỤ] Kèm tư vấn kỹ thuật phun phòng trừ sâu rầy (Miễn phí).");
        }
    }
}
