using System;

namespace DPM235407_NguyenTuanAnh_BaiTap03_01_ComposingMethods._03_Split_Temp_Remove_Assignments
{
    // =========================================================================
    // BEFORE: Tái sử dụng biến tạm cho nhiều mục đích khác nhau (Reusing Temp)
    // và gán đè trực tiếp lên tham số truyền vào (Assignments to Parameters).
    // Dẫn đến lỗi khó phát hiện (Side Effects) và làm mất ý nghĩa biến.
    // =========================================================================
    public class XuLyKho_Before
    {
        // Biến tạm `temp` bị dùng đi dùng lại cho: chu vi, sau đó là diện tích, sau đó là chi phí
        public void TinhToanKhoHang(double chieuDai, double chieuRong)
        {
            double temp = 2 * (chieuDai + chieuRong);
            Console.WriteLine($"Chu vi nhà kho: {temp} mét");

            temp = chieuDai * chieuRong;
            Console.WriteLine($"Diện tích mặt sàn kho: {temp} mét vuông");

            temp = temp * 150000; // Đơn giá thuê 150.000đ/m2
            Console.WriteLine($"Chi phí thuê kho: {temp:N0} VNĐ");
        }

        // Gán đè trực tiếp lên tham số `donGia` và `soLuong`
        public double TinhGiaChietKhau(double donGia, int soLuong, int namHopTac)
        {
            if (soLuong > 100)
            {
                donGia = donGia * 0.95; // Giảm 5% đơn giá - Thay đổi trực tiếp tham số!
            }
            if (namHopTac > 3)
            {
                donGia = donGia - 5000; // Giảm thêm 5.000đ
            }
            if (soLuong > 500)
            {
                soLuong = soLuong + 10; // Tặng thêm 10 sản phẩm - Thay đổi tham số!
            }

            return donGia * soLuong;
        }
    }
}
