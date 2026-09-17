using System;

namespace DPM235407_NguyenTuanAnh_BaiTap01_Adapter_Real_VanChuyen_DP
{
    // Adaptee 1: SDK/API của đơn vị Giao Hàng Nhanh (giao diện không tương thích)
    public class GiaoHangNhanhApi
    {
        public double CalculateExpressFee(string destinationProvince, double totalWeightKg)
        {
            // Logic tính cước riêng của GHN: 20.000đ cơ bản + 5.000đ/kg
            double cuocCoBan = 20000;
            if (destinationProvince.Contains("An Giang", StringComparison.OrdinalIgnoreCase))
            {
                cuocCoBan = 15000; // Ưu đãi nội tỉnh An Giang
            }
            return cuocCoBan + (totalWeightKg * 5000);
        }
    }
}
