namespace DPM235407_NguyenTuanAnh_BaiTap03_03_OrganizingData._08_ChangeBidirectionalToUnidirectional
{
    // BEFORE: Quan hệ hai chiều không cần thiết làm chặt chẽ phụ thuộc vòng (Circular Dependency)
    public class NhaCungCap_Before { public SanPham_Before? SanPham { get; set; } }
    public class SanPham_Before { public NhaCungCap_Before? NCC { get; set; } }
}
