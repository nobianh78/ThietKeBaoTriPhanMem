using System;
using System.Collections.Generic;

namespace DPM235407_NguyenTuanAnh_BaiTap03_03_OrganizingData._05_Change_Value_Reference
{
    // =========================================================================
    // REAL APPLICATION (Hệ thống Nông Dược An Giang):
    // Phân định rạch ròi:
    // 1. `LoHangThucThe` (Entity): Có Identity (Mã Lô), có vòng đời, được quản lý dạng Reference.
    // 2. `ChinhSachGiaChietKhau` (Value Object): Không có ID, so sánh theo giá trị, bất biến (Immutable).
    // =========================================================================

    // Value Object: Chính sách giá
    public readonly record struct ChinhSachGiaMungVuMua
    {
        public decimal TiLeGiamVungSauVungXa { get; }
        public decimal TroGiaPhanBon { get; }

        public ChinhSachGiaMungVuMua(decimal tiLeGiam, decimal troGia)
        {
            TiLeGiamVungSauVungXa = tiLeGiam;
            TroGiaPhanBon = troGia;
        }
    }

    // Entity Reference: Lô hàng bảo vệ thực vật
    public class LoHangThucThe_Real
    {
        public string MaLo { get; }
        public string TenThuoc { get; }
        public int SoLuongTon { get; private set; }
        public DateTime HanSuDung { get; }

        public LoHangThucThe_Real(string maLo, string tenThuoc, int soLuongTon, DateTime hsd)
        {
            MaLo = maLo;
            TenThuoc = tenThuoc;
            SoLuongTon = soLuongTon;
            HanSuDung = hsd;
        }

        public void XuatKho(int soLuong)
        {
            if (soLuong > SoLuongTon)
            {
                throw new InvalidOperationException($"Lô {MaLo} ({TenThuoc}) chỉ còn tồn {SoLuongTon}, không đủ xuất {soLuong}!");
            }
            SoLuongTon -= soLuong;
            Console.WriteLine($"   -> [KHO NÔNG DƯỢC] Đã trừ {soLuong} từ Lô {MaLo}. Tồn kho hiện tại: {SoLuongTon} sp.");
        }
    }

    public class KhoTrungTamNongDuoc_Real
    {
        private readonly Dictionary<string, LoHangThucThe_Real> _khoHang = new();

        public void NhapKhoLoMoi(LoHangThucThe_Real lo)
        {
            _khoHang[lo.MaLo] = lo;
        }

        public LoHangThucThe_Real LayLoHang(string maLo)
        {
            if (_khoHang.TryGetValue(maLo, out var lo)) return lo;
            throw new KeyNotFoundException($"Không tìm thấy lô {maLo} trong kho!");
        }

        public void InTonKho()
        {
            Console.WriteLine("---------------- TỒN KHO THỰC TẾ TẠI KHO TRUNG TÂM ----------------");
            foreach (var lo in _khoHang.Values)
            {
                Console.WriteLine($" * Lô: {lo.MaLo,-12} | Thuốc: {lo.TenThuoc,-26} | Tồn: {lo.SoLuongTon,4} | HSD: {lo.HanSuDung:dd/MM/yyyy}");
            }
            Console.WriteLine("-------------------------------------------------------------------\n");
        }
    }
}
