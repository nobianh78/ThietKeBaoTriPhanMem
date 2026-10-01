namespace DPM235407_NguyenTuanAnh_BaiTap03_03_OrganizingData._13_ReplaceTypeCodeWithSubclasses
{
    // REAL: Phân loại Nông dược kế thừa
    public abstract class NongDuoc_Real { public abstract int ThoiGianCachLyNgay(); }
    public class ThuocTruSauDocCao_Real : NongDuoc_Real { public override int ThoiGianCachLyNgay() => 14; }
    public class ChePhamSinhHoc_Real : NongDuoc_Real { public override int ThoiGianCachLyNgay() => 3; }
}
