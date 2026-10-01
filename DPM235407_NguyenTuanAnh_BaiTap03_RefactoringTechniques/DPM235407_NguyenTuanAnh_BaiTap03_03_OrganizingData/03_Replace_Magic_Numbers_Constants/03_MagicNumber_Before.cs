using System;

namespace DPM235407_NguyenTuanAnh_BaiTap03_03_OrganizingData._03_Replace_Magic_Numbers_Constants
{
    // =========================================================================
    // BEFORE: Sử dụng "Số Ma Thuật" (Magic Numbers) rải rác trong code.
    // Người bảo trì không hiểu các con số 0.1, 0.05, 15, 30 mang ý nghĩa gì.
    // Khi chính sách thay đổi, việc sửa đổi thủ công rất dễ sót và gây lỗi.
    // =========================================================================
    public class KiemTraKhoVaGia_Before
    {
        public void KiemTraTonKho(int tonKho, int soNgayConLai)
        {
            // Magic Number 15: Tồn kho an toàn tối thiểu
            if (tonKho <= 15)
            {
                Console.WriteLine("[BEFORE] CẢNH BÁO: Tồn kho nguy hiểm (<= 15)!");
            }

            // Magic Number 30: Số ngày cận hạn sử dụng
            if (soNgayConLai <= 30)
            {
                Console.WriteLine("[BEFORE] CẢNH BÁO: Thuốc cận date (<= 30 ngày)!");
            }
        }

        public double TinhTienHoaDon(double tienHang, int capDaiLy)
        {
            double chietKhau = 0;
            if (capDaiLy == 1)
            {
                chietKhau = tienHang * 0.12; // Magic Number 0.12
            }
            else if (capDaiLy == 2)
            {
                chietKhau = tienHang * 0.07; // Magic Number 0.07
            }

            double sauGiam = tienHang - chietKhau;
            double vat = sauGiam * 0.05; // Magic Number 0.05

            return sauGiam + vat;
        }
    }
}
