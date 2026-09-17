using System;

namespace DPM235407_NguyenTuanAnh_BaiTap01_Proxy_Real_BaoCao_DP
{
    // [Subject Interface]: Giao diện thống kê báo cáo theo yêu cầu mục 4 PDF
    public interface IBaoCaoThongKeService
    {
        void XemBaoCaoDoanhThuVaKhuyenMai(NguoiDung user, DateTime tuNgay, DateTime denNgay);
        void XemBaoCaoTonKhoVaChiPhi(NguoiDung user, DateTime tuNgay, DateTime denNgay);
    }
}
