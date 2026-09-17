using System.Collections.Generic;

namespace DPM235407_NguyenTuanAnh_Tuan02_Strategy_Real_GiaXuat_DP
{
    public class KetQuaTinhGiaXuat
    {
        public string PhuongPhap { get; set; } = string.Empty;
        public int TongSoLuongXuat { get; set; }
        public decimal TongGiaTriXuat { get; set; }
        public decimal DonGiaBinhQuanXuat => TongSoLuongXuat > 0 ? TongGiaTriXuat / TongSoLuongXuat : 0;
        public List<ChiTietXuatLo> ChiTietCacLo { get; set; } = new();
    }
}
