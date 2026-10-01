using System;

namespace DPM235407_NguyenTuanAnh_BaiTap03_02_MovingFeatures._01_Move_Method_Field
{
    // =========================================================================
    // AFTER: Áp dụng kỹ thuật Move Method & Move Field
    // Di chuyển phương thức `KiemTraVaCapNhatGiaoDich` về đúng lớp sở hữu dữ liệu
    // là `TaiKhoanKhachHang_After`. Tuân thủ nguyên tắc "Information Expert" trong GRASP/OOP.
    // =========================================================================
    public class TaiKhoanKhachHang_After
    {
        public string MaKhachHang { get; set; } = "KH001";
        public string TenKhachHang { get; set; } = "Nông dân Ba Tri";
        public double SoDuNoHienTai { get; private set; } = 5000000;
        public double HanMucNoChoPhep { get; set; } = 20000000;
        public int SoVuDaHopTac { get; set; } = 4;

        // Method được chuyển về đây
        public bool GhiNhanGiaoDichMuaHang(double soTienMuaMoi, double soTienTraNgay)
        {
            double tienNoPhatSinh = soTienMuaMoi - soTienTraNgay;
            if (CoTheVayNo(tienNoPhatSinh))
            {
                SoDuNoHienTai += tienNoPhatSinh;
                Console.WriteLine($"[AFTER] Giao dịch thành công. Dư nợ mới của {TenKhachHang}: {SoDuNoHienTai:N0} đ");
                return true;
            }

            double tongNoSauKhiMua = SoDuNoHienTai + tienNoPhatSinh;
            Console.WriteLine($"[AFTER] Từ chối bán nợ: Tổng nợ {tongNoSauKhiMua:N0} đ vượt hạn mức {HanMucNoChoPhep:N0} đ!");
            return false;
        }

        public bool CoTheVayNo(double soTienNoThem)
        {
            return (SoDuNoHienTai + soTienNoThem) <= HanMucNoChoPhep;
        }
    }

    public class GiaoDienBanHangForm_After
    {
        public void ThucHienBanHang(TaiKhoanKhachHang_After khachHang, double tienHang, double daTra)
        {
            // Form UI chỉ gọi hành vi từ Domain Object, không tự tính toán công nợ
            khachHang.GhiNhanGiaoDichMuaHang(tienHang, daTra);
        }
    }
}
