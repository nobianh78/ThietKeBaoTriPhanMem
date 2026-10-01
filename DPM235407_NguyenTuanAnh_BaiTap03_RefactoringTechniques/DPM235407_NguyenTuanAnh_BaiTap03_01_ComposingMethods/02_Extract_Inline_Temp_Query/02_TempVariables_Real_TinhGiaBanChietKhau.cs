using System;

namespace DPM235407_NguyenTuanAnh_BaiTap03_01_ComposingMethods._02_Extract_Inline_Temp_Query
{
    // =========================================================================
    // REAL APPLICATION (Hệ thống Nông Dược An Giang):
    // Tái cấu trúc logic tính giá bán sỉ theo cấp đại lý trong `frmBanSi.cs`.
    // Mã gốc: Các biến tạm gán đè liên tục trong các sự kiện TextChanged / ValueChanged.
    // Sau khi Refactor: Chuyển thành các thuộc tính Query thuần túy (Pure Queries),
    // dễ dàng bảo trì và hỗ trợ xuất báo cáo tài chính chính xác.
    // =========================================================================

    public enum CapDaiLy
    {
        DaiLyCap1,
        DaiLyCap2,
        HopTacXaNongNghiep,
        NongDanTrucTiep
    }

    public class DonHangBanSiNongDuoc_Real
    {
        public string TenVatTu { get; set; } = "Thuốc trừ sâu sinh học Radiant 60SC (Chai 100ml)";
        public int SoLuongChai { get; set; } = 250;
        public decimal DonGiaNiemYet { get; set; } = 185000;
        public CapDaiLy CapBacDaiLy { get; set; } = CapDaiLy.DaiLyCap1;
        public bool CoHoTroGiaoXeTaiTanRuong { get; set; } = true;
        public int SoTanVatTu { get; set; } = 2; // Khối lượng để tính cước xe tải

        // 1. Query: Tổng giá gốc niêm yết
        public decimal TongTienNiemYet => SoLuongChai * DonGiaNiemYet;

        // 2. Query: Tỉ lệ chiết khấu thương mại dựa trên cấp bậc đại lý & khối lượng mua
        public decimal TiLeChietKhau
        {
            get
            {
                decimal tiLeCoBan = CapBacDaiLy switch
                {
                    CapDaiLy.DaiLyCap1 => 0.12m,           // Đại lý cấp 1: 12%
                    CapDaiLy.DaiLyCap2 => 0.07m,           // Đại lý cấp 2: 7%
                    CapDaiLy.HopTacXaNongNghiep => 0.05m,  // HTX: 5%
                    _ => 0.0m
                };

                // Thưởng thêm 2% nếu mua số lượng lớn từ 200 chai trở lên trong vụ mùa
                bool duDieuKienThuongSoLuong = SoLuongChai >= 200;
                if (duDieuKienThuongSoLuong)
                {
                    tiLeCoBan += 0.02m;
                }

                return tiLeCoBan;
            }
        }

        // 3. Query: Số tiền chiết khấu được giảm
        public decimal TienChietKhau => TongTienNiemYet * TiLeChietKhau;

        // 4. Query: Tiền hàng sau chiết khấu
        public decimal TienHangSauChietKhau => TongTienNiemYet - TienChietKhau;

        // 5. Query: Phí vận chuyển bằng xe tải
        public decimal CuocVanChuyenXeTai
        {
            get
            {
                if (!CoHoTroGiaoXeTaiTanRuong) return 0;
                const decimal cuocMoiTan = 150000;
                return Math.Max(200000, SoTanVatTu * cuocMoiTan);
            }
        }

        // 6. Query: Thuế VAT đầu ra cho ngành thuốc BVTV (5% theo quy định nông nghiệp)
        public decimal ThueVATNongNghiep => TienHangSauChietKhau * 0.05m;

        // 7. Query: Tổng giá trị thanh toán cuối cùng
        public decimal TongThanhToanCuoiCung => TienHangSauChietKhau + CuocVanChuyenXeTai + ThueVATNongNghiep;

        public void InBangKeChiTietDonHang()
        {
            Console.WriteLine("╔════════════════════════════════════════════════════════════════╗");
            Console.WriteLine("║        BẢNG TÍNH GIÁ BÁN SỈ NÔNG DƯỢC (REFACTORED QUERY)       ║");
            Console.WriteLine("╠════════════════════════════════════════════════════════════════╣");
            Console.WriteLine($"║ Sản phẩm      : {TenVatTu,-46} ║");
            Console.WriteLine($"║ Số lượng      : {SoLuongChai,5} chai | Đơn giá: {DonGiaNiemYet,12:N0} đ     ║");
            Console.WriteLine($"║ Đối tượng     : {CapBacDaiLy,-46} ║");
            Console.WriteLine("╟────────────────────────────────────────────────────────────────╢");
            Console.WriteLine($"║ 1. Tiền hàng niêm yết       : {TongTienNiemYet,18:N0} đ      ║");
            Console.WriteLine($"║ 2. Chiết khấu thương mại ({TiLeChietKhau * 100,2:0}%) : -{TienChietKhau,17:N0} đ      ║");
            Console.WriteLine($"║ 3. Tiền sau chiết khấu      : {TienHangSauChietKhau,18:N0} đ      ║");
            Console.WriteLine($"║ 4. Cước xe tải giao tận nơi : +{CuocVanChuyenXeTai,17:N0} đ      ║");
            Console.WriteLine($"║ 5. Thuế VAT nông dược (5%)  : +{ThueVATNongNghiep,17:N0} đ      ║");
            Console.WriteLine("╟────────────────────────────────────────────────────────────────╢");
            Console.WriteLine($"║ TỔNG THANH TOÁN             : {TongThanhToanCuoiCung,18:N0} đ      ║");
            Console.WriteLine("╚════════════════════════════════════════════════════════════════╝\n");
        }
    }
}
