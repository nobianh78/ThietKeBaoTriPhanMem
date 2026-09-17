using System;
using System.Collections.Generic;

namespace DPM235407_NguyenTuanAnh_Tuan02_Memento_Real_HoaDon_DP
{
    // Caretaker: Quản lý các điểm phục hồi snapshot hóa đơn
    public class LichSuHoaDonCaretaker
    {
        private readonly Stack<IMementoHoaDon> _danhSachSnapshot = new();
        private readonly HoaDonBanHang _hoaDon;

        public LichSuHoaDonCaretaker(HoaDonBanHang hoaDon)
        {
            _hoaDon = hoaDon;
        }

        public void SaoLuu(string moTa)
        {
            var snapshot = _hoaDon.LuuTrangThai(moTa);
            _danhSachSnapshot.Push(snapshot);
            Console.WriteLine($"   [LƯU SNAPSHOT] Đã ghi nhớ: {snapshot.GetMoTa()}");
        }

        public void HoanTac()
        {
            if (_danhSachSnapshot.Count == 0)
            {
                Console.WriteLine("   [THÔNG BÁO] Không có snapshot nào để hoàn tác.");
                return;
            }

            var snapshot = _danhSachSnapshot.Pop();
            _hoaDon.KhoiPhucTrangThai(snapshot);
        }

        public void HienThiLichSu()
        {
            Console.WriteLine("\n[DANH SÁCH CÁC ĐIỂM PHỤC HỒI (SNAPSHOTS) CỦA HÓA ĐƠN]");
            int i = 1;
            foreach (var snap in _danhSachSnapshot)
            {
                Console.WriteLine($"   {i++}. {snap.GetMoTa()}");
            }
        }
    }
}
