using System.Collections.Generic;
namespace DPM235407_NguyenTuanAnh_BaiTap03_01_ComposingMethods._08_ReplaceMethodWithMethodObject
{
    // REAL: TinhGiaBinhQuanGiaQuyenCalculator (Mục 3 PDF Đồ án)
    public class TinhGiaBinhQuanGiaQuyenCalculator_Real
    {
        private readonly List<(int SL, decimal Gia)> _danhSachLo;
        private readonly decimal _chiPhiLuuKho;
        public TinhGiaBinhQuanGiaQuyenCalculator_Real(List<(int SL, decimal Gia)> danhSachLo, decimal chiPhiLuuKho)
        {
            _danhSachLo = danhSachLo; _chiPhiLuuKho = chiPhiLuuKho;
        }
        public decimal TinhDonGiaBQGQ()
        {
            decimal tongTien = _chiPhiLuuKho;
            int tongSL = 0;
            foreach (var lo in _danhSachLo) { tongTien += lo.SL * lo.Gia; tongSL += lo.SL; }
            return tongSL > 0 ? (tongTien / tongSL) : 0;
        }
    }
}
