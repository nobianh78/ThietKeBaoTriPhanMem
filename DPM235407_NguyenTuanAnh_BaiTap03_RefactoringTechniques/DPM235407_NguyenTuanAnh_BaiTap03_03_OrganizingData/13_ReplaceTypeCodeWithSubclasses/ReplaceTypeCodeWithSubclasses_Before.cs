namespace DPM235407_NguyenTuanAnh_BaiTap03_03_OrganizingData._13_ReplaceTypeCodeWithSubclasses
{
    // BEFORE: Type code với switch-case trong tính tiền
    public class NhanVien_Before
    {
        public const int BAN_HANG = 1;
        public const int QUAN_LY = 2;
        public int Loai { get; set; }
        public decimal TinhLuong() => Loai == BAN_HANG ? 7000000 : 15000000;
    }
}
