namespace DPM235407_NguyenTuanAnh_BaiTap03_03_OrganizingData._14_ReplaceTypeCodeWithStateStrategy
{
    // REAL: Strategy tính giá xuất kho Nông Dược (Mục 3 PDF Đồ án: FIFO vs Bình quân gia quyền)
    public interface IStrategyGiaXuat { decimal TinhGia(decimal giaGoc); }
    public class StrategyFIFO : IStrategyGiaXuat { public decimal TinhGia(decimal g) => g; }
    public class StrategyBQGQ : IStrategyGiaXuat { public decimal TinhGia(decimal g) => g * 1.02m; }
    public class QuanLyKho_Real
    {
        public IStrategyGiaXuat PhuongPhapTinh { get; set; } = new StrategyFIFO();
    }
}
