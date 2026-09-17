namespace DPM235407_NguyenTuanAnh_Tuan02_Command_Real_HoaDon_DP
{
    // Interface lệnh điều khiển thao tác trên hóa đơn
    public interface IHoaDonCommand
    {
        void Execute();
        void Undo();
        string GetMoTa();
    }
}
