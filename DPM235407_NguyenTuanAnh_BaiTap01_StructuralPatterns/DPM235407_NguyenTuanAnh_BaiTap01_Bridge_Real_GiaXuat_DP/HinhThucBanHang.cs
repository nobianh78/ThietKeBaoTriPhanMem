using System;
using System.Collections.Generic;

namespace DPM235407_NguyenTuanAnh_BaiTap01_Bridge_Real_GiaXuat_DP
{
    // [Bridge Abstraction]: Tầng trừu tượng Quản lý Bán Hàng
    public abstract class HinhThucBanHang
    {
        protected IPhuongPhapTinhGiaXuat _phuongPhapTinhGia;

        public HinhThucBanHang(IPhuongPhapTinhGiaXuat phuongPhap)
        {
            _phuongPhapTinhGia = phuongPhap;
        }

        public void ThayDoiPhuongPhap(IPhuongPhapTinhGiaXuat phuongPhapMoi)
        {
            _phuongPhapTinhGia = phuongPhapMoi;
        }

        public abstract void ThucHienBanHang(string tenKhach, string tenThuoc, int soLuong, List<LoHang> cacLo);
    }
}
