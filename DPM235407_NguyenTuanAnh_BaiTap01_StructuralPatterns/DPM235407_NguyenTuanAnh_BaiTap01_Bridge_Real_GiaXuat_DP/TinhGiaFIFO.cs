using System;
using System.Collections.Generic;
using System.Linq;

namespace DPM235407_NguyenTuanAnh_BaiTap01_Bridge_Real_GiaXuat_DP
{
    // [Concrete Implementation 2]: Phương pháp Nhập trước - Xuất trước (FIFO / Hạn dùng trước)
    public class TinhGiaFIFO : IPhuongPhapTinhGiaXuat
    {
        public string LayTenPhuongPhap()
        {
            return "Nhập trước xuất trước (FIFO theo HSD)";
        }

        public decimal TinhGiaVonXuatKho(List<LoHang> cacLo, int soLuongXuat)
        {
            decimal tongGiaVon = 0;
            int canXuat = soLuongXuat;

            // Sắp xếp các lô theo hạn dùng sớm nhất (FEFO/FIFO)
            var danhSachSapXep = cacLo.OrderBy(l => l.HanSuDung).ToList();

            foreach (var lo in danhSachSapXep)
            {
                if (canXuat <= 0) break;

                int layTuLo = Math.Min(lo.SoLuongTon, canXuat);
                tongGiaVon += layTuLo * lo.DonGiaNhap;
                canXuat -= layTuLo;
            }

            return tongGiaVon;
        }
    }
}
