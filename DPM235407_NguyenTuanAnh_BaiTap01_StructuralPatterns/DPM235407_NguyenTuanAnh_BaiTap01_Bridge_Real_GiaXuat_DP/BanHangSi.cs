using System;
using System.Collections.Generic;

namespace DPM235407_NguyenTuanAnh_BaiTap01_Bridge_Real_GiaXuat_DP
{
    // [Refined Abstraction 2]: Bán hàng sỉ cho các đại lý cấp 2, hợp tác xã
    public class BanHangSi : HinhThucBanHang
    {
        public BanHangSi(IPhuongPhapTinhGiaXuat phuongPhap) : base(phuongPhap) { }

        public override void ThucHienBanHang(string tenKhach, string tenThuoc, int soLuong, List<LoHang> cacLo)
        {
            decimal giaVon = _phuongPhapTinhGia.TinhGiaVonXuatKho(cacLo, soLuong);
            // Bán sỉ: Biên lợi nhuận thấp hơn (+8%) nhưng số lượng lớn
            decimal giaBanChuaChietKhau = giaVon * 1.08m;
            decimal chietKhauDaiLy = giaBanChuaChietKhau * 0.03m; // Thêm chiết khấu sỉ 3%
            decimal tongTien = giaBanChuaChietKhau - chietKhauDaiLy;

            Console.WriteLine($"[BÁN SỈ ĐẠI LÝ / HTX] Đại lý: {tenKhach}");
            Console.WriteLine($" - Sản phẩm: {tenThuoc} | Số lượng lớn: {soLuong}");
            Console.WriteLine($" - Phương pháp định giá kho: {_phuongPhapTinhGia.LayTenPhuongPhap()}");
            Console.WriteLine($" - Giá vốn xuất kho: {giaVon:N0} VNĐ");
            Console.WriteLine($" - Chiết khấu đại lý (3%): -{chietKhauDaiLy:N0} VNĐ");
            Console.WriteLine($" - Tổng thanh toán sỉ: {tongTien:N0} VNĐ\n");
        }
    }
}
