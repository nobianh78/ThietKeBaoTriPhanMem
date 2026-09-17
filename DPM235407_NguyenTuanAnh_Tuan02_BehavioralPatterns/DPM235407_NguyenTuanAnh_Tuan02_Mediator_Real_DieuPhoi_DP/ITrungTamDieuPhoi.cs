namespace DPM235407_NguyenTuanAnh_Tuan02_Mediator_Real_DieuPhoi_DP
{
    // Interface Trung tâm điều phối hệ thống bán hàng nông dược An Giang
    public interface ITrungTamDieuPhoi
    {
        void ThongBao(object nguonPhat, string suKien, object? duLieu = null);
    }
}
