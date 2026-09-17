using System;
using System.Collections.Generic;

namespace DPM235407_NguyenTuanAnh_Tuan02_ChainOfResponsibility_Real_XacThuc_DP
{
    // Bước 4: Kiểm tra phân quyền truy cập chức năng kinh doanh nông dược
    public class PhanQuyenTruyCapHandler : AbstractXacThucHandler
    {
        // Bảng phân quyền chi tiết các chức năng theo PDF
        private readonly Dictionary<string, List<string>> _quyenChucNang = new()
        {
            { "QuanLy", new List<string> { "LapHoaDon", "CauHinhXuatKho", "BaoCaoTongHop", "SuaHoaDonGiamGia", "KiemTraTonKho" } },
            { "NhanVienBanHang", new List<string> { "LapHoaDon", "SuaHoaDonGiamGia", "KiemTraTonKho" } },
            { "ThuKho", new List<string> { "CauHinhXuatKho", "KiemTraTonKho" } }
        };

        public override bool XuLy(YeuCauTruyCap yeuCau)
        {
            if (!_quyenChucNang.ContainsKey(yeuCau.VaiTro) ||
                !_quyenChucNang[yeuCau.VaiTro].Contains(yeuCau.ChucNangCanThucHien))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"   [LỖI BƯỚC 4] Người dùng '{yeuCau.TenDangNhap}' ({yeuCau.VaiTro}) KHÔNG CÓ QUYỀN thực hiện chức năng: {yeuCau.ChucNangCanThucHien}");
                Console.ResetColor();
                return false;
            }

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"   [BƯỚC 4 - THÀNH CÔNG] Đã cấp quyền truy cập chức năng '{yeuCau.ChucNangCanThucHien}' cho {yeuCau.VaiTro}!");
            Console.ResetColor();
            return base.XuLy(yeuCau);
        }
    }
}
