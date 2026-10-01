namespace DPM235407_NguyenTuanAnh_BaiTap03_03_OrganizingData._15_ReplaceSubclassWithFields
{
    // BEFORE: Tạo lớp con chỉ để trả về một giá trị hằng số đơn giản
    public abstract class GoiBaoBi_Before { public abstract int DungTich(); }
    public class Chai250ml_Before : GoiBaoBi_Before { public override int DungTich() => 250; }
    public class Chai500ml_Before : GoiBaoBi_Before { public override int DungTich() => 500; }
}
