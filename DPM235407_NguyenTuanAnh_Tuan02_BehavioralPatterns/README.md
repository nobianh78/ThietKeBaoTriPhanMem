# BÀI TẬP VỀ NHÀ: 10 MẪU THIẾT KẾ HÀNH VI (BEHAVIORAL DESIGN PATTERNS)
**Môn học:** Thiết kế phát triển và Bảo trì Phần mềm  
**Học viên thực hiện:** Nguyễn Tuấn Anh  
**Mã số học viên (MSSV):** DPM235407  
**Lớp / Khóa:** Cao học K24 / Đại học An Giang  
**Nguồn tham khảo lý thuyết:** [Refactoring.Guru - Behavioral Design Patterns in C#](https://refactoring.guru/design-patterns/behavioral-patterns)  
**Tài liệu đề tài thực tế:** Đồ án bảo trì hệ thống phần mềm Công ty Nông Dược An Giang (`DoAn-thietke-phattrien-baotri-phanmem-24pm.pdf`)

---

## 1. TỔNG QUAN CẤU TRÚC BÀI LÀM
Dự án được xây dựng trên nền tảng **.NET 8.0 (C#)**, quản lý tập trung thông qua file Solution `DPM235407_NguyenTuanAnh_Tuan02_BehavioralPatterns.sln`.  
Bao gồm đầy đủ **10 mẫu thiết kế hành vi (Behavioral Patterns)** với **20 Projects** độc lập (mỗi mẫu gồm 1 project lý thuyết chuẩn Refactoring.Guru và 1 project ứng dụng thực tế giải quyết yêu cầu công ty nông dược trong file PDF):

```
z:\DPM235407_NguyenTuanAnh_Tuan02_BehavioralPatterns\
│
├── DPM235407_NguyenTuanAnh_Tuan02_BehavioralPatterns.sln   <-- File Solution tổng chứa 20 dự án
├── README.md                                                 <-- Tài liệu hướng dẫn & giải trình
│
├── DPM235407_NguyenTuanAnh_Tuan02_ChainOfResponsibility-DP/              <-- [Chain of Resp] Lý thuyết Refactoring Guru
├── DPM235407_NguyenTuanAnh_Tuan02_ChainOfResponsibility_Real_XacThuc_DP/ <-- [Chain of Resp] Thực tế (Đăng nhập & phân quyền theo đề bài)
│
├── DPM235407_NguyenTuanAnh_Tuan02_Command-DP/                            <-- [Command] Lý thuyết Refactoring Guru
├── DPM235407_NguyenTuanAnh_Tuan02_Command_Real_HoaDon_DP/                <-- [Command] Thực tế (Lập HĐ, phụ phí ship, dịch vụ, giảm giá & Undo)
│
├── DPM235407_NguyenTuanAnh_Tuan02_Iterator-DP/                           <-- [Iterator] Lý thuyết Refactoring Guru
├── DPM235407_NguyenTuanAnh_Tuan02_Iterator_Real_KhoHang_DP/              <-- [Iterator] Thực tế (Xuất lô kho theo HSD FEFO hoặc chỉ định)
│
├── DPM235407_NguyenTuanAnh_Tuan02_Mediator-DP/                           <-- [Mediator] Lý thuyết Refactoring Guru
├── DPM235407_NguyenTuanAnh_Tuan02_Mediator_Real_DieuPhoi_DP/             <-- [Mediator] Thực tế (Điều phối trung gian Bán Hàng - Kho - Kế Toán - Giao Vận)
│
├── DPM235407_NguyenTuanAnh_Tuan02_Memento-DP/                            <-- [Memento] Lý thuyết Refactoring Guru
├── DPM235407_NguyenTuanAnh_Tuan02_Memento_Real_HoaDon_DP/                <-- [Memento] Thực tế (Lưu snapshot & hoàn tác bản thảo hóa đơn)
│
├── DPM235407_NguyenTuanAnh_Tuan02_Observer-DP/                           <-- [Observer] Lý thuyết Refactoring Guru
├── DPM235407_NguyenTuanAnh_Tuan02_Observer_Real_TonKho_DP/               <-- [Observer] Thực tế (Cảnh báo tồn an toàn, cận HSD & khuyến mãi mới)
│
├── DPM235407_NguyenTuanAnh_Tuan02_State-DP/                              <-- [State] Lý thuyết Refactoring Guru
├── DPM235407_NguyenTuanAnh_Tuan02_State_Real_DonHang_DP/                 <-- [State] Thực tế (Vòng đời đơn hàng Mới tạo -> Đã chốt -> Giao -> Hoàn thành)
│
├── DPM235407_NguyenTuanAnh_Tuan02_Strategy-DP/                           <-- [Strategy] Lý thuyết Refactoring Guru
├── DPM235407_NguyenTuanAnh_Tuan02_Strategy_Real_GiaXuat_DP/              <-- [Strategy] Thực tế (Tính giá xuất kho Bình quân gia quyền / FIFO)
│
├── DPM235407_NguyenTuanAnh_Tuan02_TemplateMethod-DP/                     <-- [Template Method] Lý thuyết Refactoring Guru
├── DPM235407_NguyenTuanAnh_Tuan02_TemplateMethod_Real_BanHang_DP/        <-- [Template Method] Thực tế (Quy trình bán hàng sỉ đại lý vs bán lẻ nông dân)
│
├── DPM235407_NguyenTuanAnh_Tuan02_Visitor-DP/                            <-- [Visitor] Lý thuyết Refactoring Guru
└── DPM235407_NguyenTuanAnh_Tuan02_Visitor_Real_ThongKe_DP/               <-- [Visitor] Thực tế (Báo cáo doanh số theo nhân viên & tồn kho từ ngày đến ngày)
```

---

## 2. CHI TIẾT 10 MẪU VÀ ỨNG DỤNG THỰC TẾ (FILE PDF ĐỀ BÀI CÔNG TY NÔNG DƯỢC AN GIANG)

### 1. Chain of Responsibility Pattern
- **Lý thuyết (`..._ChainOfResponsibility-DP`)**: Chuyển giao yêu cầu qua một chuỗi các Handler (`MonkeyHandler` -> `SquirrelHandler` -> `DogHandler`).
- **Thực tế (`..._ChainOfResponsibility_Real_XacThuc_DP`)**:
  - *Nghiệp vụ đề bài (Mục 4 & Hiện trạng)*: Hoàn thiện chức năng đăng nhập và phân quyền (nhân viên bán hàng vs quản lý).
  - *Giải pháp chuỗi*:
    1. `KiemTraDuLieuTrongHandler`: Kiểm tra username/password không để trống.
    2. `XacThucTaiKhoanHandler`: Xác thực thông tin tài khoản và mật khẩu từ cơ sở dữ liệu.
    3. `KiemTraKhoaTaiKhoanHandler`: Kiểm tra trạng thái tài khoản có bị khóa vi phạm hay không.
    4. `PhanQuyenTruyCapHandler`: Kiểm tra vai trò của người dùng (`QuanLy`, `NhanVienBanHang`, `ThuKho`) có được phép truy cập chức năng yêu cầu (`LapHoaDon`, `CauHinhXuatKho`, `BaoCaoTongHop`,...).

### 2. Command Pattern
- **Lý thuyết (`..._Command-DP`)**: Đóng gói yêu cầu thành một đối tượng độc lập (`ICommand`, `SimpleCommand`, `ComplexCommand`, `Receiver`, `Invoker`).
- **Thực tế (`..._Command_Real_HoaDon_DP`)**:
  - *Nghiệp vụ đề bài (Mục 4)*: Cho phép lập hóa đơn nhập dịch vụ phát sinh, phí vận chuyển, chiết khấu giảm giá; hỗ trợ hoàn tác Undo/Redo thao tác.
  - *Giải pháp*:
    - `ThemSanPhamCommand`: Thêm thuốc BVTV (hỗ trợ Undo xóa thuốc).
    - `ThemPhiVanChuyenCommand`: Nhập chi phí vận chuyển xe giao đến ruộng (hỗ trợ Undo khôi phục).
    - `ThemDichVuPhatSinhCommand`: Nhập phụ phí thử nghiệm mẫu thuốc, bốc xếp (hỗ trợ Undo).
    - `ApDungGiamGiaCommand`: Áp dụng chiết khấu khuyến mãi (hỗ trợ Undo).
    - `NhanVienThuNganInvoker`: Quản lý stack lịch sử thao tác, cho phép người dùng hoàn tác linh hoạt khi khách hàng thay đổi ý định.

### 3. Iterator Pattern
- **Lý thuyết (`..._Iterator-DP`)**: Cung cấp cách thức truy xuất tuần tự các phần tử của tập hợp mà không để lộ cấu trúc bên trong (`Iterator`, `IteratorAggregate`, `AlphabeticalOrderIterator`).
- **Thực tế (`..._Iterator_Real_KhoHang_DP`)**:
  - *Nghiệp vụ đề bài (Mục 3)*: "Nhập hàng theo lô nhưng khi xuất hàng thì hệ thống sẽ hoạt động theo cấu hình (hệ thống tự tính và phân lô theo ngày hết hạn trước sẽ xuất trước và có hiển thị lô và ngày hết hạn trong chi tiết phiếu xuất, hoặc theo chỉ định của người dùng)".
  - *Giải pháp*:
    - `XuatTheoHanSuDungIterator` (FEFO): Tự động sắp xếp các lô theo hạn sử dụng tăng dần, xuất các lô thuốc cận date trước để tránh quá hạn trong kho.
    - `XuatTheoChiDinhIterator`: Duyệt chính xác các mã lô thuốc theo yêu cầu chỉ định của khách hàng/người dùng.
    - `XuatTheoNhapTruocXuatTruocIterator` (FIFO): Duyệt theo thứ tự ngày nhập kho.

### 4. Mediator Pattern
- **Lý thuyết (`..._Mediator-DP`)**: Giảm bớt sự phụ thuộc lẫn nhau giữa các lớp bằng cách tập trung giao tiếp qua đối tượng trung gian (`IMediator`, `ConcreteMediator`).
- **Thực tế (`..._Mediator_Real_DieuPhoi_DP`)**:
  - *Nghiệp vụ đề bài*: Kết nối vận hành trơn tru giữa các bộ phận trong công ty nông dược An Giang.
  - *Giải pháp*:
    - `DieuPhoiBanHangMediator`: Điều phối trung gian.
    - `BoPhanBanHang` gửi đơn hàng mới -> Mediator tự động báo `BoPhanKhoHang` kiểm tra tồn kho và trừ lô thuốc -> Mediator báo `BoPhanKeToan` tính chiết khấu và in hóa đơn -> Mediator báo `BoPhanVanChuyen` điều xe tải giao tận nhà vườn. Các bộ phận không cần biết trực tiếp đến nhau.

### 5. Memento Pattern
- **Lý thuyết (`..._Memento-DP`)**: Lưu trữ và khôi phục trạng thái nội bộ của đối tượng mà không vi phạm tính bao đóng (`Originator`, `IMemento`, `Caretaker`).
- **Thực tế (`..._Memento_Real_HoaDon_DP`)**:
  - *Nghiệp vụ đề bài*: Lưu vết các bản thảo hóa đơn khi nhân viên chỉnh sửa cước phí vận chuyển, chiết khấu khuyến mãi mùa vụ, dịch vụ phụ trợ.
  - *Giải pháp*:
    - `HoaDonBanHang` (Originator): Lưu trạng thái qua `HoaDonMemento` (Deep Copy dữ liệu).
    - `LichSuHoaDonCaretaker`: Quản lý stack các snapshot, cho phép Rollback/Undo khôi phục về bất kỳ thời điểm nào trước đó.

### 6. Observer Pattern
- **Lý thuyết (`..._Observer-DP`)**: Định nghĩa cơ chế đăng ký theo dõi và tự động thông báo khi có sự kiện thay đổi (`ISubject`, `IObserver`, `Subject`, `ConcreteObserver`).
- **Thực tế (`..._Observer_Real_TonKho_DP`)**:
  - *Nghiệp vụ đề bài*: Quản lý tồn kho thuốc BVTV, cảnh báo an toàn và chương trình khuyến mãi.
  - *Giải pháp*:
    - `KhoNongDuocSubject`: Quản lý và bắn thông báo sự kiện tự động:
      1. Tồn kho thuốc dưới mức an toàn (<= 15) -> `BoPhanThuKhoObserver` lập phiếu nhập hàng.
      2. Lô thuốc cận hạn sử dụng (< 30 ngày) -> `QuanLyCuaHangObserver` chỉ đạo giảm giá 25% xả kho.
      3. Triển khai chương trình khuyến mãi mới -> `NhanVienBanHangObserver` gọi điện/nhắn tin báo khách.

### 7. State Pattern
- **Lý thuyết (`..._State-DP`)**: Cho phép một đối tượng thay đổi hành vi khi trạng thái nội tại của nó thay đổi (`Context`, `State`, `ConcreteStateA`, `ConcreteStateB`).
- **Thực tế (`..._State_Real_DonHang_DP`)**:
  - *Nghiệp vụ đề bài*: Quản lý vòng đời chặt chẽ của đơn hàng bán nông dược, ngăn chặn các thao tác sai quy trình.
  - *Giải pháp*:
    - `TrangThaiMoiTao`: Đang soạn đơn, cho phép thêm thuốc, nhập phí ship, giảm giá.
    - `TrangThaiDaXacNhan`: Đã chốt hóa đơn, trừ kho thuốc theo HSD; KHÓA không cho sửa sản phẩm hay giá.
    - `TrangThaiDangGiaoHang`: Đang trên xe tải vận chuyển đến nhà vườn.
    - `TrangThaiHoanThanh`: Đã giao hàng và thanh toán đủ tiền; ngăn chặn mọi hành vi chỉnh sửa hoặc hủy đơn.
    - `TrangThaiDaHuy`: Hủy đơn và tự động hoàn trả hàng tồn kho.

### 8. Strategy Pattern
- **Lý thuyết (`..._Strategy-DP`)**: Định nghĩa một tập hợp các thuật toán, đóng gói từng thuật toán và cho phép hoán đổi linh hoạt tại runtime (`IStrategy`, `ConcreteStrategyA`, `ConcreteStrategyB`, `Context`).
- **Thực tế (`..._Strategy_Real_GiaXuat_DP`)**:
  - *Nghiệp vụ đề bài (Mục 3)*: "Giá xuất sản phẩm được tính theo 2 phương pháp tùy chọn (bình quân gia quyền, nhập trước xuất trước)".
  - *Giải pháp*:
    - `TinhGiaBinhQuanGiaQuyenStrategy`: Tính đơn giá bình quân = Tổng giá trị tồn / Tổng số lượng tồn để tính giá vốn lô xuất.
    - `TinhGiaNhapTruocXuatTruocStrategy` (FIFO): Lấy giá từ các lô nhập sớm nhất còn tồn cho đến khi đủ số lượng xuất.
    - `QuanLyKhoNongDuocContext`: Cho phép đổi phương pháp tính giá vốn kho tại runtime chỉ với một câu lệnh.

### 9. Template Method Pattern
- **Lý thuyết (`..._TemplateMethod-DP`)**: Định nghĩa khung xương (skeleton) của thuật toán trong một phương thức trừu tượng, trì hoãn một số bước cho các lớp con triển khai (`AbstractClass`, `ConcreteClass1`, `ConcreteClass2`).
- **Thực tế (`..._TemplateMethod_Real_BanHang_DP`)**:
  - *Nghiệp vụ đề bài (Mục 3)*: Chỉnh chức năng bán hàng sỉ và lẻ.
  - *Giải pháp*:
    - `QuyTrinhBanHangTemplate`: Cố định 7 bước chuẩn:
      1. Kiểm tra tồn kho (chung)
      2. Tính tiền hàng gốc (chung)
      3. Áp dụng chiết khấu (lớp con: Bán sỉ giảm 10-15% theo số lượng; Bán lẻ theo voucher)
      4. Tính phí vận chuyển (lớp con: Bán sỉ cước xe tải theo km; Bán lẻ shipper xe máy)
      5. Hook dịch vụ phụ trợ (lớp con: Bán sỉ thêm bốc xếp hạ hàng; Bán lẻ tư vấn kỹ thuật)
      6. Phân lô xuất kho theo HSD (chung)
      7. In hóa đơn tài chính (chung)
    - `QuyTrinhBanSi` & `QuyTrinhBanLe`: Triển khai các bước đặc thù.

### 10. Visitor Pattern
- **Lý thuyết (`..._Visitor-DP`)**: Tách biệt thuật toán khỏi các đối tượng mà nó thao tác, cho phép thêm thao tác mới vào cấu trúc đối tượng mà không cần sửa đổi lớp (`IComponent`, `IVisitor`, `ConcreteVisitor`).
- **Thực tế (`..._Visitor_Real_ThongKe_DP`)**:
  - *Nghiệp vụ đề bài (Mục 4)*:
    + Thống kê tồn kho hàng hóa, chi phí vận chuyển, dịch vụ phụ, giảm giá khuyến mãi từ ngày đến ngày.
    + Thống kê những hóa đơn bán giảm giá và khuyến mãi theo từng nhân viên đăng nhập, từ ngày đến ngày.
  - *Giải pháp*:
    - Elements: `HoaDonBanHangElement`, `LoHangTonKhoElement`, `DichVuPhatSinhElement`.
    - Visitors:
      + `BaoCaoTheoNhanVienTuNgayDenNgayVisitor`: Thống kê doanh số, chiết khấu theo nhân viên đăng nhập trong khoảng ngày.
      + `BaoCaoTonKhoVaChiPhiPhuTuNgayDenNgayVisitor`: Thống kê tổng hợp toàn công ty về giá trị tồn kho, chi phí vận chuyển, phụ phí dịch vụ và khuyến mãi trong khoảng ngày.

---

## 3. HƯỚNG DẪN BIÊN DỊCH VÀ CHẠY DỰ ÁN

### Biên dịch toàn bộ Solution (20 Projects):
Mở PowerShell tại thư mục gốc và chạy:
```powershell
dotnet build DPM235407_NguyenTuanAnh_Tuan02_BehavioralPatterns.sln
```
*Kết quả:* `Build succeeded. 0 Warning(s), 0 Error(s)`.

---

### Lệnh chạy kiểm thử từng Project:

#### 1. Chain of Responsibility
```powershell
dotnet run --project DPM235407_NguyenTuanAnh_Tuan02_ChainOfResponsibility-DP
dotnet run --project DPM235407_NguyenTuanAnh_Tuan02_ChainOfResponsibility_Real_XacThuc_DP
```

#### 2. Command
```powershell
dotnet run --project DPM235407_NguyenTuanAnh_Tuan02_Command-DP
dotnet run --project DPM235407_NguyenTuanAnh_Tuan02_Command_Real_HoaDon_DP
```

#### 3. Iterator
```powershell
dotnet run --project DPM235407_NguyenTuanAnh_Tuan02_Iterator-DP
dotnet run --project DPM235407_NguyenTuanAnh_Tuan02_Iterator_Real_KhoHang_DP
```

#### 4. Mediator
```powershell
dotnet run --project DPM235407_NguyenTuanAnh_Tuan02_Mediator-DP
dotnet run --project DPM235407_NguyenTuanAnh_Tuan02_Mediator_Real_DieuPhoi_DP
```

#### 5. Memento
```powershell
dotnet run --project DPM235407_NguyenTuanAnh_Tuan02_Memento-DP
dotnet run --project DPM235407_NguyenTuanAnh_Tuan02_Memento_Real_HoaDon_DP
```

#### 6. Observer
```powershell
dotnet run --project DPM235407_NguyenTuanAnh_Tuan02_Observer-DP
dotnet run --project DPM235407_NguyenTuanAnh_Tuan02_Observer_Real_TonKho_DP
```

#### 7. State
```powershell
dotnet run --project DPM235407_NguyenTuanAnh_Tuan02_State-DP
dotnet run --project DPM235407_NguyenTuanAnh_Tuan02_State_Real_DonHang_DP
```

#### 8. Strategy
```powershell
dotnet run --project DPM235407_NguyenTuanAnh_Tuan02_Strategy-DP
dotnet run --project DPM235407_NguyenTuanAnh_Tuan02_Strategy_Real_GiaXuat_DP
```

#### 9. Template Method
```powershell
dotnet run --project DPM235407_NguyenTuanAnh_Tuan02_TemplateMethod-DP
dotnet run --project DPM235407_NguyenTuanAnh_Tuan02_TemplateMethod_Real_BanHang_DP
```

#### 10. Visitor
```powershell
dotnet run --project DPM235407_NguyenTuanAnh_Tuan02_Visitor-DP
dotnet run --project DPM235407_NguyenTuanAnh_Tuan02_Visitor_Real_ThongKe_DP
```
