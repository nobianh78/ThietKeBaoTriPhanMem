using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace DPM235407_NguyenTuanAnh_BaiTap03_03_OrganizingData._01_Self_Encapsulate_Collection
{
    // =========================================================================
    // AFTER: Áp dụng kỹ thuật Encapsulate Collection (Đóng gói tập hợp)
    // - Danh sách thực sự được giữ `private`.
    // - Getter chỉ trả về `IReadOnlyCollection<T>` hoặc `ReadOnlyCollection<T>`.
    // - Thêm các phương thức nghiệp vụ kiểm soát: `ThemMatHang()`, `XoaMatHang()`.
    // =========================================================================
    public class MatHang_After
    {
        public string TenHang { get; }
        public decimal DonGia { get; }

        public MatHang_After(string tenHang, decimal donGia)
        {
            if (string.IsNullOrWhiteSpace(tenHang)) throw new ArgumentException("Tên hàng không được rỗng");
            if (donGia <= 0) throw new ArgumentException("Đơn giá phải lớn hơn 0");
            TenHang = tenHang;
            DonGia = donGia;
        }
    }

    public class PhieuXuat_After
    {
        public string MaPhieu { get; }
        private readonly List<MatHang_After> _danhSachMatHang = new();

        public PhieuXuat_After(string maPhieu)
        {
            MaPhieu = maPhieu;
        }

        // Chỉ trả về ReadOnlyCollection để ngăn chặn chỉnh sửa từ bên ngoài
        public IReadOnlyList<MatHang_After> DanhSachMatHang => _danhSachMatHang.AsReadOnly();

        public void ThemMatHang(MatHang_After matHang)
        {
            if (matHang == null) throw new ArgumentNullException(nameof(matHang));
            _danhSachMatHang.Add(matHang);
        }

        public bool XoaMatHang(MatHang_After matHang)
        {
            return _danhSachMatHang.Remove(matHang);
        }

        public decimal TongTien
        {
            get
            {
                decimal tong = 0;
                foreach (var item in _danhSachMatHang) tong += item.DonGia;
                return tong;
            }
        }
    }
}
