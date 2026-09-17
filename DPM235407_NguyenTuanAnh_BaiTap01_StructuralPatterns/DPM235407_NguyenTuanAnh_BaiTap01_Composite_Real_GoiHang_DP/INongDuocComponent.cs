namespace DPM235407_NguyenTuanAnh_BaiTap01_Composite_Real_GoiHang_DP
{
    // [Composite Component Interface]
    // Giao diện chung cho cả sản phẩm nông dược đơn lẻ và gói combo khuyến mãi
    public interface INongDuocComponent
    {
        string Ten { get; }
        decimal TinhTongTien();
        void HienThiChiTiet(int depth);
        void Add(INongDuocComponent item);
        void Remove(INongDuocComponent item);
        bool IsComposite();
    }
}
