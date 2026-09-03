using System;
using System.Text;

namespace DPM235407_NguyenTuanAnh_Tuan01_Prototype_Real_LoHang_DP
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.WriteLine("=== MẪU PROTOTYPE: QUẢN LÝ LÔ HÀNG ===\n");

            // Tạo lô hàng gốc
            LoHangNongDuoc loGoc = new LoHangNongDuoc("L001", "Phân bón NPK", "Công ty ABC", new DateTime(2027, 1, 1));
            Console.WriteLine("Thông tin Lô hàng gốc:");
            loGoc.HienThiThongTin();

            Console.WriteLine("\nThực hiện nhập kho lô mới cùng loại hàng, chỉ khác Hạn sử dụng...");
            // Nhân bản và sửa đổi thuộc tính cần thiết
            LoHangNongDuoc loMoi = (LoHangNongDuoc)loGoc.Clone();
            loMoi.MaLo = "L002";
            loMoi.NgayHetHan = new DateTime(2028, 5, 1);

            Console.WriteLine("\nThông tin Lô hàng mới (nhân bản từ lô gốc):");
            loMoi.HienThiThongTin();

            Console.ReadLine();
        }
    }
}