using System;

namespace DPM235407_NguyenTuanAnh_BaiTap03_03_OrganizingData._02_Replace_Data_Value_With_Object
{
    // =========================================================================
    // BEFORE: Code Smell "Primitive Obsession" (Ám ảnh kiểu dữ liệu nguyên thủy)
    // Dùng kiểu string, long, double thô sơ để biểu diễn các khái niệm nghiệp vụ
    // như: Mã vạch sản phẩm, Tiền tệ, Số điện thoại.
    // Dễ bị truyền nhầm thứ tự tham số và không thể tự kiểm tra tính hợp lệ.
    // =========================================================================
    public class SanPhamNongDuoc_Before
    {
        public string TenSanPham { get; set; } = "Tilt Super 300EC";
        public string MaVach { get; set; } = "8935012345678"; // Chỉ là string, không kiểm tra độ dài/định dạng
        public long GiaBan { get; set; } = 240000;            // Chỉ là long, không có đơn vị tiền tệ
        public string DonViTinh { get; set; } = "Chai 250ml";  // Chuỗi tự do dễ sai chính tả

        public void InThongTin(string nguoiMua, string soDienThoai)
        {
            // Dễ bị nhầm lẫn giữa chuỗi mã vạch và số điện thoại
            Console.WriteLine($"[BEFORE] Bán {TenSanPham} (Mã: {MaVach}) cho {nguoiMua} (SĐT: {soDienThoai}) - Giá: {GiaBan} đ");
        }
    }
}
