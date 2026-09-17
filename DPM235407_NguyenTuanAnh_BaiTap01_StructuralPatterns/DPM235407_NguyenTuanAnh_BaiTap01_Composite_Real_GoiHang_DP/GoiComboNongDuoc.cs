using System;
using System.Collections.Generic;
using System.Linq;

namespace DPM235407_NguyenTuanAnh_BaiTap01_Composite_Real_GoiHang_DP
{
    // [Composite]: Gói combo khuyến mãi mùa vụ (có thể chứa sản phẩm lẻ hoặc combo con)
    public class GoiComboNongDuoc : INongDuocComponent
    {
        public string Ten { get; set; }
        public decimal TiLeGiamGiaCombo { get; set; } // Ví dụ: 0.1m = giảm 10% cho cả gói
        private readonly List<INongDuocComponent> _danhSachThanhPhan = new List<INongDuocComponent>();

        public GoiComboNongDuoc(string tenCombo, decimal tiLeGiamGia = 0m)
        {
            Ten = tenCombo;
            TiLeGiamGiaCombo = tiLeGiamGia;
        }

        public void Add(INongDuocComponent item)
        {
            _danhSachThanhPhan.Add(item);
        }

        public void Remove(INongDuocComponent item)
        {
            _danhSachThanhPhan.Remove(item);
        }

        public bool IsComposite() => true;

        public decimal TinhTongTien()
        {
            decimal tongGoc = _danhSachThanhPhan.Sum(tp => tp.TinhTongTien());
            decimal tienGiam = tongGoc * TiLeGiamGiaCombo;
            return tongGoc - tienGiam;
        }

        public void HienThiChiTiet(int depth)
        {
            string indent = new string(' ', depth * 3);
            decimal tongGoc = _danhSachThanhPhan.Sum(tp => tp.TinhTongTien());
            Console.WriteLine($"{indent}+ [COMBO KHUYẾN MÃI] {Ten} (Ưu đãi: {TiLeGiamGiaCombo * 100}% | Tổng sau giảm: {TinhTongTien():N0} VNĐ):");

            foreach (var item in _danhSachThanhPhan)
            {
                item.HienThiChiTiet(depth + 1);
            }
        }
    }
}
