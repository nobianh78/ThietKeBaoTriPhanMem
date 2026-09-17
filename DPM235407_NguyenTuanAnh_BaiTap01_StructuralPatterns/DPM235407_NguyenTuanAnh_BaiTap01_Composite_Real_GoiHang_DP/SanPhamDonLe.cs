using System;

namespace DPM235407_NguyenTuanAnh_BaiTap01_Composite_Real_GoiHang_DP
{
    // [Leaf]: Sản phẩm nông dược đơn lẻ (thuốc bảo vệ thực vật, phân bón)
    public class SanPhamDonLe : INongDuocComponent
    {
        public string MaSanPham { get; set; }
        public string Ten { get; set; }
        public string DonViTinh { get; set; } // Chai, Gói, Bao 50kg
        public decimal DonGia { get; set; }
        public int SoLuong { get; set; }

        public SanPhamDonLe(string ma, string ten, string dvt, decimal donGia, int soLuong)
        {
            MaSanPham = ma;
            Ten = ten;
            DonViTinh = dvt;
            DonGia = donGia;
            SoLuong = soLuong;
        }

        public decimal TinhTongTien()
        {
            return DonGia * SoLuong;
        }

        public void HienThiChiTiet(int depth)
        {
            string indent = new string(' ', depth * 3);
            Console.WriteLine($"{indent}- [{MaSanPham}] {Ten} | {SoLuong} {DonViTinh} x {DonGia:N0} = {TinhTongTien():N0} VNĐ");
        }

        public void Add(INongDuocComponent item)
        {
            throw new NotSupportedException("Sản phẩm đơn lẻ không thể chứa sản phẩm con.");
        }

        public void Remove(INongDuocComponent item)
        {
            throw new NotSupportedException("Sản phẩm đơn lẻ không thể xóa sản phẩm con.");
        }

        public bool IsComposite() => false;
    }
}
