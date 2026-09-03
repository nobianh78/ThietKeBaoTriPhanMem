# 🎓 THIẾT KẾ PHÁT TRIỂN & BẢO TRÌ PHẦN MỀM

![C#](https://img.shields.io/badge/C%23-%23239120.svg?style=for-the-badge&logo=c-sharp&logoColor=white)
![.NET](https://img.shields.io/badge/.NET-5C2D91?style=for-the-badge&logo=.net&logoColor=white)
![Visual Studio](https://img.shields.io/badge/Visual%20Studio-5C2D91.svg?style=for-the-badge&logo=visual-studio&logoColor=white)

Repository này lưu trữ mã nguồn các bài tập thực hành môn **Thiết kế phát triển và Bảo trì Phần mềm**, Trường Đại học An Giang. 

> **Sinh viên thực hiện:** Nguyễn Tuấn Anh  
> **Mã số sinh viên:** DPM235407  
> **Ngôn ngữ lập trình:** C# / .NET  

---

## 📑 BÀI TẬP TUẦN 1: CREATIONAL DESIGN PATTERN

Tuần này tập trung vào việc tìm hiểu và áp dụng 5 mẫu thiết kế thuộc nhóm **Khởi tạo (Creational)**. Solution bao gồm 10 project con, được chia thành 2 nhóm chính:

### Triển khai lý thuyết (Conceptual)
Mã nguồn minh họa cấu trúc chuẩn của 5 mẫu thiết kế cơ bản dựa trên tài liệu tham khảo từ *Refactoring.Guru*:
1. `DPM235407_NguyenTuanAnh_Tuan01_Factory-DP`
2. `DPM235407_NguyenTuanAnh_Tuan01_Builder-DP`
3. `DPM235407_NguyenTuanAnh_Tuan01_AbstractFactory-DP`
4. `DPM235407_NguyenTuanAnh_Tuan01_Prototype-DP`
5. `DPM235407_NguyenTuanAnh_Tuan01_Singleton-DP`

### Áp dụng Đồ án thực tế (Real)
Áp dụng các mẫu thiết kế trên vào hệ thống quản lý bán hàng của **Công ty nông dược An Giang**:
1. **Factory Method (`Factory_Real_NhanVien_DP`):** Khởi tạo và phân quyền cho đối tượng Nhân viên (Bán hàng, Quản lý).
2. **Builder (`Builder_Real_HoaDon_DP`):** Xây dựng từng bước Hóa đơn bán hàng phức tạp (có dịch vụ phụ, phí vận chuyển, giảm giá).
3. **Abstract Factory (`Abstract_Real_BaoCao_DP`):** Cung cấp giao diện tạo nhóm Báo cáo thống kê đồng bộ tùy theo vai trò người dùng.
4. **Prototype (`Prototype_Real_LoHang_DP`):** Nhân bản nhanh thông tin Lô hàng nông dược khi nhập kho các lô tương tự.
5. **Singleton (`Singleton_Real_Database_DP`):** Quản lý trạng thái duy nhất của Phiên đăng nhập (Session) trên toàn hệ thống.

---

## 🚀 HƯỚNG DẪN CÀI ĐẶT VÀ CHẠY PROJECT

1. **Clone repository:**
   ```bash
   git clone [https://github.com/nobianh78/ThietKeBaoTriPhanMem.git](https://github.com/nobianh78/ThietKeBaoTriPhanMem.git)