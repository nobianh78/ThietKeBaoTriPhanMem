using System;
using System.Collections.Generic;
using System.Linq;

namespace DPM235407_NguyenTuanAnh_Tuan02_Memento_Real_HoaDon_DP
{
    // Memento lưu trữ trạng thái snapshot của hóa đơn
    public class HoaDonMemento : IMementoHoaDon
    {
        public List<ChiTietThuoc> DanhSachSanPham { get; }
        public decimal ChiPhiVanChuyen { get; }
        public decimal DichVuPhatSinh { get; }
        public string TenDichVu { get; }
        public decimal GiamGia { get; }
        public DateTime ThoiGian { get; }
        public string MoTa { get; }

        public HoaDonMemento(List<ChiTietThuoc> sanPhams, decimal phiVanChuyen, decimal dichVu, string tenDichVu, decimal giamGia, string moTa)
        {
            // Sao lưu độc lập danh sách sản phẩm (Deep Copy)
            DanhSachSanPham = sanPhams.Select(sp => sp.Clone()).ToList();
            ChiPhiVanChuyen = phiVanChuyen;
            DichVuPhatSinh = dichVu;
            TenDichVu = tenDichVu;
            GiamGia = giamGia;
            ThoiGian = DateTime.Now;
            MoTa = moTa;
        }

        public DateTime GetThoiGian() => ThoiGian;
        public string GetMoTa() => $"[{ThoiGian:HH:mm:ss}] {MoTa} (Tổng tiền: {TinhTong():N0}đ)";

        private decimal TinhTong()
        {
            decimal tienHang = DanhSachSanPham.Sum(s => s.ThanhTien);
            return tienHang + ChiPhiVanChuyen + DichVuPhatSinh - GiamGia;
        }
    }
}
