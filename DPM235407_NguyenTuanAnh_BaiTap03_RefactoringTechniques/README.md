<div align="center">

# 🛠️ BÀI TẬP 03: REFACTORING TECHNIQUES (CÁC KỸ THUẬT TÁI CẤU TRÚC MÃ NGUỒN)
### HỆ THỐNG QUẢN LÝ BÁN HÀNG CÔNG TY NÔNG DƯỢC AN GIANG
**TRƯỜNG ĐẠI HỌC AN GIANG — ĐẠI HỌC QUỐC GIA TP. HỒ CHÍ MINH**

---

[![C#](https://img.shields.io/badge/C%23-239120?style=for-the-badge&logo=c-sharp&logoColor=white)](https://docs.microsoft.com/en-us/dotnet/csharp/)
[![.NET](https://img.shields.io/badge/.NET-8.0%20%7C%2010.0-512BD4?style=for-the-badge&logo=dotnet&logoColor=white)](https://dotnet.microsoft.com/)
[![Refactoring.Guru](https://img.shields.io/badge/Refactoring-Refactoring.Guru-FFA500?style=for-the-badge&logo=codewars&logoColor=white)](https://refactoring.guru/refactoring/techniques)
[![Build Status](https://img.shields.io/badge/Build-Passing-brightgreen?style=for-the-badge&logo=github-actions&logoColor=white)](https://github.com/nobianh78/ThietKeBaoTriPhanMem)

<br/>

> *"Tái cấu trúc mã nguồn theo chuẩn Refactoring.Guru kết hợp giải quyết các Code Smell thực tế từ mã nguồn gốc Cửa hàng Nông Dược An Giang."*

</div>

---

## 👤 THÔNG TIN HỌC VIÊN THỰC HIỆN

| 🎯 Thông tin | 📝 Chi tiết |
|:---|:---|
| **Học viên thực hiện** | **NGUYỄN TUẤN ANH** |
| **Mã học viên (MSSV)** | `DPM235407` |
| **Lớp / Khóa** | Cao học Kỹ thuật Phần mềm (K24) |
| **Đơn vị đào tạo** | Trường Đại học An Giang — ĐHQG-HCM |
| **Học phần** | Thiết kế phát triển và Bảo trì Phần mềm |
| **Tài liệu tham khảo lý thuyết** | [Refactoring.Guru - Refactoring Techniques](https://refactoring.guru/refactoring/techniques) |
| **Mã nguồn thực tế tham chiếu** | Dự án gốc `Cuahang_Nongduoc` (`frmBanLe.cs`, `frmBanSi.cs`, `Num2Str.cs`, `BusinessObject/`) |

---

## 📋 TỔNG QUAN CẤU TRÚC BÀI TẬP 03

Dự án được tổ chức thành file Solution `DPM235407_NguyenTuanAnh_BaiTap03_RefactoringTechniques.sln` gồm **3 Projects C#** tương ứng với 3 nhóm kỹ thuật tái cấu trúc trọng tâm:

```
DPM235407_NguyenTuanAnh_BaiTap03_RefactoringTechniques/
│
├── DPM235407_NguyenTuanAnh_BaiTap03_RefactoringTechniques.sln
├── README.md
│
├── DPM235407_NguyenTuanAnh_BaiTap03_01_ComposingMethods/       <-- [Nhóm 1] Composing Methods
│   ├── 01_Extract_Inline_Method/
│   │   ├── 01_ExtractMethod_Before.cs                          (Code Smell: Long Method)
│   │   ├── 01_ExtractMethod_After.cs                           (Extract Method & Inline Method)
│   │   └── 01_ExtractMethod_Real_LapPhieuBanHang.cs            (Refactor Luu() & ChiTiet frmBanLe.cs)
│   ├── 02_Extract_Inline_Temp_Query/
│   │   ├── 02_TempVariables_Before.cs                          (Code Smell: Temporary Variables)
│   │   ├── 02_TempVariables_After.cs                           (Replace Temp with Query & Extract Variable)
│   │   └── 02_TempVariables_Real_TinhGiaBanChietKhau.cs        (Refactor tính giá sỉ & chiết khấu frmBanSi.cs)
│   ├── 03_Split_Temp_Remove_Assignments/
│   │   ├── 03_SplitTemp_Before.cs                              (Reusing Temp & Parameter Assignments)
│   │   ├── 03_SplitTemp_After.cs                               (Split Temp Variable & In Parameters)
│   │   └── 03_SplitTemp_Real_PhanBoSoLuongXuatKho.cs           (Refactor phân bổ số lượng FEFO kho nông dược)
│   ├── 04_Method_Object_Substitute_Algorithm/
│   │   ├── 04_MethodObject_Before.cs                           (Complex Method với chằng chịt biến cục bộ)
│   │   ├── 04_MethodObject_After.cs                            (Replace Method with Method Object)
│   │   └── 04_MethodObject_Real_DocSoThanhChu.cs               (Refactor Num2Str.cs & Tính giá vốn BQGQ Mục 3 PDF)
│   └── Program.cs
│
├── DPM235407_NguyenTuanAnh_BaiTap03_02_MovingFeatures/          <-- [Nhóm 2] Moving Features between Objects
│   ├── 01_Move_Method_Field/
│   │   ├── 01_MoveMethod_Before.cs                             (Code Smell: Feature Envy trên Form UI)
│   │   ├── 01_MoveMethod_After.cs                              (Move Method & Information Expert)
│   │   └── 01_MoveMethod_Real_CapNhatCongNoVaGiaBan.cs         (Move tính công nợ & thành tiền vào PhieuBan/ChiTiet)
│   ├── 02_Extract_Inline_Class/
│   │   ├── 02_ExtractClass_Before.cs                           (Code Smell: Large Class / Divergent Change)
│   │   ├── 02_ExtractClass_After.cs                            (Extract Class ThongTinLienHe, DiaChi, NganHang)
│   │   └── 02_ExtractClass_Real_DiaChiLienHeDaiLy.cs           (Tách địa chỉ giao hàng ruộng & GPS cho Đại lý)
│   ├── 03_Hide_Delegate_Remove_MiddleMan/
│   │   ├── 03_HideDelegate_Before.cs                           (Code Smell: Message Chains / Vi phạm Demeter)
│   │   ├── 03_HideDelegate_After.cs                            (Hide Delegate)
│   │   └── 03_HideDelegate_Real_TruyXuatDonGiaLoHang.cs        (Đóng gói chuỗi gọi MaSanPham.SanPham.DonGia)
│   ├── 04_Foreign_Method_Local_Extension/
│   │   ├── 04_Extension_Before.cs                              (Code tiện ích DateTime viết rải rác)
│   │   ├── 04_Extension_After.cs                               (Introduce Local Extension / Extension Methods)
│   │   └── 04_Extension_Real_QuanLyHanDungFEFO.cs              (Extension Methods lọc cận date & sắp xếp FEFO)
│   └── Program.cs
│
└── DPM235407_NguyenTuanAnh_BaiTap03_03_OrganizingData/           <-- [Nhóm 3] Organizing Data
    ├── 01_Self_Encapsulate_Collection/
    │   ├── 01_EncapsulateCollection_Before.cs                  (Để lộ List<T> public getter/setter)
    │   ├── 01_EncapsulateCollection_After.cs                   (Encapsulate Collection với ReadOnlyCollection)
    │   └── 01_EncapsulateCollection_Real_DanhSachChiTietPhieuBan.cs (Đóng gói IList<ChiTietPhieuBan> trong PhieuBan.cs)
    ├── 02_Replace_Data_Value_With_Object/
    │   ├── 02_ValueObject_Before.cs                            (Code Smell: Primitive Obsession)
    │   ├── 02_ValueObject_After.cs                             (Tạo Value Objects MaVachEAN13, SoDienThoaiVN)
    │   └── 02_ValueObject_Real_MaVachDonViTienTe.cs            (Value Objects TienTeNongDuoc & QuyCachDongGoi)
    ├── 03_Replace_Magic_Numbers_Constants/
    │   ├── 03_MagicNumber_Before.cs                            (Magic Numbers 0.1, 0.05, 15, 30 rải rác)
    │   ├── 03_MagicNumber_After.cs                             (Replace Magic Number with Symbolic Constant)
    │   └── 03_MagicNumber_Real_DinhMucNongDuoc.cs              (Hằng số quy định chuẩn kho nông dược An Giang)
    ├── 04_Replace_Type_Code_State_Subclass/
    │   ├── 04_TypeCode_Before.cs                               (Switch-case theo mã loại nguyên thủy)
    │   ├── 04_TypeCode_After.cs                                (Replace Type Code with Subclasses / OCP)
    │   └── 04_TypeCode_Real_PhanLoaiSanPhamVaKhachHang.cs      (Đa hình Thuốc độc cao, Sinh học, Phân bón lá)
    ├── 05_Change_Value_Reference/
    │   ├── 05_ValueRef_Before.cs                               (New LoHang độc lập làm mất nhất quán tồn kho)
    │   ├── 05_ValueRef_After.cs                                (Change Value to Reference / Kho Repository)
    │   └── 05_ValueRef_Real_DinhDanhLoHangTonKho.cs            (Phân biệt Entity Lô Hàng vs Value Object Bảng Giá)
    └── Program.cs
```

---

## 🎯 CHI TIẾT CÁC NHÓM KỸ THUẬT VÀ ỨNG DỤNG THỰC TẾ

### 1. Nhóm 1: Composing Methods (Tổ chức lại các phương thức)
- **Extract Method & Inline Method:**
  - *Trước refactor:* Phương thức `Luu()` trong `frmBanLe.cs` quá dài (> 100 dòng), làm từ việc kiểm tra dữ liệu rỗng, cộng dồn DataRow, trừ kho đến in ấn.
  - *Sau refactor:* Tách thành `ValidateThongTinPhieu()`, `TinhToanTaiChinh()`, `CapNhatTonKhoFEFO()`, `InPhieuXuatKho()`.
- **Replace Temp with Query & Extract Variable:**
  - *Trước refactor:* Sử dụng hàng loạt biến tạm `giaGoc`, `chietKhau`, `phiVanChuyen`, `vat` trong các sự kiện giao diện.
  - *Sau refactor:* Chuyển thành các thuộc tính Query thuần túy (`TongTienNiemYet`, `TiLeChietKhau`, `CuocVanChuyenXeTai`, `ThueVATNongNghiep`).
- **Split Temporary Variable & Remove Assignments to Parameters:**
  - *Trước refactor:* Tái sử dụng một biến số lượng và trừ trực tiếp lên tham số đầu vào khi phân bổ kho.
  - *Sau refactor:* Giữ nguyên tham số `in`, tách biến tạm `soLuongConLaiCanDapUng` và `soLuongLayTuLo`.
- **Replace Method with Method Object & Substitute Algorithm:**
  - *Trước refactor:* Lớp `Num2Str.cs` đọc tiền bằng chữ chứa chuỗi `switch-case` lồng phức tạp và nhiều biến tạm nối chuỗi.
  - *Sau refactor:* Thay thế bằng thuật toán xử lý nhóm 3 chữ số sạch sẽ qua `StringBuilder` và đóng gói thuật toán tính giá vốn BQGQ thành `TinhGiaBinhQuanGiaQuyenCalculator`.

---

### 2. Nhóm 2: Moving Features between Objects (Di chuyển tính năng)
- **Move Method & Move Field:**
  - *Trước refactor:* Form giao diện `frmBanLe.cs` tự tính `numThanhTien.Value = numDonGia.Value * numSoLuong.Value` và `numConNo.Value = numTongTien.Value - numDaTra.Value` (Code smell: Feature Envy).
  - *Sau refactor:* Chuyển toàn bộ phương thức tính toán về cho `PhieuBan` và `ChiTietPhieuBan` (Information Expert).
- **Extract Class & Inline Class:**
  - *Trước refactor:* Lớp `KhachHang`, `DaiLy`, `NhaCungCap` chứa lẫn lộn thông tin pháp nhân, chuỗi địa chỉ tự do và tài khoản ngân hàng.
  - *Sau refactor:* Tách thành `DiaChiGiaoHangNongDuoc` (hỗ trợ định vị GPS tận ruộng) và `ThongTinLienHe`.
- **Hide Delegate & Remove Middle Man:**
  - *Trước refactor:* Client gọi chuỗi `chiTiet.MaSanPham.SanPham.GiaBanLe` (vi phạm Law of Demeter).
  - *Sau refactor:* `DongBanHangChiTiet` và `LoMaSanPhamNongDuoc` tự đóng gói việc truy xuất đơn giá và tên thuốc.
- **Introduce Local Extension (C# Extension Methods):**
  - *Trước refactor:* Các phép kiểm tra ngày hết hạn lặp lại khắp nơi.
  - *Sau refactor:* Viết Extension Methods cho `DateTime` và `IEnumerable<LoHangNongDuoc>`: `IsCanDate()`, `IsDaHetHan()`, `LayCacLoCanDate()`, `SapXepTheoFEFO()`.

---

### 3. Nhóm 3: Organizing Data (Tổ chức dữ liệu)
- **Self Encapsulate Field & Encapsulate Collection:**
  - *Trước refactor:* `PhieuBan.cs` để `public IList<ChiTietPhieuBan> ChiTiet { get; set; }` cho phép can thiệp trực tiếp làm sai lệch tổng tiền.
  - *Sau refactor:* Danh sách được giữ `private`, trả về `IReadOnlyList<T>` và chỉ cho phép thêm/xóa qua phương thức nghiệp vụ.
- **Replace Data Value with Object (Value Objects):**
  - *Trước refactor:* Dùng kiểu `string` thô cho mã vạch, `long` cho tiền tệ (Primitive Obsession).
  - *Sau refactor:* Tạo `TienTeNongDuoc`, `QuyCachDongGoi`, `MaVachEAN13`.
- **Replace Magic Number with Symbolic Constant:**
  - *Trước refactor:* Sử dụng các con số `15`, `30`, `0.12`, `0.05` không rõ ngữ cảnh.
  - *Sau refactor:* Định nghĩa tập trung trong `QuyDinhNongDuocAnGiang` (`TonKhoAnToanToiThieu = 15`, `SoNgayCanhBaoCanDate = 30`).
- **Replace Type Code with Subclasses / Polymorphism:**
  - *Trước refactor:* Dùng `int LoaiKhachHang` kết hợp chuỗi `switch-case` tính chiết khấu.
  - *Sau refactor:* Triển khai lớp con đa hình `KhachHangDaiLyCap1`, `KhachHangHopTacXa`, `KhachHangNongDan` và `ILoaiThuocNongDuoc`.
- **Change Value to Reference:**
  - *Trước refactor:* Khởi tạo đối tượng `LoHang` độc lập tại từng đơn hàng làm mất đồng bộ tồn kho.
  - *Sau refactor:* Quản lý tham chiếu Lô Hàng duy nhất trong `KhoTrungTamNongDuoc_Real`.

---

## 🚀 HƯỚNG DẪN BIÊN DỊCH VÀ CHẠY CHƯƠNG TRÌNH

### 1. Biên dịch toàn bộ Solution:
```powershell
cd C:\Hoc\ThietKeBaoTriPhanMem\DPM235407_NguyenTuanAnh_BaiTap03_RefactoringTechniques
dotnet build DPM235407_NguyenTuanAnh_BaiTap03_RefactoringTechniques.sln
```

### 2. Chạy từng Project kiểm tra kết quả:
```powershell
# Chạy Nhóm 1: Composing Methods
dotnet run --project DPM235407_NguyenTuanAnh_BaiTap03_01_ComposingMethods

# Chạy Nhóm 2: Moving Features between Objects
dotnet run --project DPM235407_NguyenTuanAnh_BaiTap03_02_MovingFeatures

# Chạy Nhóm 3: Organizing Data
dotnet run --project DPM235407_NguyenTuanAnh_BaiTap03_03_OrganizingData
```

---

<div align="center">

**© 2026 Nguyễn Tuấn Anh (MSSV: DPM235407) — Trường Đại học An Giang**  
*Mọi ý kiến đóng góp xin vui lòng tạo Issue hoặc Pull Request trên Repository.*

</div>
