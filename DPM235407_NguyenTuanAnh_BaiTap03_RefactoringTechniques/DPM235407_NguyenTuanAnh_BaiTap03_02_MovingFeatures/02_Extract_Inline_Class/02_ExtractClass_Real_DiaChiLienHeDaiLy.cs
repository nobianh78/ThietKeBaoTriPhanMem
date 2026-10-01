using System;

namespace DPM235407_NguyenTuanAnh_BaiTap03_02_MovingFeatures._02_Extract_Inline_Class
{
    // =========================================================================
    // REAL APPLICATION (Hệ thống Nông Dược An Giang):
    // Tách cấu trúc khách hàng/đại lý trong `KhachHang.cs` và `DaiLy.cs`.
    // Mã cũ: `KhachHang` chứa các chuỗi `m_DiaChi`, `m_DienThoai` không chuẩn hóa,
    // không hỗ trợ tách biệt địa chỉ nhận hàng tận ruộng (cho xe tải giao hàng).
    // REFACTOR: Tách thành `DiaChiGiaoHang` và `HoSoKhachHang` có phương thức định dạng chuẩn.
    // =========================================================================

    public class ToaDoGPS
    {
        public double ViDo { get; set; }
        public double KinhDo { get; set; }

        public override string ToString() => $"({ViDo:F4}, {KinhDo:F4})";
    }

    public class DiaChiGiaoHangNongDuoc
    {
        public string TenCanhDong { get; set; } = string.Empty;
        public string ApKhom { get; set; } = string.Empty;
        public string XaPhuong { get; set; } = string.Empty;
        public string HuyenThiXa { get; set; } = string.Empty;
        public string TinhThanh { get; set; } = "An Giang";
        public ToaDoGPS? ToaDo { get; set; }

        public string LayDiaChiChiTiet()
        {
            string diaChi = $"{TenCanhDong}, {ApKhom}, {XaPhuong}, {HuyenThiXa}, {TinhThanh}";
            if (ToaDo != null)
            {
                diaChi += $" [Tọa độ GPS: {ToaDo}]";
            }
            return diaChi;
        }
    }

    public class DaiLyNongDuoc_Real
    {
        public string MaDaiLy { get; set; } = "DL-TG-005";
        public string TenDaiLy { get; set; } = "Đại lý Vật tư Nông nghiệp Sáu Thoại";
        public string SoDienThoai { get; set; } = "0296.3876.543";
        public DiaChiGiaoHangNongDuoc DiaChiGiaoHang { get; set; } = new();

        public void InThongTinDaiLy()
        {
            Console.WriteLine("---------------- THÔNG TIN ĐẠI LÝ & ĐỊA ĐIỂM GIAO HÀNG ----------------");
            Console.WriteLine($"Mã đại lý  : {MaDaiLy}");
            Console.WriteLine($"Tên đại lý : {TenDaiLy}");
            Console.WriteLine($"Hotline    : {SoDienThoai}");
            Console.WriteLine($"Giao hàng  : {DiaChiGiaoHang.LayDiaChiChiTiet()}");
            Console.WriteLine("-----------------------------------------------------------------------");
        }
    }
}
