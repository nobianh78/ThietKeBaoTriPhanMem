namespace DPM235407_NguyenTuanAnh_BaiTap03_03_OrganizingData._04_SelfEncapsulateField
{
    // REAL: Self Encapsulate đơn giá phân bón hỗ trợ lớp con ghi đè chính sách chiết khấu
    public class PhanBon_Real
    {
        private decimal _giaNiemYet = 350000;
        public virtual decimal GiaBan => _giaNiemYet;
        public decimal TinhThanhTien(int soBao) => GiaBan * soBao;
    }
    public class PhanBonTroGia_Real : PhanBon_Real
    {
        public override decimal GiaBan => base.GiaBan - 30000; // Trợ giá 30k
    }
}
