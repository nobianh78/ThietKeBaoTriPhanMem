using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPM235407_NguyenTuanAnh_Tuan01_Abstract_Real_BaoCao_DP
{
    // Concrete Product (Dành cho Quản lý)
    class BaoCaoTonKhoQuanLy : IBaoCaoTonKho
    {
        public string XuatBaoCaoTonKho() => "Báo cáo tồn kho (View Quản lý): Hiển thị chi tiết giá vốn bình quân gia quyền và toàn bộ kho.";
    }
}