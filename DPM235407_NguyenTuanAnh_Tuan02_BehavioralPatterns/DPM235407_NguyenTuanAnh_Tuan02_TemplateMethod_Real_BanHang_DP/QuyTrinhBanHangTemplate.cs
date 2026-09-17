using System;

namespace DPM235407_NguyenTuanAnh_Tuan02_TemplateMethod_Real_BanHang_DP
{
    // Lớp trừu tượng định nghĩa Khuôn Mẫu Quy Trình Bán Hàng Nông Dược An Giang
    public abstract class QuyTrinhBanHangTemplate
    {
        // TEMPLATE METHOD: Cố định các bước của thuật toán bán hàng
        public void XuLyDonHang(DonHangNongDuoc donHang)
        {
            Console.WriteLine($"\n================================================================================");
            Console.WriteLine($" BẮT ĐẦU QUY TRÌNH XỬ LÝ: {donHang.MaDon} ({GetLoaiHinh()}) - KHÁCH: {donHang.TenKhachHang}");
            Console.WriteLine($"================================================================================");

            // Bước 1: Kiểm tra tồn kho (Cố định)
            KiemTraTonKho(donHang);

            // Bước 2: Tính tiền hàng gốc (Cố định)
            TinhTienHangGoc(donHang);

            // Bước 3: Áp dụng chính sách chiết khấu (Biến đổi theo Bán sỉ / Bán lẻ)
            ApDungChietKhau(donHang);

            // Bước 4: Tính chi phí vận chuyển (Biến đổi theo Xe tải sỉ / Shipper lẻ)
            TinhChiPhiVanChuyen(donHang);

            // Bước 5: Hook dịch vụ phụ trợ phát sinh (Tùy chọn)
            HookDichVuPhatSinh(donHang);

            // Bước 6: Phân lô xuất kho theo ngày hết hạn trước xuất trước (Cố định)
            PhanLoXuatKhoTheoHSD(donHang);

            // Bước 7: In hóa đơn tài chính chi tiết (Cố định)
            InHoaDon(donHang);
        }

        public abstract string GetLoaiHinh();

        // Bước cố định 1
        protected virtual void KiemTraTonKho(DonHangNongDuoc donHang)
        {
            Console.WriteLine($"1. [KHO HÀNG] Kiểm tra thuốc '{donHang.TenThuoc}' đủ số lượng {donHang.SoLuong} gói/chai.");
        }

        // Bước cố định 2
        protected virtual void TinhTienHangGoc(DonHangNongDuoc donHang)
        {
            Console.WriteLine($"2. [KẾ TOÁN] Tiền hàng gốc: {donHang.SoLuong} x {donHang.DonGiaGoc:N0}đ = {donHang.TienHangGoc:N0} đ.");
        }

        // Bước trừu tượng 3: Triển khai riêng ở lớp con
        protected abstract void ApDungChietKhau(DonHangNongDuoc donHang);

        // Bước trừu tượng 4: Triển khai riêng ở lớp con
        protected abstract void TinhChiPhiVanChuyen(DonHangNongDuoc donHang);

        // Hook bước 5: Cho phép can thiệp dịch vụ phụ
        protected virtual void HookDichVuPhatSinh(DonHangNongDuoc donHang) { }

        // Bước cố định 6
        protected virtual void PhanLoXuatKhoTheoHSD(DonHangNongDuoc donHang)
        {
            // Tự động phân lô theo HSD gần nhất xuất trước
            donHang.MaLoXuat = "LO-FEFO-2025/08";
            donHang.NgayHetHan = DateTime.Now.AddMonths(14);
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"5. [XUẤT KHO THEO CẤU HÌNH] Phân lô FEFO: {donHang.MaLoXuat} (HSD: {donHang.NgayHetHan:dd/MM/yyyy})");
            Console.ResetColor();
        }

        // Bước cố định 7
        protected virtual void InHoaDon(DonHangNongDuoc donHang)
        {
            Console.WriteLine("--------------------------------------------------------------------------------");
            Console.WriteLine($" HÓA ĐƠN BÁN NÔNG DƯỢC ({GetLoaiHinh()}) - {donHang.MaDon}");
            Console.WriteLine($" Thuốc: {donHang.TenThuoc} | Số lượng: {donHang.SoLuong} | Đơn giá: {donHang.DonGiaGoc:N0}đ");
            Console.WriteLine($" Lô xuất kho: {donHang.MaLoXuat} | Hạn sử dụng: {donHang.NgayHetHan:dd/MM/yyyy}");
            Console.WriteLine($"   + Tiền hàng gốc:          {donHang.TienHangGoc,16:N0} đ");
            Console.WriteLine($"   - Chiết khấu giảm giá:    {donHang.ChietKhau,16:N0} đ");
            Console.WriteLine($"   + Phí vận chuyển:         {donHang.PhiVanChuyen,16:N0} đ");
            if (donHang.PhiDichVu > 0)
                Console.WriteLine($"   + Dịch vụ ({donHang.TenDichVu}): {donHang.PhiDichVu,16:N0} đ");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"   ===> TỔNG CỘNG THANH TOÁN: {donHang.TongThanhToan,16:N0} đ");
            Console.ResetColor();
            Console.WriteLine("--------------------------------------------------------------------------------");
        }
    }
}
