using System;
namespace DPM235407_NguyenTuanAnh_BaiTap03_01_ComposingMethods._01_ExtractMethod
{
    // AFTER: Extract Method
    public class InPhieuBanHang_After
    {
        public void InThongTinPhieu(string maPhieu, string khachHang, double tienHang)
        {
            InBanner();
            InChiTiet(maPhieu, khachHang);
            InTongKet(tienHang);
        }
        private void InBanner()
        {
            Console.WriteLine("************************************");
            Console.WriteLine("***   NÔNG DƯỢC AN GIANG - PHIẾU BÁN ***");
            Console.WriteLine("************************************");
        }
        private void InChiTiet(string maPhieu, string khachHang) => Console.WriteLine($"Mã: {maPhieu} | Khách: {khachHang}");
        private void InTongKet(double tienHang)
        {
            double vat = TinhVAT(tienHang);
            Console.WriteLine($"Tiền hàng: {tienHang:N0} đ | VAT: {vat:N0} đ | Tổng: {tienHang + vat:N0} đ");
        }
        private double TinhVAT(double tien) => tien * 0.1;
    }
}
