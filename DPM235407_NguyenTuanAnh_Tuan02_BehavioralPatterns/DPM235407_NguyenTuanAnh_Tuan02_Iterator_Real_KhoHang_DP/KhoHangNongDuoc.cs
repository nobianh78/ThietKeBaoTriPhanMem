using System;
using System.Collections.Generic;

namespace DPM235407_NguyenTuanAnh_Tuan02_Iterator_Real_KhoHang_DP
{
    // Lớp Kho Hàng Aggregate
    public class KhoHangNongDuoc : IKhoHangAggregate
    {
        private readonly List<LoHangNongDuoc> _danhSachLo = new();

        public void NhapLoHang(LoHangNongDuoc lo)
        {
            _danhSachLo.Add(lo);
        }

        public IKhoHangIterator TaoIterator(KieuXuatKho kieu, List<string>? danhSachChiDinh = null)
        {
            return kieu switch
            {
                KieuXuatKho.HetHanTruocXuatTruoc_FEFO => new XuatTheoHanSuDungIterator(_danhSachLo),
                KieuXuatKho.NhapTruocXuatTruoc_FIFO => new XuatTheoNhapTruocXuatTruocIterator(_danhSachLo),
                KieuXuatKho.XuatTheoChiDinh => new XuatTheoChiDinhIterator(_danhSachLo, danhSachChiDinh ?? new List<string>()),
                _ => new XuatTheoHanSuDungIterator(_danhSachLo)
            };
        }

        // Xuất kho và in chi tiết phiếu xuất hiển thị rõ Số Lô & Ngày Hết Hạn theo đề bài
        public void XuatKhoPhanLo(string tenThuoc, int soLuongCanXuat, KieuXuatKho kieuCaiDat, List<string>? danhSachChiDinh = null)
        {
            Console.WriteLine($"\n>>> YÊU CẦU XUẤT KHO: [{tenThuoc}] - SỐ LƯỢNG CẦN XUẤT: {soLuongCanXuat} gói/chai");
            Console.WriteLine($"    Cấu hình phương thức: {kieuCaiDat}");

            var iterator = TaoIterator(kieuCaiDat, danhSachChiDinh);
            int soLuongConLai = soLuongCanXuat;

            Console.WriteLine("--------------------------------------------------------------------------------");
            Console.WriteLine(string.Format("{0,-12} {1,-26} {2,-13} {3,-13} {4,10}", "Số Lô", "Tên Thuốc", "Ngày Nhập", "Hạn Sử Dụng", "SL Xuất"));
            Console.WriteLine("--------------------------------------------------------------------------------");

            while (iterator.HasNext() && soLuongConLai > 0)
            {
                var lo = iterator.Next();
                if (lo == null || lo.TenThuoc != tenThuoc || lo.SoLuongTon <= 0)
                    continue;

                int slLay = Math.Min(lo.SoLuongTon, soLuongConLai);
                lo.SoLuongTon -= slLay;
                soLuongConLai -= slLay;

                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine(string.Format("{0,-12} {1,-26} {2,-13:dd/MM/yyyy} {3,-13:dd/MM/yyyy} {4,10}",
                    lo.MaLo, lo.TenThuoc, lo.NgayNhapKho, lo.NgayHetHan, $"{slLay}"));
                Console.ResetColor();
            }

            Console.WriteLine("--------------------------------------------------------------------------------");
            if (soLuongConLai == 0)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("   ===> XUẤT KHO THÀNH CÔNG ĐỦ SỐ LƯỢNG YÊU CẦU!");
                Console.ResetColor();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"   ===> CẢNH BÁO: Kho chỉ còn đủ xuất, thiếu {soLuongConLai} sản phẩm!");
                Console.ResetColor();
            }
        }
    }
}
