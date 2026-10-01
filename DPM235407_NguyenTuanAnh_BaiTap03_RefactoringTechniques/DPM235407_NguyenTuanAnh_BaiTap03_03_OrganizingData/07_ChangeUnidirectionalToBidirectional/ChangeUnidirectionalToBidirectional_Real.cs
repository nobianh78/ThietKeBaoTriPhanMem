using System.Collections.Generic;
namespace DPM235407_NguyenTuanAnh_BaiTap03_03_OrganizingData._07_ChangeUnidirectionalToBidirectional
{
    // REAL: Quan hệ hai chiều giữa PhieuBan và ChiTietPhieuBan (BusinessObject/PhieuBan.cs)
    public class PhieuBan_Real
    {
        public string MaPhieu { get; set; } = "PB-01";
        public List<ChiTiet_Real> ChiTiets { get; } = new();
        public void ThemChiTiet(ChiTiet_Real ct) { ChiTiets.Add(ct); ct.PhieuBan = this; }
    }
    public class ChiTiet_Real
    {
        public string TenThuoc { get; set; } = "Radiant";
        public PhieuBan_Real? PhieuBan { get; set; }
    }
}
