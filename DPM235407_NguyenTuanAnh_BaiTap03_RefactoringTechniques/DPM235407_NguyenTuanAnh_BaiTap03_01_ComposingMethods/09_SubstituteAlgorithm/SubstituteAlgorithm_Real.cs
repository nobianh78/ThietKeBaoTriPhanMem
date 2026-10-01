using System.Collections.Generic;
using System.Linq;
namespace DPM235407_NguyenTuanAnh_BaiTap03_01_ComposingMethods._09_SubstituteAlgorithm
{
    // REAL: Thay thế thuật toán lọc thuốc bảo vệ thực vật hết hạn
    public class QuanLyThuocHetHan_Real
    {
        public List<string> LocThuocHetHan(Dictionary<string, int> danhSachThuocVaSoNgayCon)
            => danhSachThuocVaSoNgayCon.Where(kvp => kvp.Value <= 0).Select(kvp => kvp.Key).ToList();
    }
}
