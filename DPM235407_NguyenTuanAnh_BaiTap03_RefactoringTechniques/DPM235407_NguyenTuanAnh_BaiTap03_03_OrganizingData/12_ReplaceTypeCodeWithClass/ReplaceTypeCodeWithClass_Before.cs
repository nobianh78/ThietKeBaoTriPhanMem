namespace DPM235407_NguyenTuanAnh_BaiTap03_03_OrganizingData._12_ReplaceTypeCodeWithClass
{
    // BEFORE: Dùng int mã hóa nhóm máu / loại thuốc
    public class Thuoc_Before
    {
        public const int TRU_SAU = 1;
        public const int TRU_BENH = 2;
        public int LoaiThuoc { get; set; }
    }
}
