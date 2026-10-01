using System;
using System.Collections.Generic;

namespace DPM235407_NguyenTuanAnh_BaiTap03_03_OrganizingData._05_Change_Value_Reference
{
    // =========================================================================
    // AFTER: Áp dụng kỹ thuật Change Value to Reference (Chuyển Giá trị thành Tham chiếu Thực thể)
    // - Quản lý duy nhất một phiên bản thực thể Lô Hàng thông qua Repository / Kho Repository.
    // - Mọi đơn hàng tham chiếu đến cùng một đối tượng Lô Hàng trong bộ nhớ.
    // - Đảm bảo tính nhất quán (Consistency) của dữ liệu tồn kho.
    // =========================================================================
    public class LoHang_After
    {
        public string MaLo { get; }
        public int SoLuongTon { get; private set; }

        public LoHang_After(string maLo, int soLuongTon)
        {
            MaLo = maLo;
            SoLuongTon = soLuongTon;
        }

        public void TruTonKho(int soLuong)
        {
            if (soLuong > SoLuongTon) throw new InvalidOperationException($"Lô {MaLo} không đủ hàng để trừ!");
            SoLuongTon -= soLuong;
        }
    }

    public class KhoHangRepository
    {
        private readonly Dictionary<string, LoHang_After> _loHangDict = new();

        public void DangKyLoHang(LoHang_After lo)
        {
            _loHangDict[lo.MaLo] = lo;
        }

        public LoHang_After LayLoHangTheoMa(string maLo)
        {
            if (_loHangDict.TryGetValue(maLo, out var lo)) return lo;
            throw new KeyNotFoundException($"Không tìm thấy lô hàng: {maLo}");
        }
    }

    public class DonHangXuat_After
    {
        public LoHang_After LoHangRef { get; }

        public DonHangXuat_After(LoHang_After loHangRef)
        {
            LoHangRef = loHangRef; // Tham chiếu đến đối tượng thực thể duy nhất
        }

        public void XuatKho(int soLuong)
        {
            LoHangRef.TruTonKho(soLuong);
            Console.WriteLine($"[AFTER] Đơn hàng trừ {soLuong} sp. Tồn kho thực tế còn lại của lô {LoHangRef.MaLo}: {LoHangRef.SoLuongTon}");
        }
    }
}
