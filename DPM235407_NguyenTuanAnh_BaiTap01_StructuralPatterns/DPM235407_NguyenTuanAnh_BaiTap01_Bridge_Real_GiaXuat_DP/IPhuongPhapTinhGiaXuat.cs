using System.Collections.Generic;

namespace DPM235407_NguyenTuanAnh_BaiTap01_Bridge_Real_GiaXuat_DP
{
    // [Bridge Implementation Interface]
    // Định nghĩa phương pháp tính giá vốn xuất kho theo yêu cầu PDF
    public interface IPhuongPhapTinhGiaXuat
    {
        string LayTenPhuongPhap();
        decimal TinhGiaVonXuatKho(List<LoHang> cacLo, int soLuongXuat);
    }
}
