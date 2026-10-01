using System;

namespace DPM235407_NguyenTuanAnh_BaiTap03_01_ComposingMethods._03_Split_Temp_Remove_Assignments
{
    // =========================================================================
    // AFTER: Áp dụng kỹ thuật:
    // 1. Split Temporary Variable (Tách biến tạm - mỗi biến chỉ giữ 1 trách nhiệm)
    // 2. Remove Assignments to Parameters (Không sửa đổi giá trị tham số truyền vào)
    // =========================================================================
    public class XuLyKho_After
    {
        // 1. Tách biến tạm rõ nghĩa, bất biến
        public void TinhToanKhoHang(double chieuDai, double chieuRong)
        {
            double chuViKho = 2 * (chieuDai + chieuRong);
            Console.WriteLine($"Chu vi nhà kho: {chuViKho} mét");

            double dienTichMatSan = chieuDai * chieuRong;
            Console.WriteLine($"Diện tích mặt sàn kho: {dienTichMatSan} mét vuông");

            const double donGiaThueMoiMetVuong = 150000;
            double chiPhiThueKho = dienTichMatSan * donGiaThueMoiMetVuong;
            Console.WriteLine($"Chi phí thuê kho: {chiPhiThueKho:N0} VNĐ");
        }

        // 2. Giữ nguyên giá trị tham số gốc, sử dụng biến cục bộ để tính toán
        public double TinhGiaChietKhau(in double donGiaGoc, in int soLuongDatHang, int namHopTac)
        {
            double donGiaSauGiam = donGiaGoc;
            int tongSoLuongGiaoThucTe = soLuongDatHang;

            if (soLuongDatHang > 100)
            {
                donGiaSauGiam *= 0.95; // Giảm 5%
            }
            if (namHopTac > 3)
            {
                donGiaSauGiam -= 5000; // Giảm thêm 5.000đ
            }
            if (soLuongDatHang > 500)
            {
                tongSoLuongGiaoThucTe += 10; // Tặng 10 chai khuyến mãi
            }

            return donGiaSauGiam * tongSoLuongGiaoThucTe;
        }
    }
}
