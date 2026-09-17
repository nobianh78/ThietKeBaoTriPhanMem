using System;
using System.Collections.Generic;
using System.Linq;

namespace DPM235407_NguyenTuanAnh_Tuan02_State_Real_DonHang_DP
{
    public class MatHangMua
    {
        public string TenThuoc { get; set; }
        public int SoLuong { get; set; }
        public decimal DonGia { get; set; }
        public decimal ThanhTien => SoLuong * DonGia;

        public MatHangMua(string tenThuoc, int soLuong, decimal donGia)
        {
            TenThuoc = tenThuoc;
            SoLuong = soLuong;
            DonGia = donGia;
        }
    }

    // Context: Quản lý Đơn hàng Nông dược An Giang
    public class DonHangNongDuoc
    {
        public string MaDonHang { get; set; }
        public string TenKhachHang { get; set; }
        public List<MatHangMua> DanhSachMatHang { get; } = new();
        public decimal PhiVanChuyen { get; set; } = 0;
        public decimal GiamGiaKhuyenMai { get; set; } = 0;

        public decimal TongTienHang => DanhSachMatHang.Sum(m => m.ThanhTien);
        public decimal TongThanhToan => TongTienHang + PhiVanChuyen - GiamGiaKhuyenMai;

        // Con trỏ State hiện tại
        private ITrangThaiDonHang _trangThaiHienTai;

        public DonHangNongDuoc(string maDon, string tenKhach)
        {
            MaDonHang = maDon;
            TenKhachHang = tenKhach;
            _trangThaiHienTai = new TrangThaiMoiTao();
            Console.WriteLine($"[TẠO ĐƠN] Đơn hàng {MaDonHang} bắt đầu với trạng thái: {_trangThaiHienTai.TenTrangThai}");
        }

        public void ChuyenTrangThai(ITrangThaiDonHang trangThaiMoi)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"\n[CHUYỂN TRẠNG THÁI] {_trangThaiHienTai.TenTrangThai}  ===>  {trangThaiMoi.TenTrangThai}");
            Console.ResetColor();
            _trangThaiHienTai = trangThaiMoi;
        }

        // Ủy quyền hành vi cho State hiện tại
        public void ThemSanPham(string tenThuoc, int soLuong, decimal donGia)
            => _trangThaiHienTai.ThemSanPham(this, tenThuoc, soLuong, donGia);

        public void ThietLapChiPhi(decimal phiShip, decimal giamGia)
            => _trangThaiHienTai.ThietLapChiPhi(this, phiShip, giamGia);

        public void XacNhanDonHang()
            => _trangThaiHienTai.XacNhanDonHang(this);

        public void XuatKhoGiaoHang()
            => _trangThaiHienTai.XuatKhoGiaoHang(this);

        public void HoanTatThanhToan()
            => _trangThaiHienTai.HoanTatThanhToan(this);

        public void HuyDonHang(string lyDo)
            => _trangThaiHienTai.HuyDonHang(this, lyDo);

        public void InThongTin()
        {
            Console.WriteLine("\n--------------------------------------------------------------------------------");
            Console.WriteLine($" ĐƠN HÀNG: {MaDonHang} | KHÁCH: {TenKhachHang} | TRẠNG THÁI: {_trangThaiHienTai.TenTrangThai}");
            Console.WriteLine("--------------------------------------------------------------------------------");
            foreach (var sp in DanhSachMatHang)
            {
                Console.WriteLine($" - {sp.TenThuoc,-32} SL: {sp.SoLuong,4} | Giá: {sp.DonGia,10:N0}đ | Tiền: {sp.ThanhTien,12:N0}đ");
            }
            if (PhiVanChuyen > 0) Console.WriteLine($" + Phí vận chuyển:       {PhiVanChuyen,14:N0} đ");
            if (GiamGiaKhuyenMai > 0) Console.WriteLine($" - Chiết khấu giảm giá:  {GiamGiaKhuyenMai,14:N0} đ");
            Console.WriteLine($" ===> TỔNG CỘNG THANH TOÁN: {TongThanhToan,14:N0} đ");
            Console.WriteLine("--------------------------------------------------------------------------------");
        }
    }
}
