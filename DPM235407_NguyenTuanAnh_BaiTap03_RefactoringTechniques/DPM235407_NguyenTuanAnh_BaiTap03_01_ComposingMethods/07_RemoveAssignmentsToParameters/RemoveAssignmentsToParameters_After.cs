namespace DPM235407_NguyenTuanAnh_BaiTap03_01_ComposingMethods._07_RemoveAssignmentsToParameters
{
    // AFTER: Remove Assignments to Parameters
    public class ChietKhau_After
    {
        public double TinhGia(in double donGiaGoc, in int soLuong)
        {
            double donGiaSauGiam = donGiaGoc;
            if (soLuong > 50) donGiaSauGiam *= 0.9;
            return donGiaSauGiam * soLuong;
        }
    }
}
