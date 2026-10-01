using System.Collections.Generic;
namespace DPM235407_NguyenTuanAnh_BaiTap03_03_OrganizingData._07_ChangeUnidirectionalToBidirectional
{
    // BEFORE: Khách hàng biết danh sách Đơn hàng, nhưng Đơn hàng không biết Khách hàng
    public class DonHang_Before { public string MaDon { get; set; } = ""; }
    public class KhachHang_Before { public List<DonHang_Before> DonHangs { get; set; } = new(); }
}
