using System;

namespace DPM235407_NguyenTuanAnh_Tuan02_Observer_Real_TonKho_DP
{
    public enum LoaiCanhBao
    {
        TonKhoDuoiMucAnToan,
        ThuocCanHanSuDung,
        KhuyenMaiGiaMoi
    }

    public class ThongTinCanhBaoKho
    {
        public LoaiCanhBao Loai { get; set; }
        public string MaLo { get; set; }
        public string TenThuoc { get; set; }
        public string NoiDung { get; set; }
        public DateTime ThoiGian { get; set; }

        public ThongTinCanhBaoKho(LoaiCanhBao loai, string maLo, string tenThuoc, string noiDung)
        {
            Loai = loai;
            MaLo = maLo;
            TenThuoc = tenThuoc;
            NoiDung = noiDung;
            ThoiGian = DateTime.Now;
        }
    }
}
