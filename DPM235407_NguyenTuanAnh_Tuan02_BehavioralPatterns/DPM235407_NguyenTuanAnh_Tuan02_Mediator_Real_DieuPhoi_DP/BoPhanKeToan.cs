using System;

namespace DPM235407_NguyenTuanAnh_Tuan02_Mediator_Real_DieuPhoi_DP
{
    // Bộ phận Kế toán: Tính chiết khấu giảm giá, dịch vụ phụ và xuất hóa đơn
    public class BoPhanKeToan : BoPhanBase
    {
        public void LapHoaDonTaiChinh(ThongTinDonHang donHang)
        {
            Console.WriteLine($"\n[BỘ PHẬN KẾ TOÁN] Lập hóa đơn và tính các khoản giảm giá, chi phí...");
            
            // Áp dụng chiết khấu mùa vụ 10% nếu mua trên 30 sản phẩm
            if (donHang.SoLuong >= 30)
            {
                donHang.ChietKhau = donHang.TongTienHang * 0.10m;
                Console.WriteLine($"   Áp dụng chiết khấu đại lý sỉ (10%): -{donHang.ChietKhau:N0} đ");
            }

            // Phí vận chuyển xe tải
            donHang.PhiVanChuyen = 180000;
            Console.WriteLine($"   Cộng phí cước vận chuyển giao tận xã: +{donHang.PhiVanChuyen:N0} đ");
            Console.WriteLine($"   ===> TỔNG HÓA ĐƠN CẦN THANH TOÁN: {donHang.TongThanhToan:N0} đ");

            TrungTamDieuPhoi?.ThongBao(this, "HoaDonDaLap", donHang);
        }
    }
}
