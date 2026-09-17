using System;

namespace DPM235407_NguyenTuanAnh_BaiTap01_Flyweight_Real_LoHang_DP
{
    // [Flyweight - Intrinsic State]: Trạng thái nội tại dùng chung chia sẻ cho hàng ngàn lô
    public class ThongTinThuocFlyweight
    {
        public string MaThuoc { get; }
        public string TenThuongPham { get; }
        public string HoatChat { get; }
        public string QuyCach { get; } // Chai 500ml, Gói 100g, Can 5 Lít...
        public string HangSanXuat { get; } // Syngenta, Lộc Trời, Bayer...
        public string NhomDocTinh { get; } // GHS Cấp 4, Cấp 5...

        public ThongTinThuocFlyweight(string ma, string ten, string hoatChat, string quyCach, string hangSX, string docTinh)
        {
            MaThuoc = ma;
            TenThuongPham = ten;
            HoatChat = hoatChat;
            QuyCach = quyCach;
            HangSanXuat = hangSX;
            NhomDocTinh = docTinh;
        }

        // Nhận trạng thái ngoại tại (Extrinsic State) khi thực hiện in hoặc tính toán
        public void HienThiThongTinLo(LoHangContext loHang)
        {
            Console.WriteLine($"[LÔ HÀNG: {loHang.SoLo}] {TenThuongPham} ({HoatChat} - {QuyCach})");
            Console.WriteLine($"  Hãng SX: {HangSanXuat} | Độc tính: {NhomDocTinh}");
            Console.WriteLine($"  Vị trí kho: {loHang.ViTriKho} | NSX: {loHang.NgaySanXuat:dd/MM/yyyy} | HSD: {loHang.HanSuDung:dd/MM/yyyy}");
            Console.WriteLine($"  Tồn kho: {loHang.SoLuongTon:N0} đơn vị | Giá xuất: {loHang.DonGiaXuat:N0} VNĐ");
        }
    }
}
