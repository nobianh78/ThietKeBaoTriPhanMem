using System;
using System.Text;

namespace DPM235407_NguyenTuanAnh_BaiTap03_03_OrganizingData
{
    class Program
    {
        static void Main()
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.WriteLine("================================================================================");
            Console.WriteLine("   BÀI TẬP 03 - NHÓM 3: ORGANIZING DATA (ĐẦY ĐỦ 15 KỸ THUẬT)");
            Console.WriteLine("   Học viên: Nguyễn Tuấn Anh - MSSV: DPM235407 - Lớp: Cao học K24");
            Console.WriteLine("================================================================================\n");

            // 1. Change Value to Reference
            Console.WriteLine(">>> 1. CHANGE VALUE TO REFERENCE <<<");
            var lo = new _01_ChangeValueToReference.LoThuocThucThe_Real("LOT-2026-TIL", 200);
            lo.TruKho(50);
            Console.WriteLine($"[REAL] Lô {lo.MaLo} tồn kho còn lại: {lo.TonKho} chai\n");

            // 2. Change Reference to Value
            Console.WriteLine(">>> 2. CHANGE REFERENCE TO VALUE <<<");
            var toaDo = new _02_ChangeReferenceToValue.ToaDoRuong_Real(105.0124, 10.4289);
            Console.WriteLine($"[REAL] Tọa độ ruộng bất biến: {toaDo}\n");

            // 3. Duplicate Observed Data
            Console.WriteLine(">>> 3. DUPLICATE OBSERVED DATA <<<");
            var khoSub = new _03_DuplicateObservedData.TonKhoSubject_Real();
            khoSub.OnCanhBaoTonKho += (ma, ton) => Console.WriteLine($"[REAL OBSERVER] Cảnh báo: Thuốc {ma} chỉ còn {ton} đơn vị!");
            khoSub.CapNhatTon("Radiant 60SC", 12);

            // 4. Self Encapsulate Field
            Console.WriteLine("\n>>> 4. SELF ENCAPSULATE FIELD <<<");
            var pbTroGia = new _04_SelfEncapsulateField.PhanBonTroGia_Real();
            Console.WriteLine($"[REAL] Giá phân bón trợ giá (10 bao): {pbTroGia.TinhThanhTien(10):N0} VNĐ\n");

            // 5. Replace Data Value with Object
            Console.WriteLine(">>> 5. REPLACE DATA VALUE WITH OBJECT <<<");
            var mv = new _05_ReplaceDataValueWithObject.MaVachEAN13_Real("8935012345678");
            Console.WriteLine($"[REAL] Mã vạch thuốc BVTV: {mv}\n");

            // 6. Replace Array with Object
            Console.WriteLine(">>> 6. REPLACE ARRAY WITH OBJECT <<<");
            var loNhap = new _06_ReplaceArrayWithObject.LoHangNhapKho_Real();
            Console.WriteLine($"[REAL] Lô nhập: {loNhap.MaLo} - Thuốc: {loNhap.TenThuoc} - SL: {loNhap.SoLuong}\n");

            // 7. Change Unidirectional to Bidirectional
            Console.WriteLine(">>> 7. CHANGE UNIDIRECTIONAL TO BIDIRECTIONAL <<<");
            var phieuBan = new _07_ChangeUnidirectionalToBidirectional.PhieuBan_Real();
            var chiTiet = new _07_ChangeUnidirectionalToBidirectional.ChiTiet_Real();
            phieuBan.ThemChiTiet(chiTiet);
            Console.WriteLine($"[REAL] Chi tiết {chiTiet.TenThuoc} thuộc phiếu {chiTiet.PhieuBan?.MaPhieu}\n");

            // 8. Change Bidirectional to Unidirectional
            Console.WriteLine(">>> 8. CHANGE BIDIRECTIONAL TO UNIDIRECTIONAL <<<");
            var sp = new _08_ChangeBidirectionalToUnidirectional.SanPhamNongDuoc_Real();
            Console.WriteLine($"[REAL] Thuốc: {sp.TenThuoc} (ĐVT: {sp.DVT.TenDVT})\n");

            // 9. Encapsulate Field
            Console.WriteLine(">>> 9. ENCAPSULATE FIELD <<<");
            var tonKho = new _09_EncapsulateField.TonKho_Real { SoLuongTon = 85 };
            Console.WriteLine($"[REAL] Tồn kho đóng gói: {tonKho.SoLuongTon} chai\n");

            // 10. Encapsulate Collection
            Console.WriteLine(">>> 10. ENCAPSULATE COLLECTION <<<");
            var phieuLe = new _10_EncapsulateCollection.PhieuBanLeNongDuoc_Real();
            phieuLe.ThemThuoc("Tilt Super 300EC");
            phieuLe.ThemThuoc("Radiant 60SC");
            Console.WriteLine($"[REAL] Phiếu bán có {phieuLe.DanhSachThuoc.Count} mặt hàng an toàn.\n");

            // 11. Replace Magic Number with Symbolic Constant
            Console.WriteLine(">>> 11. REPLACE MAGIC NUMBER WITH SYMBOLIC CONSTANT <<<");
            Console.WriteLine($"[REAL] Ngưỡng cận date: {_11_ReplaceMagicNumberWithSymbolicConstant.QuyDinhNongDuoc_Real.SoNgayCanhBaoCanDate} ngày | CK Cấp 1: {_11_ReplaceMagicNumberWithSymbolicConstant.QuyDinhNongDuoc_Real.TiLeChietKhauDaiLyCap1 * 100}%\n");

            // 12. Replace Type Code with Class
            Console.WriteLine(">>> 12. REPLACE TYPE CODE WITH CLASS <<<");
            Console.WriteLine($"[REAL] Cấp: {_12_ReplaceTypeCodeWithClass.CapDaiLy_Real.Cap1.TenCap} | Chiết khấu: {_12_ReplaceTypeCodeWithClass.CapDaiLy_Real.Cap1.ChietKhau * 100}%\n");

            // 13. Replace Type Code with Subclasses
            Console.WriteLine(">>> 13. REPLACE TYPE CODE WITH SUBCLASSES <<<");
            _13_ReplaceTypeCodeWithSubclasses.NongDuoc_Real docCao = new _13_ReplaceTypeCodeWithSubclasses.ThuocTruSauDocCao_Real();
            Console.WriteLine($"[REAL] Thuốc sâu độc cao: Cách ly {docCao.ThoiGianCachLyNgay()} ngày trước thu hoạch\n");

            // 14. Replace Type Code with State/Strategy
            Console.WriteLine(">>> 14. REPLACE TYPE CODE WITH STATE/STRATEGY <<<");
            var kho = new _14_ReplaceTypeCodeWithStateStrategy.QuanLyKho_Real();
            Console.WriteLine($"[REAL] Giá xuất FIFO (gốc 100k): {kho.PhuongPhapTinh.TinhGia(100000):N0} đ");
            kho.PhuongPhapTinh = new _14_ReplaceTypeCodeWithStateStrategy.StrategyBQGQ();
            Console.WriteLine($"[REAL] Giá xuất BQGQ (gốc 100k): {kho.PhuongPhapTinh.TinhGia(100000):N0} đ\n");

            // 15. Replace Subclass with Fields
            Console.WriteLine(">>> 15. REPLACE SUBCLASS WITH FIELDS <<<");
            var qc = _15_ReplaceSubclassWithFields.QuyCachDongGoiNongDuoc_Real.ChaiNho();
            Console.WriteLine($"[REAL] {qc.TenQuyCach}: Dung tích {qc.DungTichMl}ml ({qc.SoChaiMoiThung} chai/thùng)");

            Console.WriteLine("\n================================================================================");
            Console.WriteLine("          HOÀN THÀNH 15/15 KỸ THUẬT ORGANIZING DATA!");
            Console.WriteLine("================================================================================");
        }
    }
}
