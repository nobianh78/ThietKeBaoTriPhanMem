namespace DPM235407_NguyenTuanAnh_BaiTap03_01_ComposingMethods._04_InlineTemp
{
    // BEFORE: Biến tạm chỉ dùng gán kết quả của 1 hàm rồi return ngay
    public class TinhGia_Before
    {
        public bool KiemTraGiaCao(DonHang_Before dh)
        {
            double donGia = dh.LayDonGia();
            return donGia > 1000000;
        }
    }
    public class DonHang_Before { public double LayDonGia() => 1500000; }
}
