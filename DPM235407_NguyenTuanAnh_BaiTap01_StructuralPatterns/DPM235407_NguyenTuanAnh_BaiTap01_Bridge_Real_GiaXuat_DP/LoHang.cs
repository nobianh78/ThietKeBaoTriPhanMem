using System;

namespace DPM235407_NguyenTuanAnh_BaiTap01_Bridge_Real_GiaXuat_DP
{
    // Thông tin lô hàng nông dược trong kho
    public class LoHang
    {
        public string SoLo { get; set; } = string.Empty;
        public string TenThuoc { get; set; } = string.Empty;
        public int SoLuongTon { get; set; }
        public decimal DonGiaNhap { get; set; }
        public DateTime HanSuDung { get; set; }

        public LoHang(string soLo, string tenThuoc, int soLuong, decimal donGia, DateTime hsd)
        {
            SoLo = soLo;
            TenThuoc = tenThuoc;
            SoLuongTon = soLuong;
            DonGiaNhap = donGia;
            HanSuDung = hsd;
        }
    }
}
