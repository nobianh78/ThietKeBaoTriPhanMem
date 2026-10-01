using System;
using System.Text;
using DPM235407_NguyenTuanAnh_BaiTap03_03_OrganizingData._01_Self_Encapsulate_Collection;
using DPM235407_NguyenTuanAnh_BaiTap03_03_OrganizingData._02_Replace_Data_Value_With_Object;
using DPM235407_NguyenTuanAnh_BaiTap03_03_OrganizingData._03_Replace_Magic_Numbers_Constants;
using DPM235407_NguyenTuanAnh_BaiTap03_03_OrganizingData._04_Replace_Type_Code_State_Subclass;
using DPM235407_NguyenTuanAnh_BaiTap03_03_OrganizingData._05_Change_Value_Reference;

namespace DPM235407_NguyenTuanAnh_BaiTap03_03_OrganizingData
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.WriteLine("================================================================================");
            Console.WriteLine("   BÀI TẬP 03 - NHÓM 3: ORGANIZING DATA (TỔ CHỨC DỮ LIỆU)");
            Console.WriteLine("   Học viên: Nguyễn Tuấn Anh - MSSV: DPM235407 - Lớp: Cao học K24");
            Console.WriteLine("================================================================================\n");

            // 1. ENCAPSULATE COLLECTION
            Console.WriteLine(">>> 1. DEMO: ENCAPSULATE COLLECTION (ĐÓNG GÓI TẬP HỢP) <<<");
            var phieuAfter = new PhieuXuat_After("PX-001");
            phieuAfter.ThemMatHang(new MatHang_After("Thuốc trừ rầy Chess 50WG", 120000));
            phieuAfter.ThemMatHang(new MatHang_After("Thuốc dưỡng lá Atonik", 85000));
            Console.WriteLine($"[AFTER] Phiếu {phieuAfter.MaPhieu} có {phieuAfter.DanhSachMatHang.Count} mặt hàng, tổng tiền: {phieuAfter.TongTien:N0} đ");

            Console.WriteLine("\n[REAL] Đóng gói danh sách chi tiết phiếu bán nông dược (PhieuBan.cs):");
            var phieuReal = new PhieuBanNongDuoc_Real("PB-TG-2026", "Hợp tác xã Nông nghiệp Vĩnh Hanh");
            phieuReal.ThemHoacCapNhatSanPham("SP01", "Amistar Top 325SC", 10, 310000);
            phieuReal.ThemHoacCapNhatSanPham("SP02", "Tilt Super 300EC", 15, 240000);
            phieuReal.ThemHoacCapNhatSanPham("SP01", "Amistar Top 325SC", 5, 310000); // Tự động tăng số lượng lên 15
            phieuReal.InPhieuXuat();

            // 2. REPLACE DATA VALUE WITH OBJECT
            Console.WriteLine(">>> 2. DEMO: REPLACE DATA VALUE WITH OBJECT (VALUE OBJECTS) <<<");
            var spAfter = new SanPhamNongDuoc_After();
            spAfter.InThongTin("Nguyễn Văn Nông", new SoDienThoaiVN("0918123456"));

            Console.WriteLine("\n[REAL] Áp dụng Value Objects cho Tiền tệ VNĐ và Quy cách bao bì:");
            var spReal = new SanPhamNongDuoc_Real();
            spReal.InThongTinSanPham();

            // 3. REPLACE MAGIC NUMBERS WITH SYMBOLIC CONSTANTS
            Console.WriteLine(">>> 3. DEMO: REPLACE MAGIC NUMBERS WITH SYMBOLIC CONSTANTS <<<");
            var kiemTraAfter = new KiemTraKhoVaGia_After();
            kiemTraAfter.KiemTraTonKho(10, 20);

            Console.WriteLine("\n[REAL] Áp dụng định mức tiêu chuẩn kho Nông Dược An Giang:");
            var dinhMucReal = new QuanLyDinhMucKhoNongDuoc_Real();
            dinhMucReal.KiemTraLoHangTon("Radiant 60SC", 12, 18);
            decimal tienDonHang = dinhMucReal.TinhChiPhiXuatDonHang(12000000, 4);
            Console.WriteLine($" -> Chi phí xuất đơn hàng 12tr (gồm chiết khấu, VAT, bốc dỡ 4 tấn): {tienDonHang:N0} VNĐ\n");

            // 4. REPLACE TYPE CODE WITH SUBCLASSES / POLYMORPHISM
            Console.WriteLine(">>> 4. DEMO: REPLACE TYPE CODE WITH SUBCLASSES / POLYMORPHISM <<<");
            KhachHangNongDuoc_After kh1 = new KhachHangDaiLyCap1("Đại lý Cấp 1 An Phú");
            KhachHangNongDuoc_After kh2 = new KhachHangHopTacXa("HTX Lúa Vàng Châu Phú");
            Console.WriteLine($"[AFTER] {kh1.TenKhachHang}: Chiết khấu = {kh1.TinhTienChietKhau(10000000):N0} đ | {kh1.LayChinhSachBaoHanh()}");
            Console.WriteLine($"[AFTER] {kh2.TenKhachHang}: Chiết khấu = {kh2.TinhTienChietKhau(10000000):N0} đ | {kh2.LayChinhSachBaoHanh()}");

            Console.WriteLine("\n[REAL] Phân loại Thuốc BVTV và Phân bón lá đa hình:");
            var thuocTruSau = new SanPhamNongDuocPhanLoai_Real("Thuốc sâu Radiant 60SC", 185000, new ThuocTruSauDocCao());
            var thuocTruBenh = new SanPhamNongDuocPhanLoai_Real("Chế phẩm Trichoderma", 75000, new ThuocTruBenhSinhHoc());
            var phanBon = new SanPhamNongDuocPhanLoai_Real("Phân bón lá NPK Đầu Trâu 501", 45000, new PhanBonLaDinhDuong());
            thuocTruSau.InThongTinChiTiet();
            thuocTruBenh.InThongTinChiTiet();
            phanBon.InThongTinChiTiet();

            // 5. CHANGE VALUE TO REFERENCE
            Console.WriteLine(">>> 5. DEMO: CHANGE VALUE TO REFERENCE (THỰC THỂ TỒN KHO) <<<");
            var repo = new KhoHangRepository();
            var loGoc = new LoHang_After("L01", 100);
            repo.DangKyLoHang(loGoc);

            var don1 = new DonHangXuat_After(repo.LayLoHangTheoMa("L01"));
            var don2 = new DonHangXuat_After(repo.LayLoHangTheoMa("L01"));
            don1.XuatKho(30);
            don2.XuatKho(20);

            Console.WriteLine("\n[REAL] Quản lý Lô Kho tập trung (Entity Reference):");
            var khoTrungTam = new KhoTrungTamNongDuoc_Real();
            khoTrungTam.NhapKhoLoMoi(new LoHangThucThe_Real("LO-2026-TIL", "Tilt Super 300EC", 200, DateTime.Today.AddMonths(18)));
            khoTrungTam.NhapKhoLoMoi(new LoHangThucThe_Real("LO-2026-RAD", "Radiant 60SC", 150, DateTime.Today.AddMonths(24)));
            khoTrungTam.InTonKho();

            // Thực hiện xuất kho từ 2 phiếu bán hàng khác nhau tham chiếu cùng 1 lô
            Console.WriteLine("Đơn bán hàng 01 xuất 50 chai Tilt Super:");
            khoTrungTam.LayLoHang("LO-2026-TIL").XuatKho(50);

            Console.WriteLine("Đơn bán hàng 02 xuất 80 chai Tilt Super:");
            khoTrungTam.LayLoHang("LO-2026-TIL").XuatKho(80);

            khoTrungTam.InTonKho();

            Console.WriteLine("================================================================================");
            Console.WriteLine("               HOÀN THÀNH TOÀN BỘ DEMO ORGANIZING DATA!");
            Console.WriteLine("================================================================================");
        }
    }
}
