using System;
using System.Collections.Generic;
using System.Text;

namespace DPM235407_NguyenTuanAnh_BaiTap01_Flyweight_Real_LoHang_DP
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.WriteLine("================================================================================");
            Console.WriteLine(" CÔNG TY NÔNG DƯỢC AN GIANG - HỆ THỐNG QUẢN LÝ KHO LÔ HÀNG QUY MÔ LỚN");
            Console.WriteLine(" MẪU THIẾT KẾ FLYWEIGHT: TỐI ƯU HÓA BỘ NHỚ LƯU TRỮ HÀNG NGÀN LÔ HÀNG NÔNG DƯỢC");
            Console.WriteLine("================================================================================\n");

            var factory = new ThuocFlyweightFactory();

            // Danh sách các lô hàng trong kho
            var danhSachCacLo = new List<(ThongTinThuocFlyweight flyweight, LoHangContext context)>();

            Console.WriteLine("--- GIAI ĐOẠN 1: NHẬP VÀ PHÂN BỔ 5 LÔ HÀNG MẪU ---");

            // Lô 1: Thuốc trừ bệnh Tilt Super
            var thuoc1 = factory.LayThongTinThuoc("TILT300", "Tilt Super 300EC", "Difenoconazole + Propiconazole", "Chai 250ml", "Syngenta", "GHS Cấp 5");
            var lo1 = new LoHangContext("LO-TILT-2025-01", new DateTime(2025, 1, 10), new DateTime(2027, 1, 10), "Kệ A1-Kho An Giang", 500, 135000m);
            danhSachCacLo.Add((thuoc1, lo1));

            // Lô 2: Cùng loại thuốc Tilt Super nhưng số lô và HSD khác
            var thuoc2 = factory.LayThongTinThuoc("TILT300", "Tilt Super 300EC", "Difenoconazole + Propiconazole", "Chai 250ml", "Syngenta", "GHS Cấp 5");
            var lo2 = new LoHangContext("LO-TILT-2025-02", new DateTime(2025, 6, 15), new DateTime(2027, 6, 15), "Kệ A1-Kho An Giang", 800, 138000m);
            danhSachCacLo.Add((thuoc2, lo2));

            // Lô 3: Thuốc trừ sâu Regent
            var thuoc3 = factory.LayThongTinThuoc("REGENT800", "Regent 800WG", "Fipronil 800g/kg", "Gói 1.6g", "Bayer CropScience", "GHS Cấp 4");
            var lo3 = new LoHangContext("LO-REG-2026-01", new DateTime(2026, 2, 1), new DateTime(2028, 2, 1), "Kệ B2-Kho An Giang", 2000, 25000m);
            danhSachCacLo.Add((thuoc3, lo3));

            // Lô 4: Thuốc trừ sâu Regent nhập tiếp đợt sau
            var thuoc4 = factory.LayThongTinThuoc("REGENT800", "Regent 800WG", "Fipronil 800g/kg", "Gói 1.6g", "Bayer CropScience", "GHS Cấp 4");
            var lo4 = new LoHangContext("LO-REG-2026-02", new DateTime(2026, 5, 20), new DateTime(2028, 5, 20), "Kệ B2-Kho An Giang", 3500, 25000m);
            danhSachCacLo.Add((thuoc4, lo4));

            // Lô 5: Phân bón lá Đầu Trâu
            var thuoc5 = factory.LayThongTinThuoc("DAUTRAU-MK", "Đầu Trâu MK 701", "NPK 10-30-20 + TE", "Hũ 500g", "Bình Điền", "Cấp an toàn");
            var lo5 = new LoHangContext("LO-DT-2026-A", new DateTime(2026, 3, 1), new DateTime(2029, 3, 1), "Kệ C3-Kho Phân", 1200, 65000m);
            danhSachCacLo.Add((thuoc5, lo5));

            Console.WriteLine("\n--- THÔNG TIN CHI TIẾT CÁC LÔ HÀNG XUẤT RA ---");
            foreach (var item in danhSachCacLo)
            {
                item.flyweight.HienThiThongTinLo(item.context);
                Console.WriteLine();
            }

            Console.WriteLine("--- GIAI ĐOẠN 2: THỐNG KÊ TỐI ƯU BỘ NHỚ RAM ---");
            Console.WriteLine($"Tổng số lô hàng đang lưu trữ: {danhSachCacLo.Count} lô");
            Console.WriteLine($"Số đối tượng Flyweight (thông tin thuốc) thực sự được tạo trong RAM: {factory.SoLuongFlyweightTrongRAM} đối tượng!");
            Console.WriteLine("\n--> Nhờ Flyweight Pattern, dù kho có nhập 100.000 lô hàng thì dữ liệu tĩnh");
            Console.WriteLine("    chỉ lưu 1 bản duy nhất trong bộ nhớ, tối ưu triệt để hiệu năng hệ thống!");
        }
    }
}
