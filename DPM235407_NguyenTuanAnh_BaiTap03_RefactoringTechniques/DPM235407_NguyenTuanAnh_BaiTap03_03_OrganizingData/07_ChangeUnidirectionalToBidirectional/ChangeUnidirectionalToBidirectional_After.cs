using System.Collections.Generic;
namespace DPM235407_NguyenTuanAnh_BaiTap03_03_OrganizingData._07_ChangeUnidirectionalToBidirectional
{
    // AFTER: Quan hệ 2 chiều 2-way association
    public class KhachHang_After
    {
        public List<DonHang_After> DonHangs { get; } = new();
        public void ThemDon(DonHang_After dh) { DonHangs.Add(dh); dh.KhachHang = this; }
    }
    public class DonHang_After { public KhachHang_After? KhachHang { get; set; } }
}
