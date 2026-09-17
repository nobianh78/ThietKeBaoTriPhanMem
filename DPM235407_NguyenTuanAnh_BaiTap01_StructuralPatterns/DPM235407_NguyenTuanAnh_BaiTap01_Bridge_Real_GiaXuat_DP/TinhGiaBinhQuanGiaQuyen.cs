using System;
using System.Collections.Generic;
using System.Linq;

namespace DPM235407_NguyenTuanAnh_BaiTap01_Bridge_Real_GiaXuat_DP
{
    // [Concrete Implementation 1]: Phương pháp Bình Quân Gia Quyền
    public class TinhGiaBinhQuanGiaQuyen : IPhuongPhapTinhGiaXuat
    {
        public string LayTenPhuongPhap()
        {
            return "Bình quân gia quyền (Weighted Average)";
        }

        public decimal TinhGiaVonXuatKho(List<LoHang> cacLo, int soLuongXuat)
        {
            int tongSoLuongTon = cacLo.Sum(l => l.SoLuongTon);
            if (tongSoLuongTon == 0) return 0;

            decimal tongGiaTriTon = cacLo.Sum(l => l.SoLuongTon * l.DonGiaNhap);
            decimal donGiaBinhQuan = tongGiaTriTon / tongSoLuongTon;

            return donGiaBinhQuan * soLuongXuat;
        }
    }
}
