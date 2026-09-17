using System;

namespace DPM235407_NguyenTuanAnh_Tuan02_Observer_Real_TonKho_DP
{
    // Người quan sát: Nhân viên bán hàng trực tiếp với nông dân
    public class NhanVienBanHangObserver : IKhoHangObserver
    {
        public string TenBoPhan => "Nhân Viên Bán Hàng";

        public void CapNhat(ThongTinCanhBaoKho cb)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"   [BÁN HÀNG NHẬN TIN] Loại: {cb.Loai}");
            Console.WriteLine($"      Nội dung: {cb.NoiDung}");
            if (cb.Loai == LoaiCanhBao.KhuyenMaiGiaMoi)
            {
                Console.WriteLine("      => Hành động: Nhắn tin Zalo/gọi điện mời nông dân tham gia nhận ưu đãi giá mới!");
            }
            else if (cb.Loai == LoaiCanhBao.TonKhoDuoiMucAnToan)
            {
                Console.WriteLine("      => Hành động: Thông báo với khách thuốc sắp tạm hết, xin hẹn giao đợt tiếp theo.");
            }
            Console.ResetColor();
        }
    }
}
