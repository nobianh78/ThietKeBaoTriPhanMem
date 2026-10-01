using System;
namespace DPM235407_NguyenTuanAnh_BaiTap03_02_MovingFeatures._07_IntroduceForeignMethod
{
    // REAL: Phương thức đối ngoại tính ngày giao hàng tránh Chủ nhật
    public class LichGiaoPhanBon_Real
    {
        public static DateTime TinhNgayGiaoNongDuoc(DateTime ngayDat)
        {
            DateTime ngayGiao = ngayDat.AddDays(2);
            if (ngayGiao.DayOfWeek == DayOfWeek.Sunday) ngayGiao = ngayGiao.AddDays(1);
            return ngayGiao;
        }
    }
}
