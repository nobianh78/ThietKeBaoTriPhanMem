using System;
using System.Text;

namespace DPM235407_NguyenTuanAnh_Tuan01_Factory_Real_NhanVien_DP
{
    // Lớp Creator trừu tượng (Nhà máy/Phòng nhân sự chung)
    abstract class PhongNhanSu
    {
        // Factory Method
        public abstract INhanVien TaoNhanVien();

        // Core business logic (SomeOperation)
        public string PhanCongCongViec()
        {
            // Gọi factory method để tạo đối tượng nhân viên
            var nhanVien = TaoNhanVien();
            // Sử dụng đối tượng vừa tạo vào quy trình nghiệp vụ chung
            var ketQua = "Hệ thống phân công thành công: " + nhanVien.HienThiQuyenHan();
            return ketQua;
        }
    }

    // Concrete Creator 1: Xử lý tuyển dụng/tạo tài khoản cho nhân viên bán hàng
    class PhongNhanSuBanHang : PhongNhanSu
    {
        public override INhanVien TaoNhanVien()
        {
            return new NhanVienBanHang();
        }
    }

    // Concrete Creator 2: Xử lý tuyển dụng/tạo tài khoản cho nhân viên quản lý
    class PhongNhanSuQuanLy : PhongNhanSu
    {
        public override INhanVien TaoNhanVien()
        {
            return new NhanVienQuanLy();
        }
    }

    // Giao diện (IProduct) khai báo các hành vi mà mọi nhân viên phải có.
    public interface INhanVien
    {
        string HienThiQuyenHan();
    }

    // Concrete Product 1: Cung cấp chi tiết quyền hạn của nhân viên bán hàng
    class NhanVienBanHang : INhanVien
    {
        public string HienThiQuyenHan()
        {
            return "{Nhân viên Bán hàng} - Được phép lập hóa đơn, nhập dịch vụ phát sinh và xem thống kê hóa đơn do mình lập.";
        }
    }

    // Concrete Product 2: Cung cấp chi tiết quyền hạn của nhân viên quản lý
    class NhanVienQuanLy : INhanVien
    {
        public string HienThiQuyenHan()
        {
            return "{Nhân viên Quản lý} - Được phép cấu hình nhập/xuất kho (FIFO), phân lô hàng và xem toàn bộ thống kê công ty.";
        }
    }

    class Client
    {
        public void Main()
        {
            Console.WriteLine("App: Khởi chạy quy trình tạo Nhân viên Bán hàng...");
            ClientCode(new PhongNhanSuBanHang());

            Console.WriteLine("\n--------------------------------------------------\n");

            Console.WriteLine("App: Khởi chạy quy trình tạo Nhân viên Quản lý...");
            ClientCode(new PhongNhanSuQuanLy());
        }

        public void ClientCode(PhongNhanSu phongNhanSu)
        {
            // Client code hoạt động thông qua abstract class, không bị phụ thuộc vào class cụ thể
            Console.WriteLine("Client: Chức năng phân quyền không cần biết class cụ thể của nhân viên, nhưng vẫn hoạt động chính xác.\n> "
                + phongNhanSu.PhanCongCongViec());
        }
    }

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