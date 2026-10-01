using System;
namespace DPM235407_NguyenTuanAnh_BaiTap03_03_OrganizingData._03_DuplicateObservedData
{
    // REAL: Đồng bộ tồn kho giữa Model và Form hiển thị
    public class TonKhoSubject_Real
    {
        public event Action<string, int>? OnCanhBaoTonKho;
        public void CapNhatTon(string maThuoc, int ton)
        {
            if (ton <= 15) OnCanhBaoTonKho?.Invoke(maThuoc, ton);
        }
    }
}
