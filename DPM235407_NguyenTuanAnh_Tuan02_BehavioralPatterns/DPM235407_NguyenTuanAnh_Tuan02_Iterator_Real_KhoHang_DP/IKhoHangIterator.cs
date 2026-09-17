namespace DPM235407_NguyenTuanAnh_Tuan02_Iterator_Real_KhoHang_DP
{
    // Interface Iterator duyệt lô hàng
    public interface IKhoHangIterator
    {
        bool HasNext();
        LoHangNongDuoc? Next();
        LoHangNongDuoc? CurrentItem();
        void Reset();
    }
}
