using System;
using System.Collections.Generic;
using System.Text;

namespace DPM235407_NguyenTuanAnh_Tuan01_Builder_Real_HoaDon_DP
{
    // Product: Hóa đơn
    public class HoaDonBanHang
    {
        private List<string> _thanhPhan = new List<string>();

        public void Add(string phan)
        {
            _thanhPhan.Add(phan);
        }

        public string HienThiHoaDon()
        {
            string str = "Chi tiết hóa đơn:\n";
            foreach (var item in _thanhPhan)
            {
                str += " - " + item + "\n";
            }
            return str;
        }
    }

    // Builder Interface
    public interface IHoaDonBuilder
    {
        void TaoChiTietSanPham();
        void ThemDichVuPhu();
        void ThemChiPhiVanChuyen();
        void ThemGiamGiaKhuyenMai();
        HoaDonBanHang GetHoaDon();
    }

    // Concrete Builder: Xây dựng hóa đơn đầy đủ (có vận chuyển, có giảm giá)
    public class HoaDonDayDuBuilder : IHoaDonBuilder
    {
        private HoaDonBanHang _hoaDon = new HoaDonBanHang();

        public HoaDonDayDuBuilder() { this.Reset(); }
        public void Reset() { this._hoaDon = new HoaDonBanHang(); }

        public void TaoChiTietSanPham() { this._hoaDon.Add("Sản phẩm: Thuốc trừ sâu ABC (SL: 10)"); }
        public void ThemDichVuPhu() { this._hoaDon.Add("Dịch vụ phụ: Phun thuốc hộ"); }
        public void ThemChiPhiVanChuyen() { this._hoaDon.Add("Phí vận chuyển: 50.000 VNĐ"); }
        public void ThemGiamGiaKhuyenMai() { this._hoaDon.Add("Giảm giá: 10% (Chương trình Mùa Vụ)"); }

        public HoaDonBanHang GetHoaDon()
        {
            HoaDonBanHang result = this._hoaDon;
            this.Reset();
            return result;
        }
    }

    // Director: Quản lý luồng tạo hóa đơn
    public class NhanVienThuNgan
    {
        private IHoaDonBuilder _builder;
        public IHoaDonBuilder Builder { set { _builder = value; } }

        public void LapHoaDonCoBan()
        {
            this._builder.TaoChiTietSanPham();
        }

        public void LapHoaDonDichVuTamDiem()
        {
            this._builder.TaoChiTietSanPham();
            this._builder.ThemDichVuPhu();
            this._builder.ThemChiPhiVanChuyen();
            this._builder.ThemGiamGiaKhuyenMai();
        }
    }

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