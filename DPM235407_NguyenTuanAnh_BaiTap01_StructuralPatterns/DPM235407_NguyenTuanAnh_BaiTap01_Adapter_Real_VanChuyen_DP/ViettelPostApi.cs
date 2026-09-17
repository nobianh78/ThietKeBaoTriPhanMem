using System;

namespace DPM235407_NguyenTuanAnh_BaiTap01_Adapter_Real_VanChuyen_DP
{
    // Adaptee 2: SDK/API của Viettel Post (giao diện và kiểu dữ liệu hoàn toàn khác)
    public class ViettelPostApi
    {
        public long TraCuuGiaCuocNongNghiep(string diaChiNhan, float trongLuongKg, bool coBaoHiem)
        {
            // Logic riêng của Viettel Post tính bằng kiểu long
            long giaCuoc = 18000 + (long)(trongLuongKg * 4500);
            if (coBaoHiem)
            {
                giaCuoc += 10000; // Bảo hiểm hàng nông dược dễ vỡ/chất lỏng
            }
            return giaCuoc;
        }
    }
}
