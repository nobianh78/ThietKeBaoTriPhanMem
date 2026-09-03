using System;
using System.Collections.Generic;

namespace DPM235407_NguyenTuanAnh_Tuan01_Builder_Real_HoaDon_DP
{
    // Product: Hóa đơn
    public class HoaDonBanHang
    {
        private List<string> _thanhPhan = new List<string>();

        public void Add(string phan)
        {
            _thanhPhan.Add(phan);
        }

        public string HienThiHoaDon()
        {
            string str = "Chi tiết hóa đơn:\n";
            foreach (var item in _thanhPhan)
            {
                str += " - " + item + "\n";
            }
            return str;
        }
    }
}
