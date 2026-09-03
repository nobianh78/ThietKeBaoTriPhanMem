using System;
using System.Text;

namespace DPM235407_NguyenTuanAnh_Tuan01_Prototype_Real_LoHang_DP
{
    // Prototype interface
    public interface ILoHangPrototype
    {
        ILoHangPrototype Clone();
    }

    // Concrete Prototype
    public class LoHangNongDuoc : ILoHangPrototype
    {
        public string MaLo { get; set; }
        public string TenSanPham { get; set; }
        public string NhaCungCap { get; set; }
        public DateTime NgayHetHan { get; set; }

        public LoHangNongDuoc(string maLo, string tenSanPham, string nhaCungCap, DateTime ngayHetHan)
        {
            MaLo = maLo;
            TenSanPham = tenSanPham;
            NhaCungCap = nhaCungCap;
            NgayHetHan = ngayHetHan;
        }

        // Tạo bản sao hời (Shallow copy)
        public ILoHangPrototype Clone()
        {
            Console.WriteLine($"[Hệ thống] Đang nhân bản Lô hàng {MaLo}...");
            return (ILoHangPrototype)this.MemberwiseClone();
        }

        public void HienThiThongTin()
        {
            Console.WriteLine($"- Lô: {MaLo} | SP: {TenSanPham} | NCC: {NhaCungCap} | HSD: {NgayHetHan.ToShortDateString()}");
        }
    }

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