using System;

namespace DPM235407_NguyenTuanAnh_Tuan02_Visitor_Real_ThongKe_DP
{
    // Element 3: Dịch vụ phát sinh (phun thuốc mẫu, bốc vác hàng hóa)
    public class DichVuPhatSinhElement : IDoiTuongDuLieuElement
    {
        public string MaDichVu { get; set; }
        public string TenDichVu { get; set; }
        public DateTime NgayThucHien { get; set; }
        public string NhanVienPhuTrach { get; set; }
        public decimal ChiPhi { get; set; }

        public DichVuPhatSinhElement(string maDV, string tenDV, DateTime ngay, string nv, decimal chiPhi)
        {
            MaDichVu = maDV;
            TenDichVu = tenDV;
            NgayThucHien = ngay;
            NhanVienPhuTrach = nv;
            ChiPhi = chiPhi;
        }

        public void Accept(IBaoCaoVisitor visitor) => visitor.VisitDichVuPhatSinh(this);
    }
}
