using System;
using System.Collections.Generic;

namespace DPM235407_NguyenTuanAnh_BaiTap01_Proxy_Real_BaoCao_DP
{
    // [Protection & Logging & Caching Proxy]: Kiểm soát phân quyền và nhật ký truy cập
    public class BaoCaoThongKeProxy : IBaoCaoThongKeService
    {
        private readonly BaoCaoThongKeThucTeService _realService;
        private readonly HashSet<string> _cacheBaoCao = new();

        public BaoCaoThongKeProxy(BaoCaoThongKeThucTeService realService)
        {
            _realService = realService;
        }

        public void XemBaoCaoDoanhThuVaKhuyenMai(NguoiDung user, DateTime tuNgay, DateTime denNgay)
        {
            GhiNhatKy(user, "Báo Cáo Doanh Thu & Khuyến Mãi", tuNgay, denNgay);

            string cacheKey = $"DoanhThu_{user.MaNV}_{tuNgay:yyyyMMdd}_{denNgay:yyyyMMdd}";
            if (_cacheBaoCao.Contains(cacheKey))
            {
                Console.WriteLine($"[Proxy Cache] -> Trả về kết quả nhanh từ bộ đệm (không cần truy vấn lại CSDL).");
            }
            else
            {
                _realService.XemBaoCaoDoanhThuVaKhuyenMai(user, tuNgay, denNgay);
                _cacheBaoCao.Add(cacheKey);
            }
        }

        public void XemBaoCaoTonKhoVaChiPhi(NguoiDung user, DateTime tuNgay, DateTime denNgay)
        {
            GhiNhatKy(user, "Báo Cáo Tồn Kho & Chi Phí Phụ", tuNgay, denNgay);

            // [Protection Proxy]: Kiểm tra phân quyền truy cập
            if (user.VaiTro != "QuanLy")
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"\n[CẢNH BÁO BẢO MẬT - TRUY CẬP BỊ TỪ CHỐI]");
                Console.WriteLine($"Nhân viên '{user.HoTen}' (Vai trò: {user.VaiTro}) KHÔNG có quyền xem Báo cáo Tồn kho & Chi phí mật của công ty!");
                Console.WriteLine("Yêu cầu quyền Quản lý (QuanLy) để truy cập tính năng này.");
                Console.ResetColor();
                return;
            }

            _realService.XemBaoCaoTonKhoVaChiPhi(user, tuNgay, denNgay);
        }

        private void GhiNhatKy(NguoiDung user, string tenBaoCao, DateTime tuNgay, DateTime denNgay)
        {
            Console.WriteLine($"[Proxy Audit Log] [{DateTime.Now:dd/MM/yyyy HH:mm:ss}] Người dùng: {user.HoTen} ({user.MaNV}) yêu cầu xem '{tenBaoCao}' (Từ {tuNgay:dd/MM/yyyy} đến {denNgay:dd/MM/yyyy})");
        }
    }
}
