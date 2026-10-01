using System;

namespace DPM235407_NguyenTuanAnh_BaiTap03_03_OrganizingData._05_Change_Value_Reference
{
    // =========================================================================
    // BEFORE: Code Smell "Confused Identity" (Nhầm lẫn giữa Đối tượng Giá trị và Thực thể Tham chiếu)
    // Mỗi lần bán một mặt hàng, hệ thống lại `new LoHang()` độc lập mà không đồng bộ
    // với Lô hàng gốc trong kho. Khi một phiếu bán trừ số lượng, các phiếu bán khác
    // không nhìn thấy số lượng tồn thực tế đã giảm!
    // =========================================================================
    public class LoHang_Before
    {
        public string MaLo { get; set; } = string.Empty;
        public int SoLuongTon { get; set; }

        public LoHang_Before(string maLo, int soLuong)
        {
            MaLo = maLo;
            SoLuongTon = soLuong;
        }
    }

    public class DonHangXuat_Before
    {
        // Mỗi đơn hàng tự giữ một instance LoHang riêng biệt -> Bị mất tính nhất quán dữ liệu!
        public LoHang_Before LoHang { get; set; }

        public DonHangXuat_Before(string maLo, int soLuongKho)
        {
            LoHang = new LoHang_Before(maLo, soLuongKho);
        }

        public void XuatKho(int soLuong)
        {
            LoHang.SoLuongTon -= soLuong;
            Console.WriteLine($"[BEFORE] Đơn hàng trừ {soLuong} sp. Tồn cục bộ của đối tượng này: {LoHang.SoLuongTon}");
        }
    }
}
