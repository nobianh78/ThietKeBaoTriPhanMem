using System;

namespace DPM235407_NguyenTuanAnh_BaiTap03_02_MovingFeatures._03_Hide_Delegate_Remove_MiddleMan
{
    // =========================================================================
    // AFTER: Áp dụng kỹ thuật Hide Delegate (Ẩn người ủy nhiệm)
    // Lớp `NhanVien_After` cung cấp trực tiếp phương thức `LayTenTruongPhong()`,
    // ẩn đi sự tồn tại và cấu trúc của `PhongBan` và `NguoiQuanLy`.
    // Tuân thủ triệt để "Law of Demeter" (Nguyên tắc ít hiểu biết nhất).
    // (Lưu ý: Nếu lớp trung gian làm quá nhiều việc ủy nhiệm rỗng, kỹ thuật
    // Remove Middle Man có thể được áp dụng ngược lại khi cần thiết).
    // =========================================================================
    public class NguoiQuanLy_After
    {
        public string TenNguoiQuanLy { get; set; } = "Kỹ sư Trần Văn Hùng";
    }

    public class PhongBan_After
    {
        public string TenPhongBan { get; set; } = "Phòng Kinh Doanh & Bảo Vệ Thực Vật";
        public NguoiQuanLy_After TruongPhong { get; set; } = new();

        public string LayTenTruongPhong() => TruongPhong.TenNguoiQuanLy;
    }

    public class NhanVien_After
    {
        public string TenNhanVien { get; set; } = "Nguyễn Tuấn Anh";
        private PhongBan_After PhongBan { get; set; } = new();

        // Hide Delegate: Ẩn ủy quyền bên trong
        public string LayTenTruongPhong() => PhongBan.LayTenTruongPhong();
        public string LayTenPhongBan() => PhongBan.TenPhongBan;
    }

    public class ClientGoiDichVu_After
    {
        public void InThongTinQuanLy(NhanVien_After nv)
        {
            // Client gọi trực tiếp trên NhanVien, hoàn toàn không cần biết cấu trúc nội bộ
            Console.WriteLine($"[AFTER] Trưởng phòng trực tiếp của {nv.TenNhanVien} là: {nv.LayTenTruongPhong()} ({nv.LayTenPhongBan()})");
        }
    }
}
