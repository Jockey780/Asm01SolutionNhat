Mô tả bài chi tiết Assigment 1 WPF
	Lê Hoàng Minh Nhật 
	SE161790 
	SĐT: 0338290661

Các chức năng đã thực hiện (Login và CRUD cho Product):
- Login
	- Có valadiation khi đăng nhập (báo lỗi khi đăng nhập sai)
	- Có chức năng phần quyền cho từng Roles(Admin, Staff, Customer)
- Sau khi Login thành công
	- Mỗi user sẽ có những window riêng
	- Có thể Log out	
	- Admin có thể xem và chỉnh sửa User Product Order và Order detail (do bug ở phần khi chọn menu khác thì nó không hiện lên nên em làm mỗi CRUD của product)
		- Có thể Search product (show những prodcut có cùng CategoryId hoặc Quantity) và khi thanh Search trống thì nó sẽ hiện toàn bộ Product
		- Khi chọn một product thì product đó sẽ tự fill vào các TextBox phù hợp
		(Do lỗi sơ suất của em trong khi tạo DB cho UnitPrice nên nó tự động thêm .0000 vào sau mỗi giá tiền)

	- Customer chỉ có thể xem được danh sách sản phẩm và Order detail (em bị bug ở phần khi chọn menu thì nó không hiện nội dung lên)
	- Staff chỉ có xem và chỉnh sửa Product và Order detail (em bị do bug ở phần khi chọn menu thì nó không hiện nội dung lên)

Các phi chức năng đã thực hiện:

	- Thiết kế lại giao diện WPF nhờ tích hợp một xíu về MVVM trong layer GUI
	- Thêm đổ bóng cho các TextBox và Button
	- Có thể Minimzie, Maximize window trong window Admin, Staff, Customer
	- Có thể tắt Window

Tổng kết

	Với những chức năng và thiếu sót của em thì em xin đánh giá bài em là 6 điểm.
		Em xin cảm ơn
