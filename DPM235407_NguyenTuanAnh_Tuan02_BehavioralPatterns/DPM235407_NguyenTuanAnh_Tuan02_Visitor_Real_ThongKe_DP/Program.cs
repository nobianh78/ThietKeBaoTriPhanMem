using System;
using System.Collections.Generic;

namespace DPM235407_NguyenTuanAnh_Tuan02_Visitor_Real_ThongKe_DP
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.WriteLine("================================================================================");
            Console.WriteLine(" CÔNG TY NÔNG DƯỢC AN GIANG - PHÂN HỆ THỐNG KÊ BÁO CÁO ĐA CHIỀU (VISITOR)");
            Console.WriteLine("================================================================================");

            // Tập hợp các đối tượng dữ liệu trong hệ thống
            var danhSachDuLieu = new List<IDoiTuongDuLieuElement>();

            // 1. Thêm các hóa đơn bán hàng tháng 3/2026
            danhSachDuLieu.Add(new HoaDonBanHangElement("HD-001", "Nguyễn Tuấn Anh", new DateTime(2026, 3, 2),  12000000, 600000, 250000, 100000));
            danhSachDuLieu.Add(new HoaDonBanHangElement("HD-002", "Nguyễn Tuấn Anh", new DateTime(2026, 3, 10), 18500000, 950000, 300000, 0));
            danhSachDuLieu.Add(new HoaDonBanHangElement("HD-003", "Lê Văn Khoa",     new DateTime(2026, 3, 12),  8000000,  300000, 150000, 50000));
            danhSachDuLieu.Add(new HoaDonBanHangElement("HD-004", "Nguyễn Tuấn Anh", new DateTime(2026, 3, 22), 25000000, 1500000, 400000, 200000));
            danhSachDuLieu.Add(new HoaDonBanHangElement("HD-005", "Lê Văn Khoa",     new DateTime(2026, 3, 28), 14000000, 500000, 200000, 0));

            // 2. Thêm các lô hàng tồn kho
            danhSachDuLieu.Add(new LoHangTonKhoElement("LO-VIR-01", "Thuốc trừ sâu Virtako", 250, 38000, new DateTime(2027, 6, 30)));
            danhSachDuLieu.Add(new LoHangTonKhoElement("LO-FIL-02", "Thuốc trừ đạo ôn Filia", 180, 105000, new DateTime(2026, 12, 31)));
            danhSachDuLieu.Add(new LoHangTonKhoElement("LO-CHE-03", "Thuốc trừ rầy Chess", 320, 55000, new DateTime(2027, 3, 15)));

            // 3. Thêm các dịch vụ phát sinh
            danhSachDuLieu.Add(new DichVuPhatSinhElement("DV-01", "Khảo nghiệm nồng độ thuốc ruộng", new DateTime(2026, 3, 5), "Nguyễn Tuấn Anh", 150000));
            danhSachDuLieu.Add(new DichVuPhatSinhElement("DV-02", "Bốc xếp xe tải đêm", new DateTime(2026, 3, 18), "Lê Văn Khoa", 200000));

            DateTime tuNgay = new DateTime(2026, 3, 1);
            DateTime denNgay = new DateTime(2026, 3, 31);

            // BÁO CÁO 1: Áp dụng Visitor thống kê theo nhân viên "Nguyễn Tuấn Anh" từ ngày đến ngày
            var visitorNhanVienAnh = new BaoCaoTheoNhanVienTuNgayDenNgayVisitor(tuNgay, denNgay, "Nguyễn Tuấn Anh");
            foreach (var item in danhSachDuLieu) item.Accept(visitorNhanVienAnh);
            visitorNhanVienAnh.InKetQuaBaoCao();

            // BÁO CÁO 2: Áp dụng Visitor thống kê theo nhân viên "Lê Văn Khoa" từ ngày đến ngày
            var visitorNhanVienKhoa = new BaoCaoTheoNhanVienTuNgayDenNgayVisitor(tuNgay, denNgay, "Lê Văn Khoa");
            foreach (var item in danhSachDuLieu) item.Accept(visitorNhanVienKhoa);
            visitorNhanVienKhoa.InKetQuaBaoCao();

            // BÁO CÁO 3: Áp dụng Visitor thống kê tổng hợp toàn công ty: tồn kho, cước vận chuyển, dịch vụ phụ, giảm giá
            var visitorTongHop = new BaoCaoTonKhoVaChiPhiPhuTuNgayDenNgayVisitor(tuNgay, denNgay);
            foreach (var item in danhSachDuLieu) item.Accept(visitorTongHop);
            visitorTongHop.InKetQuaBaoCao();

            Console.WriteLine("\n================================================================================");
        }
    }
}
