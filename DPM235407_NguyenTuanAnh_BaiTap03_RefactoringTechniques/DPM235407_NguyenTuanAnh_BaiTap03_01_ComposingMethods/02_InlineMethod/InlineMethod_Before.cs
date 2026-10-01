namespace DPM235407_NguyenTuanAnh_BaiTap03_01_ComposingMethods._02_InlineMethod
{
    // BEFORE: Phương thức quá vụn vặt, thân hàm rõ ràng như chính tên gọi
    public class KiemTraGiamGia_Before
    {
        private int _soLanGiaoDich = 6;
        public bool DuDieuKienChietKhau() => CoNhieuHon5LanGiaoDich();
        private bool CoNhieuHon5LanGiaoDich() => _soLanGiaoDich > 5;
    }
}
