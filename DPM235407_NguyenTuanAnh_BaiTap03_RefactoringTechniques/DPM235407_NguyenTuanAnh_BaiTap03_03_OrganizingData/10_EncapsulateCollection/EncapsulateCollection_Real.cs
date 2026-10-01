using System.Collections.Generic;
namespace DPM235407_NguyenTuanAnh_BaiTap03_03_OrganizingData._10_EncapsulateCollection
{
    // REAL: Đóng gói danh sách mặt hàng bán lẻ Nông Dược
    public class PhieuBanLeNongDuoc_Real
    {
        private readonly List<string> _danhSachThuoc = new();
        public IReadOnlyList<string> DanhSachThuoc => _danhSachThuoc.AsReadOnly();
        public void ThemThuoc(string ten) => _danhSachThuoc.Add(ten);
    }
}
