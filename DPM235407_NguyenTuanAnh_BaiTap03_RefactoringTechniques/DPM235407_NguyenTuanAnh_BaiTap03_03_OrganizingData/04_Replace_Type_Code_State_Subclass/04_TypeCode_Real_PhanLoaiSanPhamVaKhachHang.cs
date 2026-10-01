using System;

namespace DPM235407_NguyenTuanAnh_BaiTap03_03_OrganizingData._04_Replace_Type_Code_State_Subclass
{
    // =========================================================================
    // REAL APPLICATION (Hệ thống Nông Dược An Giang):
    // Phân loại danh mục Thuốc Bảo Vệ Thực Vật & Phân Bón trong kho:
    // - Thuốc trừ sâu: Có quy chuẩn cách ly an toàn nghiêm ngặt (PSI: Pre-Harvest Interval)
    // - Thuốc trừ bệnh (Diệt nấm): Có nhiệt độ bảo quản và hạn dùng ngắn hơn
    // - Phân bón lá / Kích rễ: Có thể bán kèm combo không cần đơn thuốc BVTV
    // =========================================================================

    public interface ILoaiThuocNongDuoc
    {
        string TenPhanLoai { get; }
        int ThoiGianCachLyNgay { get; }
        decimal TinhThueMoiTruong(decimal donGia);
        string HuongDanBaoQuan();
    }

    public class ThuocTruSauDocCao : ILoaiThuocNongDuoc
    {
        public string TenPhanLoai => "Thuốc trừ sâu độc cao (Nhóm II/III)";
        public int ThoiGianCachLyNgay => 14;
        public decimal TinhThueMoiTruong(decimal donGia) => donGia * 0.03m;
        public string HuongDanBaoQuan() => "Kho riêng biệt, có khóa an toàn, thoáng khí, cách xa nguồn nước.";
    }

    public class ThuocTruBenhSinhHoc : ILoaiThuocNongDuoc
    {
        public string TenPhanLoai => "Thuốc trừ bệnh sinh học / Vi sinh";
        public int ThoiGianCachLyNgay => 3;
        public decimal TinhThueMoiTruong(decimal donGia) => 0m; // Miễn thuế môi trường cho chế phẩm sinh học
        public string HuongDanBaoQuan() => "Nhiệt độ dưới 30 độ C, tránh ánh sáng trực tiếp.";
    }

    public class PhanBonLaDinhDuong : ILoaiThuocNongDuoc
    {
        public string TenPhanLoai => "Phân bón lá cao cấp & Điều hòa sinh trưởng";
        public int ThoiGianCachLyNgay => 0;
        public decimal TinhThueMoiTruong(decimal donGia) => 0m;
        public string HuongDanBaoQuan() => "Để nơi khô ráo, kê trên pallet cách mặt đất 15cm.";
    }

    public class SanPhamNongDuocPhanLoai_Real
    {
        public string TenSanPham { get; set; } = string.Empty;
        public decimal DonGia { get; set; }
        public ILoaiThuocNongDuoc PhanLoai { get; set; }

        public SanPhamNongDuocPhanLoai_Real(string ten, decimal donGia, ILoaiThuocNongDuoc phanLoai)
        {
            TenSanPham = ten;
            DonGia = donGia;
            PhanLoai = phanLoai;
        }

        public void InThongTinChiTiet()
        {
            Console.WriteLine($"---------------- [{PhanLoai.TenPhanLoai}] ----------------");
            Console.WriteLine($"Tên sản phẩm      : {TenSanPham}");
            Console.WriteLine($"Đơn giá niêm yết  : {DonGia:N0} VNĐ");
            Console.WriteLine($"Thời gian cách ly : {PhanLoai.ThoiGianCachLyNgay} ngày trước khi thu hoạch");
            Console.WriteLine($"Thuế môi trường   : {PhanLoai.TinhThueMoiTruong(DonGia):N0} VNĐ");
            Console.WriteLine($"Bảo quản          : {PhanLoai.HuongDanBaoQuan()}");
            Console.WriteLine();
        }
    }
}
