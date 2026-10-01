using System;
using System.Collections.Generic;
using System.Text;
using DPM235407_NguyenTuanAnh_BaiTap03_02_MovingFeatures._01_Move_Method_Field;
using DPM235407_NguyenTuanAnh_BaiTap03_02_MovingFeatures._02_Extract_Inline_Class;
using DPM235407_NguyenTuanAnh_BaiTap03_02_MovingFeatures._03_Hide_Delegate_Remove_MiddleMan;
using DPM235407_NguyenTuanAnh_BaiTap03_02_MovingFeatures._04_Foreign_Method_Local_Extension;

namespace DPM235407_NguyenTuanAnh_BaiTap03_02_MovingFeatures
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.WriteLine("================================================================================");
            Console.WriteLine("   BÀI TẬP 03 - NHÓM 2: MOVING FEATURES (DI CHUYỂN TÍNH NĂNG GIỮA CÁC ĐỐI TƯỢNG)");
            Console.WriteLine("   Học viên: Nguyễn Tuấn Anh - MSSV: DPM235407 - Lớp: Cao học K24");
            Console.WriteLine("================================================================================\n");

            // 1. MOVE METHOD & MOVE FIELD
            Console.WriteLine(">>> 1. DEMO: MOVE METHOD & MOVE FIELD <<<");
            Console.WriteLine("[AFTER] Gọi hàm nghiệp vụ chuyển vào TaiKhoanKhachHang:");
            var tk = new TaiKhoanKhachHang_After();
            tk.GhiNhanGiaoDichMuaHang(12000000, 2000000);

            Console.WriteLine("\n[REAL] Di chuyển phương thức tính toán từ Form vào PhieuBan & ChiTiet:");
            var phieuReal = new PhieuBan_Real();
            phieuReal.ThemChiTiet("LO-01", "Thuốc trừ cỏ lúa Sofit 300EC", 40, 145000);
            phieuReal.ThemChiTiet("LO-02", "Thuốc trừ ốc bươu vàng Topsin", 25, 95000);
            phieuReal.ThanhToan(5000000);
            phieuReal.InThongTinPhieu();

            // 2. EXTRACT CLASS
            Console.WriteLine(">>> 2. DEMO: EXTRACT CLASS (TÁCH LỚP CHUYÊN BIỆT) <<<");
            var ncc = new NhaCungCap_After();
            ncc.DiaChiTruSo.SoNhaDuong = "104 Lý Thường Kiệt";
            ncc.DiaChiTruSo.PhuongXa = "Mỹ Bình";
            ncc.DiaChiTruSo.QuanHuyen = "Long Xuyên";
            ncc.DiaChiTruSo.TinhThanh = "An Giang";
            ncc.LienHe.NguoiDaiDien = "Trần Văn Nam";
            ncc.LienHe.SoDienThoai = "0903.999.888";
            Console.WriteLine($"[AFTER] NCC: {ncc.TenNCC} | Người LH: {ncc.LienHe.NguoiDaiDien} ({ncc.LienHe.SoDienThoai}) | Trụ sở: {ncc.DiaChiTruSo}");

            Console.WriteLine("\n[REAL] Hồ sơ Đại lý Nông dược với tọa độ định vị giao hàng tận ruộng:");
            var dailyReal = new DaiLyNongDuoc_Real
            {
                DiaChiGiaoHang = new DiaChiGiaoHangNongDuoc
                {
                    TenCanhDong = "Cánh đồng mẫu lớn Tà Đảnh",
                    ApKhom = "Ấp Tân Lập",
                    XaPhuong = "Xã Tà Đảnh",
                    HuyenThiXa = "Huyện Tri Tôn",
                    TinhThanh = "An Giang",
                    ToaDo = new ToaDoGPS { ViDo = 10.4289, KinhDo = 105.0124 }
                }
            };
            dailyReal.InThongTinDaiLy();

            // 3. HIDE DELEGATE
            Console.WriteLine("\n>>> 3. DEMO: HIDE DELEGATE (ẨN ỦY QUYỀN / LAW OF DEMETER) <<<");
            var nv = new NhanVien_After();
            new ClientGoiDichVu_After().InThongTinQuanLy(nv);

            Console.WriteLine("\n[REAL] Đóng gói truy xuất thông tin Lô thuốc bảo vệ thực vật:");
            var thuoc = new ThongTinThuocBVTV();
            var lo = new LoMaSanPhamNongDuoc("LOT-2026-TIL-01", DateTime.Today.AddMonths(18), thuoc);
            var dongBan = new DongBanHangChiTiet(lo, 15);
            dongBan.InThongTinChiTiet();

            // 4. INTRODUCE LOCAL EXTENSION (EXTENSION METHODS)
            Console.WriteLine("\n>>> 4. DEMO: INTRODUCE LOCAL EXTENSION / EXTENSION METHODS <<<");
            var kt = new KiemTraHanSuDung_After();
            kt.KiemTraThuoc(DateTime.Today.AddDays(15));
            kt.KiemTraThuoc(DateTime.Today.AddDays(-5));
            kt.KiemTraThuoc(DateTime.Today.AddDays(120));

            Console.WriteLine("\n[REAL] Quản lý Lô Kho & Lọc các lô cận date tự động:");
            var danhSachLoKho = new List<LoHangNongDuoc>
            {
                new LoHangNongDuoc { MaLo = "LO-ANV-01", TenSanPham = "Anvil 5SC (Syngenta)", SoLuongTon = 120, DonGiaVon = 180000, HanSuDung = DateTime.Today.AddDays(12) },
                new LoHangNongDuoc { MaLo = "LO-FIL-02", TenSanPham = "Filia 525SE", SoLuongTon = 80, DonGiaVon = 210000, HanSuDung = DateTime.Today.AddDays(300) },
                new LoHangNongDuoc { MaLo = "LO-BEA-03", TenSanPham = "Beam 75WP đặc trị đạo ôn", SoLuongTon = 45, DonGiaVon = 95000, HanSuDung = DateTime.Today.AddDays(-10) },
                new LoHangNongDuoc { MaLo = "LO-KAS-04", TenSanPham = "Kasumin 2SL trị vi khuẩn", SoLuongTon = 200, DonGiaVon = 130000, HanSuDung = DateTime.Today.AddDays(25) }
            };

            danhSachLoKho.InDanhSachLoKho("Toàn bộ danh sách lô nông dược trong kho");
            danhSachLoKho.LayCacLoCanDate().InDanhSachLoKho("Danh sách các lô CẬN DATE cần thanh lý khuyến mãi");
            danhSachLoKho.SapXepTheoFEFO().InDanhSachLoKho("Danh sách lô đã sắp xếp ưu tiên xuất kho theo FEFO");

            Console.WriteLine("================================================================================");
            Console.WriteLine("               HOÀN THÀNH TOÀN BỘ DEMO MOVING FEATURES!");
            Console.WriteLine("================================================================================");
        }
    }
}
