using System;
using System.Text;

namespace DPM235407_NguyenTuanAnh_BaiTap01_Composite_Real_GoiHang_DP
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.WriteLine("================================================================================");
            Console.WriteLine(" CÔNG TY NÔNG DƯỢC AN GIANG - QUẢN LÝ GÓI SẢN PHẨM KHUYẾN MÃI MÙA VỤ");
            Console.WriteLine(" MẪU THIẾT KẾ COMPOSITE: CẤU TRÚC CÂY SẢN PHẨM & COMBO ĐỒNG NHẤT");
            Console.WriteLine("================================================================================\n");

            // 1. Tạo các sản phẩm đơn lẻ (Leaf)
            var thuocTruSau = new SanPhamDonLe("SP01", "Thuốc trừ sâu Regent 800WG", "Gói", 25000m, 10);
            var thuocDaoOn = new SanPhamDonLe("SP02", "Thuốc trị đạo ôn Beam 75WP", "Gói", 35000m, 10);
            var thuocTroLuc = new SanPhamDonLe("SP03", "Chất trợ lực bám dính Super Silicon", "Chai", 60000m, 2);

            // 2. Tạo Combo nhánh con: "Combo Bảo Vệ Lá Lúa" (Composite con)
            var comboLaLua = new GoiComboNongDuoc("Combo Bảo Vệ Lá Đòng Lúa Trổ", tiLeGiamGia: 0.05m); // Giảm 5%
            comboLaLua.Add(thuocTruSau);
            comboLaLua.Add(thuocDaoOn);
            comboLaLua.Add(thuocTroLuc);

            // 3. Tạo Combo lớn cấp vụ: "Thùng Giải Pháp Vụ Đông Xuân" (Composite gốc)
            var thungVuDongXuan = new GoiComboNongDuoc("Thùng Giải Pháp Vụ Đông Xuân Toàn Diện", tiLeGiamGia: 0.10m); // Giảm 10%
            thungVuDongXuan.Add(comboLaLua); // Thêm combo con vào combo lớn
            thungVuDongXuan.Add(new SanPhamDonLe("PB01", "Phân bón NPK Đầu Trâu 20-20-15", "Bao 50kg", 750000m, 2));
            thungVuDongXuan.Add(new SanPhamDonLe("PB02", "Phân bón Urê Cà Mau Hạt Đục", "Bao 50kg", 550000m, 1));

            // 4. In toàn bộ cây gói hàng và tính tổng tiền tự động duyệt đệ quy
            Console.WriteLine("--- BẢNG KÊ CÂY GÓI HÀNG ĐẶT MUA CỦA KHÁCH HÀNG ---");
            thungVuDongXuan.HienThiChiTiet(0);

            Console.WriteLine("\n--------------------------------------------------");
            Console.WriteLine($" TỔNG TIỀN THANH TOÁN TOÀN BỘ GÓI HÀNG: {thungVuDongXuan.TinhTongTien():N0} VNĐ");
            Console.WriteLine("--------------------------------------------------");
            Console.WriteLine("--> Mẫu Composite cho phép Client xử lý một sản phẩm đơn hay một thùng combo");
            Console.WriteLine("    chứa nhiều cấp con hoàn toàn đồng nhất qua giao diện INongDuocComponent!");
        }
    }
}
