using System;
using System.Collections.Generic;
using System.Linq;

namespace DPM235407_NguyenTuanAnh_Tuan02_Strategy_Real_GiaXuat_DP
{
    // Strategy 1: Phương pháp Bình quân gia quyền (Weighted Average)
    public class TinhGiaBinhQuanGiaQuyenStrategy : ITinhGiaXuatStrategy
    {
        public string TenPhuongPhap => "Bình quân gia quyền (Weighted Average)";

        public KetQuaTinhGiaXuat TinhGiaXuat(List<LoThuocNhap> danhSachLo, int soLuongCanXuat)
        {
            var ketQua = new KetQuaTinhGiaXuat
            {
                PhuongPhap = TenPhuongPhap,
                TongSoLuongXuat = soLuongCanXuat
            };

            int tongTonKho = danhSachLo.Sum(l => l.SoLuongTon);
            if (tongTonKho < soLuongCanXuat)
            {
                throw new InvalidOperationException($"Không đủ tồn kho để xuất! (Tồn: {tongTonKho}, Cần: {soLuongCanXuat})");
            }

            // Đơn giá bình quân = Tổng giá trị tồn / Tổng số lượng tồn
            decimal tongGiaTriTon = danhSachLo.Sum(l => l.SoLuongTon * l.DonGiaNhap);
            decimal donGiaBinhQuan = tongGiaTriTon / tongTonKho;

            ketQua.TongGiaTriXuat = soLuongCanXuat * donGiaBinhQuan;

            int conLai = soLuongCanXuat;
            foreach (var lo in danhSachLo)
            {
                if (conLai <= 0) break;
                int lay = Math.Min(lo.SoLuongTon, conLai);
                ketQua.ChiTietCacLo.Add(new ChiTietXuatLo(lo.MaLo, lay, donGiaBinhQuan));
                conLai -= lay;
            }

            return ketQua;
        }
    }
}
