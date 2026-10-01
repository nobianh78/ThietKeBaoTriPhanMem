using System.Collections.Generic;
namespace DPM235407_NguyenTuanAnh_BaiTap03_03_OrganizingData._10_EncapsulateCollection
{
    // BEFORE: Để lộ List<T> có thể bị Clear() hoặc sửa đổi ngoài tầm kiểm soát
    public class Phieu_Before { public List<string> Items { get; set; } = new(); }
}
