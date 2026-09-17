using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DPM235407_NguyenTuanAnh_BaiTap01_Decorator_Real_HoaDon_DP
{
    // [Concrete Component]: Hóa đơn cơ bản ban đầu (chỉ tính tiền hàng thuần túy)
    public class HoaDonCoBan : IHoaDon
    {
        public string MaHoaDon { get; }
        public string TenKhachHang { get; }
        public DateTime NgayLap { get; }
        private readonly List<(string tenThuoc, int soLuong, decimal donGia)> _matHang = new();

        public HoaDonCoBan(string maHD, string tenKhach)
        {
            MaHoaDon = maHD;
            TenKhachHang = tenKhach;
            NgayLap = DateTime.Now;
        }

        public void ThemMatHang(string tenThuoc, int soLuong, decimal donGia)
        {
            _matHang.Add((tenThuoc, soLuong, donGia));
        }

        public decimal TinhTongTien()
        {
            return _matHang.Sum(x => x.soLuong * x.donGia);
        }

        public string InChiTietHoaDon()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"HÓA ĐƠN BÁN HÀNG: {MaHoaDon} | Ngày lập: {NgayLap:dd/MM/yyyy HH:mm}");
            sb.AppendLine($"Khách hàng: {TenKhachHang}");
            sb.AppendLine("Danh sách nông dược xuất bán:");
            foreach (var item in _matHang)
            {
                decimal thanhTien = item.soLuong * item.donGia;
                sb.AppendLine($"  * {item.tenThuoc}: {item.soLuong} x {item.donGia:N0} = {thanhTien:N0} VNĐ");
            }
            sb.AppendLine($"--> Tiền hàng cơ bản: {TinhTongTien():N0} VNĐ");
            return sb.ToString();
        }
    }
}
