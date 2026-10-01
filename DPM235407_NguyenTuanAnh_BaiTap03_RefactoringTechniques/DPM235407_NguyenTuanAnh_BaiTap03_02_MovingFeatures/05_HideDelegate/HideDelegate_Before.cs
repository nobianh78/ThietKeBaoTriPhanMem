namespace DPM235407_NguyenTuanAnh_BaiTap03_02_MovingFeatures._05_HideDelegate
{
    // BEFORE: Message Chains vi phạm Law of Demeter
    public class TruongPhong_Before { public string Ten { get; set; } = "Kỹ sư Hùng"; }
    public class PhongBan_Before { public TruongPhong_Before Truong { get; set; } = new(); }
    public class NhanVien_Before { public PhongBan_Before Phong { get; set; } = new(); }
}
