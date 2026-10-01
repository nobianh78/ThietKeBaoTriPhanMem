namespace DPM235407_NguyenTuanAnh_BaiTap03_01_ComposingMethods._09_SubstituteAlgorithm
{
    // BEFORE: Thuật toán tìm kiếm thủ công rườm rà
    public class TimKiemThuoc_Before
    {
        public string TimThuoc(string[] danhSach, string tuKhoa)
        {
            for (int i = 0; i < danhSach.Length; i++)
            {
                if (danhSach[i] == tuKhoa) return danhSach[i];
            }
            return "";
        }
    }
}
