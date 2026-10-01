using System;
using System.Collections.Generic;
using System.Text;

namespace DPM235407_NguyenTuanAnh_BaiTap03_01_ComposingMethods
{
    class Program
    {
        static void Main()
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.WriteLine("================================================================================");
            Console.WriteLine("   BÀI TẬP 03 - NHÓM 1: COMPOSING METHODS (ĐẦY ĐỦ 9 KỸ THUẬT)");
            Console.WriteLine("   Học viên: Nguyễn Tuấn Anh - MSSV: DPM235407 - Lớp: Cao học K24");
            Console.WriteLine("================================================================================\n");

            // 1. Extract Method
            Console.WriteLine(">>> 1. EXTRACT METHOD <<<");
            new _01_ExtractMethod.InPhieuBanHang_After().InThongTinPhieu("PB01", "Đại lý Bảy Lúa", 5000000);
            new _01_ExtractMethod.LapPhieuBanLeNongDuoc_Real().LuuPhieu("PB-AG-01", "HTX Tri Tôn", new() { ("Tilt Super", 10, 240000), ("Radiant", 5, 185000) });

            // 2. Inline Method
            Console.WriteLine("\n>>> 2. INLINE METHOD <<<");
            Console.WriteLine($"[AFTER] Đủ điều kiện CK: {new _02_InlineMethod.KiemTraGiamGia_After().DuDieuKienChietKhau()}");
            Console.WriteLine($"[REAL] Cần nhập thêm thuốc (tồn 10 chai): {new _02_InlineMethod.KiemTraTonKho_Real().CanNhapThemThuocBVTV(10)}");

            // 3. Extract Variable
            Console.WriteLine("\n>>> 3. EXTRACT VARIABLE <<<");
            new _03_ExtractVariable.DonHangKiemTra_After().KiemTra("Windows 11", "Chrome", 150);
            Console.WriteLine($"[REAL] Giá sau ưu đãi HTX vụ Đông Xuân: {new _03_ExtractVariable.TinhChietKhauMuaVu_Real().TinhGiaSauUuDai(10000000, true, true, 4):N0} VNĐ");

            // 4. Inline Temp
            Console.WriteLine("\n>>> 4. INLINE TEMP <<<");
            Console.WriteLine($"[REAL] Thuốc đặc trị: {new _04_InlineTemp.KiemTraThuocBaoVeThucVat_Real().IsThuocDacTri(new())}");

            // 5. Replace Temp with Query
            Console.WriteLine("\n>>> 5. REPLACE TEMP WITH QUERY <<<");
            var hd = new _05_ReplaceTempWithQuery.HoaDonBanSiNongDuoc_Real();
            Console.WriteLine($"[REAL] Tiền gốc: {hd.TienGoc:N0} đ | CK: {hd.ChietKhau:N0} đ | VAT: {hd.ThueVAT:N0} đ | Tổng: {hd.TongThanhToan:N0} đ");

            // 6. Split Temporary Variable
            Console.WriteLine("\n>>> 6. SPLIT TEMPORARY VARIABLE <<<");
            new _06_SplitTemporaryVariable.KhoHang_After().TinhToan(20, 15);
            new _06_SplitTemporaryVariable.TinhToanGiaoHangNongDuoc_Real().TinhChiPhi(40, 350000);

            // 7. Remove Assignments to Parameters
            Console.WriteLine("\n>>> 7. REMOVE ASSIGNMENTS TO PARAMETERS <<<");
            Console.WriteLine($"[REAL] Giá phân bón trợ giá hộ nghèo (10 bao x 450k): {new _07_RemoveAssignmentsToParameters.TroGiaPhanBon_Real().TinhGiaCuoiCung(450000, 10, true):N0} đ");

            // 8. Replace Method with Method Object
            Console.WriteLine("\n>>> 8. REPLACE METHOD WITH METHOD OBJECT <<<");
            var bqgq = new _08_ReplaceMethodWithMethodObject.TinhGiaBinhQuanGiaQuyenCalculator_Real(new() { (100, 150000), (200, 165000) }, 500000);
            Console.WriteLine($"[REAL] Đơn giá bình quân gia quyền xuất kho: {bqgq.TinhDonGiaBQGQ():N0} VNĐ");

            // 9. Substitute Algorithm
            Console.WriteLine("\n>>> 9. SUBSTITUTE ALGORITHM <<<");
            var hetHan = new _09_SubstituteAlgorithm.QuanLyThuocHetHan_Real().LocThuocHetHan(new() { {"Tilt Super", 15}, {"Beam 75WP", -3}, {"Kasumin", 0} });
            Console.WriteLine($"[REAL] Danh sách thuốc hết hạn: {string.Join(", ", hetHan)}");

            Console.WriteLine("\n================================================================================");
            Console.WriteLine("          HOÀN THÀNH 9/9 KỸ THUẬT COMPOSING METHODS!");
            Console.WriteLine("================================================================================");
        }
    }
}
