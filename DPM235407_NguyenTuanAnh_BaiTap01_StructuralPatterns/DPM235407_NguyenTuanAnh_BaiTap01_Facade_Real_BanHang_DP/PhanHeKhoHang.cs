using System;
using System.Collections.Generic;
using System.Linq;

namespace DPM235407_NguyenTuanAnh_BaiTap01_Facade_Real_BanHang_DP
{
    // Dữ liệu lô hàng nông dược
    public class LoHangChiTiet
    {
        public string SoLo { get; set; }
        public string TenThuoc { get; set; }
        public DateTime HanSuDung { get; set; }
        public int SoLuongTon { get; set; }
        public decimal DonGiaBan { get; set; }

        public LoHangChiTiet(string soLo, string tenThuoc, DateTime hsd, int soLuong, decimal donGia)
        {
            SoLo = soLo;
            TenThuoc = tenThuoc;
            HanSuDung = hsd;
            SoLuongTon = soLuong;
            DonGiaBan = donGia;
        }
    }

    // [Subsystem 2]: Phân hệ quản lý kho nông dược theo lô & HSD (mục 3 PDF)
    public class PhanHeKhoHang
    {
        private readonly List<LoHangChiTiet> _khoHang = new List<LoHangChiTiet>();

        public PhanHeKhoHang()
        {
            // Khởi tạo các lô hàng thực tế trong kho An Giang
            _khoHang.Add(new LoHangChiTiet("LO-2025-A", "Thuốc trừ sâu sinh học Takare", new DateTime(2026, 11, 15), 50, 85000m));
            _khoHang.Add(new LoHangChiTiet("LO-2026-B", "Thuốc trừ sâu sinh học Takare", new DateTime(2027, 8, 20), 100, 85000m));
        }

        public bool XuatKhoTheoFIFO(string tenThuoc, int soLuongCanXuat, out List<(string SoLo, DateTime HSD, int SoLuong)> thongTinLoXuat)
        {
            thongTinLoXuat = new List<(string, DateTime, int)>();
            int tongTon = _khoHang.Where(l => l.TenThuoc == tenThuoc).Sum(l => l.SoLuongTon);

            if (tongTon < soLuongCanXuat)
            {
                Console.WriteLine($"[Kho Hàng] Lỗi: Không đủ hàng xuất ({tenThuoc} chỉ còn tồn {tongTon}).");
                return false;
            }

            // Tự động phân lô theo ngày hết hạn trước sẽ xuất trước (FEFO/FIFO theo mục 3 PDF)
            var cacLoKhaDung = _khoHang.Where(l => l.TenThuoc == tenThuoc && l.SoLuongTon > 0)
                                       .OrderBy(l => l.HanSuDung).ToList();

            int canLay = soLuongCanXuat;
            foreach (var lo in cacLoKhaDung)
            {
                if (canLay <= 0) break;
                int lay = Math.Min(lo.SoLuongTon, canLay);
                lo.SoLuongTon -= lay;
                canLay -= lay;
                thongTinLoXuat.Add((lo.SoLo, lo.HanSuDung, lay));
            }

            Console.WriteLine($"[Kho Hàng] Xuất kho thành công: Phân bổ {soLuongCanXuat} chai {tenThuoc} theo HSD ưu tiên!");
            return true;
        }
    }
}
