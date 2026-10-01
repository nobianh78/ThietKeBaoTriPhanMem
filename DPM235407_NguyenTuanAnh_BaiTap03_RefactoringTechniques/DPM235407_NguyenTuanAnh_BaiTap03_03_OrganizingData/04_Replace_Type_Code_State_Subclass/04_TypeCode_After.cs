using System;

namespace DPM235407_NguyenTuanAnh_BaiTap03_03_OrganizingData._04_Replace_Type_Code_State_Subclass
{
    // =========================================================================
    // AFTER: Áp dụng kỹ thuật:
    // 1. Replace Type Code with Subclasses (Đa hình kế thừa)
    // 2. Replace Type Code with State/Strategy (khi loại khách hàng có thể đổi linh hoạt)
    // Loại bỏ hoàn toàn switch-case, tuân thủ nguyên tắc Open-Closed Principle (OCP).
    // =========================================================================

    public abstract class KhachHangNongDuoc_After
    {
        public string TenKhachHang { get; set; }

        protected KhachHangNongDuoc_After(string tenKhachHang)
        {
            TenKhachHang = tenKhachHang;
        }

        public abstract double TinhTienChietKhau(double tongTien);
        public abstract string LayChinhSachBaoHanh();
    }

    public class KhachHangNongDan : KhachHangNongDuoc_After
    {
        public KhachHangNongDan(string ten) : base(ten) { }
        public override double TinhTienChietKhau(double tongTien) => 0;
        public override string LayChinhSachBaoHanh() => "Đổi trả trong vòng 3 ngày nếu phát hiện lỗi bao bì";
    }

    public class KhachHangDaiLyCap1 : KhachHangNongDuoc_After
    {
        public KhachHangDaiLyCap1(string ten) : base(ten) { }
        public override double TinhTienChietKhau(double tongTien) => tongTien * 0.12;
        public override string LayChinhSachBaoHanh() => "Bảo hiểm rủi ro mùa vụ và đổi trả hàng trước 30 ngày hết hạn";
    }

    public class KhachHangHopTacXa : KhachHangNongDuoc_After
    {
        public KhachHangHopTacXa(string ten) : base(ten) { }
        public override double TinhTienChietKhau(double tongTien) => tongTien * 0.08;
        public override string LayChinhSachBaoHanh() => "Hỗ trợ thử nghiệm phun thuốc mẫu và đổi trả trước hạn 30 ngày";
    }
}
