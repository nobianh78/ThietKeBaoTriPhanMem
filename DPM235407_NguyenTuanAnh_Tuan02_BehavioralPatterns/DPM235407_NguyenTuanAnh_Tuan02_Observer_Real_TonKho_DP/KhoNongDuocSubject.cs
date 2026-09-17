using System;
using System.Collections.Generic;

namespace DPM235407_NguyenTuanAnh_Tuan02_Observer_Real_TonKho_DP
{
    // Dữ liệu lô hàng nội bộ
    public class LoHangInfo
    {
        public string MaLo { get; set; }
        public string TenThuoc { get; set; }
        public int SoLuongTon { get; set; }
        public DateTime NgayHetHan { get; set; }

        public LoHangInfo(string maLo, string tenThuoc, int soLuongTon, DateTime ngayHetHan)
        {
            MaLo = maLo;
            TenThuoc = tenThuoc;
            SoLuongTon = soLuongTon;
            NgayHetHan = ngayHetHan;
        }
    }

    // Subject: Quản lý biến động kho hàng Nông Dược An Giang
    public class KhoNongDuocSubject
    {
        private readonly List<IKhoHangObserver> _observers = new();
        private readonly List<LoHangInfo> _danhSachLo = new();

        public void DangKy(IKhoHangObserver observer)
        {
            _observers.Add(observer);
            Console.WriteLine($"[HỆ THỐNG] Đã đăng ký nhận thông báo cho bộ phận: {observer.TenBoPhan}");
        }

        public void HuyDangKy(IKhoHangObserver observer)
        {
            _observers.Remove(observer);
            Console.WriteLine($"[HỆ THỐNG] Đã hủy đăng ký nhận thông báo cho: {observer.TenBoPhan}");
        }

        private void ThongBao(ThongTinCanhBaoKho canhBao)
        {
            Console.WriteLine($"\n>>> [BẮN THÔNG BÁO TỰ ĐỘNG LÚC {canhBao.ThoiGian:HH:mm:ss}] <<<");
            foreach (var obs in _observers)
            {
                obs.CapNhat(canhBao);
            }
        }

        public void ThemLoHang(LoHangInfo lo) => _danhSachLo.Add(lo);

        // Xuất kho bán hàng - Nếu tồn dưới 15 thì bắn cảnh báo
        public void XuatKho(string maLo, int soLuong)
        {
            var lo = _danhSachLo.Find(l => l.MaLo == maLo);
            if (lo == null) return;

            lo.SoLuongTon -= soLuong;
            Console.WriteLine($"\n[KHO HÀNG] Đã xuất {soLuong} chai '{lo.TenThuoc}' từ lô {lo.MaLo}. Tồn kho còn: {lo.SoLuongTon}");

            if (lo.SoLuongTon <= 15)
            {
                var cb = new ThongTinCanhBaoKho(
                    LoaiCanhBao.TonKhoDuoiMucAnToan,
                    lo.MaLo,
                    lo.TenThuoc,
                    $"Lô {lo.MaLo} - Thuốc '{lo.TenThuoc}' chỉ còn {lo.SoLuongTon} sản phẩm (Dưới ngưỡng an toàn 15)!"
                );
                ThongBao(cb);
            }
        }

        // Quét hạn sử dụng - Nếu HSD < 30 ngày so với hiện tại
        public void QuetKiemTraHanSuDung()
        {
            Console.WriteLine("\n[HỆ THỐNG] Đang chạy tác vụ tự động quét hạn sử dụng các lô thuốc BVTV...");
            DateTime homNay = DateTime.Now;

            foreach (var lo in _danhSachLo)
            {
                int soNgayConLai = (lo.NgayHetHan - homNay).Days;
                if (soNgayConLai <= 30)
                {
                    var cb = new ThongTinCanhBaoKho(
                        LoaiCanhBao.ThuocCanHanSuDung,
                        lo.MaLo,
                        lo.TenThuoc,
                        $"Lô {lo.MaLo} - Thuốc '{lo.TenThuoc}' cận hạn sử dụng! Chỉ còn {soNgayConLai} ngày (HSD: {lo.NgayHetHan:dd/MM/yyyy})!"
                    );
                    ThongBao(cb);
                }
            }
        }

        // Phát động chương trình khuyến mãi giảm giá
        public void PhatDongKhuyenMai(string tenChuongTrinh, decimal phanTramGiam)
        {
            var cb = new ThongTinCanhBaoKho(
                LoaiCanhBao.KhuyenMaiGiaMoi,
                "ALL-PROMO",
                "Toàn bộ thuốc nông dược vụ Đông Xuân",
                $"Công ty phát động chiến dịch: '{tenChuongTrinh}' - Giảm ngay {phanTramGiam}% trên mỗi hóa đơn!"
            );
            ThongBao(cb);
        }
    }
}
