using System;

namespace DPM235407_NguyenTuanAnh_Tuan02_Strategy_Real_GiaXuat_DP
{
    // Thông tin lô hàng thuốc bảo vệ thực vật nhập kho
    public class LoThuocNhap
    {
        public string MaLo { get; set; }
        public string TenThuoc { get; set; }
        public DateTime NgayNhap { get; set; }
        public int SoLuongTon { get; set; }
        public decimal DonGiaNhap { get; set; }

        public LoThuocNhap(string maLo, string tenThuoc, DateTime ngayNhap, int soLuongTon, decimal donGiaNhap)
        {
            MaLo = maLo;
            TenThuoc = tenThuoc;
            NgayNhap = ngayNhap;
            SoLuongTon = soLuongTon;
            DonGiaNhap = donGiaNhap;
        }

        public LoThuocNhap Clone() => new(MaLo, TenThuoc, NgayNhap, SoLuongTon, DonGiaNhap);
    }

    public class ChiTietXuatLo
    {
        public string MaLo { get; set; }
        public int SoLuongXuat { get; set; }
        public decimal DonGiaVon { get; set; }
        public decimal ThanhTien => SoLuongXuat * DonGiaVon;

        public ChiTietXuatLo(string maLo, int soLuongXuat, decimal donGiaVon)
        {
            MaLo = maLo;
            SoLuongXuat = soLuongXuat;
            DonGiaVon = donGiaVon;
        }
    }
}
