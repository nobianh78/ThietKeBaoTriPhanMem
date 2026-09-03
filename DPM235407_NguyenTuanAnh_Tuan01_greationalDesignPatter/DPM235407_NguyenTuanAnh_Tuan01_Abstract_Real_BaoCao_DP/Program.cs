using System;
using System.Text;

namespace DPM235407_NguyenTuanAnh_Tuan01_Abstract_Real_BaoCao_DP
{
    // Abstract Products
    public interface IBaoCaoTonKho
    {
        string XuatBaoCaoTonKho();
    }

    public interface IBaoCaoBanHang
    {
        string XuatBaoCaoGiamGia();
    }

    // Concrete Products (Dành cho Quản lý)
    class BaoCaoTonKhoQuanLy : IBaoCaoTonKho
    {
        public string XuatBaoCaoTonKho() => "Báo cáo tồn kho (View Quản lý): Hiển thị chi tiết giá vốn bình quân gia quyền và toàn bộ kho.";
    }

    class BaoCaoBanHangQuanLy : IBaoCaoBanHang
    {
        public string XuatBaoCaoGiamGia() => "Báo cáo bán hàng (View Quản lý): Thống kê tổng chi phí khuyến mãi của TẤT CẢ nhân viên.";
    }

    // Concrete Products (Dành cho Nhân viên)
    class BaoCaoTonKhoNhanVien : IBaoCaoTonKho
    {
        public string XuatBaoCaoTonKho() => "Báo cáo tồn kho (View Nhân viên): Chỉ hiển thị số lượng tồn để tư vấn khách hàng, ẩn giá vốn.";
    }

    class BaoCaoBanHangNhanVien : IBaoCaoBanHang
    {
        public string XuatBaoCaoGiamGia() => "Báo cáo bán hàng (View Nhân viên): Thống kê hóa đơn giảm giá DO CHÍNH NHÂN VIÊN ĐÓ lập.";
    }

    // Abstract Factory
    public interface IBaoCaoFactory
    {
        IBaoCaoTonKho TaoBaoCaoTonKho();
        IBaoCaoBanHang TaoBaoCaoBanHang();
    }

    // Concrete Factories
    public class FactoryBaoCaoQuanLy : IBaoCaoFactory
    {
        public IBaoCaoTonKho TaoBaoCaoTonKho() => new BaoCaoTonKhoQuanLy();
        public IBaoCaoBanHang TaoBaoCaoBanHang() => new BaoCaoBanHangQuanLy();
    }

    public class FactoryBaoCaoNhanVien : IBaoCaoFactory
    {
        public IBaoCaoTonKho TaoBaoCaoTonKho() => new BaoCaoTonKhoNhanVien();
        public IBaoCaoBanHang TaoBaoCaoBanHang() => new BaoCaoBanHangNhanVien();
    }

    // Client
    class HeThongThongKe
    {
        private IBaoCaoTonKho _baoCaoTonKho;
        private IBaoCaoBanHang _baoCaoBanHang;

        public HeThongThongKe(IBaoCaoFactory factory)
        {
            _baoCaoTonKho = factory.TaoBaoCaoTonKho();
            _baoCaoBanHang = factory.TaoBaoCaoBanHang();
        }

        public void InBaoCao()
        {
            Console.WriteLine(_baoCaoTonKho.XuatBaoCaoTonKho());
            Console.WriteLine(_baoCaoBanHang.XuatBaoCaoGiamGia());
        }
    }

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