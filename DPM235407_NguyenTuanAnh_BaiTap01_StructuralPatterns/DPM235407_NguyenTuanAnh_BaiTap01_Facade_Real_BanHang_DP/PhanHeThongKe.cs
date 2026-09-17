using System;
using System.Collections.Generic;

namespace DPM235407_NguyenTuanAnh_BaiTap01_Facade_Real_BanHang_DP
{
    // [Subsystem 4]: Phân hệ lưu vết giao dịch phục vụ thống kê theo nhân viên (mục 4 PDF)
    public class PhanHeThongKe
    {
        private readonly List<string> _nhatKyGiaoDich = new List<string>();

        public void GhiNhanHoaDon(string maNV, string maHD, decimal tongTien, decimal giamGia)
        {
            string banGhi = $"[{DateTime.Now:dd/MM/yyyy HH:mm}] NV: {maNV} | HĐ: {maHD} | Tổng: {tongTien:N0} VNĐ | Giảm: {giamGia:N0} VNĐ";
            _nhatKyGiaoDich.Add(banGhi);
            Console.WriteLine($"[Thống Kê] Đã lưu giao dịch vào sổ bán hàng phục vụ báo cáo doanh số.");
        }
    }
}
