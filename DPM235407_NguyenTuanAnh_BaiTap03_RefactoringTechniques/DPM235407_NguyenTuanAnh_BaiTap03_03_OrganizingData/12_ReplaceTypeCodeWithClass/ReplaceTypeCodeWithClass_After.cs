namespace DPM235407_NguyenTuanAnh_BaiTap03_03_OrganizingData._12_ReplaceTypeCodeWithClass
{
    // AFTER: Thay Type Code bằng Lớp Nhóm Thuốc
    public class NhomThuoc
    {
        public static readonly NhomThuoc TruSau = new("Thuốc trừ sâu");
        public static readonly NhomThuoc TruBenh = new("Thuốc trừ bệnh");
        public string Ten { get; }
        private NhomThuoc(string ten) => Ten = ten;
    }
    public class Thuoc_After { public NhomThuoc Loai { get; set; } = NhomThuoc.TruSau; }
}
