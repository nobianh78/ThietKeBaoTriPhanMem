using System;
using System.Collections.Generic;
using System.Text;

namespace DPM235407_NguyenTuanAnh_BaiTap01_Bridge_Real_GiaXuat_DP
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.WriteLine("================================================================================");
            Console.WriteLine(" CÔNG TY NÔNG DƯỢC AN GIANG - QUẢN LÝ XUẤT KHO VÀ BÁN HÀNG SỈ / LẺ");
            Console.WriteLine(" MẪU THIẾT KẾ BRIDGE: TÁCH HÌNH THỨC BÁN HÀNG VÀ PHƯƠNG PHÁP TÍNH GIÁ KHO");
            Console.WriteLine("================================================================================\n");

            // Giả lập dữ liệu tồn kho thuốc trừ sâu Tilt Super 300EC gồm 2 lô nhập với đơn giá khác nhau
            var khoTiltSuper = new List<LoHang>
            {
                new LoHang("LO-001", "Tilt Super 300EC", soLuong: 100, donGia: 120000m, hsd: new DateTime(2027, 6, 1)),
                new LoHang("LO-002", "Tilt Super 300EC", soLuong: 200, donGia: 135000m, hsd: new DateTime(2027, 12, 1))
            };

            var phuongPhapBinhQuan = new TinhGiaBinhQuanGiaQuyen();
            var phuongPhapFIFO = new TinhGiaFIFO();

            // Kịch bản 1: Bán lẻ cho nông dân - Áp dụng tính giá kho FIFO
            HinhThucBanHang banLe = new BanHangLe(phuongPhapFIFO);
            banLe.ThucHienBanHang("Chú Năm Nông Dân (Thoại Sơn)", "Tilt Super 300EC", 20, khoTiltSuper);

            // Kịch bản 2: Bán sỉ cho đại lý - Áp dụng tính giá kho Bình quân gia quyền
            HinhThucBanHang banSi = new BanHangSi(phuongPhapBinhQuan);
            banSi.ThucHienBanHang("HTX Nông Nghiệp Vĩnh Bình", "Tilt Super 300EC", 150, khoTiltSuper);

            // Kịch bản 3: Linh hoạt chuyển cấu hình đại lý sang phương pháp FIFO mà không cần viết lại lớp mới
            Console.WriteLine("--- Thay đổi cấu hình cửa hàng: Bán sỉ chuyển sang tính giá FIFO ---");
            banSi.ThayDoiPhuongPhap(phuongPhapFIFO);
            banSi.ThucHienBanHang("HTX Nông Nghiệp Vĩnh Bình", "Tilt Super 300EC", 150, khoTiltSuper);
        }
    }
}
