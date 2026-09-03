using System;
using System.Text;

namespace DPM235407_NguyenTuanAnh_Tuan01_Singleton_Real_Database_DP
{
    // Singleton class
    public sealed class PhienDangNhap
    {
        private static PhienDangNhap _instance;
        private static readonly object _lock = new object();

        // Thuộc tính của phiên đăng nhập
        public string TenNhanVien { get; private set; }
        public string QuyenHan { get; private set; }
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

    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.WriteLine("=== MẪU SINGLETON: QUẢN LÝ PHIÊN ĐĂNG NHẬP ===\n");

            // Nơi nào trong chương trình cũng gọi được GetInstance() và nó luôn trỏ về 1 đối tượng duy nhất
            PhienDangNhap session1 = PhienDangNhap.GetInstance();
            session1.DangNhap("Nguyễn Tuấn Anh", "Admin");

            PhienDangNhap session2 = PhienDangNhap.GetInstance();

            Console.WriteLine($"\nKiểm tra Session 2: User đang login là {session2.TenNhanVien}");

            if (session1 == session2)
            {
                Console.WriteLine("=> Singleton hoạt động đúng: session1 và session2 là cùng một phiên đăng nhập.");
            }
            Console.ReadLine();
        }
    }
}