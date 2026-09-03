using System;
using System.Text;

namespace DPM235407_NguyenTuanAnh_Tuan01_Factory_Real_NhanVien_DP
{
    class Program
    {
        static void Main(string[] args)
        {
            // Hỗ trợ hiển thị tiếng Việt có dấu trên Console
            Console.OutputEncoding = Encoding.UTF8;

            Console.WriteLine("==================================================");
            Console.WriteLine("Đồ án: Quản lý bán hàng Công ty Nông dược An Giang");
            Console.WriteLine("Mẫu thiết kế: Factory Method (Phân quyền nhân viên)");
            Console.WriteLine("Thực hiện: Nguyễn Tuấn Anh - DPM235407");
            Console.WriteLine("==================================================\n");

            new Client().Main();

            Console.ReadLine();
        }
    }
}