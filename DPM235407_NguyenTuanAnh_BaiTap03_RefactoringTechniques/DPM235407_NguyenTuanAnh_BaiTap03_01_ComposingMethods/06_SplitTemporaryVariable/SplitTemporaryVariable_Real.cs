using System;
namespace DPM235407_NguyenTuanAnh_BaiTap03_01_ComposingMethods._06_SplitTemporaryVariable
{
    // REAL: Phân bổ số lượng bao thuốc và tiền cước giao vận
    public class TinhToanGiaoHangNongDuoc_Real
    {
        public void TinhChiPhi(int soBaoThuoc, decimal donGiaBao)
        {
            decimal tongTienThuoc = soBaoThuoc * donGiaBao;
            decimal trongLuongKg = soBaoThuoc * 25; // mỗi bao 25kg
            decimal cuocXeTai = trongLuongKg * 500; // 500đ/kg
            Console.WriteLine($"[REAL] Tiền thuốc: {tongTienThuoc:N0} đ | Cước xe ({trongLuongKg}kg): {cuocXeTai:N0} đ");
        }
    }
}
