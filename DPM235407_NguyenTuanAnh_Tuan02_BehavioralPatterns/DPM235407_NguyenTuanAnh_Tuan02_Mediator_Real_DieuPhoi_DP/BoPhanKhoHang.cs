using System;

namespace DPM235407_NguyenTuanAnh_Tuan02_Mediator_Real_DieuPhoi_DP
{
    // Bộ phận Kho hàng: Kiểm tra tồn kho thuốc BVTV và phân lô xuất kho
    public class BoPhanKhoHang : BoPhanBase
    {
        public bool KiemTraVaXuatKho(ThongTinDonHang donHang)
        {
            Console.WriteLine($"\n[BỘ PHẬN KHO HÀNG] Kiểm tra tồn kho thuốc '{donHang.TenThuoc}'...");
            // Giả lập phân lô tự động theo HSD trước xuất trước (FEFO)
            donHang.MaLoXuat = "LO-AG-2025/HSD-2027";
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"   Đã trừ kho thành công {donHang.SoLuong} sản phẩm! Phân vào Lô: {donHang.MaLoXuat}");
            Console.ResetColor();

            TrungTamDieuPhoi?.ThongBao(this, "XuatKhoThanhCong", donHang);
            return true;
        }
    }
}
