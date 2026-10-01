using System;

namespace DPM235407_NguyenTuanAnh_BaiTap03_02_MovingFeatures._01_Move_Method_Field
{
    // =========================================================================
    // BEFORE: Code Smell "Feature Envy" (Ganh tị tính năng)
    // Lớp `GiaoDienBanHangForm_Before` thực hiện tính toán tiền lãi, chiết khấu,
    // và cập nhật số dư công nợ của tài khoản khách hàng bằng cách truy cập liên tục
    // vào các thuộc tính của `TaiKhoanKhachHang_Before`.
    // =========================================================================
    public class TaiKhoanKhachHang_Before
    {
        public string MaKhachHang { get; set; } = "KH001";
        public string TenKhachHang { get; set; } = "Nông dân Ba Tri";
        public double SoDuNoHienTai { get; set; } = 5000000;
        public double HanMucNoChoPhep { get; set; } = 20000000;
        public int SoVuDaHopTac { get; set; } = 4;
    }

    public class GiaoDienBanHangForm_Before
    {
        // Smell: Hàm này phụ thuộc quá nhiều vào dữ liệu của TaiKhoanKhachHang
        public bool KiemTraVaCapNhatGiaoDich(TaiKhoanKhachHang_Before khachHang, double soTienMuaMoi, double soTienTraNgay)
        {
            double tienNoMoi = soTienMuaMoi - soTienTraNgay;
            double tongNoDuKien = khachHang.SoDuNoHienTai + tienNoMoi;

            // Kiểm tra hạn mức nợ
            if (tongNoDuKien > khachHang.HanMucNoChoPhep)
            {
                Console.WriteLine($"[BEFORE] Từ chối bán nợ: Tổng nợ {tongNoDuKien:N0} đ vượt hạn mức {khachHang.HanMucNoChoPhep:N0} đ!");
                return false;
            }

            // Cập nhật công nợ
            khachHang.SoDuNoHienTai = tongNoDuKien;
            Console.WriteLine($"[BEFORE] Giao dịch thành công. Dư nợ mới của {khachHang.TenKhachHang}: {khachHang.SoDuNoHienTai:N0} đ");
            return true;
        }
    }
}
