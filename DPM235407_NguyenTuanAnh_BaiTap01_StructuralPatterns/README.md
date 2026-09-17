# BÀI TẬP VỀ NHÀ: 7 MẪU THIẾT KẾ CẤU TRÚC (STRUCTURAL DESIGN PATTERNS)
**Môn học:** Thiết kế phát triển và Bảo trì Phần mềm  
**Học viên thực hiện:** Nguyễn Tuấn Anh  
**Mã số học viên (MSSV):** DPM235407  
**Lớp / Khóa:** Cao học K24 / Đại học An Giang  
**Nguồn tham khảo lý thuyết:** [Refactoring.Guru - Structural Design Patterns in C#](https://refactoring.guru/design-patterns/csharp)  
**Tài liệu đề tài thực tế:** Đồ án bảo trì hệ thống phần mềm Công ty Nông Dược An Giang (`DoAn-thietke-phattrien-baotri-phanmem-24pm.pdf`)

---

## 1. TỔNG QUAN CẤU TRÚC BÀI LÀM
Dự án được xây dựng trên nền tảng **.NET 8.0 (C#)**, quản lý tập trung thông qua file Solution `DPM235407_NguyenTuanAnh_BaiTap01_StructuralPatterns.sln`.  
Bao gồm đầy đủ **7 mẫu thiết kế cấu trúc (Structural Patterns)** với **14 Projects** độc lập (mỗi mẫu gồm 1 project lý thuyết chuẩn Refactoring.Guru và 1 project ứng dụng thực tế giải quyết yêu cầu công ty nông dược trong file PDF):

```
z:\DPM235407_NguyenTuanAnh_BaiTap01_StructuralPatterns\
│
├── DPM235407_NguyenTuanAnh_BaiTap01_StructuralPatterns.sln   <-- File Solution tổng
├── README.md                                                 <-- Tài liệu hướng dẫn
│
├── DPM235407_NguyenTuanAnh_BaiTap01_Adapter-DP/              <-- [Adapter] Lý thuyết
├── DPM235407_NguyenTuanAnh_BaiTap01_Adapter_Real_VanChuyen_DP/<-- [Adapter] Thực tế (Cước vận chuyển đối tác GHN, ViettelPost)
│
├── DPM235407_NguyenTuanAnh_BaiTap01_Bridge-DP/               <-- [Bridge] Lý thuyết
├── DPM235407_NguyenTuanAnh_BaiTap01_Bridge_Real_GiaXuat_DP/  <-- [Bridge] Thực tế (Bán sỉ/lẻ kết hợp tính giá FIFO / Bình quân gia quyền)
│
├── DPM235407_NguyenTuanAnh_BaiTap01_Composite-DP/            <-- [Composite] Lý thuyết
├── DPM235407_NguyenTuanAnh_BaiTap01_Composite_Real_GoiHang_DP/<-- [Composite] Thực tế (Cây sản phẩm lẻ và combo mùa vụ)
│
├── DPM235407_NguyenTuanAnh_BaiTap01_Decorator-DP/            <-- [Decorator] Lý thuyết
├── DPM235407_NguyenTuanAnh_BaiTap01_Decorator_Real_HoaDon_DP/<-- [Decorator] Thực tế (Hóa đơn mở rộng: Vận chuyển, Dịch vụ phụ, Giảm giá)
│
├── DPM235407_NguyenTuanAnh_BaiTap01_Facade-DP/               <-- [Facade] Lý thuyết
├── DPM235407_NguyenTuanAnh_BaiTap01_Facade_Real_BanHang_DP/  <-- [Facade] Thực tế (Facade bán hàng: Đăng nhập -> Kho FIFO -> Tính tiền -> Thống kê)
│
├── DPM235407_NguyenTuanAnh_BaiTap01_Flyweight-DP/            <-- [Flyweight] Lý thuyết
├── DPM235407_NguyenTuanAnh_BaiTap01_Flyweight_Real_LoHang_DP/<-- [Flyweight] Thực tế (Tối ưu RAM lưu trữ hàng ngàn lô nông dược)
│
├── DPM235407_NguyenTuanAnh_BaiTap01_Proxy-DP/                <-- [Proxy] Lý thuyết
└── DPM235407_NguyenTuanAnh_BaiTap01_Proxy_Real_BaoCao_DP/    <-- [Proxy] Thực tế (Phân quyền báo cáo từ ngày đến ngày & Audit Log)
```

---

## 2. CHI TIẾT CÁC MẪU VÀ ỨNG DỤNG THỰC TẾ (FILE PDF ĐỀ BÀI)

### 1. Adapter Pattern
- **Lý thuyết (`..._Adapter-DP`)**: Chuyển đổi giao diện lớp `Adaptee` sang giao diện `ITarget` thông qua `Adapter`.
- **Thực tế (`..._Adapter_Real_VanChuyen_DP`)**:
  - *Nghiệp vụ đề bài*: Lập hóa đơn bán hàng cho phép tính phí vận chuyển phát sinh theo từng đơn vị giao hàng.
  - *Giải pháp*: Chuẩn hóa giao diện `IDichVuVanChuyen` cho hệ thống công ty, sử dụng `GiaoHangNhanhAdapter` và `ViettelPostAdapter` để chuyển đổi API từ các đối tác giao vận bên thứ ba.

### 2. Bridge Pattern
- **Lý thuyết (`..._Bridge-DP`)**: Tách rời tầng trừu tượng (`Abstraction`) khỏi tầng cài đặt (`IImplementation`) để cả hai có thể phát triển độc lập.
- **Thực tế (`..._Bridge_Real_GiaXuat_DP`)**:
  - *Nghiệp vụ đề bài (Mục 3)*: Chỉnh chức năng bán hàng sỉ & lẻ, giá xuất sản phẩm tính theo 2 phương pháp tùy chọn: bình quân gia quyền hoặc nhập trước xuất trước (FIFO).
  - *Giải pháp*:
    - Nhánh Abstraction: `HinhThucBanHang` -> `BanHangLe`, `BanHangSi`.
    - Nhánh Implementation: `IPhuongPhapTinhGiaXuat` -> `TinhGiaBinhQuanGiaQuyen`, `TinhGiaFIFO`.
    - Cho phép thay đổi linh hoạt phương pháp tính giá vốn kho cho từng loại hình bán hàng tại thời điểm runtime.

### 3. Composite Pattern
- **Lý thuyết (`..._Composite-DP`)**: Tổ chức các đối tượng theo cấu trúc hình cây để mô tả quan hệ một phần - toàn bộ (`Component`, `Leaf`, `Composite`).
- **Thực tế (`..._Composite_Real_GoiHang_DP`)**:
  - *Nghiệp vụ đề bài*: Quản lý danh mục hàng nông dược bán lẻ và các gói khuyến mãi / combo trọn gói mùa vụ lúa (Combo phòng trừ rầy lá đòng, Thùng giải pháp Đông Xuân).
  - *Giải pháp*:
    - `INongDuocComponent`: Giao diện chung duyệt cây, tính giá và hiển thị bảng kê.
    - `SanPhamDonLe`: Node lá (từng chai thuốc, bao phân bón).
    - `GoiComboNongDuoc`: Node tổ hợp (chứa nhiều sản phẩm đơn lẻ hoặc combo con), tự động duyệt đệ quy tính tổng chi phí và chiết khấu.

### 4. Decorator Pattern
- **Lý thuyết (`..._Decorator-DP`)**: Gắn thêm hành vi mới vào đối tượng một cách linh hoạt mà không làm thay đổi cấu trúc lớp gốc (`Component`, `Decorator`).
- **Thực tế (`..._Decorator_Real_HoaDon_DP`)**:
  - *Nghiệp vụ đề bài (Mục 4)*: Sửa lỗi hiện trạng hóa đơn không tính cước vận chuyển, thiếu dịch vụ phụ phát sinh (bốc vác, thử nghiệm mẫu) và không có giảm giá khuyến mãi.
  - *Giải pháp*:
    - `HoaDonCoBan`: Tính tiền thuốc/phân bón gốc.
    - Bọc thêm `PhiVanChuyenDecorator`: Cộng thêm chi phí giao hàng tận ruộng.
    - Bọc thêm `DichVuPhatSinhDecorator`: Cộng thêm chi phí dịch vụ phụ.
    - Bọc thêm `GiamGiaKhuyenMaiDecorator`: Trừ tiền chiết khấu khuyến mãi mùa vụ.

### 5. Facade Pattern
- **Lý thuyết (`..._Facade-DP`)**: Cung cấp giao diện cấp cao đồng nhất đơn giản hóa việc tương tác với nhiều hệ thống con phức tạp.
- **Thực tế (`..._Facade_Real_BanHang_DP`)**:
  - *Nghiệp vụ đề bài*: Quy trình bán hàng gồm nhiều bước phức tạp: kiểm tra đăng nhập nhân viên, phân lô xuất kho theo HSD (ngày hết hạn trước xuất trước), tính phụ phí & chiết khấu, in phiếu xuất hiển thị số lô/HSD, và lưu dữ liệu thống kê.
  - *Giải pháp*: Lớp `BanHangFacade` cung cấp phương thức `LapDonHangNongDuoc(...)` điều phối trọn vẹn cả 4 phân hệ (`PhanHeXacThuc`, `PhanHeKhoHang`, `PhanHeTinhTien`, `PhanHeThongKe`) chỉ trong một dòng lệnh.

### 6. Flyweight Pattern
- **Lý thuyết (`..._Flyweight-DP`)**: Tiết kiệm bộ nhớ bằng cách chia sẻ trạng thái nội tại chung giữa nhiều đối tượng.
- **Thực tế (`..._Flyweight_Real_LoHang_DP`)**:
  - *Nghiệp vụ đề bài*: Quản lý hàng chục ngàn lô hàng nông dược trong kho.
  - *Giải pháp*:
    - Trạng thái nội tại (Intrinsic): `ThongTinThuocFlyweight` (tên thuốc, hoạt chất, quy cách, hãng SX) được lưu trữ dùng chung qua `ThuocFlyweightFactory`.
    - Trạng thái ngoại tại (Extrinsic): `LoHangContext` (số lô, NSX, HSD, vị trí kho, số lượng tồn, đơn giá) truyền vào khi tính toán.
    - Tiết kiệm hơn 95% bộ nhớ RAM khi quản lý lượng lớn lô hàng.

### 7. Proxy Pattern
- **Lý thuyết (`..._Proxy-DP`)**: Cung cấp đối tượng thay thế hoặc đại diện để kiểm soát truy cập vào đối tượng thực (`ISubject`, `RealSubject`, `Proxy`).
- **Thực tế (`..._Proxy_Real_BaoCao_DP`)**:
  - *Nghiệp vụ đề bài (Mục 4)*: Thống kê tồn kho, chi phí vận chuyển, dịch vụ phụ, giảm giá từ ngày đến ngày; Thống kê hóa đơn theo nhân viên đăng nhập; Hoàn thiện đăng nhập và phân quyền.
  - *Giải pháp*:
    - `BaoCaoThongKeProxy` đóng vai trò **Protection Proxy**: Phân quyền nghiêm ngặt giữa tài khoản `QuanLy` (được xem toàn bộ báo cáo tài chính/tồn kho) và `NhanVienBanHang` (chỉ được xem báo cáo doanh số cá nhân của chính mình, chặn truy cập vào báo cáo mật công ty).
    - Tích hợp **Logging Proxy**: Ghi nhật ký kiểm toán (Audit log) thời điểm và người tra cứu báo cáo.
    - Tích hợp **Caching Proxy**: Tự động lưu cache kết quả khi tra cứu cùng khoảng ngày để tăng tốc độ phản hồi.

---

## 3. HƯỚNG DẪN BIÊN DỊCH VÀ CHẠY DỰ ÁN

### Biên dịch toàn bộ Solution:
Mở PowerShell hoặc Command Prompt tại thư mục gốc và chạy:
```powershell
dotnet build DPM235407_NguyenTuanAnh_BaiTap01_StructuralPatterns.sln
```
Kết quả: `Build succeeded. 0 Warning(s), 0 Error(s)`.

### Chạy từng Project:
```powershell
# 1. Adapter
dotnet run --project DPM235407_NguyenTuanAnh_BaiTap01_Adapter-DP
dotnet run --project DPM235407_NguyenTuanAnh_BaiTap01_Adapter_Real_VanChuyen_DP

# 2. Bridge
dotnet run --project DPM235407_NguyenTuanAnh_BaiTap01_Bridge-DP
dotnet run --project DPM235407_NguyenTuanAnh_BaiTap01_Bridge_Real_GiaXuat_DP

# 3. Composite
dotnet run --project DPM235407_NguyenTuanAnh_BaiTap01_Composite-DP
dotnet run --project DPM235407_NguyenTuanAnh_BaiTap01_Composite_Real_GoiHang_DP

# 4. Decorator
dotnet run --project DPM235407_NguyenTuanAnh_BaiTap01_Decorator-DP
dotnet run --project DPM235407_NguyenTuanAnh_BaiTap01_Decorator_Real_HoaDon_DP

# 5. Facade
dotnet run --project DPM235407_NguyenTuanAnh_BaiTap01_Facade-DP
dotnet run --project DPM235407_NguyenTuanAnh_BaiTap01_Facade_Real_BanHang_DP

# 6. Flyweight
dotnet run --project DPM235407_NguyenTuanAnh_BaiTap01_Flyweight-DP
dotnet run --project DPM235407_NguyenTuanAnh_BaiTap01_Flyweight_Real_LoHang_DP

# 7. Proxy
dotnet run --project DPM235407_NguyenTuanAnh_BaiTap01_Proxy-DP
dotnet run --project DPM235407_NguyenTuanAnh_BaiTap01_Proxy_Real_BaoCao_DP
```
