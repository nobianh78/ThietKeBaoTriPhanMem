using System;

namespace DPM235407_NguyenTuanAnh_Tuan02_Iterator_Real_KhoHang_DP
{
    // Thực thể quản lý Lô hàng nông dược
    public class LoHangNongDuoc
    {
        public string MaLo { get; set; }
        public string TenThuoc { get; set; }
        public string HoatChat { get; set; }
        public DateTime NgayNhapKho { get; set; }
        public DateTime NgayHetHan { get; set; }
        public int SoLuongTon { get; set; }
        public decimal DonGia { get; set; }

        public LoHangNongDuoc(string maLo, string tenThuoc, string hoatChat, DateTime ngayNhap, DateTime ngayHetHan, int soLuongTon, decimal donGia)
        {
            MaLo = maLo;
            TenThuoc = tenThuoc;
            HoatChat = hoatChat;
            NgayNhapKho = ngayNhap;
            NgayHetHan = ngayHetHan;
            SoLuongTon = soLuongTon;
            DonGia = donGia;
        }

        public override string ToString()
        {
            return $"[Lô: {MaLo,-10}] {TenThuoc,-28} | Nhập: {NgayNhapKho:dd/MM/yyyy} | HSD: {NgayHetHan:dd/MM/yyyy} | Tồn: {SoLuongTon,4} gói/chai | Đơn giá: {DonGia,10:N0} đ";
        }
    }
}
