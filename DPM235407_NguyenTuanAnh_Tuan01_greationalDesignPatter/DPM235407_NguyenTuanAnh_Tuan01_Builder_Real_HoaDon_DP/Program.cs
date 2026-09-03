using System;
using System.Text;

namespace DPM235407_NguyenTuanAnh_Tuan01_Builder_Real_HoaDon_DP
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.WriteLine("=== MẪU BUILDER: LẬP HÓA ĐƠN BÁN HÀNG ===\n");

            var director = new NhanVienThuNgan();
            var builder = new HoaDonDayDuBuilder();
            director.Builder = builder;

            Console.WriteLine("1. Lập hóa đơn mua tại quầy (Không giao hàng, không dịch vụ):");
            director.LapHoaDonCoBan();
            Console.WriteLine(builder.GetHoaDon().HienThiHoaDon());

            Console.WriteLine("2. Lập hóa đơn giao tận nơi (Đầy đủ chi phí, có giảm giá):");
            director.LapHoaDonDichVuTamDiem();
            Console.WriteLine(builder.GetHoaDon().HienThiHoaDon());

            Console.ReadLine();
        }
    }
}