using System.Collections.Generic;
namespace DPM235407_NguyenTuanAnh_BaiTap03_03_OrganizingData._10_EncapsulateCollection
{
    // AFTER: Encapsulate Collection trả về IReadOnlyList
    public class Phieu_After
    {
        private readonly List<string> _items = new();
        public IReadOnlyList<string> Items => _items.AsReadOnly();
        public void Them(string item) => _items.Add(item);
    }
}
