namespace DPM235407_NguyenTuanAnh_BaiTap03_03_OrganizingData._04_SelfEncapsulateField
{
    // AFTER: Truy cập trường qua Getter/Setter (Self Encapsulate)
    public class SanPham_After
    {
        private decimal _donGia = 100000;
        public virtual decimal DonGia { get => _donGia; set => _donGia = value; }
        public decimal TinhTien(int sl) => DonGia * sl;
    }
}
