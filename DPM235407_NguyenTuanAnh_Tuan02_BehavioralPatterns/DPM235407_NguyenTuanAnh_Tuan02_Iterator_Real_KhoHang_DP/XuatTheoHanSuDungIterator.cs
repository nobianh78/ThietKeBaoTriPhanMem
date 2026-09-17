using System.Collections.Generic;
using System.Linq;

namespace DPM235407_NguyenTuanAnh_Tuan02_Iterator_Real_KhoHang_DP
{
    // Iterator duyệt theo ngày hết hạn trước xuất trước (FEFO)
    public class XuatTheoHanSuDungIterator : IKhoHangIterator
    {
        private readonly List<LoHangNongDuoc> _danhSachSapXep;
        private int _viTri = 0;

        public XuatTheoHanSuDungIterator(List<LoHangNongDuoc> danhSachLuu)
        {
            // Tự động sắp xếp các lô theo ngày hết hạn tăng dần (gần nhất lên đầu)
            _danhSachSapXep = danhSachLuu.OrderBy(l => l.NgayHetHan).ToList();
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
