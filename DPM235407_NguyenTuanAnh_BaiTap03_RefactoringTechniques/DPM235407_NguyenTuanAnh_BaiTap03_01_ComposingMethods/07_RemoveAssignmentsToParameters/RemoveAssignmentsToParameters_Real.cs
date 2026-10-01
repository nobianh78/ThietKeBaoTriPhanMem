namespace DPM235407_NguyenTuanAnh_BaiTap03_01_ComposingMethods._07_RemoveAssignmentsToParameters
{
    // REAL: Trợ giá phân bón mùa vụ cho nông dân
    public class TroGiaPhanBon_Real
    {
        public decimal TinhGiaCuoiCung(in decimal donGiaNiemYet, in int soBao, in bool hoNgheo)
        {
            decimal donGiaThucTe = donGiaNiemYet;
            if (hoNgheo) donGiaThucTe -= 50000m; // Trợ giá 50k/bao
            return donGiaThucTe * soBao;
        }
    }
}
