using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System;

namespace DPM235407_NguyenTuanAnh_Tuan01_Abstract_Real_BaoCao_DP
{
    // Client
    class HeThongThongKe
    {
        private IBaoCaoTonKho _baoCaoTonKho;
        private IBaoCaoBanHang _baoCaoBanHang;

        public HeThongThongKe(IBaoCaoFactory factory)
        {
            _baoCaoTonKho = factory.TaoBaoCaoTonKho();
            _baoCaoBanHang = factory.TaoBaoCaoBanHang();
        }

        public void InBaoCao()
        {
            Console.WriteLine(_baoCaoTonKho.XuatBaoCaoTonKho());
            Console.WriteLine(_baoCaoBanHang.XuatBaoCaoGiamGia());
        }
    }
}