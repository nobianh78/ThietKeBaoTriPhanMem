namespace DPM235407_NguyenTuanAnh_Tuan02_Visitor_Real_ThongKe_DP
{
    // Visitor Interface
    public interface IBaoCaoVisitor
    {
        void VisitHoaDon(HoaDonBanHangElement hoaDon);
        void VisitLoHangTonKho(LoHangTonKhoElement loHang);
        void VisitDichVuPhatSinh(DichVuPhatSinhElement dichVu);
        void InKetQuaBaoCao();
    }
}
