using System;
using System.Collections.Generic;

namespace DPM235407_NguyenTuanAnh_BaiTap03_03_OrganizingData._01_Self_Encapsulate_Collection
{
    // =========================================================================
    // REAL APPLICATION (Hệ thống Nông Dược An Giang):
    // Trong `PhieuBan.cs` gốc: `public IList<ChiTietPhieuBan> ChiTiet { get; set; }`
    // Cho phép bất kỳ Controller hoặc Form nào gán `ChiTiet = null` hoặc thêm dòng
    // mà không đồng bộ cập nhật trường `TongTien` và `ConNo`.
    // REFACTOR: Encapsulate Collection + Tự động tính toán tổng tiền bất biến.
    // =========================================================================

    public class DongPhieuBanNongDuoc
    {
        public string MaSanPham { get; }
        public string TenThuoc { get; }
        public int SoLuong { get; private set; }
        public decimal DonGia { get; }

        public DongPhieuBanNongDuoc(string maSP, string tenThuoc, int soLuong, decimal donGia)
        {
            if (soLuong <= 0) throw new ArgumentOutOfRangeException(nameof(soLuong), "Số lượng phải > 0");
            if (donGia <= 0) throw new ArgumentOutOfRangeException(nameof(donGia), "Đơn giá phải > 0");

            MaSanPham = maSP;
            TenThuoc = tenThuoc;
            SoLuong = soLuong;
            DonGia = donGia;
        }

        public void TangSoLuong(int them)
        {
            if (them <= 0) throw new ArgumentOutOfRangeException(nameof(them));
            SoLuong += them;
        }

        public decimal ThanhTien => SoLuong * DonGia;
    }

    public class PhieuBanNongDuoc_Real
    {
        public string MaPhieu { get; }
        public string TenKhachHang { get; }
        public DateTime NgayLapPhieu { get; }
        private readonly List<DongPhieuBanNongDuoc> _chiTietList = new();

        public PhieuBanNongDuoc_Real(string maPhieu, string tenKhachHang)
        {
            MaPhieu = maPhieu;
            TenKhachHang = tenKhachHang;
            NgayLapPhieu = DateTime.Now;
        }

        // Đóng gói danh sách chi tiết
        public IReadOnlyList<DongPhieuBanNongDuoc> ChiTiet => _chiTietList.AsReadOnly();

        public void ThemHoacCapNhatSanPham(string maSP, string tenThuoc, int soLuong, decimal donGia)
        {
            var tonTai = _chiTietList.Find(x => x.MaSanPham == maSP);
            if (tonTai != null)
            {
                tonTai.TangSoLuong(soLuong);
            }
            else
            {
                _chiTietList.Add(new DongPhieuBanNongDuoc(maSP, tenThuoc, soLuong, donGia));
            }
        }

        public bool XoaSanPham(string maSP)
        {
            int index = _chiTietList.FindIndex(x => x.MaSanPham == maSP);
            if (index >= 0)
            {
                _chiTietList.RemoveAt(index);
                return true;
            }
            return false;
        }

        public decimal TongTienHang
        {
            get
            {
                decimal tong = 0;
                foreach (var ct in _chiTietList) tong += ct.ThanhTien;
                return tong;
            }
        }

        public void InPhieuXuat()
        {
            Console.WriteLine($"\n================== PHIẾU BÁN HÀNG: {MaPhieu} ==================");
            Console.WriteLine($"Khách hàng: {TenKhachHang} | Ngày lập: {NgayLapPhieu:dd/MM/yyyy HH:mm}");
            Console.WriteLine("---------------------------------------------------------------");
            foreach (var item in _chiTietList)
            {
                Console.WriteLine($" * [{item.MaSanPham}] {item.TenThuoc,-25} | SL: {item.SoLuong,3} | Đơn giá: {item.DonGia,9:N0} đ | TT: {item.ThanhTien,10:N0} đ");
            }
            Console.WriteLine("---------------------------------------------------------------");
            Console.WriteLine($"TỔNG TIỀN HÀNG: {TongTienHang,12:N0} VNĐ\n");
        }
    }
}
