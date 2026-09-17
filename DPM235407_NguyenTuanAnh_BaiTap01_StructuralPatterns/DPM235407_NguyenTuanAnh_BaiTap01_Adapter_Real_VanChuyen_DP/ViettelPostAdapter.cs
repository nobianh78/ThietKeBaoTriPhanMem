namespace DPM235407_NguyenTuanAnh_BaiTap01_Adapter_Real_VanChuyen_DP
{
    // Adapter 2: Chuyển đổi ViettelPostApi sang chuẩn IDichVuVanChuyen
    public class ViettelPostAdapter : IDichVuVanChuyen
    {
        private readonly ViettelPostApi _viettelApi;

        public ViettelPostAdapter(ViettelPostApi viettelApi)
        {
            _viettelApi = viettelApi;
        }

        public string LayTenDoiTac()
        {
            return "Viettel Post (Bưu chính Viettel)";
        }

        public decimal TinhPhiVanChuyen(DonHangNongDuoc donHang)
        {
            // Tự động bật bảo hiểm hàng hóa nếu đơn hàng nông dược giá trị > 1.000.000đ
            bool coBaoHiem = donHang.GiaTriDonHang > 1000000m;
            long fee = _viettelApi.TraCuuGiaCuocNongNghiep(donHang.DiaChiNhanHang, (float)donHang.TrongLuongKg, coBaoHiem);
            return (decimal)fee;
        }
    }
}
