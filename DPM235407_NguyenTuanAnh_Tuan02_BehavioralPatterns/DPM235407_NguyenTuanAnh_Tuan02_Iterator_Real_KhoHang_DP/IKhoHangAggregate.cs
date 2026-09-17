using System.Collections.Generic;

namespace DPM235407_NguyenTuanAnh_Tuan02_Iterator_Real_KhoHang_DP
{
    public enum KieuXuatKho
    {
        HetHanTruocXuatTruoc_FEFO, // Hệ thống tự động phân lô theo HSD gần nhất xuất trước
        NhapTruocXuatTruoc_FIFO,   // Lô nào nhập trước thì xuất trước
        XuatTheoChiDinh            // Người dùng chủ động chỉ định mã lô cụ thể
    }

    public interface IKhoHangAggregate
    {
        IKhoHangIterator TaoIterator(KieuXuatKho kieu, List<string>? danhSachChiDinh = null);
    }
}
