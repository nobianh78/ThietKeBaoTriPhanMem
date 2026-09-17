namespace DPM235407_NguyenTuanAnh_Tuan02_Mediator_Real_DieuPhoi_DP
{
    // Lớp cơ sở cho các phòng ban trong công ty nông dược
    public abstract class BoPhanBase
    {
        protected ITrungTamDieuPhoi? TrungTamDieuPhoi;

        public void GanDieuPhoi(ITrungTamDieuPhoi dieuPhoi)
        {
            TrungTamDieuPhoi = dieuPhoi;
        }
    }
}
