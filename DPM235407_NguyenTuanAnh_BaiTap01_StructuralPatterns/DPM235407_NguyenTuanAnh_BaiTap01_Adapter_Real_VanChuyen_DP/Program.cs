using System;
using System.Text;

namespace DPM235407_NguyenTuanAnh_BaiTap01_Adapter_Real_VanChuyen_DP
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.WriteLine("================================================================================");
            Console.WriteLine(" CÔNG TY NÔNG DƯỢC AN GIANG - HỆ THỐNG QUẢN LÝ BÁN HÀNG");
            Console.WriteLine(" MẪU THIẾT KẾ ADAPTER: TÍCH HỢP TÍNH CƯỚC VẬN CHUYỂN ĐỐI TÁC");
            Console.WriteLine("================================================================================\n");

            // Tạo đơn hàng nông dược thực tế
            var donHang1 = new DonHangNongDuoc(
                maDon: "DH-AG-2026-001",
                khachHang: "Đại lý VTNN Út Mười",
                diaChi: "Huyện Tri Tôn, Tỉnh An Giang",
                trongLuong: 45.5, // 45.5 kg phân bón & thuốc sâu
                giaTri: 3500000m
            );

            Console.WriteLine($"Đơn hàng: {donHang1.MaDonHang} | Khách hàng: {donHang1.TenKhachHang}");
            Console.WriteLine($"Nơi nhận: {donHang1.DiaChiNhanHang} | Khối lượng: {donHang1.TrongLuongKg} kg");
            Console.WriteLine($"Giá trị hàng: {donHang1.GiaTriDonHang:N0} VNĐ\n");

            // Tích hợp đơn vị 1: Giao Hàng Nhanh qua Adapter
            IDichVuVanChuyen ghnDichVu = new GiaoHangNhanhAdapter(new GiaoHangNhanhApi());
            decimal phiGHN = ghnDichVu.TinhPhiVanChuyen(donHang1);
            Console.WriteLine($"[1] Cước qua {ghnDichVu.LayTenDoiTac()}: {phiGHN:N0} VNĐ");

            // Tích hợp đơn vị 2: Viettel Post qua Adapter
            IDichVuVanChuyen viettelDichVu = new ViettelPostAdapter(new ViettelPostApi());
            decimal phiViettel = viettelDichVu.TinhPhiVanChuyen(donHang1);
            Console.WriteLine($"[2] Cước qua {viettelDichVu.LayTenDoiTac()}: {phiViettel:N0} VNĐ");

            Console.WriteLine("\n--> Hệ thống tính cước vận chuyển tự động áp dụng vào Hóa đơn bán hàng");
            Console.WriteLine("    mà không cần chỉnh sửa mã nguồn cốt lõi của công ty nông dược!");
        }
    }
}
