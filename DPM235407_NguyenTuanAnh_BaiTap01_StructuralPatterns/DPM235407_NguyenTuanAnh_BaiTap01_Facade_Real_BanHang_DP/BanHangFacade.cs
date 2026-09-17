using System;
using System.Collections.Generic;

namespace DPM235407_NguyenTuanAnh_BaiTap01_Facade_Real_BanHang_DP
{
    // [FACADE]: Đơn giản hóa toàn bộ quy trình bán hàng nông dược phức tạp
    public class BanHangFacade
    {
        private readonly PhanHeXacThuc _xacThuc;
        private readonly PhanHeKhoHang _khoHang;
        private readonly PhanHeTinhTien _tinhTien;
        private readonly PhanHeThongKe _thongKe;

        public BanHangFacade()
        {
            _xacThuc = new PhanHeXacThuc();
            _khoHang = new PhanHeKhoHang();
            _tinhTien = new PhanHeTinhTien();
            _thongKe = new PhanHeThongKe();
        }

        // Phương thức cấp cao duy nhất Client cần gọi
        public bool LapDonHangNongDuoc(
            string maNV, string matKhau,
            string tenKhachHang, string tenThuoc, int soLuong, decimal donGia,
            decimal phiVanChuyen, decimal phiDichVuPhu, decimal giamGia)
        {
            Console.WriteLine("--------------------------------------------------------------------------------");
            Console.WriteLine("FACADE: BẮT ĐẦU ĐIỀU PHỐI QUY TRÌNH BÁN HÀNG NÔNG DƯỢC TỔNG THỂ");
            Console.WriteLine("--------------------------------------------------------------------------------");

            // Bước 1: Xác thực nhân viên đăng nhập
            if (!_xacThuc.KiemTraDangNhap(maNV, matKhau))
            {
                Console.WriteLine("FACADE: Hủy giao dịch do xác thực không hợp lệ!");
                return false;
            }

            // Bước 2: Xuất kho theo lô HSD sớm nhất (FIFO)
            if (!_khoHang.XuatKhoTheoFIFO(tenThuoc, soLuong, out var danhSachLo))
            {
                Console.WriteLine("FACADE: Hủy giao dịch do tồn kho không đáp ứng!");
                return false;
            }

            // Bước 3: Tính toán tài chính
            decimal tienHang = soLuong * donGia;
            decimal tongThanhToan = _tinhTien.TinhTien(tienHang, phiVanChuyen, phiDichVuPhu, giamGia);

            // Bước 4: In phiếu xuất chi tiết có số lô và HSD theo yêu cầu mục 3 PDF
            string maHD = "HD-" + Guid.NewGuid().ToString().Substring(0, 8).ToUpper();
            Console.WriteLine($"\n===> CHI TIẾT PHIẾU BÁN HÀNG & XUẤT KHO: {maHD}");
            Console.WriteLine($"Khách hàng: {tenKhachHang} | Nhân viên lập: {maNV}");
            Console.WriteLine($"Mặt hàng: {tenThuoc} | Số lượng: {soLuong} chai");
            Console.WriteLine("Phân bổ lô hàng xuất kho (theo ngày hết hạn trước xuất trước):");
            foreach (var lo in danhSachLo)
            {
                Console.WriteLine($"  * Số lô: {lo.SoLo} | HSD: {lo.HSD:dd/MM/yyyy} | Số lượng xuất: {lo.SoLuong} chai");
            }
            Console.WriteLine($"Tiền hàng: {tienHang:N0} VNĐ | Phí vận chuyển: +{phiVanChuyen:N0} VNĐ");
            Console.WriteLine($"Dịch vụ phụ: +{phiDichVuPhu:N0} VNĐ | Giảm giá khuyến mãi: -{giamGia:N0} VNĐ");
            Console.WriteLine($"---> TỔNG TIỀN PHẢI THU: {tongThanhToan:N0} VNĐ\n");

            // Bước 5: Lưu thống kê theo nhân viên
            _thongKe.GhiNhanHoaDon(maNV, maHD, tongThanhToan, giamGia);

            Console.WriteLine("FACADE: QUY TRÌNH BÁN HÀNG HOÀN TẤT THÀNH CÔNG!\n");
            return true;
        }
    }
}
