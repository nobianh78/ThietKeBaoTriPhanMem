using System;
using System.Collections.Generic;

namespace DPM235407_NguyenTuanAnh_BaiTap01_Bridge_Real_GiaXuat_DP
{
    // [Refined Abstraction 1]: Bán hàng lẻ cho bà con nông dân
    public class BanHangLe : HinhThucBanHang
    {
        public BanHangLe(IPhuongPhapTinhGiaXuat phuongPhap) : base(phuongPhap) { }

        public override void ThucHienBanHang(string tenKhach, string tenThuoc, int soLuong, List<LoHang> cacLo)
        {
            decimal giaVon = _phuongPhapTinhGia.TinhGiaVonXuatKho(cacLo, soLuong);
            // Bán lẻ: Lợi nhuận định mức +15% so với giá vốn
            decimal giaBan = giaVon * 1.15m;

            Console.WriteLine($"[BÁN LẺ TẠI QUẦY] Khách hàng: {tenKhach}");
            Console.WriteLine($" - Sản phẩm: {tenThuoc} | Số lượng: {soLuong}");
            Console.WriteLine($" - Phương pháp định giá kho: {_phuongPhapTinhGia.LayTenPhuongPhap()}");
            Console.WriteLine($" - Giá vốn xuất kho: {giaVon:N0} VNĐ");
            Console.WriteLine($" - Tổng tiền bán lẻ (+15% lợi nhuận): {giaBan:N0} VNĐ\n");
        }
    }
}
