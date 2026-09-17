using System;

namespace DPM235407_NguyenTuanAnh_Tuan02_TemplateMethod_Real_BanHang_DP
{
    // Bán sỉ: Phục vụ đại lý cấp 2, Hợp tác xã nông nghiệp
    public class QuyTrinhBanSi : QuyTrinhBanHangTemplate
    {
        public override string GetLoaiHinh() => "BÁN SỈ ĐẠI LÝ / HTX";

        protected override void ApDungChietKhau(DonHangNongDuoc donHang)
        {
            // Bán buôn chiết khấu theo khối lượng lớn
            if (donHang.SoLuong >= 500)
            {
                donHang.ChietKhau = donHang.TienHangGoc * 0.15m;
                Console.WriteLine($"3. [CHIẾT KHẤU SỈ] Đơn hàng cực lớn (>=500) -> Chiết khấu 15%: -{donHang.ChietKhau:N0} đ");
            }
            else if (donHang.SoLuong >= 100)
            {
                donHang.ChietKhau = donHang.TienHangGoc * 0.10m;
                Console.WriteLine($"3. [CHIẾT KHẤU SỈ] Đơn hàng sỉ (>=100) -> Chiết khấu 10%: -{donHang.ChietKhau:N0} đ");
            }
        }

        protected override void TinhChiPhiVanChuyen(DonHangNongDuoc donHang)
        {
            // Bán sỉ vận chuyển bằng xe tải thùng 3.5 tấn: 15,000đ/km
            donHang.PhiVanChuyen = (decimal)(donHang.KhoangCachKm * 15000);
            Console.WriteLine($"4. [VẬN CHUYỂN XE TẢI] Cự ly {donHang.KhoangCachKm} km x 15,000đ/km = +{donHang.PhiVanChuyen:N0} đ");
        }

        protected override void HookDichVuPhatSinh(DonHangNongDuoc donHang)
        {
            // Dịch vụ phụ: Bốc vác xếp thùng nông dược tại kho người mua
            donHang.TenDichVu = "Bốc xếp pallet hạ hàng xuống kho";
            donHang.PhiDichVu = 250000;
            Console.WriteLine($"4.1 [DỊCH VỤ PHỤ] Cộng phụ phí bốc xếp xe tải: +{donHang.PhiDichVu:N0} đ");
        }
    }
}
