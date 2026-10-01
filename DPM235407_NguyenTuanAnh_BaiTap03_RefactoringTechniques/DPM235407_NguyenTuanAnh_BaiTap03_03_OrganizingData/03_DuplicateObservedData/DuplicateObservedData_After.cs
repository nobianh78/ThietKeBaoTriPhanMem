using System;
namespace DPM235407_NguyenTuanAnh_BaiTap03_03_OrganizingData._03_DuplicateObservedData
{
    // AFTER: Tách Domain Model và sử dụng Observer Pattern / Event đồng bộ UI
    public class HoaDonModel_After
    {
        public event Action<decimal>? OnTongTienChanged;
        private decimal _tienHang;
        public decimal TienHang
        {
            get => _tienHang;
            set { _tienHang = value; OnTongTienChanged?.Invoke(_tienHang * 1.1m); }
        }
    }
}
