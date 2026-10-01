using System;
using System.Linq;
namespace DPM235407_NguyenTuanAnh_BaiTap03_01_ComposingMethods._09_SubstituteAlgorithm
{
    // AFTER: Substitute Algorithm với LINQ
    public class TimKiemThuoc_After
    {
        public string TimThuoc(string[] danhSach, string tuKhoa)
            => danhSach.FirstOrDefault(t => string.Equals(t, tuKhoa, StringComparison.OrdinalIgnoreCase)) ?? "";
    }
}
