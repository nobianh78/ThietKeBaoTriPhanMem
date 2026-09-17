using System;

namespace DPM235407_NguyenTuanAnh_BaiTap01_Flyweight_Real_LoHang_DP
{
    // [Extrinsic State Context]: Trạng thái ngoại tại riêng biệt của từng lô hàng
    public class LoHangContext
    {
        public string SoLo { get; set; }
        public DateTime NgaySanXuat { get; set; }
        public DateTime HanSuDung { get; set; }
        public string ViTriKho { get; set; } // Kệ A1-02, Kho lạnh B...
        public int SoLuongTon { get; set; }
        public decimal DonGiaXuat { get; set; }

        public LoHangContext(string soLo, DateTime nsx, DateTime hsd, string viTri, int soLuong, decimal donGia)
        {
            SoLo = soLo;
            NgaySanXuat = nsx;
            HanSuDung = hsd;
            ViTriKho = viTri;
            SoLuongTon = soLuong;
            DonGiaXuat = donGia;
        }
    }
}
