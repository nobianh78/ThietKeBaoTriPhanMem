namespace DPM235407_NguyenTuanAnh_Tuan02_ChainOfResponsibility_Real_XacThuc_DP
{
    // Interface khai báo bước xử lý xác thực
    public interface IXacThucHandler
    {
        IXacThucHandler SetNext(IXacThucHandler handler);
        bool XuLy(YeuCauTruyCap yeuCau);
    }
}
