using System;

namespace DPM235407_NguyenTuanAnh_Tuan02_Observer_Real_TonKho_DP
{
    // Người quan sát: Thủ kho phụ trách tồn kho thực tế và bảo quản
    public class BoPhanThuKhoObserver : IKhoHangObserver
    {
        public string TenBoPhan => "Thủ Kho An Giang";

        public void CapNhat(ThongTinCanhBaoKho cb)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"   [THỦ KHO NHẬN TIN] Loại: {cb.Loai}");
            Console.WriteLine($"      Nội dung: {cb.NoiDung}");
            if (cb.Loai == LoaiCanhBao.TonKhoDuoiMucAnToan)
            {
                Console.WriteLine("      => Hành động: Soạn ngay phiếu đề xuất nhập thêm thuốc BVTV vào kho trung tâm!");
            }
            else if (cb.Loai == LoaiCanhBao.ThuocCanHanSuDung)
            {
                Console.WriteLine("      => Hành động: Đánh dấu tem màu đỏ lên thùng thuốc, ưu tiên xuất kho lô này ngay!");
            }
            Console.ResetColor();
        }
    }
}
