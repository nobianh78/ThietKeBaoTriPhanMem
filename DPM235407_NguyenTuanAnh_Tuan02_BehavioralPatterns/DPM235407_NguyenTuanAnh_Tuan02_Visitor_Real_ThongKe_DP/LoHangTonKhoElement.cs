using System;

namespace DPM235407_NguyenTuanAnh_Tuan02_Visitor_Real_ThongKe_DP
{
    // Element 2: Lô hàng tồn kho nông dược
    public class LoHangTonKhoElement : IDoiTuongDuLieuElement
    {
        public string MaLo { get; set; }
        public string TenThuoc { get; set; }
        public int SoLuongTon { get; set; }
        public decimal DonGiaVon { get; set; }
        public DateTime NgayHetHan { get; set; }

        public decimal GiaTriTonKho => SoLuongTon * DonGiaVon;

        public LoHangTonKhoElement(string maLo, string tenThuoc, int slTon, decimal giaVon, DateTime hsd)
        {
            MaLo = maLo;
            TenThuoc = tenThuoc;
            SoLuongTon = slTon;
            DonGiaVon = giaVon;
            NgayHetHan = hsd;
        }

        public void Accept(IBaoCaoVisitor visitor) => visitor.VisitLoHangTonKho(this);
    }
}
