using System.Collections.Generic;

namespace DPM235407_NguyenTuanAnh_Tuan02_Strategy_Real_GiaXuat_DP
{
    // Strategy Interface: Định nghĩa thuật toán tính giá xuất sản phẩm
    public interface ITinhGiaXuatStrategy
    {
        string TenPhuongPhap { get; }
        KetQuaTinhGiaXuat TinhGiaXuat(List<LoThuocNhap> danhSachLo, int soLuongCanXuat);
    }
}
