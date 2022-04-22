drop database QuanLyThuVien
create database QuanLyThuVien
use QuanLyThuVien


create table DocGia
(
	IDDG nvarchar(50) primary key,
	TenDG nvarchar(50) ,
	DienThoai nvarchar(50) ,
	DiaChi nvarchar(50) ,
	UserName nvarchar(50)  , 
	Password nvarchar(50)  ,
)

insert into DocGia(IDDG,TenDG,DienThoai,DiaChi,UserName,Password)
values('1',N'Tuấn',N'123456789',N'123456789',N'123',N'123')

select * from DocGia
go
create table PhieuMuon
(
	IDPM int primary key,
	IDDG nvarchar(50)  ,
	TenDG nvarchar(50)  ,
	NgayMuon datetime  ,
	NgayTra datetime  ,
	TienPhat int ,
	GhiChu nvarchar(50) ,
	CONSTRAINT FK_PHIEUMUON_DOCGIA FOREIGN KEY (IDDG) REFERENCES DocGia(IDDG)
)

create table TheLoai
(
	ID INT,
	IDCate NVARCHAR(50) primary key,
	NameCate NVARCHAR(50)  ,
)

select * from theloai

insert into TheLoai(id, IDCate, NameCate)
values (1,N'Chính trị - pháp luật',N'Chính trị - pháp luật')
insert into TheLoai(id, IDCate, NameCate)
values (2,N'Khoa học công nghệ - kinh tế',N'Khoa học công nghệ - kinh tế')
insert into TheLoai(id, IDCate, NameCate)
values (3,N'Văn học nghệ thuật',N'Văn học nghệ thuật')
insert into TheLoai(id, IDCate, NameCate)
values (4,N'Văn hóa xã hội – Lịch sử',N'Văn hóa xã hội – Lịch sử')
insert into TheLoai(id, IDCate, NameCate)
values (5,N'Giáo trình',N'Giáo trình')
insert into TheLoai(id, IDCate, NameCate)
values (6,N'Truyện, tiểu thuyết',N'Truyện, tiểu thuyết')
insert into TheLoai(id, IDCate, NameCate)
values (7,N'Tâm lý, tâm linh, tôn giáo',N'Tâm lý, tâm linh, tôn giáo')
insert into TheLoai(id, IDCate, NameCate)
values (8,N'Sách thiếu nhi',N'Sách thiếu nhi')
insert into TheLoai(id, IDCate, NameCate)
values (9,N'Self help',N'Self help')

SELECT * FROM TheLoai
 
create table Sach
(
	IDSach nvarchar(10) primary key,
	TenSach NVARCHAR(50)  ,
	TheLoai NVARCHAR(50)  ,
	MoTa NVARCHAR(max)  ,
	TacGia NVARCHAR(50)  ,
	NgayXuatBan datetime  ,
	SoLuong int  ,
	HinhAnh NVARCHAR(max) ,
	CONSTRAINT FK_SACH_THELOAI FOREIGN KEY (TheLoai) REFERENCES TheLoai(IDCate)
)
go

alter trigger TaoIDSach
on Sach
INSTEAD OF INSERT
as 
begin 
	
	DECLARE @idSach NVARCHAR(10), @tensach nvarchar(50), @theloai nvarchar(50), @MoTa NVARCHAR(50),@TacGia NVARCHAR(50),@NgayXuatBan datetime
	DECLARE @SoLuong int, @HinhAnh NVARCHAR(max)	
	select @tensach = TenSach, @MoTa =MoTa, @TacGia = TacGia, @HinhAnh = HinhAnh from inserted
	select @theloai = TheLoai,@NgayXuatBan = NgayXuatBan, @SoLuong = SoLuong from inserted	
    declare @id int
	set @id = 1
	set @idSach = LEFT(@tensach,3) + LEFT(@theloai,3) + CAST(@id AS NVARCHAR(10))
	while ((select Count(*) from Sach where IDSach = @idSach) != 0 )
	BEGIN    
		SET @id = @id  + 1
		set @idSach = LEFT(@tensach,3) + LEFT(@theloai,3) + CAST(@id AS NVARCHAR(10))		
	END
	
	insert into Sach(IDSach,TenSach,TheLoai,MoTa,TacGia,NgayXuatBan,SoLuong,HinhAnh)
	values(@idSach,@tensach,@theloai,@MoTa,@TacGia,@NgayXuatBan,@SoLuong,@HinhAnh)

	EXEC ThemTuDongChiTietSach @soluong = @SoLuong, @idSach = @idSach
end

go

select * from Sach

create table ChiTietSach
(
	IDChiTietSach nvarchar(20) primary key,
	IDSach nvarchar(10),
	TinhTrang nvarchar(50),
	CONSTRAINT FK_ChiTietSach_Sach FOREIGN KEY (IDSach) REFERENCES SACH(IDSach)
)
go

alter PROCEDURE ThemTuDongChiTietSach @soluong nvarchar(30), @idSach nvarchar(10)
AS
declare @id int
set @id = @soluong
while (@id > 0) 
begin
	declare @newID nvarchar(20)
	set @newID = @idSach + CAST(@id AS NVARCHAR(10))
	insert into ChiTietSach(IDChiTietSach,IDSach,TinhTrang)
	values(@newID,@idSach,N'Đang dùng');
	set @id = @id -1
end

create table TrangThai
(
	ID int,
	IDTT nvarchar(50) primary key,
	TT nvarchar(50)  
)

create table CT_PM
(
	ID int primary key,
	IDPM int  ,
	IDDG nvarchar(50)  ,
	TenDG nvarchar(50)  ,
	IDSach nvarchar(10) ,
	TenSach nvarchar(50) ,
	SoLuong int ,
	TrangThai nvarchar(50) ,
	NgayTraThucTe datetime ,

	CONSTRAINT FK_CT_PM_DocGia FOREIGN KEY (IDDG) REFERENCES DocGia(IDDG),
	CONSTRAINT FK_CT_PM_PhieuMuon FOREIGN KEY (IDPM) REFERENCES PhieuMuon(IDPM),
	CONSTRAINT FK_CT_PM_Sach FOREIGN KEY (IDSach) REFERENCES Sach(IDSach),
	CONSTRAINT FK_CT_PM_TrangThai FOREIGN KEY (TrangThai) references TrangThai(IDTT)
)
go
create table DangNhap
(
	ID int primary key,
	UserName nvarchar(50)  ,
	Password nvarchar(50)  ,
)

select * from DocGia
select * from ChiTietSach
