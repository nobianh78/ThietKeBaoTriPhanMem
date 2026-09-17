using System;

namespace DPM235407_NguyenTuanAnh_Tuan02_ChainOfResponsibility_Real_XacThuc_DP
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.WriteLine("================================================================================");
            Console.WriteLine(" CÔNG TY NÔNG DƯỢC AN GIANG - PHÂN HỆ ĐĂNG NHẬP & PHÂN QUYỀN (CHAIN OF RESP)");
            Console.WriteLine("================================================================================");

            // Thiết lập chuỗi trách nhiệm:
            // Bước 1: Kiểm tra rỗng -> Bước 2: Xác thực thông tin -> Bước 3: Kiểm tra khóa -> Bước 4: Phân quyền
            var kiemTraTrong = new KiemTraDuLieuTrongHandler();
            var xacThuc = new XacThucTaiKhoanHandler();
            var kiemTraKhoa = new KiemTraKhoaTaiKhoanHandler();
            var phanQuyen = new PhanQuyenTruyCapHandler();

            kiemTraTrong.SetNext(xacThuc)
                        .SetNext(kiemTraKhoa)
                        .SetNext(phanQuyen);

            Console.WriteLine("\n--- KỊCH BẢN 1: Người dùng không nhập tài khoản hoặc mật khẩu ---");
            var req1 = new YeuCauTruyCap("", "", "LapHoaDon");
            kiemTraTrong.XuLy(req1);

            Console.WriteLine("\n--- KỊCH BẢN 2: Nhập sai mật khẩu ---");
            var req2 = new YeuCauTruyCap("banhang_anh", "sai_mat_khau", "LapHoaDon");
            kiemTraTrong.XuLy(req2);

            Console.WriteLine("\n--- KỊCH BẢN 3: Tài khoản đã bị khóa do vi phạm ---");
            var req3 = new YeuCauTruyCap("banhang_khoa", "bh456", "LapHoaDon");
            kiemTraTrong.XuLy(req3);

            Console.WriteLine("\n--- KỊCH BẢN 4: Nhân viên bán hàng truy cập chức năng hạn chế (Cấu hình xuất kho FIFO) ---");
            var req4 = new YeuCauTruyCap("banhang_anh", "bh123", "CauHinhXuatKho");
            kiemTraTrong.XuLy(req4);

            Console.WriteLine("\n--- KỊCH BẢN 5: Nhân viên bán hàng lập hóa đơn hợp lệ ---");
            var req5 = new YeuCauTruyCap("banhang_anh", "bh123", "LapHoaDon");
            kiemTraTrong.XuLy(req5);

            Console.WriteLine("\n--- KỊCH BẢN 6: Quản lý truy cập chức năng Báo cáo tổng hợp toàn công ty ---");
            var req6 = new YeuCauTruyCap("quanly_ag", "ql123", "BaoCaoTongHop");
            kiemTraTrong.XuLy(req6);

            Console.WriteLine("\n================================================================================");
        }
    }
}
