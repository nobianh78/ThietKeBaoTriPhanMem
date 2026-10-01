using System;

namespace DPM235407_NguyenTuanAnh_BaiTap03_02_MovingFeatures._03_Hide_Delegate_Remove_MiddleMan
{
    // =========================================================================
    // BEFORE: Code Smell "Message Chains" (Chuỗi gọi phương thức quá dài / Vi phạm Law of Demeter)
    // Client phải gọi liên tục qua nhiều tầng đối tượng:
    // `nhanVien.PhongBan.TruongPhong.TenNguoiQuanLy`
    // Client bị phụ thuộc quá chặt vào cấu trúc quan hệ bên trong của các đối tượng.
    // =========================================================================
    public class NguoiQuanLy_Before
    {
        public string TenNguoiQuanLy { get; set; } = "Kỹ sư Trần Văn Hùng";
    }

    public class PhongBan_Before
    {
        public string TenPhongBan { get; set; } = "Phòng Kinh Doanh & Bảo Vệ Thực Vật";
        public NguoiQuanLy_Before TruongPhong { get; set; } = new();
    }

    public class NhanVien_Before
    {
        public string TenNhanVien { get; set; } = "Nguyễn Tuấn Anh";
        public PhongBan_Before PhongBan { get; set; } = new();
    }

    public class ClientGoiDichVu_Before
    {
        public void InThongTinQuanLy(NhanVien_Before nv)
        {
            // Vi phạm Law of Demeter: Client phải hiểu sâu cấu trúc PhongBan -> TruongPhong -> Ten
            string tenSep = nv.PhongBan.TruongPhong.TenNguoiQuanLy;
            Console.WriteLine($"[BEFORE] Trưởng phòng trực tiếp của {nv.TenNhanVien} là: {tenSep}");
        }
    }
}
