using System;
using System.Collections.Generic;
using System.Linq;

namespace DPM235407_NguyenTuanAnh_Tuan02_Strategy_Real_GiaXuat_DP
{
    // Strategy 2: Phương pháp Nhập trước xuất trước - FIFO (First In First Out)
    public class TinhGiaNhapTruocXuatTruocStrategy : ITinhGiaXuatStrategy
    {
        public string TenPhuongPhap => "Nhập trước xuất trước (FIFO)";

        public KetQuaTinhGiaXuat TinhGiaXuat(List<LoThuocNhap> danhSachLo, int soLuongCanXuat)
        {
            var ketQua = new KetQuaTinhGiaXuat
            {
                PhuongPhap = TenPhuongPhap,
                TongSoLuongXuat = soLuongCanXuat
            };

            // Sắp xếp các lô theo ngày nhập kho tăng dần (lô cũ nhất lên đầu)
            var danhSachSapXep = danhSachLo.OrderBy(l => l.NgayNhap).ToList();
            int tongTonKho = danhSachSapXep.Sum(l => l.SoLuongTon);
            if (tongTonKho < soLuongCanXuat)
            {
                throw new InvalidOperationException($"Không đủ tồn kho để xuất! (Tồn: {tongTonKho}, Cần: {soLuongCanXuat})");
            }

            int soLuongCanLay = soLuongCanXuat;
            decimal tongGiaTri = 0;

            foreach (var lo in danhSachSapXep)
            {
                if (soLuongCanLay <= 0) break;

                int lay = Math.Min(lo.SoLuongTon, soLuongCanLay);
                decimal thanhTienLo = lay * lo.DonGiaNhap;
                tongGiaTri += thanhTienLo;

                ketQua.ChiTietCacLo.Add(new ChiTietXuatLo(lo.MaLo, lay, lo.DonGiaNhap));
                soLuongCanLay -= lay;
            }

            ketQua.TongGiaTriXuat = tongGiaTri;
            return ketQua;
        }
    }
}
