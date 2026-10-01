using System;
using System.Collections.Generic;

namespace DPM235407_NguyenTuanAnh_BaiTap03_01_ComposingMethods._01_Extract_Inline_Method
{
    // =========================================================================
    // REAL APPLICATION (Hệ thống Nông Dược An Giang):
    // Tái cấu trúc nghiệp vụ Lập phiếu bán lẻ & trừ kho FEFO trong file `frmBanLe.cs`
    // Mã cũ trong Form GUI trộn lẫn: Kiểm tra dữ liệu -> Tính toán -> Cập nhật công nợ -> In phiếu.
    // Sau khi Refactor: Tách thành các hàm đơn nhiệm rõ ràng và tái sử dụng được.
    // =========================================================================

    public class DongChiTietPhieuBan
    {
        public string MaLoThuoc { get; set; } = string.Empty;
        public string TenThuoc { get; set; } = string.Empty;
        public int SoLuong { get; set; }
        public decimal DonGia { get; set; }
        public DateTime HanSuDung { get; set; }

        public decimal ThanhTien => SoLuong * DonGia;
    }

    public class XuLyPhieuBanLeNongDuoc_Real
    {
        public string MaPhieu { get; set; } = "PB-2026-0099";
        public string KhachHang { get; set; } = "Hợp tác xã Nông nghiệp Tri Tôn";
        public decimal SoTienDaTra { get; set; } = 3000000;
        public List<DongChiTietPhieuBan> ChiTietList { get; set; } = new();

        public void XuLyLuuPhieuBanLe()
        {
            Console.WriteLine($"=== [THỰC TẾ NÔNG DƯỢC] BẮT ĐẦU XỬ LÝ PHIẾU BÁN: {MaPhieu} ===");

            // 1. Kiểm tra dữ liệu đầu vào (Extract Method: Validate)
            if (!ValidateThongTinPhieu())
            {
                Console.WriteLine("❌ Phiếu không hợp lệ, hủy xử lý.");
                return;
            }

            // 2. Tính toán tiền hàng và công nợ (Extract Method: TinhToanTaiChinh)
            var (tongTien, tienGiam, conNo) = TinhToanTaiChinh();

            // 3. Phân bổ trừ tồn lô kho (Extract Method: CapNhatTonKhoFEFO)
            CapNhatTonKhoFEFO();

            // 4. In thông tin phiếu xuất bán lẻ (Extract Method: InPhieuXuatKho)
            InPhieuXuatKho(tongTien, tienGiam, conNo);

            Console.WriteLine("✅ Lưu phiếu bán lẻ và đồng bộ sổ cái thành công!\n");
        }

        private bool ValidateThongTinPhieu()
        {
            if (string.IsNullOrWhiteSpace(KhachHang))
            {
                Console.WriteLine("Lỗi: Khách hàng không được để trống!");
                return false;
            }
            if (ChiTietList.Count == 0)
            {
                Console.WriteLine("Lỗi: Phiếu bán phải có ít nhất một mặt hàng thuốc BVTV!");
                return false;
            }
            foreach (var item in ChiTietList)
            {
                if (item.SoLuong <= 0 || item.DonGia <= 0)
                {
                    Console.WriteLine($"Lỗi: Thuốc {item.TenThuoc} có số lượng/đơn giá không hợp lệ!");
                    return false;
                }
            }
            return true;
        }

        private (decimal tongTien, decimal tienGiam, decimal conNo) TinhToanTaiChinh()
        {
            decimal tongTien = 0;
            foreach (var item in ChiTietList)
            {
                tongTien += item.ThanhTien;
            }

            // Chiết khấu 5% nếu tổng đơn trên 5 triệu cho hợp tác xã
            decimal tienGiam = (tongTien >= 5000000) ? (tongTien * 0.05m) : 0;
            decimal phaiTra = tongTien - tienGiam;
            decimal conNo = Math.Max(0, phaiTra - SoTienDaTra);

            return (tongTien, tienGiam, conNo);
        }

        private void CapNhatTonKhoFEFO()
        {
            Console.WriteLine("-> Đang kiểm tra và trừ tồn kho theo số lô cận HSD (FEFO)...");
            foreach (var item in ChiTietList)
            {
                Console.WriteLine($"   * Đã trừ {item.SoLuong} đơn vị thuốc [{item.TenThuoc}], Lô: {item.MaLoThuoc} (HSD: {item.HanSuDung:dd/MM/yyyy})");
            }
        }

        private void InPhieuXuatKho(decimal tongTien, decimal tienGiam, decimal conNo)
        {
            Console.WriteLine("---------------- CHI TIẾT PHIẾU XUẤT NÔNG DƯỢC ----------------");
            Console.WriteLine($"Khách hàng: {KhachHang}");
            foreach (var item in ChiTietList)
            {
                Console.WriteLine($" - {item.TenThuoc,-25} | SL: {item.SoLuong,3} | Đơn giá: {item.DonGia,9:N0} đ | Thành tiền: {item.ThanhTien,10:N0} đ");
            }
            Console.WriteLine($"Tổng tiền hàng : {tongTien,12:N0} đ");
            Console.WriteLine($"Chiết khấu mùa vụ: {tienGiam,12:N0} đ");
            Console.WriteLine($"Đã thanh toán  : {SoTienDaTra,12:N0} đ");
            Console.WriteLine($"Còn nợ đại lý  : {conNo,12:N0} đ");
            Console.WriteLine("----------------------------------------------------------------");
        }
    }
}
