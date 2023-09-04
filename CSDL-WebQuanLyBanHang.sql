
--Bảng Menu: 
create table tblMenu (
	MenuID int identity(1,1) primary key,
	MenuName nvarchar(50),
	IsActive bit,
	ControllerName nvarchar(50),
	ActionName nvarchar(50),
	Levels int,
	ParentID int,
	Link nvarchar(50),
	MenuOrder int,
	Position int
)

--Bảng tblEmployees: Quản lý nhân viên
create table tblEmployees (
	EmployeeID int identity(1,1) primary key,
	EmployeeName nvarchar(50),
	Position nvarchar(100),
	Image nvarchar(200),
	Email nvarchar(50),
	Phone nvarchar(50),
	Address nvarchar(50),
	IsActive bit,
	Description ntext
)

--AdminMenu: Menu của phần Admin
create table tblAdminMenu (
	AdminMenuID bigint identity(1,1) primary key,
	ItemName nvarchar(50),
	ItemLevel int,
	ParentLevel int,
	ItemOrder int,
	IsActive bit,
	ItemTarget nvarchar(50),
	AreaName nvarchar(50),
	ControllerName nvarchar(50),
	ActionName nvarchar(50),
	Icon nvarchar(50),
	IdName nvarchar(50)
)

--Bảng Categories: Lưu trữ danh mục món ăn
create table tblCategories (
	CategoryID int identity(1,1) primary key,
	CategoryName nvarchar(50),
	Description nvarchar(50),
	Icon nvarchar(150),
	Position int,
	DataFilter nvarchar(50)
)
--Bảng Foods: Lưu trữ danh sách món ăn
create table tblFoods (
	FoodID int identity(1,1) primary key,
	CategoryID int,
	EmployeeID int,
	FoodName nvarchar(150),
	Description nvarchar(250),
	Material ntext,
	Image nvarchar(250),
	Price float,
	CreatedDate datetime,
	IsActive bit,
	Link nvarchar(500),
	Status int,
	DataFood nvarchar(50),
	FOREIGN KEY (CategoryID) REFERENCES tblCategories(CategoryID),
	FOREIGN KEY (EmployeeID) REFERENCES tblEmployees(EmployeeID)
)

--Bảng Post: Quản lý bài viết
create table tblPosts (
	PostID int identity(1,1) primary key,
	Title nvarchar(150),
	Abstract nvarchar(350),
	Contents ntext,
	Images nvarchar(150),
	Link nvarchar(150),
	Author nvarchar(50),
	Icon nvarchar(100),
	IsActive bit,
	CreatedDate datetime,
	Category int,
	Status int
)

--Bảng MenuFooter: Menu dưới
create table tblMenuFooter (
	MenuFooterID int identity primary key,
	MenuFooterName nvarchar(50),
	IsActive bit,
	ControllerName nvarchar(50),
	ActionName nvarchar(50),
	Levels int,
	ParentID int,
	MenuOrder int,
	Position int,
	Icon nvarchar(100)
)

--Bảng Feedback: Quản lý phản hồi
create table tblFeedback (
	FeedbackID int identity(1,1) primary key,
	Icon nvarchar(100),
	Description nvarchar(500),
	Image nvarchar(100),
	Name nvarchar(50),
	Profession nvarchar(50),
	IsActive bit
)

--Bảng BookTable: Quản lý khách đặt bàn 

create table tblBookTable (
	BookTableID int identity(1,1) primary key,
	Name nvarchar(50),
	Phone nvarchar(11),
	Date datetime,
	Member int,
	Request nvarchar(500)
)

--Bảng AdminMenu : quản trị
create table AdminMenu (
	AdminMenuID bigint identity(1,1) primary key,
	ItemName nvarchar(50),
	ItemLevel int,
	ParentLevel int,
	ItemOrder int,
	IsActive bit,
	ItemTarget nvarchar(20),
	AreaName nvarchar(20),
	ControllerName nvarchar(20),
	ActionName nvarchar(20),
	Icon nvarchar(50),
	IdName nvarchar(50)
)

--Bảng Role: quản lý đăng nhập
/*
create table tblRole(
	RoleID int identity(1,1) primary key,
	RoleName nvarchar(50)
)*/
--Bảng User: Người dùng
create table tblUsers(
	UserID int primary key identity(1,1),
	UserName nvarchar(50),
	FullName nvarchar(50),
	Email nvarchar(50),
	Phone nvarchar(11),
	Address nvarchar(100),
	Password nvarchar(32),
)

--Bảng Table: quản lý bàn ăn
create table tblTable (
	TableID int identity(1,1) primary key,
	TableName nvarchar(50),
	Description nvarchar(350),
	Status bit,
	IsActive bit
)

--Bảng Order: Quản lý gọi món
create table tblOrder(
	OrderID int identity(1,1) primary key,
	FullName nvarchar(50),
	Email nvarchar(50),
	Phone nvarchar(11),
	Address nvarchar(150),
	Note nvarchar(350),
	OrderDate datetime,
	Status bit,
	IsActive bit
)

--Bảng OrderDetails: Chi tiết gọi món
create table tblOrderDetails (
	OrderDetailID int identity(1,1) primary key,
	OrderID int,
	FoodID int,
	Price float,
	Quantity int,
	Total money,
	foreign key (OrderID) references tblOrder (OrderID),
	foreign key (FoodID) references tblFoods (FoodID)
)

