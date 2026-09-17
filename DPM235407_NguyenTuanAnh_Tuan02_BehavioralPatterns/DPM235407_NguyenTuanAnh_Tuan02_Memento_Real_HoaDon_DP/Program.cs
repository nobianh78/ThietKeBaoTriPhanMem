using System;

namespace DPM235407_NguyenTuanAnh_Tuan02_Memento_Real_HoaDon_DP
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.WriteLine("================================================================================");
            Console.WriteLine(" CÔNG TY NÔNG DƯỢC AN GIANG - PHÂN HỆ LƯU TRỮ VÀ HOÀN TÁC HÓA ĐƠN (MEMENTO)");
            Console.WriteLine("================================================================================");

            var hoaDon = new HoaDonBanHang("HD-NONGDUOC-882", "Đại lý Út Mập - Chợ Mới An Giang");
            var caretaker = new LichSuHoaDonCaretaker(hoaDon);

            Console.WriteLine("\n--- BƯỚC 1: Lập đơn ban đầu với 2 mặt hàng thuốc BVTV ---");
            hoaDon.DanhSachSanPham.Add(new ChiTietThuoc("Thuốc trừ bệnh Tilt Super 300EC", 20, 150000));
            hoaDon.DanhSachSanPham.Add(new ChiTietThuoc("Thuốc trừ cỏ lúa Nominee 100SC", 15, 95000));
            hoaDon.InThongTin();
            caretaker.SaoLuu("Bản nháp 1: Chỉ gồm 2 loại thuốc ban đầu");

            Console.WriteLine("\n--- BƯỚC 2: Thêm phí vận chuyển xe tải giao tận ruộng ---");
            hoaDon.ChiPhiVanChuyen = 200000;
            hoaDon.InThongTin();
            caretaker.SaoLuu("Bản nháp 2: Đã cộng thêm 200,000đ phí giao hàng");

            Console.WriteLine("\n--- BƯỚC 3: Nhập thêm dịch vụ phun khảo nghiệm và chiết khấu giảm giá ---");
            hoaDon.TenDichVu = "Khảo nghiệm phòng trừ đạo ôn lúa";
            hoaDon.DichVuPhatSinh = 350000;
            hoaDon.GiamGia = 500000;
            hoaDon.InThongTin();
            caretaker.SaoLuu("Bản nháp 3: Đã cộng dịch vụ thử nghiệm và chiết khấu 500k");

            Console.WriteLine("\n--- BƯỚC 4: KHÁCH ĐỔI Ý, YÊU CẦU HOÀN TÁC (UNDO) VỀ TRẠNG THÁI TRƯỚC ĐÓ ---");
            // Undo lần 1: bỏ dịch vụ và chiết khấu (quay về Bản nháp 2)
            caretaker.HoanTac();
            hoaDon.InThongTin();

            // Undo lần 2: khách tự lấy hàng, bỏ cả phí vận chuyển (quay về Bản nháp 1)
            caretaker.HoanTac();
            hoaDon.InThongTin();

            caretaker.HienThiLichSu();

            Console.WriteLine("\n================================================================================");
        }
    }
}
