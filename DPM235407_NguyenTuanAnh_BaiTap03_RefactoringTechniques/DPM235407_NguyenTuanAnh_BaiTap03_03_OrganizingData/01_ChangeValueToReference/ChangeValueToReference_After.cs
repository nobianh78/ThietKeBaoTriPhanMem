using System.Collections.Generic;
namespace DPM235407_NguyenTuanAnh_BaiTap03_03_OrganizingData._01_ChangeValueToReference
{
    // AFTER: Quản lý tham chiếu KhachHang duy nhất qua Repository
    public class KhachHang_After { public string Ten { get; } public KhachHang_After(string ten) => Ten = ten; }
    public class KhachHangRepo
    {
        private static readonly Dictionary<string, KhachHang_After> _cache = new();
        public static KhachHang_After Get(string ten)
        {
            if (!_cache.ContainsKey(ten)) _cache[ten] = new KhachHang_After(ten);
            return _cache[ten];
        }
    }
    public class DonHang_After
    {
        public KhachHang_After Khach { get; }
        public DonHang_After(string ten) { Khach = KhachHangRepo.Get(ten); }
    }
}
