namespace DPM235407_NguyenTuanAnh_BaiTap03_03_OrganizingData._11_ReplaceMagicNumberWithSymbolicConstant
{
    // AFTER: Hằng số tường minh
    public class DinhMuc_After
    {
        public const int TonKhoAnToanToiThieu = 15;
        public const decimal ThueSuatVATNongNghiep = 0.05m;
        public bool IsCanhBao(int ton) => ton <= TonKhoAnToanToiThieu;
        public decimal TinhVAT(decimal tien) => tien * ThueSuatVATNongNghiep;
    }
}
