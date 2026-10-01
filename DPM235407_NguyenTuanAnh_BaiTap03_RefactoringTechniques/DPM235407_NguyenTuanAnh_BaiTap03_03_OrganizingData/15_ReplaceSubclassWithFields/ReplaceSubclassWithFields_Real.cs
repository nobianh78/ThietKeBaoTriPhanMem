namespace DPM235407_NguyenTuanAnh_BaiTap03_03_OrganizingData._15_ReplaceSubclassWithFields
{
    // REAL: Quy cách đóng gói thuốc BVTV (Dung tích + Quy cách thùng)
    public class QuyCachDongGoiNongDuoc_Real
    {
        public string TenQuyCach { get; }
        public int DungTichMl { get; }
        public int SoChaiMoiThung { get; }
        public QuyCachDongGoiNongDuoc_Real(string ten, int ml, int thung)
        {
            TenQuyCach = ten; DungTichMl = ml; SoChaiMoiThung = thung;
        }
        public static QuyCachDongGoiNongDuoc_Real ChaiNho() => new("Chai nhỏ", 100, 50);
        public static QuyCachDongGoiNongDuoc_Real ChaiLon() => new("Chai lớn", 1000, 20);
    }
}
