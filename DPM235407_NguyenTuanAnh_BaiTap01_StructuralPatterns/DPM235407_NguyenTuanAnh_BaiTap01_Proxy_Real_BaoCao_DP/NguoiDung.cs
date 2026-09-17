namespace DPM235407_NguyenTuanAnh_BaiTap01_Proxy_Real_BaoCao_DP
{
    // Thông tin người dùng đăng nhập hệ thống
    public class NguoiDung
    {
        public string MaNV { get; set; }
        public string HoTen { get; set; }
        public string VaiTro { get; set; } // "QuanLy" hoặc "NhanVienBanHang"

        public NguoiDung(string ma, string ten, string vaiTro)
        {
            MaNV = ma;
            HoTen = ten;
            VaiTro = vaiTro;
        }
    }
}
