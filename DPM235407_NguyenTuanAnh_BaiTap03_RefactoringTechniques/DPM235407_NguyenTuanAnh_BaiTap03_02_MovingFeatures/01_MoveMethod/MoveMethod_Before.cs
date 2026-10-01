namespace DPM235407_NguyenTuanAnh_BaiTap03_02_MovingFeatures._01_MoveMethod
{
    // BEFORE: Feature Envy trên UI Form
    public class TaiKhoan_Before { public double SoDu { get; set; } = 5000000; }
    public class FormBanHang_Before
    {
        public void RutTien(TaiKhoan_Before tk, double tien) { tk.SoDu -= tien; }
    }
}
