using System;
namespace DPM235407_NguyenTuanAnh_BaiTap03_03_OrganizingData._09_EncapsulateField
{
    // AFTER: Encapsulate Field với kiểm tra hợp lệ
    public class SanPham_After
    {
        private decimal _gia;
        public decimal Gia
        {
            get => _gia;
            set => _gia = value >= 0 ? value : throw new ArgumentException("Giá không được âm!");
        }
    }
}
