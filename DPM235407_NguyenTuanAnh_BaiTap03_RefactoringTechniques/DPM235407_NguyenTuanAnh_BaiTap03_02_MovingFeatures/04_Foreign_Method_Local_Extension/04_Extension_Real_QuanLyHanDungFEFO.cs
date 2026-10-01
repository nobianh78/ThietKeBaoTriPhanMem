using System;
using System.Collections.Generic;
using System.Linq;

namespace DPM235407_NguyenTuanAnh_BaiTap03_02_MovingFeatures._04_Foreign_Method_Local_Extension
{
    // =========================================================================
    // REAL APPLICATION (Hệ thống Nông Dược An Giang):
    // Xây dựng các Extension Methods chuyên biệt cho Lô Thuốc Nông Dược (`LoHangNongDuoc`):
    // - Lọc các lô cận hạn sử dụng (< 30 ngày) để xả hàng khuyến mãi
    // - Tự động sắp xếp xuất kho theo quy tắc FEFO (First Expired, First Out)
    // - Tính tổng giá trị tồn kho của các lô an toàn
    // =========================================================================

    public class LoHangNongDuoc
    {
        public string MaLo { get; set; } = string.Empty;
        public string TenSanPham { get; set; } = string.Empty;
        public int SoLuongTon { get; set; }
        public decimal DonGiaVon { get; set; }
        public DateTime HanSuDung { get; set; }

        public decimal GiaTriTonKho => SoLuongTon * DonGiaVon;
    }

    public static class LoHangNongDuocExtensions
    {
        // 1. Extension Method: Lấy danh sách các lô cần cảnh báo cận date
        public static IEnumerable<LoHangNongDuoc> LayCacLoCanDate(this IEnumerable<LoHangNongDuoc> source, int soNgayCanhBao = 30)
        {
            return source.Where(lo => lo.HanSuDung.IsCanDate(soNgayCanhBao));
        }

        // 2. Extension Method: Sắp xếp danh sách lô theo thứ tự ưu tiên FEFO
        public static IOrderedEnumerable<LoHangNongDuoc> SapXepTheoFEFO(this IEnumerable<LoHangNongDuoc> source)
        {
            return source.OrderBy(lo => lo.HanSuDung);
        }

        // 3. Extension Method: Định dạng in thông tin lô kho chuyên nghiệp
        public static void InDanhSachLoKho(this IEnumerable<LoHangNongDuoc> source, string tieuDe)
        {
            Console.WriteLine($"=== {tieuDe.ToUpper()} ===");
            Console.WriteLine($"{"MÃ LÔ",-14} | {"TÊN SẢN PHẨM",-28} | {"TỒN KHO",-8} | {"HẠN DÙNG",-12} | {"TRẠNG THÁI",-15}");
            Console.WriteLine(new string('-', 88));

            foreach (var lo in source)
            {
                string trangThai = lo.HanSuDung.IsDaHetHan() ? "❌ ĐÃ HẾT HẠN" :
                                   lo.HanSuDung.IsCanDate() ? "⚠️ CẬN DATE" : "✅ AN TOÀN";

                Console.WriteLine($"{lo.MaLo,-14} | {lo.TenSanPham,-28} | {lo.SoLuongTon,8} | {lo.HanSuDung,-12:dd/MM/yyyy} | {trangThai,-15}");
            }
            Console.WriteLine(new string('-', 88) + "\n");
        }
    }
}
