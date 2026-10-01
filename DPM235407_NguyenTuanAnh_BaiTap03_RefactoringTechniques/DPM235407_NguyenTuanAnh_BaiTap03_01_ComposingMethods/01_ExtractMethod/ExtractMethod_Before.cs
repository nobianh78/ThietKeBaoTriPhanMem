using System;
namespace DPM235407_NguyenTuanAnh_BaiTap03_01_ComposingMethods._01_ExtractMethod
{
    // BEFORE: Long Method
    public class InPhieuBanHang_Before
    {
        public void InThongTinPhieu(string maPhieu, string khachHang, double tienHang)
        {
            Console.WriteLine("************************************");
            Console.WriteLine("***   NÔNG DƯỢC AN GIANG - PHIẾU BÁN ***");
            Console.WriteLine("************************************");
            Console.WriteLine($"Mã: {maPhieu} | Khách: {khachHang}");
            double vat = tienHang * 0.1;
            double tong = tienHang + vat;
            Console.WriteLine($"Tiền hàng: {tienHang:N0} đ | VAT: {vat:N0} đ | Tổng: {tong:N0} đ");
        }
    }
}
