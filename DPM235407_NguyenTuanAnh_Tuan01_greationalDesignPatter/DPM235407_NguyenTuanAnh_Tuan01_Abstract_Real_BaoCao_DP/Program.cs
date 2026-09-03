using System;
using System.Text;

namespace DPM235407_NguyenTuanAnh_Tuan01_Abstract_Real_BaoCao_DP
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.WriteLine("=== MẪU ABSTRACT FACTORY: HỆ THỐNG THỐNG KÊ BÁO CÁO ===\n");

            Console.WriteLine(">> Kịch bản 1: Giám đốc truy cập hệ thống thống kê:");
            HeThongThongKe heThongAdmin = new HeThongThongKe(new FactoryBaoCaoQuanLy());
            heThongAdmin.InBaoCao();

            Console.WriteLine("\n>> Kịch bản 2: Nhân viên bán hàng truy cập hệ thống thống kê:");
            HeThongThongKe heThongStaff = new HeThongThongKe(new FactoryBaoCaoNhanVien());
            heThongStaff.InBaoCao();

            Console.ReadLine();
        }
    }
}