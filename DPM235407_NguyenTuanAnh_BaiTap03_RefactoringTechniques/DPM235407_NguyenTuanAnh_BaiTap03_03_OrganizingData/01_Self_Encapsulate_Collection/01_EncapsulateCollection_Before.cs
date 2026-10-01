using System;
using System.Collections.Generic;

namespace DPM235407_NguyenTuanAnh_BaiTap03_03_OrganizingData._01_Self_Encapsulate_Collection
{
    // =========================================================================
    // BEFORE: Để lộ thuộc tính tập hợp `List<T>` trực tiếp ra ngoài (Public Getter & Setter)
    // Mã bên ngoài có thể gọi `phieu.DanhSachMatHang.Clear()` hoặc thêm/xóa phần tử
    // mà không thông qua bất kỳ kiểm tra hợp lệ nào, phá vỡ tính toàn vẹn dữ liệu.
    // =========================================================================
    public class MatHang_Before
    {
        public string TenHang { get; set; } = string.Empty;
        public decimal DonGia { get; set; }
    }

    public class PhieuXuat_Before
    {
        public string MaPhieu { get; set; } = "PX01";
        // Public List cho phép can thiệp tự do từ bên ngoài
        public List<MatHang_Before> DanhSachMatHang { get; set; } = new();
    }
}
