using System;
using System.Collections.Generic;

namespace DPM235407_NguyenTuanAnh_BaiTap03_01_ComposingMethods._03_Split_Temp_Remove_Assignments
{
    // =========================================================================
    // REAL APPLICATION (Hệ thống Nông Dược An Giang):
    // Phân bổ thuốc bảo vệ thực vật theo lô HSD (FEFO) xuất bán cho đại lý.
    // Mã gốc: Tái sử dụng một biến `soLuong` trừ dần và làm biến đổi đối tượng đầu vào.
    // Sau khi Refactor: Tách biến phân bổ rõ ràng, bảo toàn trạng thái tham số gốc.
    // =========================================================================

    public class LoThuocNongDuoc
    {
        public string SoLo { get; set; } = string.Empty;
        public string TenThuoc { get; set; } = string.Empty;
        public int SoLuongTon { get; set; }
        public DateTime HanSuDung { get; set; }
    }

    public class KetQuaPhanBoLoXuat
    {
        public string SoLo { get; set; } = string.Empty;
        public int SoLuongXuat { get; set; }
        public DateTime HanSuDung { get; set; }
    }

    public class PhanBoKhoNongDuoc_Real
    {
        public List<KetQuaPhanBoLoXuat> PhanBoXuatKhoFEFO(in List<LoThuocNongDuoc> danhSachLoTon, in int soLuongCanXuat)
        {
            Console.WriteLine($"\n=== [THỰC TẾ] PHÂN BỔ XUẤT KHO THEO HẠN DÙNG (YÊU CẦU: {soLuongCanXuat} ĐƠN VỊ) ===");

            // 1. Tạo bản sao danh sách để sắp xếp theo hạn sử dụng tăng dần (FEFO)
            var loHangSorted = new List<LoThuocNongDuoc>(danhSachLoTon);
            loHangSorted.Sort((a, b) => a.HanSuDung.CompareTo(b.HanSuDung));

            var danhSachPhanBo = new List<KetQuaPhanBoLoXuat>();
            int soLuongConLaiCanDapUng = soLuongCanXuat; // Biến theo dõi riêng biệt

            foreach (var lo in loHangSorted)
            {
                if (soLuongConLaiCanDapUng <= 0) break;
                if (lo.SoLuongTon <= 0) continue;

                // Tách biến tạm tính số lượng lấy từ lô hiện tại
                int soLuongLayTuLo = Math.Min(lo.SoLuongTon, soLuongConLaiCanDapUng);

                danhSachPhanBo.Add(new KetQuaPhanBoLoXuat
                {
                    SoLo = lo.SoLo,
                    SoLuongXuat = soLuongLayTuLo,
                    HanSuDung = lo.HanSuDung
                });

                soLuongConLaiCanDapUng -= soLuongLayTuLo;
            }

            if (soLuongConLaiCanDapUng > 0)
            {
                Console.WriteLine($"⚠️ Cảnh báo: Kho không đủ hàng! Còn thiếu {soLuongConLaiCanDapUng} đơn vị.");
            }

            // In kết quả phiếu phân bổ lô
            Console.WriteLine("----------------------------------------------------------------");
            Console.WriteLine($"{"SỐ LÔ",-15} | {"HẠN SỬ DỤNG",-12} | {"SỐ LƯỢNG XUẤT",-15}");
            Console.WriteLine("----------------------------------------------------------------");
            foreach (var kq in danhSachPhanBo)
            {
                Console.WriteLine($"{kq.SoLo,-15} | {kq.HanSuDung,-12:dd/MM/yyyy} | {kq.SoLuongXuat,15} chai/gói");
            }
            Console.WriteLine("----------------------------------------------------------------\n");

            return danhSachPhanBo;
        }
    }
}
