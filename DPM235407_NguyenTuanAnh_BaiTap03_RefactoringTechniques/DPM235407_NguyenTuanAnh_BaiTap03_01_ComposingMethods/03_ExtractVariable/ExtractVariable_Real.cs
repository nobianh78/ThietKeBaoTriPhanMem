using System;
namespace DPM235407_NguyenTuanAnh_BaiTap03_01_ComposingMethods._03_ExtractVariable
{
    // REAL: Đơn hàng thuốc nông dược mùa vụ
    public class TinhChietKhauMuaVu_Real
    {
        public decimal TinhGiaSauUuDai(decimal tongTien, bool isMuaVuDongXuan, bool isHopTacXa, int soNamHopTac)
        {
            bool duDieuKienChietKhauVang = isMuaVuDongXuan && isHopTacXa && (soNamHopTac >= 3);
            decimal tiLeGiam = duDieuKienChietKhauVang ? 0.10m : 0.03m;
            return tongTien * (1 - tiLeGiam);
        }
    }
}
