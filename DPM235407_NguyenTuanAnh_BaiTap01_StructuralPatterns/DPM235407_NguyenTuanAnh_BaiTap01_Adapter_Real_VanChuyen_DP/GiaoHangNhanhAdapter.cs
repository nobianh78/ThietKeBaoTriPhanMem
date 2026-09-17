namespace DPM235407_NguyenTuanAnh_BaiTap01_Adapter_Real_VanChuyen_DP
{
    // Adapter 1: Chuyển đổi GiaoHangNhanhApi sang chuẩn IDichVuVanChuyen
    public class GiaoHangNhanhAdapter : IDichVuVanChuyen
    {
        private readonly GiaoHangNhanhApi _ghnApi;

        public GiaoHangNhanhAdapter(GiaoHangNhanhApi ghnApi)
        {
            _ghnApi = ghnApi;
        }

        public string LayTenDoiTac()
        {
            return "Giao Hàng Nhanh (GHN Express)";
        }

        public decimal TinhPhiVanChuyen(DonHangNongDuoc donHang)
        {
            // Chuyển đổi tham số từ DonHangNongDuoc sang format mà GHN yêu cầu
            double fee = _ghnApi.CalculateExpressFee(donHang.DiaChiNhanHang, donHang.TrongLuongKg);
            return (decimal)fee;
        }
    }
}
