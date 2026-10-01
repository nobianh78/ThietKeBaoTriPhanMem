namespace DPM235407_NguyenTuanAnh_BaiTap03_03_OrganizingData._15_ReplaceSubclassWithFields
{
    // AFTER: Thay thế các lớp con bằng trường dữ liệu DungTichMl
    public class GoiBaoBi_After
    {
        public int DungTichMl { get; }
        public GoiBaoBi_After(int dungTich) => DungTichMl = dungTich;
        public static GoiBaoBi_After Chai250() => new(250);
        public static GoiBaoBi_After Chai500() => new(500);
    }
}
