namespace DPM235407_NguyenTuanAnh_BaiTap03_03_OrganizingData._12_ReplaceTypeCodeWithClass
{
    // REAL: Lớp Cấp Đại Lý Nông Dược
    public class CapDaiLy_Real
    {
        public static readonly CapDaiLy_Real Cap1 = new("Đại lý Cấp 1", 0.12m);
        public static readonly CapDaiLy_Real Cap2 = new("Đại lý Cấp 2", 0.07m);
        public string TenCap { get; }
        public decimal ChietKhau { get; }
        private CapDaiLy_Real(string ten, decimal ck) { TenCap = ten; ChietKhau = ck; }
    }
}
