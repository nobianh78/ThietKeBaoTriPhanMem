using System.Collections.Generic;
using System.Linq;

namespace DPM235407_NguyenTuanAnh_Tuan02_Iterator_Real_KhoHang_DP
{
    // Iterator duyệt theo chỉ định của người dùng
    public class XuatTheoChiDinhIterator : IKhoHangIterator
    {
        private readonly List<LoHangNongDuoc> _danhSachLoc;
        private int _viTri = 0;

        public XuatTheoChiDinhIterator(List<LoHangNongDuoc> danhSachGoc, List<string> danhSachMaLoChiDinh)
        {
            // Lọc ra đúng các lô mà người dùng đã chỉ định theo thứ tự ưu tiên
            _danhSachLoc = new List<LoHangNongDuoc>();
            foreach (var maLo in danhSachMaLoChiDinh)
            {
                var lo = danhSachGoc.FirstOrDefault(l => l.MaLo == maLo);
                if (lo != null)
                {
                    _danhSachLoc.Add(lo);
                }
            }
        }

        public bool HasNext() => _viTri < _danhSachLoc.Count;

        public LoHangNongDuoc? Next()
        {
            if (HasNext())
            {
                var item = _danhSachLoc[_viTri];
                _viTri++;
                return item;
            }
            return null;
        }

        public LoHangNongDuoc? CurrentItem() => (_viTri < _danhSachLoc.Count) ? _danhSachLoc[_viTri] : null;

        public void Reset() => _viTri = 0;
    }
}
