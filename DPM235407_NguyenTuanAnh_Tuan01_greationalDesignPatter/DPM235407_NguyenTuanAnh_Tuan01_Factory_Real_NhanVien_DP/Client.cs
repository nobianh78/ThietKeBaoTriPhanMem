using System;

namespace DPM235407_NguyenTuanAnh_Tuan01_Factory_Real_NhanVien_DP
{
    public class Client
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
}
