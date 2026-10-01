<div align="center">

# 🛠️ BÀI TẬP 03: REFACTORING TECHNIQUES (ĐẦY ĐỦ 32 KỸ THUẬT)
### HỆ THỐNG QUẢN LÝ BÁN HÀNG CÔNG TY NÔNG DƯỢC AN GIANG
**TRƯỜNG ĐẠI HỌC AN GIANG — ĐẠI HỌC QUỐC GIA TP. HỒ CHÍ MINH**

---

[![C#](https://img.shields.io/badge/C%23-239120?style=for-the-badge&logo=c-sharp&logoColor=white)](https://docs.microsoft.com/en-us/dotnet/csharp/)
[![.NET](https://img.shields.io/badge/.NET-8.0%20%7C%2010.0-512BD4?style=for-the-badge&logo=dotnet&logoColor=white)](https://dotnet.microsoft.com/)
[![Refactoring.Guru](https://img.shields.io/badge/Refactoring-Refactoring.Guru-FFA500?style=for-the-badge&logo=codewars&logoColor=white)](https://refactoring.guru/refactoring/techniques)
[![Build Status](https://img.shields.io/badge/Build-Passing-brightgreen?style=for-the-badge&logo=github-actions&logoColor=white)](https://github.com/nobianh78/ThietKeBaoTriPhanMem)

<br/>

> *"Tái cấu trúc mã nguồn toàn diện với đầy đủ 32 kỹ thuật Refactoring (Composing Methods, Moving Features, Organizing Data) theo chuẩn Refactoring.Guru và giải quyết triệt để các Code Smell trong hệ thống Nông Dược An Giang."*

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

## 📋 DANH SÁCH ĐẦY ĐỦ 32 KỸ THUẬT REFACTORING

Mỗi kỹ thuật đều được tổ chức thành thư mục độc lập gồm 3 file:
1. `..._Before.cs`: Mã nguồn trước khi tái cấu trúc chứa Code Smell.
2. `..._After.cs`: Mã nguồn sau khi áp dụng kỹ thuật chuẩn Refactoring.Guru.
3. `..._Real.cs`: Mã nguồn ứng dụng giải quyết bài toán nghiệp vụ Cửa hàng Nông Dược An Giang (`FileDuocThayDua`).

---

### 🌟 NHÓM 1: COMPOSING METHODS (9 KỸ THUẬT)
> Project: `DPM235407_NguyenTuanAnh_BaiTap03_01_ComposingMethods`

| STT | Kỹ thuật Refactoring | Liên kết Refactoring Guru | Ứng dụng thực tế Nông Dược An Giang |
|:---:|:---|:---|:---|
| 1 | [Extract Method](https://refactoring.guru/extract-method) | `01_ExtractMethod/` | Tách hàm `Luu()` trong `frmBanLe.cs` thành kiểm tra hợp lệ, trừ kho FEFO, tính tiền và in phiếu |
| 2 | [Inline Method](https://refactoring.guru/inline-method) | `02_InlineMethod/` | Gộp phương thức kiểm tra tồn kho an toàn `CanNhapThemThuocBVTV()` trong `frmSoLuongTon.cs` |
| 3 | [Extract Variable](https://refactoring.guru/extract-variable) | `03_ExtractVariable/` | Đặt tên biến rõ nghĩa cho điều kiện chiết khấu vụ mùa Đông Xuân cho Hợp tác xã |
| 4 | [Inline Temp](https://refactoring.guru/inline-temp) | `04_InlineTemp/` | Loại bỏ biến tạm trung gian khi kiểm tra công dụng thuốc trị đạo ôn |
| 5 | [Replace Temp with Query](https://refactoring.guru/replace-temp-with-query) | `05_ReplaceTempWithQuery/` | Chuyển các biến tạm tính chiết khấu, VAT sang thuộc tính Query trong `frmBanSi.cs` |
| 6 | [Split Temporary Variable](https://refactoring.guru/split-temporary-variable) | `06_SplitTemporaryVariable/` | Tách biến tạm lưu khối lượng thuốc riêng và cước xe tải riêng trong phân bổ vận chuyển |
| 7 | [Remove Assignments to Parameters](https://refactoring.guru/remove-assignments-to-parameters) | `07_RemoveAssignmentsToParameters/` | Dùng từ khóa `in` bảo toàn tham số gốc khi tính tiền trợ giá phân bón cho hộ nghèo |
| 8 | [Replace Method with Method Object](https://refactoring.guru/replace-method-with-method-object) | `08_ReplaceMethodWithMethodObject/` | Đóng gói thuật toán tính giá vốn Bình quân gia quyền (Mục 3 PDF) thành Calculator Object |
| 9 | [Substitute Algorithm](https://refactoring.guru/substitute-algorithm) | `09_SubstituteAlgorithm/` | Thay thế thuật toán duyệt mảng thủ công bằng LINQ khi lọc danh sách thuốc BVTV hết hạn |

---

### 🚀 NHÓM 2: MOVING FEATURES BETWEEN OBJECTS (8 KỸ THUẬT)
> Project: `DPM235407_NguyenTuanAnh_BaiTap03_02_MovingFeatures`

| STT | Kỹ thuật Refactoring | Liên kết Refactoring Guru | Ứng dụng thực tế Nông Dược An Giang |
|:---:|:---|:---|:---|
| 1 | [Move Method](https://refactoring.guru/move-method) | `01_MoveMethod/` | Chuyển hàm tính dư nợ `GhiNhanThanhToan()` từ `frmBanLe.cs` vào `PhieuBan` (Information Expert) |
| 2 | [Move Field](https://refactoring.guru/move-field) | `02_MoveField/` | Chuyển trường `QuyCach` từ chi tiết đơn hàng sang lớp `DanhMucThuocBVTV` |
| 3 | [Extract Class](https://refactoring.guru/extract-class) | `03_ExtractClass/` | Tách `DiaDiemGiaoHangRuong` (kèm tọa độ GPS) ra khỏi `KhachHangNongDan` |
| 4 | [Inline Class](https://refactoring.guru/inline-class) | `04_InlineClass/` | Gộp lớp đơn vị tiền tệ rỗng trực tiếp vào bảng báo giá nông dược `BaoGiaNongDuoc` |
| 5 | [Hide Delegate](https://refactoring.guru/hide-delegate) | `05_HideDelegate/` | Đóng gói chuỗi gọi `LoHang.Thuoc.GiaLe` qua phương thức `DonGia` của Lô hàng (Law of Demeter) |
| 6 | [Remove Middle Man](https://refactoring.guru/remove-middle-man) | `06_RemoveMiddleMan/` | Cho phép `PhieuBanLe` truy cập trực tiếp thông tin vị trí kệ kho `KhoHang.ViTriDay` |
| 7 | [Introduce Foreign Method](https://refactoring.guru/introduce-foreign-method) | `07_IntroduceForeignMethod/` | Tạo hàm `TinhNgayGiaoNongDuoc` tự động tránh ngày Chủ nhật khi giao phân bón |
| 8 | [Introduce Local Extension](https://refactoring.guru/introduce-local-extension) | `08_IntroduceLocalExtension/` | Xây dựng C# Extension Methods cho `DateTime` kiểm tra hạn dùng FEFO: `LayTrangThaiHSD()` |

---

### 📦 NHÓM 3: ORGANIZING DATA (15 KỸ THUẬT)
> Project: `DPM235407_NguyenTuanAnh_BaiTap03_03_OrganizingData`

| STT | Kỹ thuật Refactoring | Liên kết Refactoring Guru | Ứng dụng thực tế Nông Dược An Giang |
|:---:|:---|:---|:---|
| 1 | [Change Value to Reference](https://refactoring.guru/change-value-to-reference) | `01_ChangeValueToReference/` | Quản lý duy nhất một thực thể `LoThuocThucThe` trong kho để trừ tồn nhất quán |
| 2 | [Change Reference to Value](https://refactoring.guru/change-reference-to-value) | `02_ChangeReferenceToValue/` | Chuyển tọa độ ruộng giao hàng thành `readonly record struct ToaDoRuong` bất biến |
| 3 | [Duplicate Observed Data](https://refactoring.guru/duplicate-observed-data) | `03_DuplicateObservedData/` | Tách Model và phát sự kiện `OnCanhBaoTonKho` khi thuốc chạm ngưỡng nguy hiểm $\le 15$ |
| 4 | [Self Encapsulate Field](https://refactoring.guru/self-encapsulate-field) | `04_SelfEncapsulateField/` | Truy cập giá bán qua getter để lớp con `PhanBonTroGia` ghi đè giá trợ cấp |
| 5 | [Replace Data Value with Object](https://refactoring.guru/replace-data-value-with-object) | `05_ReplaceDataValueWithObject/` | Thay chuỗi string mã vạch bằng Value Object `MaVachEAN13` |
| 6 | [Replace Array with Object](https://refactoring.guru/replace-array-with-object) | `06_ReplaceArrayWithObject/` | Thay thế mảng dữ liệu thô trong `frmNhapHang.cs` bằng đối tượng `LoHangNhapKho` |
| 7 | [Change Unidirectional to Bidirectional](https://refactoring.guru/change-unidirectional-association-to-bidirectional) | `07_ChangeUnidirectionalToBidirectional/` | Thiết lập liên kết 2 chiều giữa `PhieuBan` và `ChiTiet` (`BusinessObject/PhieuBan.cs`) |
| 8 | [Change Bidirectional to Unidirectional](https://refactoring.guru/change-bidirectional-association-to-unidirectional) | `08_ChangeBidirectionalToUnidirectional/` | Xóa liên kết ngược không cần thiết từ `DonViTinh` về `SanPham` |
| 9 | [Encapsulate Field](https://refactoring.guru/encapsulate-field) | `09_EncapsulateField/` | Đóng gói trường `_soLuongTon` với validation không cho phép giá trị âm |
| 10 | [Encapsulate Collection](https://refactoring.guru/encapsulate-collection) | `10_EncapsulateCollection/` | Trả về `IReadOnlyList<string>` để ngăn chặn sửa đổi danh sách mặt hàng trái phép |
| 11 | [Replace Magic Number with Symbolic Constant](https://refactoring.guru/replace-magic-number-with-symbolic-constant) | `11_ReplaceMagicNumberWithSymbolicConstant/` | Định nghĩa hằng số `SoNgayCanhBaoCanDate = 30`, `TiLeChietKhauDaiLyCap1 = 0.12` |
| 12 | [Replace Type Code with Class](https://refactoring.guru/replace-type-code-with-class) | `12_ReplaceTypeCodeWithClass/` | Thay mã số cấp đại lý bằng đối tượng `CapDaiLy_Real.Cap1`, `Cap2` |
| 13 | [Replace Type Code with Subclasses](https://refactoring.guru/replace-type-code-with-subclasses) | `13_ReplaceTypeCodeWithSubclasses/` | Thay thế phân loại thuốc bằng kế thừa đa hình `ThuocTruSauDocCao`, `ChePhamSinhHoc` |
| 14 | [Replace Type Code with State/Strategy](https://refactoring.guru/replace-type-code-with-state-strategy) | `14_ReplaceTypeCodeWithStateStrategy/` | Áp dụng Strategy hoán đổi phương pháp tính giá xuất kho `StrategyFIFO` vs `StrategyBQGQ` |
| 15 | [Replace Subclass with Fields](https://refactoring.guru/replace-subclass-with-fields) | `15_ReplaceSubclassWithFields/` | Thay thế các lớp con dung tích bằng trường `DungTichMl` và factory `ChaiNho()`, `ChaiLon()` |

---

## 🚀 HƯỚNG DẪN BIÊN DỊCH VÀ CHẠY THỬ NGHIỆM

```powershell
cd C:\Hoc\ThietKeBaoTriPhanMem\DPM235407_NguyenTuanAnh_BaiTap03_RefactoringTechniques

# 1. Biên dịch toàn bộ Solution
dotnet build DPM235407_NguyenTuanAnh_BaiTap03_RefactoringTechniques.sln

# 2. Chạy Nhóm 1: Composing Methods (9 kỹ thuật)
dotnet run --project DPM235407_NguyenTuanAnh_BaiTap03_01_ComposingMethods

# 3. Chạy Nhóm 2: Moving Features (8 kỹ thuật)
dotnet run --project DPM235407_NguyenTuanAnh_BaiTap03_02_MovingFeatures

# 4. Chạy Nhóm 3: Organizing Data (15 kỹ thuật)
dotnet run --project DPM235407_NguyenTuanAnh_BaiTap03_03_OrganizingData
```

---

<div align="center">

**© 2026 Nguyễn Tuấn Anh (MSSV: DPM235407) — Trường Đại học An Giang**  
*Mọi ý kiến đóng góp xin vui lòng tạo Issue hoặc Pull Request trên Repository.*

</div>
