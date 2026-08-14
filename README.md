# Hướng dẫn Cập nhật & Sử dụng Thư viện Camera mới (AForge.NET)

Dự án này đã được nâng cấp chức năng chụp ảnh từ Webcam (Camera) để hỗ trợ các dòng Webcam đời mới có độ phân giải cao (1080p, 2K, 4K) sử dụng định dạng luồng nén như **MJPEG** hoặc **H.264** (không còn bị màn hình đen như khi dùng thư viện cũ `PPhotography.dll`).

---

## 1. Các thành phần được cài đặt thêm (Dependencies)

Để hỗ trợ xử lý camera mới, dự án đã sử dụng thư viện **AForge.NET** (Tương thích tốt với .NET 3.5). Các tệp thư viện được lưu trữ tại:
* `PFrmDmvt2/packages/AForge/`
  * `AForge.dll` (Core)
  * `AForge.Video.dll` (Xử lý Video)
  * `AForge.Video.DirectShow.dll` (Giao tiếp thiết bị camera)

---

## 2. Hướng dẫn cập nhật và tích hợp cho nhà phát triển khác

Nếu bạn là nhà phát triển mới muốn tích hợp hoặc cập nhật thủ công các thay đổi này vào code gốc:

### Bước 2.1: Thêm tham chiếu thư viện (References)
Mở dự án trên Visual Studio, nhấn chuột phải vào References chọn **Add Reference...** và tìm đến các file DLL của AForge tại đường dẫn `PFrmDmvt2/packages/AForge/` để thêm vào dự án:
1. `AForge.dll`
2. `AForge.Video.dll`
3. `AForge.Video.DirectShow.dll`

*(Lưu ý: Giữ nguyên tham chiếu cũ của `PPhotography` nếu các module khác ngoài Vật tư vẫn sử dụng).*

### Bước 2.2: Tạo giao diện Form chụp ảnh mới (`FrmCap`)
Tạo một Form Windows Forms mới trực tiếp trong dự án đặt tên là `FrmCap`. Sao chép nội dung từ các tệp tương ứng sau đây:
- **Giao diện & Thiết kế:** Copy nội dung của [FrmCap.Designer.vb](file:///e:/code%20dmvt2/PFrmDmvt2/FrmCap.Designer.vb) và [FrmCap.resx](file:///e:/code%20dmvt2/PFrmDmvt2/FrmCap.resx).
- **Logic xử lý:** Copy nội dung của [FrmCap.vb](file:///e:/code%20dmvt2/PFrmDmvt2/FrmCap.vb).

*Form mới này có nhiệm vụ:*
- Tự động quét danh sách camera.
- Tự động cấu hình và chọn độ phân giải cao nhất của Camera để chụp được ảnh sắc nét nhất.
- Hỗ trợ xem trực tiếp mượt mà.

### Bước 2.3: Thay đổi code gọi chụp ảnh
Tại các file thực hiện chụp ảnh của Vật tư và Nhóm Vật tư:
1. Mở file [FrmGroup.vb](file:///e:/code%20dmvt2/PFrmDmvt2/FrmGroup.vb) và [ctrItem.vb](file:///e:/code%20dmvt2/PFrmDmvt2/ctrItem.vb).
2. Xóa bỏ dòng khai báo import thư viện cũ:
   ```vb
   Imports PPhotography.PPhotography
   ```
   *(Sau khi xóa dòng này, trình biên dịch sẽ tự động trỏ lệnh `New FrmCap(pathName)` về Form nội bộ `FrmCap` vừa tạo ở Bước 2.2 thay vì gọi từ DLL cũ).*

---

## 3. Cấu hình Build dự án

- **Target Framework:** Dự án chạy trên nền tảng `.NET Framework 3.5`.
- **Đường dẫn đầu ra (OutputPath):** Cấu hình build cho **Release** đã được chuyển về:
  `..\build\app\`
  *(Giúp biên dịch ra file DLL và tự động copy đè thẳng vào thư mục chạy thật của phần mềm ở `e:\code dmvt2\build\app\PFrmDmvt2.dll`)*.

### Các bước biên dịch:
1. Mở file Solution `PFrmDmvt2.sln` bằng Visual Studio.
2. Thiết lập chế độ biên dịch thành **Release**.
3. Chọn **Rebuild Solution**.
4. Visual Studio sẽ tự động build và xuất các tệp sau vào thư mục `build/app/`:
   - `PFrmDmvt2.dll` (File logic chương trình mới nhất).
   - Bản sao của 3 DLL AForge cần thiết.
