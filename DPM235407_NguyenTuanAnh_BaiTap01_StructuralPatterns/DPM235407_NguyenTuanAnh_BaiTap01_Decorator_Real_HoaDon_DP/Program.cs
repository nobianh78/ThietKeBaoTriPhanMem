using System;
using System.Text;

namespace DPM235407_NguyenTuanAnh_BaiTap01_Decorator_Real_HoaDon_DP
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.WriteLine("================================================================================");
            Console.WriteLine(" CÔNG TY NÔNG DƯỢC AN GIANG - QUẢN LÝ LẬP HÓA ĐƠN BÁN HÀNG");
            Console.WriteLine(" MẪU THIẾT KẾ DECORATOR: BỔ SUNG CHI PHÍ VẬN CHUYỂN, DỊCH VỤ PHỤ & GIẢM GIÁ");
            Console.WriteLine("================================================================================\n");

            // 1. Lập hóa đơn bán hàng cơ bản (tiền thuốc gốc)
            var hoaDonGoc = new HoaDonCoBan("HD-AG-2026-999", "Bác Ba Nông Dân (Chợ Mới)");
            hoaDonGoc.ThemMatHang("Thuốc diệt ốc bươu vàng Bolis 12GB", soLuong: 10, donGia: 32000m);
            hoaDonGoc.ThemMatHang("Thuốc kích kháng đạo ôn Filia 525SE", soLuong: 5, donGia: 185000m);

            Console.WriteLine("--- GIAI ĐOẠN 1: HÓA ĐƠN CƠ BẢN TẠI QUẦY ---");
            Console.WriteLine(hoaDonGoc.InChiTietHoaDon());
            Console.WriteLine($"TỔNG CỘNG: {hoaDonGoc.TinhTongTien():N0} VNĐ\n");

            // 2. Khách hàng yêu cầu giao hàng tận ruộng -> Decorate thêm Phí Vận Chuyển
            IHoaDon hoaDonCoGiaoHang = new PhiVanChuyenDecorator(
                hoaDonGoc, 
                phiVanChuyen: 50000m, 
                phuongThucGiao: "Xe lôi giao tận bờ ruộng Tri Tôn"
            );

            // 3. Khách hàng sử dụng dịch vụ phụ bốc xếp phân thuốc -> Decorate thêm Dịch Vụ Phát Sinh
            IHoaDon hoaDonCoDichVu = new DichVuPhatSinhDecorator(
                hoaDonCoGiaoHang,
                tenDichVu: "Bốc xếp hàng nặng và pha thuốc thử nghiệm",
                phiDichVu: 30000m
            );

            // 4. Áp dụng chính sách khuyến mãi đầu vụ lúa -> Decorate thêm Giảm Giá Khuyến Mãi
            IHoaDon hoaDonHoanChinh = new GiamGiaKhuyenMaiDecorator(
                hoaDonCoDichVu,
                chuongTrinh: "Khuyến mãi Mừng Vụ Mùa Bội Thu 2026",
                soTienGiam: 75000m
            );

            Console.WriteLine("--- GIAI ĐOẠN 2: HÓA ĐƠN HOÀN CHỈNH (CÓ PHÍ VẬN CHUYỂN, DỊCH VỤ PHỤ & GIẢM GIÁ) ---");
            Console.WriteLine(hoaDonHoanChinh.InChiTietHoaDon());
            Console.WriteLine("==================================================");
            Console.WriteLine($" TỔNG TIỀN PHẢI THANH TOÁN: {hoaDonHoanChinh.TinhTongTien():N0} VNĐ");
            Console.WriteLine("==================================================");
            Console.WriteLine("--> Mẫu Decorator giúp giải quyết triệt để lỗi hiện trạng của đề bài:");
            Console.WriteLine("    Linh hoạt cộng thêm chi phí giao hàng, dịch vụ phát sinh và trừ giảm giá!");
        }
    }
}
