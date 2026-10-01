using System;
using System.Collections.Generic;

namespace DPM235407_NguyenTuanAnh_BaiTap03_02_MovingFeatures._01_Move_Method_Field
{
    // =========================================================================
    // REAL APPLICATION (Hệ thống Nông Dược An Giang):
    // Trong mã nguồn cũ `frmBanLe.cs`, các hàm:
    // - `numDonGia_ValueChanged`: `numThanhTien.Value = numDonGia.Value * numSoLuong.Value;`
    // - `numTongTien_ValueChanged`: `numConNo.Value = numTongTien.Value - numDaTra.Value;`
    // - `btnAdd_Click`: Tạo DataRow và cộng dồn trực tiếp trên Form.
    // REFACTOR: Chuyển toàn bộ các phương thức này về lớp `PhieuBan` và `ChiTietPhieuBan`.
    // =========================================================================

    public class ChiTietPhieuBan_Real
    {
        public string MaLoThuoc { get; set; } = string.Empty;
        public string TenThuoc { get; set; } = string.Empty;
        public int SoLuong { get; private set; }
        public decimal DonGia { get; private set; }

        public ChiTietPhieuBan_Real(string maLo, string tenThuoc, int soLuong, decimal donGia)
        {
            MaLoThuoc = maLo;
            TenThuoc = tenThuoc;
            CapNhatSoLuongVaGia(soLuong, donGia);
        }

        // Method được chuyển từ Form vào ChiTietPhieuBan
        public void CapNhatSoLuongVaGia(int soLuongMoi, decimal donGiaMoi)
        {
            if (soLuongMoi <= 0) throw new ArgumentException("Số lượng phải lớn hơn 0");
            if (donGiaMoi < 0) throw new ArgumentException("Đơn giá không được âm");

            SoLuong = soLuongMoi;
            DonGia = donGiaMoi;
        }

        // Tự tính thành tiền nội tại
        public decimal ThanhTien => SoLuong * DonGia;
    }

    public class PhieuBan_Real
    {
        public string MaPhieu { get; set; } = "PB-2026-REAL";
        public string TenKhachHang { get; set; } = "Đại lý Nông Dược Tịnh Biên";
        public decimal DaTra { get; private set; }
        public List<ChiTietPhieuBan_Real> DanhSachChiTiet { get; } = new();

        // Move Method: Thêm chi tiết và tự động bảo toàn tính toàn vẹn dữ liệu
        public void ThemChiTiet(string maLo, string tenThuoc, int soLuong, decimal donGia)
        {
            var chiTiet = new ChiTietPhieuBan_Real(maLo, tenThuoc, soLuong, donGia);
            DanhSachChiTiet.Add(chiTiet);
        }

        // Move Method: Ghi nhận thanh toán và tính nợ
        public void ThanhToan(decimal soTien)
        {
            if (soTien < 0) throw new ArgumentException("Số tiền thanh toán không được âm");
            DaTra += soTien;
        }

        // Các thuộc tính tính toán tự động
        public decimal TongTienHang
        {
            get
            {
                decimal tong = 0;
                foreach (var item in DanhSachChiTiet) tong += item.ThanhTien;
                return tong;
            }
        }

        public decimal ConNo => Math.Max(0, TongTienHang - DaTra);

        public void InThongTinPhieu()
        {
            Console.WriteLine($"\n--- PHIẾU BÁN HÀNG: {MaPhieu} ({TenKhachHang}) ---");
            foreach (var ct in DanhSachChiTiet)
            {
                Console.WriteLine($" + {ct.TenThuoc,-28} (Lô {ct.MaLoThuoc}) | SL: {ct.SoLuong,3} x {ct.DonGia,9:N0} đ = {ct.ThanhTien,10:N0} đ");
            }
            Console.WriteLine($"Tổng tiền hàng: {TongTienHang,12:N0} VNĐ");
            Console.WriteLine($"Đã thanh toán : {DaTra,12:N0} VNĐ");
            Console.WriteLine($"Số tiền còn nợ: {ConNo,12:N0} VNĐ\n");
        }
    }
}
