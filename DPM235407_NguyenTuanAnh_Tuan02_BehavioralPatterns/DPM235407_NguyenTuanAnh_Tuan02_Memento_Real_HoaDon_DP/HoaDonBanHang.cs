using System;
using System.Collections.Generic;
using System.Linq;

namespace DPM235407_NguyenTuanAnh_Tuan02_Memento_Real_HoaDon_DP
{
    // Originator: Hóa đơn bán nông dược An Giang
    public class HoaDonBanHang
    {
        public string MaHoaDon { get; set; }
        public string KhachHang { get; set; }
        public List<ChiTietThuoc> DanhSachSanPham { get; set; } = new();
        public decimal ChiPhiVanChuyen { get; set; } = 0;
        public decimal DichVuPhatSinh { get; set; } = 0;
        public string TenDichVu { get; set; } = string.Empty;
        public decimal GiamGia { get; set; } = 0;

        public decimal TongTienHang => DanhSachSanPham.Sum(s => s.ThanhTien);
        public decimal TongThanhToan => TongTienHang + ChiPhiVanChuyen + DichVuPhatSinh - GiamGia;

        public HoaDonBanHang(string maHoaDon, string khachHang)
        {
            MaHoaDon = maHoaDon;
            KhachHang = khachHang;
        }

        // Tạo snapshot trạng thái hiện tại
        public IMementoHoaDon LuuTrangThai(string moTa)
        {
            return new HoaDonMemento(DanhSachSanPham, ChiPhiVanChuyen, DichVuPhatSinh, TenDichVu, GiamGia, moTa);
        }

        // Khôi phục lại trạng thái từ snapshot
        public void KhoiPhucTrangThai(IMementoHoaDon memento)
        {
            if (memento is not HoaDonMemento snapshot)
            {
                throw new Exception("Đối tượng Memento không hợp lệ!");
            }

            DanhSachSanPham = snapshot.DanhSachSanPham.Select(sp => sp.Clone()).ToList();
            ChiPhiVanChuyen = snapshot.ChiPhiVanChuyen;
            DichVuPhatSinh = snapshot.DichVuPhatSinh;
            TenDichVu = snapshot.TenDichVu;
            GiamGia = snapshot.GiamGia;

            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine($"\n[MEMENTO UNDO] Đã khôi phục hóa đơn về: {snapshot.GetMoTa()}");
            Console.ResetColor();
        }

        public void InThongTin()
        {
            Console.WriteLine("\n--------------------------------------------------------------------------------");
            Console.WriteLine($" HÓA ĐƠN: {MaHoaDon} | KHÁCH HÀNG: {KhachHang}");
            Console.WriteLine("--------------------------------------------------------------------------------");
            foreach (var sp in DanhSachSanPham)
            {
                Console.WriteLine($" - {sp.TenThuoc,-32} SL: {sp.SoLuong,4} | Đơn giá: {sp.DonGia,12:N0}đ | Tiền: {sp.ThanhTien,12:N0}đ");
            }
            if (ChiPhiVanChuyen > 0) Console.WriteLine($" + Phí vận chuyển:        {ChiPhiVanChuyen,14:N0} đ");
            if (DichVuPhatSinh > 0)  Console.WriteLine($" + Dịch vụ phụ ({TenDichVu}): {DichVuPhatSinh,14:N0} đ");
            if (GiamGia > 0)         Console.WriteLine($" - Giảm giá khuyến mãi:  {GiamGia,14:N0} đ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($" ===> TỔNG CỘNG HÓA ĐƠN:  {TongThanhToan,14:N0} đ");
            Console.ResetColor();
            Console.WriteLine("--------------------------------------------------------------------------------");
        }
    }
}
