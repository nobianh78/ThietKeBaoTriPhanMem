using System;
using System.Collections.Generic;
using System.Text;
using DPM235407_NguyenTuanAnh_BaiTap03_01_ComposingMethods._01_Extract_Inline_Method;
using DPM235407_NguyenTuanAnh_BaiTap03_01_ComposingMethods._02_Extract_Inline_Temp_Query;
using DPM235407_NguyenTuanAnh_BaiTap03_01_ComposingMethods._03_Split_Temp_Remove_Assignments;
using DPM235407_NguyenTuanAnh_BaiTap03_01_ComposingMethods._04_Method_Object_Substitute_Algorithm;

namespace DPM235407_NguyenTuanAnh_BaiTap03_01_ComposingMethods
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.WriteLine("================================================================================");
            Console.WriteLine("   BÀI TẬP 03 - NHÓM 1: COMPOSING METHODS (TỔ CHỨC LẠI CÁC PHƯƠNG THỨC)");
            Console.WriteLine("   Học viên: Nguyễn Tuấn Anh - MSSV: DPM235407 - Lớp: Cao học K24");
            Console.WriteLine("================================================================================\n");

            // 1. EXTRACT METHOD & INLINE METHOD
            Console.WriteLine(">>> 1. DEMO: EXTRACT METHOD (TRÍCH XUẤT PHƯƠNG THỨC) <<<");
            Console.WriteLine("[BEFORE] Chạy phiếu bán dài:");
            new PhieuBanHang_Before().InThongTinPhieuBan();

            Console.WriteLine("[AFTER] Chạy phiếu bán đã trích xuất phương thức:");
            new PhieuBanHang_After().InThongTinPhieuBan();

            Console.WriteLine("[REAL] Thực tế nghiệp vụ lập phiếu bán nông dược (frmBanLe.cs):");
            var realBanLe = new XuLyPhieuBanLeNongDuoc_Real
            {
                MaPhieu = "PB-AG-2026-088",
                KhachHang = "Hợp tác xã Nông nghiệp Thoại Sơn",
                SoTienDaTra = 8000000,
                ChiTietList = new List<DongChiTietPhieuBan>
                {
                    new DongChiTietPhieuBan { MaLoThuoc = "LO-RAD-2026", TenThuoc = "Radiant 60SC trị bọ trĩ", SoLuong = 20, DonGia = 185000, HanSuDung = DateTime.Today.AddMonths(18) },
                    new DongChiTietPhieuBan { MaLoThuoc = "LO-TIL-2026", TenThuoc = "Tilt Super 300EC đạo ôn", SoLuong = 15, DonGia = 240000, HanSuDung = DateTime.Today.AddMonths(12) },
                    new DongChiTietPhieuBan { MaLoThuoc = "LO-AMI-2026", TenThuoc = "Amistar Top 325SC lem lép hạt", SoLuong = 10, DonGia = 310000, HanSuDung = DateTime.Today.AddMonths(24) }
                }
            };
            realBanLe.XuLyLuuPhieuBanLe();

            // 2. REPLACE TEMP WITH QUERY & EXTRACT VARIABLE
            Console.WriteLine("\n>>> 2. DEMO: REPLACE TEMP WITH QUERY & EXTRACT VARIABLE <<<");
            var donHangAfter = new TinhGiaDonHang_After();
            Console.WriteLine($"[AFTER] Tiền thanh toán tính theo Query: {donHangAfter.TinhTongTienPhaiTra():N0} đ (Phí ship: {donHangAfter.PhiVanChuyen:N0} đ, Chiết khấu: {donHangAfter.TienChietKhau:N0} đ)");

            Console.WriteLine("\n[REAL] Bảng tính giá sỉ theo cấp đại lý (frmBanSi.cs):");
            var banSiReal = new DonHangBanSiNongDuoc_Real
            {
                TenVatTu = "Thuốc trừ bệnh Anvil 5SC (Chai 1L)",
                SoLuongChai = 300,
                DonGiaNiemYet = 220000,
                CapBacDaiLy = CapDaiLy.DaiLyCap1,
                CoHoTroGiaoXeTaiTanRuong = true,
                SoTanVatTu = 3
            };
            banSiReal.InBangKeChiTietDonHang();

            // 3. SPLIT TEMP & REMOVE ASSIGNMENTS TO PARAMETERS
            Console.WriteLine(">>> 3. DEMO: SPLIT TEMPORARY VARIABLE & REMOVE PARAMETER ASSIGNMENTS <<<");
            var phanBoReal = new PhanBoKhoNongDuoc_Real();
            var danhSachLo = new List<LoThuocNongDuoc>
            {
                new LoThuocNongDuoc { SoLo = "LOT-2025-A", TenThuoc = "Filia 525SE", SoLuongTon = 30, HanSuDung = DateTime.Today.AddMonths(2) },
                new LoThuocNongDuoc { SoLo = "LOT-2026-B", TenThuoc = "Filia 525SE", SoLuongTon = 100, HanSuDung = DateTime.Today.AddMonths(14) },
                new LoThuocNongDuoc { SoLo = "LOT-2026-C", TenThuoc = "Filia 525SE", SoLuongTon = 50, HanSuDung = DateTime.Today.AddMonths(20) }
            };
            phanBoReal.PhanBoXuatKhoFEFO(danhSachLo, 75);

            // 4. METHOD OBJECT & SUBSTITUTE ALGORITHM
            Console.WriteLine(">>> 4. DEMO: REPLACE METHOD WITH METHOD OBJECT & SUBSTITUTE ALGORITHM <<<");
            var calculator = new TinhToanPhucTap_After();
            double thuong = calculator.TinhThuongDoanhSoVaThue(1200, 150000000, 5, 1.5, true);
            Console.WriteLine($"[AFTER] Thưởng doanh số nhân viên kinh doanh nông dược: {thuong:N0} VNĐ");

            Console.WriteLine("\n[REAL 1] Đọc số tiền thành chữ trên hóa đơn (Refactor Num2Str.cs):");
            long[] cacMucTien = { 0, 150000, 1505000, 24050000, 1250000000 };
            foreach (var tien in cacMucTien)
            {
                Console.WriteLine($" -> {tien,15:N0} VNĐ = {DocSoThanhChuNongDuoc_Real.ChuyenSoTienThanhChu(tien)}");
            }

            Console.WriteLine("\n[REAL 2] Tính giá vốn Bình Quân Gia Quyền (BQGQ) Mục 3 PDF:");
            var loNhaps = new List<LoNhapVatTu>
            {
                new LoNhapVatTu { MaLo = "NL01", SoLuongNhap = 500, DonGiaNhap = 100000, ChiPhiVanChuyenPhanBo = 2000000, ThueNhapKhau = 1000000 },
                new LoNhapVatTu { MaLo = "NL02", SoLuongNhap = 300, DonGiaNhap = 115000, ChiPhiVanChuyenPhanBo = 1500000, ThueNhapKhau = 800000 }
            };
            var bqgqCalc = new TinhGiaBinhQuanGiaQuyenCalculator(loNhaps, 1000000, 0.01m);
            decimal giaBQGQ = bqgqCalc.TinhDonGiaBQGQ();
            Console.WriteLine($" -> Đơn giá vốn bình quân gia quyền xuất kho: {giaBQGQ:N2} VNĐ / sản phẩm");

            Console.WriteLine("\n================================================================================");
            Console.WriteLine("               HOÀN THÀNH TOÀN BỘ DEMO COMPOSING METHODS!");
            Console.WriteLine("================================================================================");
        }
    }
}
