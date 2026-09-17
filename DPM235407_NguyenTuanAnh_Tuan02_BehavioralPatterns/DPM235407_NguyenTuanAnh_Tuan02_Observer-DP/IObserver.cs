namespace DPM235407_NguyenTuanAnh_Tuan02_Observer_DP
{
    public interface IObserver
    {
        // Receive update from subject
        void Update(ISubject subject);
    }
}
