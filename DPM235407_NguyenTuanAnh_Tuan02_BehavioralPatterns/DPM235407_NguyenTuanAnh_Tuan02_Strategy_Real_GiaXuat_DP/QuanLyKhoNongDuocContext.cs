using System;
using System.Collections.Generic;

namespace DPM235407_NguyenTuanAnh_Tuan02_Strategy_Real_GiaXuat_DP
{
    // Context: Quản lý kho hàng Nông Dược An Giang
    public class QuanLyKhoNongDuocContext
    {
        private ITinhGiaXuatStrategy _strategy;
        private readonly List<LoThuocNhap> _danhSachLo = new();

        public QuanLyKhoNongDuocContext(ITinhGiaXuatStrategy strategy)
        {
            _strategy = strategy;
        }

        public void SetStrategy(ITinhGiaXuatStrategy strategy)
        {
            _strategy = strategy;
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine($"\n[CẤU HÌNH THAY ĐỔI] Đã chuyển phương pháp tính giá sang: {_strategy.TenPhuongPhap}");
            Console.ResetColor();
        }

        public void NhapLo(LoThuocNhap lo) => _danhSachLo.Add(lo);

        public void XuatKhoTinhGia(int soLuongXuat)
        {
            Console.WriteLine($"\n--- THỰC HIỆN TÍNH GIÁ XUẤT KHO CHO {soLuongXuat} ĐƠN VỊ SẢN PHẨM ---");
            Console.WriteLine($"Phương pháp áp dụng: {_strategy.TenPhuongPhap}");

            var ketQua = _strategy.TinhGiaXuat(_danhSachLo, soLuongXuat);

            Console.WriteLine("--------------------------------------------------------------------------------");
            Console.WriteLine(string.Format("{0,-12} {1,14} {2,18} {3,20}", "Mã Lô", "Số Lượng Xuất", "Đơn Giá Vốn", "Thành Tiền Vốn"));
            Console.WriteLine("--------------------------------------------------------------------------------");
            foreach (var ct in ketQua.ChiTietCacLo)
            {
                Console.WriteLine(string.Format("{0,-12} {1,14} {2,18:N0} đ {3,20:N0} đ", ct.MaLo, ct.SoLuongXuat, ct.DonGiaVon, ct.ThanhTien));
            }
            Console.WriteLine("--------------------------------------------------------------------------------");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($" ===> TỔNG GIÁ TRỊ VỐN XUẤT KHO:  {ketQua.TongGiaTriXuat,20:N0} đ");
            Console.WriteLine($" ===> ĐƠN GIÁ BÌNH QUÂN / ĐƠN VỊ: {ketQua.DonGiaBinhQuanXuat,20:N0} đ");
            Console.ResetColor();
            Console.WriteLine("--------------------------------------------------------------------------------");
        }
    }
}
