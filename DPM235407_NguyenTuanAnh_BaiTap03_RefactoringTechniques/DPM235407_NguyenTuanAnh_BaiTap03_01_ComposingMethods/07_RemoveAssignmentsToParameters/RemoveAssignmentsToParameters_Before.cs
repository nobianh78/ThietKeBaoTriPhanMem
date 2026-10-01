namespace DPM235407_NguyenTuanAnh_BaiTap03_01_ComposingMethods._07_RemoveAssignmentsToParameters
{
    // BEFORE: Gán đè trực tiếp lên tham số đầu vào
    public class ChietKhau_Before
    {
        public double TinhGia(double donGia, int soLuong)
        {
            if (soLuong > 50) donGia = donGia * 0.9;
            return donGia * soLuong;
        }
    }
}
