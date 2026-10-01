using System;

namespace DPM235407_NguyenTuanAnh_BaiTap03_03_OrganizingData._02_Replace_Data_Value_With_Object
{
    // =========================================================================
    // AFTER: Áp dụng kỹ thuật Replace Data Value with Object (Tạo Value Objects)
    // - Đóng gói các giá trị nguyên thủy thành các lớp bất biến (Immutable Value Objects).
    // - Tự kiểm tra tính hợp lệ trong Constructor.
    // - Tránh nhầm lẫn tham số kiểu dữ liệu tại thời điểm biên dịch (Compile-time Safety).
    // =========================================================================

    public readonly record struct MaVachEAN13
    {
        public string Value { get; }

        public MaVachEAN13(string value)
        {
            if (string.IsNullOrWhiteSpace(value) || value.Length != 13 || !long.TryParse(value, out _))
            {
                throw new ArgumentException($"Mã vạch '{value}' không đúng định dạng EAN-13 (13 chữ số)!");
            }
            Value = value;
        }

        public override string ToString() => Value;
    }

    public readonly record struct SoDienThoaiVN
    {
        public string Value { get; }

        public SoDienThoaiVN(string value)
        {
            if (string.IsNullOrWhiteSpace(value) || value.Length < 10 || !value.StartsWith("0"))
            {
                throw new ArgumentException($"Số điện thoại '{value}' không hợp lệ!");
            }
            Value = value;
        }

        public override string ToString() => Value;
    }

    public class SanPhamNongDuoc_After
    {
        public string TenSanPham { get; set; } = "Tilt Super 300EC";
        public MaVachEAN13 MaVach { get; set; } = new("8935012345678");
        public decimal GiaBan { get; set; } = 240000;

        public void InThongTin(string nguoiMua, SoDienThoaiVN soDienThoai)
        {
            Console.WriteLine($"[AFTER] Bán {TenSanPham} (Mã EAN-13: {MaVach}) cho {nguoiMua} (SĐT: {soDienThoai}) - Giá: {GiaBan:N0} đ");
        }
    }
}
