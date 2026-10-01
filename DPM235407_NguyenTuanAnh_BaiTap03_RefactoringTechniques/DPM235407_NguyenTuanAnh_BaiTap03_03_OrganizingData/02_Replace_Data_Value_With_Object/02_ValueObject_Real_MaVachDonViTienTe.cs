using System;

namespace DPM235407_NguyenTuanAnh_BaiTap03_03_OrganizingData._02_Replace_Data_Value_With_Object
{
    // =========================================================================
    // REAL APPLICATION (Hệ thống Nông Dược An Giang):
    // Thay thế các trường `m_GiaBanLe`, `m_GiaBanSi`, `m_DVT` trong `SanPham.cs`
    // bằng các Value Object: `TienTeNongDuoc` (hỗ trợ định dạng tiền VNĐ và kiểm soát số âm)
    // và `QuyCachDongGoi` (chứa đơn vị tính, thể tích, quy cách thùng/chai).
    // =========================================================================

    public readonly record struct TienTeNongDuoc
    {
        public decimal Amount { get; }

        public TienTeNongDuoc(decimal amount)
        {
            if (amount < 0) throw new ArgumentOutOfRangeException(nameof(amount), "Tiền tệ nông dược không được âm!");
            Amount = amount;
        }

        public static implicit operator TienTeNongDuoc(decimal val) => new(val);
        public static implicit operator decimal(TienTeNongDuoc val) => val.Amount;

        public static TienTeNongDuoc operator +(TienTeNongDuoc a, TienTeNongDuoc b) => new(a.Amount + b.Amount);
        public static TienTeNongDuoc operator -(TienTeNongDuoc a, TienTeNongDuoc b) => new(Math.Max(0, a.Amount - b.Amount));
        public static TienTeNongDuoc operator *(TienTeNongDuoc a, int quantity) => new(a.Amount * quantity);

        public override string ToString() => $"{Amount:N0} VNĐ";
    }

    public readonly record struct QuyCachDongGoi
    {
        public string DonViCoSo { get; }
        public int DungTichMl { get; }
        public int SoLuongTrenThung { get; }

        public QuyCachDongGoi(string donViCoSo, int dungTichMl, int soLuongTrenThung)
        {
            DonViCoSo = donViCoSo;
            DungTichMl = dungTichMl;
            SoLuongTrenThung = soLuongTrenThung;
        }

        public override string ToString() => $"{DonViCoSo} {DungTichMl}ml ({SoLuongTrenThung} {DonViCoSo}/thùng)";
    }

    public class SanPhamNongDuoc_Real
    {
        public string MaSanPham { get; set; } = "SP-TIL-300";
        public string TenSanPham { get; set; } = "Thuốc trừ nấm bệnh Tilt Super 300EC";
        public QuyCachDongGoi QuyCach { get; set; } = new("Chai", 250, 40);
        public TienTeNongDuoc GiaBanLe { get; set; } = 240000;
        public TienTeNongDuoc GiaBanSi { get; set; } = 210000;

        public void InThongTinSanPham()
        {
            Console.WriteLine("---------------- CHI TIẾT SẢN PHẨM NÔNG DƯỢC (VALUE OBJECTS) ----------------");
            Console.WriteLine($"Mã thuốc    : {MaSanPham}");
            Console.WriteLine($"Tên thuốc   : {TenSanPham}");
            Console.WriteLine($"Quy cách    : {QuyCach}");
            Console.WriteLine($"Giá bán lẻ  : {GiaBanLe}");
            Console.WriteLine($"Giá bán sỉ  : {GiaBanSi}");
            Console.WriteLine("----------------------------------------------------------------------------\n");
        }
    }
}
