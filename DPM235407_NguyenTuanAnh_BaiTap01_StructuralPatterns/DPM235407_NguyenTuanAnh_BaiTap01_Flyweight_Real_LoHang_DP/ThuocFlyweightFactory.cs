using System;
using System.Collections.Generic;

namespace DPM235407_NguyenTuanAnh_BaiTap01_Flyweight_Real_LoHang_DP
{
    // [Flyweight Factory]: Quản lý và tái sử dụng bộ đệm các loại thuốc nông dược
    public class ThuocFlyweightFactory
    {
        private readonly Dictionary<string, ThongTinThuocFlyweight> _flyweights = new();

        public ThongTinThuocFlyweight LayThongTinThuoc(string maThuoc, string ten, string hoatChat, string quyCach, string hangSX, string docTinh)
        {
            string key = maThuoc.ToUpper();

            if (!_flyweights.ContainsKey(key))
            {
                // Chưa có thì tạo mới và cache lại
                _flyweights[key] = new ThongTinThuocFlyweight(maThuoc, ten, hoatChat, quyCach, hangSX, docTinh);
                Console.WriteLine($"[Factory Cache] -> Tạo mới đối tượng Flyweight trong RAM cho thuốc: {ten} (Mã: {maThuoc})");
            }

            return _flyweights[key];
        }

        public int SoLuongFlyweightTrongRAM => _flyweights.Count;
    }
}
