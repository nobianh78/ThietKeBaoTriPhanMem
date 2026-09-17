using System;
using System.Collections.Generic;

namespace DPM235407_NguyenTuanAnh_Tuan02_Iterator_Real_KhoHang_DP
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.WriteLine("================================================================================");
            Console.WriteLine(" CÔNG TY NÔNG DƯỢC AN GIANG - PHÂN HỆ QUẢN LÝ XUẤT LÔ KHO THEO CẤU HÌNH (ITERATOR)");
            Console.WriteLine("================================================================================");

            var kho = new KhoHangNongDuoc();

            // Nhập kho các lô thuốc nông dược với ngày sản xuất, ngày nhập và HSD khác nhau
            kho.NhapLoHang(new LoHangNongDuoc("LO-2025-01", "Thuốc trừ rầy Chess 50WG", "Pymetrozine", new DateTime(2025, 1, 10), new DateTime(2026, 12, 31), 40, 65000));
            kho.NhapLoHang(new LoHangNongDuoc("LO-2024-09", "Thuốc trừ rầy Chess 50WG", "Pymetrozine", new DateTime(2024, 9, 15), new DateTime(2026, 6, 30),  50, 62000));
            kho.NhapLoHang(new LoHangNongDuoc("LO-2025-03", "Thuốc trừ rầy Chess 50WG", "Pymetrozine", new DateTime(2025, 3, 20), new DateTime(2027, 3, 20),  80, 68000));
            kho.NhapLoHang(new LoHangNongDuoc("LO-2024-11", "Thuốc trừ rầy Chess 50WG", "Pymetrozine", new DateTime(2024, 11, 5),  new DateTime(2026, 9, 15),  35, 63000));

            Console.WriteLine("\n=== DANH SÁCH TOÀN BỘ CÁC LÔ HÀNG ĐANG CÓ TRONG KHO ===");
            var itAll = kho.TaoIterator(KieuXuatKho.NhapTruocXuatTruoc_FIFO);
            while (itAll.HasNext())
            {
                Console.WriteLine(itAll.Next());
            }

            Console.WriteLine("\n================================================================================");
            Console.WriteLine(" CẤU HÌNH 1 (YÊU CẦU ĐỀ BÀI): TỰ ĐỘNG PHÂN LÔ THEO NGÀY HẾT HẠN TRƯỚC XUẤT TRƯỚC (FEFO)");
            Console.WriteLine(" (Hệ thống tự chọn lô hết hạn sớm nhất để tránh tồn kho thuốc BVTV quá hạn)");
            Console.WriteLine("================================================================================");
            // Yêu cầu xuất 70 gói thuốc Chess 50WG
            kho.XuatKhoPhanLo("Thuốc trừ rầy Chess 50WG", 70, KieuXuatKho.HetHanTruocXuatTruoc_FEFO);

            Console.WriteLine("\n================================================================================");
            Console.WriteLine(" CẤU HÌNH 2 (YÊU CẦU ĐỀ BÀI): XUẤT THEO CHỈ ĐỊNH CỦA NGƯỜI DÙNG");
            Console.WriteLine(" (Khách hàng quen yêu cầu lấy đúng Lô LO-2025-03 hạn dài)");
            Console.WriteLine("================================================================================");
            // Người dùng chủ động chọn lô LO-2025-03
            var chiDinh = new List<string> { "LO-2025-03" };
            kho.XuatKhoPhanLo("Thuốc trừ rầy Chess 50WG", 30, KieuXuatKho.XuatTheoChiDinh, chiDinh);

            Console.WriteLine("\n================================================================================");
        }
    }
}
