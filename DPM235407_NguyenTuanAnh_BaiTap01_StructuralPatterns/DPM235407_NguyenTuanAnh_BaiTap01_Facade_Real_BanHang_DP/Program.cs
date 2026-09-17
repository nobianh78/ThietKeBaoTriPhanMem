using System;
using System.Text;

namespace DPM235407_NguyenTuanAnh_BaiTap01_Facade_Real_BanHang_DP
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.WriteLine("================================================================================");
            Console.WriteLine(" CÔNG TY NÔNG DƯỢC AN GIANG - PHẦN MỀM QUẢN LÝ BÁN HÀNG");
            Console.WriteLine(" MẪU THIẾT KẾ FACADE: GIAO DIỆN ĐƠN GIẢN HÓA TOÀN BỘ QUY TRÌNH BÁN HÀNG");
            Console.WriteLine("================================================================================\n");

            // Client chỉ cần khởi tạo 1 đối tượng Facade duy nhất
            BanHangFacade banHangFacade = new BanHangFacade();

            // Thực hiện giao dịch bán 70 chai thuốc trừ sâu (tự động phân bổ 2 lô, tính phụ phí và giảm giá)
            banHangFacade.LapDonHangNongDuoc(
                maNV: "NV01",
                matKhau: "123456",
                tenKhachHang: "Đại lý Nông Dược Tân Châu",
                tenThuoc: "Thuốc trừ sâu sinh học Takare",
                soLuong: 70,
                donGia: 85000m,
                phiVanChuyen: 40000m,
                phiDichVuPhu: 20000m,
                giamGia: 50000m
            );
        }
    }
}
