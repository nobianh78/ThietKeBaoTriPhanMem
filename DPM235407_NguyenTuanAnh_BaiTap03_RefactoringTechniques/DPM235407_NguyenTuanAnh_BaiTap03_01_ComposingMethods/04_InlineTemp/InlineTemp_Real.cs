namespace DPM235407_NguyenTuanAnh_BaiTap03_01_ComposingMethods._04_InlineTemp
{
    // REAL: Inline biến tạm kiểm tra thuốc diệt nấm đạo ôn
    public class KiemTraThuocBaoVeThucVat_Real
    {
        public bool IsThuocDacTri(ThuocBVTV thuoc) => thuoc.LayCongDung().Contains("Đạo ôn");
    }
    public class ThuocBVTV { public string LayCongDung() => "Đặc trị Đạo ôn cổ bông và lem lép hạt"; }
}
