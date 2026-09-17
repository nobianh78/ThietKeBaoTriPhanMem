namespace DPM235407_NguyenTuanAnh_Tuan02_Observer_Real_TonKho_DP
{
    public interface IKhoHangObserver
    {
        void CapNhat(ThongTinCanhBaoKho canhBao);
        string TenBoPhan { get; }
    }
}
