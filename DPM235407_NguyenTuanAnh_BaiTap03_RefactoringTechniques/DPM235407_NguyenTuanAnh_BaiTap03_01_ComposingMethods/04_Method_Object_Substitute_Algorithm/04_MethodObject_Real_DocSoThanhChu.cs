using System;
using System.Collections.Generic;
using System.Text;

namespace DPM235407_NguyenTuanAnh_BaiTap03_01_ComposingMethods._04_Method_Object_Substitute_Algorithm
{
    // =========================================================================
    // REAL APPLICATION (Hệ thống Nông Dược An Giang):
    // 1. Tái cấu trúc file legacy `Num2Str.cs` đọc số tiền thành chữ trên hóa đơn nông dược.
    // 2. Chuyển thuật toán tính giá vốn bình quân gia quyền (Mục 3 đề bài PDF)
    //    thành Method Object `TinhGiaBinhQuanGiaQuyenCalculator`.
    // =========================================================================

    // --- PHẦN 1: REFACTOR THUẬT TOÁN ĐỌC TIỀN BẰNG CHỮ (SUBSTITUTE ALGORITHM) ---
    public class DocSoThanhChuNongDuoc_Real
    {
        private static readonly string[] ChuSo = { "không", "một", "hai", "ba", "bốn", "năm", "sáu", "bảy", "tám", "chín" };
        private static readonly string[] HangDonVi = { "", "nghìn", "triệu", "tỷ", "nghìn tỷ", "triệu tỷ" };

        public static string ChuyenSoTienThanhChu(long soTien)
        {
            if (soTien == 0) return "Không đồng";
            if (soTien < 0) return "Âm " + ChuyenSoTienThanhChu(Math.Abs(soTien));

            var sb = new StringBuilder();
            int hangIndex = 0;
            long tempTien = soTien;

            while (tempTien > 0)
            {
                int nhom3So = (int)(tempTien % 1000);
                if (nhom3So > 0)
                {
                    string chuNhom = DocNhom3ChuSo(nhom3So, tempTien > 999);
                    string hang = HangDonVi[hangIndex];
                    string phanChu = string.IsNullOrEmpty(hang) ? chuNhom : $"{chuNhom} {hang}";
                    
                    if (sb.Length > 0)
                        sb.Insert(0, phanChu + " ");
                    else
                        sb.Append(phanChu);
                }
                tempTien /= 1000;
                hangIndex++;
            }

            string ketQua = sb.ToString().Trim();
            // Chuẩn hóa viết hoa chữ cái đầu và thêm từ "đồng"
            return char.ToUpper(ketQua[0]) + ketQua.Substring(1) + " đồng chẵn.";
        }

        private static string DocNhom3ChuSo(int so, bool coHangTruoc)
        {
            int tram = so / 100;
            int chuc = (so % 100) / 10;
            int donVi = so % 10;
            var sb = new StringBuilder();

            if (tram > 0 || coHangTruoc)
            {
                sb.Append($"{ChuSo[tram]} trăm ");
            }

            if (chuc > 1)
            {
                sb.Append($"{ChuSo[chuc]} mươi ");
                if (donVi == 1) sb.Append("mốt");
                else if (donVi == 5) sb.Append("lăm");
                else if (donVi > 0) sb.Append(ChuSo[donVi]);
            }
            else if (chuc == 1)
            {
                sb.Append("mười ");
                if (donVi == 5) sb.Append("lăm");
                else if (donVi > 0) sb.Append(ChuSo[donVi]);
            }
            else if (chuc == 0 && donVi > 0)
            {
                if (tram > 0 || coHangTruoc) sb.Append("linh ");
                sb.Append(ChuSo[donVi]);
            }

            return sb.ToString().Trim();
        }
    }

    // --- PHẦN 2: METHOD OBJECT TÍNH GIÁ VỐN BÌNH QUÂN GIA QUYỀN NÔNG DƯỢC ---
    public class LoNhapVatTu
    {
        public string MaLo { get; set; } = string.Empty;
        public int SoLuongNhap { get; set; }
        public decimal DonGiaNhap { get; set; }
        public decimal ChiPhiVanChuyenPhanBo { get; set; }
        public decimal ThueNhapKhau { get; set; }
    }

    public class TinhGiaBinhQuanGiaQuyenCalculator
    {
        private readonly List<LoNhapVatTu> _danhSachLo;
        private readonly decimal _chiPhiLuuKho;
        private readonly decimal _haoHutMoiTruongTiLe;

        public TinhGiaBinhQuanGiaQuyenCalculator(
            List<LoNhapVatTu> danhSachLo, 
            decimal chiPhiLuuKho, 
            decimal haoHutMoiTruongTiLe)
        {
            _danhSachLo = danhSachLo;
            _chiPhiLuuKho = chiPhiLuuKho;
            _haoHutMoiTruongTiLe = haoHutMoiTruongTiLe;
        }

        public decimal TinhDonGiaBQGQ()
        {
            if (_danhSachLo == null || _danhSachLo.Count == 0) return 0;

            decimal tongGiaTriNhap = 0;
            int tongSoLuongThucNhap = 0;

            foreach (var lo in _danhSachLo)
            {
                decimal giaTriLo = (lo.SoLuongNhap * lo.DonGiaNhap) + lo.ChiPhiVanChuyenPhanBo + lo.ThueNhapKhau;
                tongGiaTriNhap += giaTriLo;
                tongSoLuongThucNhap += lo.SoLuongNhap;
            }

            if (tongSoLuongThucNhap == 0) return 0;

            decimal giaVonCoBan = tongGiaTriNhap / tongSoLuongThucNhap;
            decimal chiPhiPhatSinhMoiDonVi = _chiPhiLuuKho / tongSoLuongThucNhap;
            decimal heSoHaoHut = 1 + _haoHutMoiTruongTiLe;

            return (giaVonCoBan + chiPhiPhatSinhMoiDonVi) * heSoHaoHut;
        }
    }
}
