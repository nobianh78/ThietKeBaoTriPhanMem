namespace DPM235407_NguyenTuanAnh_Tuan02_ChainOfResponsibility_Real_XacThuc_DP
{
    // Lớp chứa dữ liệu yêu cầu đăng nhập và truy cập chức năng
    public class YeuCauTruyCap
    {
        public string TenDangNhap { get; set; }
        public string MatKhau { get; set; }
        public string ChucNangCanThucHien { get; set; }
        public string VaiTro { get; set; } = string.Empty;
        public bool DaKhoa { get; set; } = false;

        public YeuCauTruyCap(string tenDangNhap, string matKhau, string chucNang)
        {
            TenDangNhap = tenDangNhap;
            MatKhau = matKhau;
            ChucNangCanThucHien = chucNang;
        }
    }
}
