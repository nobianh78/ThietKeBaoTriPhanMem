using System;
using System.Text;

namespace DPM235407_NguyenTuanAnh_Tuan01_Singleton_Real_Database_DP
{
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