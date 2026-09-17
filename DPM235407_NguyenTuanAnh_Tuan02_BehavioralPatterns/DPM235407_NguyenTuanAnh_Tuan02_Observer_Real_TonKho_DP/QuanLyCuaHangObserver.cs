using System;

namespace DPM235407_NguyenTuanAnh_Tuan02_Observer_Real_TonKho_DP
{
    // Người quan sát: Ban giám đốc / Quản lý kiểm soát rủi ro
    public class QuanLyCuaHangObserver : IKhoHangObserver
    {
        public string TenBoPhan => "Quản Lý Cửa Hàng";

        public void CapNhat(ThongTinCanhBaoKho cb)
        {
            if (cb.Loai == LoaiCanhBao.ThuocCanHanSuDung)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"   [QUẢN LÝ NHẬN BÁO CÁO KHẨN CẤP]");
                Console.WriteLine($"      Cảnh báo: {cb.NoiDung}");
                Console.WriteLine("      => Chỉ đạo: Ký quyết định áp dụng chiết khấu xả kho giảm giá 25% trước khi hết hạn!");
                Console.ResetColor();
            }
        }
    }
}
