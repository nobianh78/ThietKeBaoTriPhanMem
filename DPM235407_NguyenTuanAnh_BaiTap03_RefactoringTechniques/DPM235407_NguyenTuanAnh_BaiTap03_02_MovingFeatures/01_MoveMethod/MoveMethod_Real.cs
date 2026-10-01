using System;
namespace DPM235407_NguyenTuanAnh_BaiTap03_02_MovingFeatures._01_MoveMethod
{
    // REAL: Di chuyển phương thức tính công nợ vào PhieuBan (frmBanLe.cs)
    public class PhieuBanNongDuoc_Real
    {
        public decimal TongTien { get; set; } = 15000000;
        public decimal DaTra { get; private set; } = 5000000;
        public void GhiNhanThanhToan(decimal soTien) => DaTra += soTien;
        public decimal ConNo => Math.Max(0, TongTien - DaTra);
    }
}
