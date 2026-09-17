namespace DPM235407_NguyenTuanAnh_Tuan02_Visitor_Real_ThongKe_DP
{
    // Interface Element nhận Visitor
    public interface IDoiTuongDuLieuElement
    {
        void Accept(IBaoCaoVisitor visitor);
    }
}
