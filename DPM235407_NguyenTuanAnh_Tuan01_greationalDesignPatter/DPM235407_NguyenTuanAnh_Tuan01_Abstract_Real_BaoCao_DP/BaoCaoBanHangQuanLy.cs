using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPM235407_NguyenTuanAnh_Tuan01_Abstract_Real_BaoCao_DP
{
    // Concrete Product (Dành cho Quản lý)
    class BaoCaoBanHangQuanLy : IBaoCaoBanHang
    {
        public string XuatBaoCaoGiamGia() => "Báo cáo bán hàng (View Quản lý): Thống kê tổng chi phí khuyến mãi của TẤT CẢ nhân viên.";
    }
}
