using System;
using System.Collections.Generic;
namespace DPM235407_NguyenTuanAnh_BaiTap03_01_ComposingMethods._01_ExtractMethod
{
    // REAL: Refactoring frmBanLe.cs Luu()
    public class LapPhieuBanLeNongDuoc_Real
    {
        public void LuuPhieu(string maPhieu, string khachHang, List<(string TenThuoc, int SL, decimal Gia)> chiTiet)
        {
            if (!KiemTraHopLe(chiTiet)) return;
            decimal tongTien = TinhTongTien(chiTiet);
            CapNhatTonKhoFEFO(chiTiet);
            InHoaDon(maPhieu, khachHang, chiTiet, tongTien);
        }
        private bool KiemTraHopLe(List<(string TenThuoc, int SL, decimal Gia)> list) => list != null && list.Count > 0;
        private decimal TinhTongTien(List<(string TenThuoc, int SL, decimal Gia)> list)
        {
            decimal sum = 0;
            foreach (var item in list) sum += item.SL * item.Gia;
            return sum;
        }
        private void CapNhatTonKhoFEFO(List<(string TenThuoc, int SL, decimal Gia)> list)
        {
            foreach (var item in list) Console.WriteLine($"   -> [FEFO] Trừ kho {item.SL} đơn vị thuốc {item.TenThuoc}");
        }
        private void InHoaDon(string ma, string kh, List<(string TenThuoc, int SL, decimal Gia)> list, decimal tong)
        {
            Console.WriteLine($"[REAL] Phiếu {ma} - KH: {kh} - Tổng tiền: {tong:N0} VNĐ");
        }
    }
}
