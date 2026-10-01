using System;
using System.Text;
using DPM235407_NguyenTuanAnh_BaiTap03_02_MovingFeatures._08_IntroduceLocalExtension;

namespace DPM235407_NguyenTuanAnh_BaiTap03_02_MovingFeatures
{
    class Program
    {
        static void Main()
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.WriteLine("================================================================================");
            Console.WriteLine("   BÀI TẬP 03 - NHÓM 2: MOVING FEATURES (ĐẦY ĐỦ 8 KỸ THUẬT)");
            Console.WriteLine("   Học viên: Nguyễn Tuấn Anh - MSSV: DPM235407 - Lớp: Cao học K24");
            Console.WriteLine("================================================================================\n");

            // 1. Move Method
            Console.WriteLine(">>> 1. MOVE METHOD <<<");
            var phieu = new _01_MoveMethod.PhieuBanNongDuoc_Real();
            phieu.GhiNhanThanhToan(3000000);
            Console.WriteLine($"[REAL] Phiếu bán còn nợ: {phieu.ConNo:N0} VNĐ");

            // 2. Move Field
            Console.WriteLine("\n>>> 2. MOVE FIELD <<<");
            var ct = new _02_MoveField.ChiTietDonHang_Real();
            Console.WriteLine($"[REAL] Thuốc: {ct.Thuoc.TenThuoc} - Quy cách: {ct.Thuoc.QuyCach}");

            // 3. Extract Class
            Console.WriteLine("\n>>> 3. EXTRACT CLASS <<<");
            var kh = new _03_ExtractClass.KhachHangNongDan_Real();
            Console.WriteLine($"[REAL] KH: {kh.HoTen} | Địa điểm giao: {kh.DiaDiemGiao.TenCanhDong} ({kh.DiaDiemGiao.ToaDoGPS})");

            // 4. Inline Class
            Console.WriteLine("\n>>> 4. INLINE CLASS <<<");
            var bg = new _04_InlineClass.BaoGiaNongDuoc_Real();
            Console.WriteLine($"[REAL] Báo giá: {bg.TenThuoc} = {bg.DonGiaVND:N0} VNĐ");

            // 5. Hide Delegate
            Console.WriteLine("\n>>> 5. HIDE DELEGATE <<<");
            var lo = new _05_HideDelegate.LoHangNongDuoc_Real();
            Console.WriteLine($"[REAL] Thuốc từ lô: {lo.TenThuoc} | Đơn giá: {lo.DonGia:N0} VNĐ");

            // 6. Remove Middle Man
            Console.WriteLine("\n>>> 6. REMOVE MIDDLE MAN <<<");
            var pb = new _06_RemoveMiddleMan.PhieuBanLe_Real();
            Console.WriteLine($"[REAL] Vị trí lấy hàng: {pb.Kho.ViTriDay}");

            // 7. Introduce Foreign Method
            Console.WriteLine("\n>>> 7. INTRODUCE FOREIGN METHOD <<<");
            DateTime ngayGiao = _07_IntroduceForeignMethod.LichGiaoPhanBon_Real.TinhNgayGiaoNongDuoc(DateTime.Today);
            Console.WriteLine($"[REAL] Ngày đặt: {DateTime.Today:dd/MM/yyyy} -> Dự kiến giao: {ngayGiao:dd/MM/yyyy}");

            // 8. Introduce Local Extension
            Console.WriteLine("\n>>> 8. INTRODUCE LOCAL EXTENSION <<<");
            Console.WriteLine($"[REAL] Hạn dùng 15 ngày tới: {DateTime.Today.AddDays(15).LayTrangThaiHSD()}");
            Console.WriteLine($"[REAL] Hạn dùng đã qua 5 ngày: {DateTime.Today.AddDays(-5).LayTrangThaiHSD()}");

            Console.WriteLine("\n================================================================================");
            Console.WriteLine("          HOÀN THÀNH 8/8 KỸ THUẬT MOVING FEATURES!");
            Console.WriteLine("================================================================================");
        }
    }
}
