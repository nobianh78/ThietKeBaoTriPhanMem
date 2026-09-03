using System;

namespace DPM235407_NguyenTuanAnh_Tuan01_Singleton_Real_Database_DP
{
    // Singleton class
    public sealed class PhienDangNhap
    {
        private static PhienDangNhap? _instance;
        private static readonly object _lock = new object();

        // Thuộc tính của phiên đăng nhập
        public string TenNhanVien { get; private set; } = string.Empty;
        public string QuyenHan { get; private set; } = string.Empty;
        public DateTime ThoiGianDangNhap { get; private set; }

        // Constructor private để ngăn chặn dùng từ khóa new từ bên ngoài
        private PhienDangNhap() { }

        // Cung cấp điểm truy cập toàn cục
        public static PhienDangNhap GetInstance()
        {
            if (_instance == null)
            {
                lock (_lock)
                {
                    if (_instance == null)
                    {
                        _instance = new PhienDangNhap();
                    }
                }
            }
            return _instance;
        }

        public void DangNhap(string tenNhanVien, string quyenHan)
        {
            TenNhanVien = tenNhanVien;
            QuyenHan = quyenHan;
            ThoiGianDangNhap = DateTime.Now;
            Console.WriteLine($"[Hệ thống] {TenNhanVien} ({QuyenHan}) đã đăng nhập thành công lúc {ThoiGianDangNhap}.");
        }
    }
}
