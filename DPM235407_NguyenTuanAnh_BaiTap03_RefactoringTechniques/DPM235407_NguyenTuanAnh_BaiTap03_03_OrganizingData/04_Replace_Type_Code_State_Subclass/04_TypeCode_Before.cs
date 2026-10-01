using System;

namespace DPM235407_NguyenTuanAnh_BaiTap03_03_OrganizingData._04_Replace_Type_Code_State_Subclass
{
    // =========================================================================
    // BEFORE: Sử dụng mã kiểu dữ liệu nguyên thủy (Type Code: int / string)
    // kết hợp chuỗi `switch-case` hoặc `if-else` dài đặc trưng của Conditional Complexity.
    // Khi thêm loại sản phẩm hoặc nhóm khách hàng mới, phải sửa switch-case ở nhiều nơi.
    // =========================================================================
    public class KhachHangNongDuoc_Before
    {
        public const int TYPE_NONG_DAN = 1;
        public const int TYPE_DAI_LY_CAP_2 = 2;
        public const int TYPE_DAI_LY_CAP_1 = 3;
        public const int TYPE_HOP_TAC_XA = 4;

        public string TenKhachHang { get; set; } = string.Empty;
        public int LoaiKhachHang { get; set; }

        public double TinhTienChietKhau(double tongTien)
        {
            switch (LoaiKhachHang)
            {
                case TYPE_NONG_DAN:
                    return 0; // Không chiết khấu
                case TYPE_DAI_LY_CAP_2:
                    return tongTien * 0.05;
                case TYPE_DAI_LY_CAP_1:
                    return tongTien * 0.12;
                case TYPE_HOP_TAC_XA:
                    return tongTien * 0.08;
                default:
                    throw new ArgumentException("Loại khách hàng không hợp lệ");
            }
        }

        public string LayChinhSachBaoHanh()
        {
            switch (LoaiKhachHang)
            {
                case TYPE_NONG_DAN:
                    return "Đổi trả trong vòng 3 ngày nếu phát hiện lỗi bao bì";
                case TYPE_DAI_LY_CAP_1:
                case TYPE_HOP_TAC_XA:
                    return "Bảo hiểm rủi ro mùa vụ và đổi trả hàng trước 30 ngày hết hạn";
                default:
                    return "Chính sách tiêu chuẩn";
            }
        }
    }
}
