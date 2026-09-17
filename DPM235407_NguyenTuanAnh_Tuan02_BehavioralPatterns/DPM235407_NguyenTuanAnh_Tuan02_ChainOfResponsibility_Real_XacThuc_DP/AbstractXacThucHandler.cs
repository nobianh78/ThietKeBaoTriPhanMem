namespace DPM235407_NguyenTuanAnh_Tuan02_ChainOfResponsibility_Real_XacThuc_DP
{
    // Lớp cơ sở cài đặt liên kết Handler
    public abstract class AbstractXacThucHandler : IXacThucHandler
    {
        protected IXacThucHandler? NextHandler;

        public IXacThucHandler SetNext(IXacThucHandler handler)
        {
            NextHandler = handler;
            return handler;
        }

        public virtual bool XuLy(YeuCauTruyCap yeuCau)
        {
            if (NextHandler != null)
            {
                return NextHandler.XuLy(yeuCau);
            }
            return true; // Kết thúc chuỗi an toàn
        }
    }
}
