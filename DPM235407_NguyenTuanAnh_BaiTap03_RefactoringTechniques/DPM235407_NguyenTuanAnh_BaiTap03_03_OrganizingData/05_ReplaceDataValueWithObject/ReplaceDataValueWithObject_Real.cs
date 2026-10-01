namespace DPM235407_NguyenTuanAnh_BaiTap03_03_OrganizingData._05_ReplaceDataValueWithObject
{
    // REAL: Mã vạch EAN-13 thuốc nông dược
    public readonly record struct MaVachEAN13_Real(string Code)
    {
        public override string ToString() => $"[EAN-13: {Code}]";
    }
}
