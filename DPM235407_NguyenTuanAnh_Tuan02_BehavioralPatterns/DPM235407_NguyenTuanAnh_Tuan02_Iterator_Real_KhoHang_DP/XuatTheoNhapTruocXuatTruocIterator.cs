using System.Collections.Generic;
using System.Linq;

namespace DPM235407_NguyenTuanAnh_Tuan02_Iterator_Real_KhoHang_DP
{
    // Iterator duyệt theo ngày nhập trước xuất trước (FIFO)
    public class XuatTheoNhapTruocXuatTruocIterator : IKhoHangIterator
    {
        private readonly List<LoHangNongDuoc> _danhSachSapXep;
        private int _viTri = 0;

        public XuatTheoNhapTruocXuatTruocIterator(List<LoHangNongDuoc> danhSachGoc)
        {
            _danhSachSapXep = danhSachGoc.OrderBy(l => l.NgayNhapKho).ToList();
        }

        public bool HasNext() => _viTri < _danhSachSapXep.Count;

        public LoHangNongDuoc? Next()
        {
            if (HasNext())
            {
                var item = _danhSachSapXep[_viTri];
                _viTri++;
                return item;
            }
            return null;
        }

        public LoHangNongDuoc? CurrentItem() => (_viTri < _danhSachSapXep.Count) ? _danhSachSapXep[_viTri] : null;

        public void Reset() => _viTri = 0;
    }
}
