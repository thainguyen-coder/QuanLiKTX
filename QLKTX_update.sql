CREATE DATABASE quanlyKiTucXa
USE quanlyKiTucXa
GO

CREATE TABLE TAIKHOAN1(
STT int IDENTITY(1,1),
tenDangNhap varchar(50),
matKhau varchar(50),
maNV char(20) CONSTRAINT fk_phon FOREIGN KEY REFERENCES NHANVIEN(maNV)
)
INSERT INTO TAIKHOAN1 (tenDangNhap,matKhau,maNV) VALUES
('Lan',123,'HC01');
INSERT INTO TAIKHOAN1 (tenDangNhap,matKhau,maNV) VALUES
('Tai',123,'KL01');
INSERT INTO TAIKHOAN1 (tenDangNhap,matKhau,maNV) VALUES
('Anh',123,'KL02');
INSERT INTO TAIKHOAN1 (tenDangNhap,matKhau,maNV) VALUES
('An',123,'TP01');

CREATE TABLE PHONG(
STT int IDENTITY(1,1),
maPhong char(20) NOT NULL CONSTRAINT pk_phong PRIMARY KEY,
soLuongSV int check (soLuongSV <= 8),
tinhTrangPhong nvarchar(50)
)

CREATE TABLE SINHVIEN(
STT int IDENTITY(1,1),
maSV char(20) NOT NULL CONSTRAINT pk_sv PRIMARY KEY,
hoTen nvarchar(100) NOT NULL, 
ngaySinh date NOT NULL,
gioiTinh nvarchar(3) NOT NULL,
cmnd char(9) NOT NULL,
sdt char(10),
lop nvarchar(500)
)

CREATE TABLE NHANVIEN(
STT INT IDENTITY(1,1),
maNV char(20) NOT NULL CONSTRAINT pk_nv PRIMARY KEY,
hoTen nvarchar(100) NOT NULL, 
ngaySinh date NOT NULL,
gioiTinh nvarchar(3) NOT NULL,
cmnd char(9) NOT NULL,
sdt char(10),
chucVu nvarchar(100)
)

CREATE TABLE PHONGSV(
STT int IDENTITY(1,1),
maPhong char(20) CONSTRAINT fk_phongg FOREIGN KEY REFERENCES PHONG(maPhong),
maSV char(20) CONSTRAINT fk_sinhvien FOREIGN KEY REFERENCES SINHVIEN(maSV),
ngayBatDau date NOT NULL,
ngayKetThuc date NOT NULL
)

CREATE TABLE DIEN(
STT int IDENTITY(1,1),
maCongToDien char(20) NOT NULL CONSTRAINT pk_dien PRIMARY KEY,
chiSoDau int NOT NULL,
chiSoCuoi int NOT NULL,
check (chiSoCuoi > chiSoDau),
tieuThu int NOT NULL,
gia bigint NOT NULL,
thanhTien bigint NOT NULL
)

CREATE TABLE NUOC(
STT int IDENTITY(1,1),
maCongToNuoc char(20) NOT NULL CONSTRAINT pk_nuoc PRIMARY KEY,
chiSoDau int NOT NULL,
chiSoCuoi int NOT NULL,
check (chiSoCuoi > chiSoDau),
tieuThu int NOT NULL,
gia bigint NOT NULL,
thanhTien bigint NOT NULL
)

CREATE TABLE HOADON(
STT int IDENTITY(1,1),
maHD char(20) NOT NULL CONSTRAINT pk_hd PRIMARY KEY,
maNV char(20) CONSTRAINT fk_nvlap FOREIGN KEY REFERENCES NHANVIEN(maNV),
maPhong char(20) CONSTRAINT fk_phonghd FOREIGN KEY REFERENCES PHONG(maPhong),
maCongToDien char(20) CONSTRAINT fk_madien FOREIGN KEY REFERENCES DIEN(maCongToDien),
maCongToNuoc char(20) CONSTRAINT fk_manuoc FOREIGN KEY REFERENCES NUOC(maCongToNuoc),
tongTien bigint NOT NULL
)
--Tài Khoản

--Phòng
INSERT INTO PHONG (maPhong,soLuongSV,tinhTrangPhong) VALUES
('C1.101',8,N'Tốt');
INSERT INTO PHONG (maPhong,soLuongSV,tinhTrangPhong) VALUES
('C1.102',8,N'Tốt');
INSERT INTO PHONG (maPhong,soLuongSV,tinhTrangPhong) VALUES
('C1.103',5,N'Tốt');
INSERT INTO PHONG (maPhong,soLuongSV,tinhTrangPhong) VALUES
('C1.202',8,N'Tốt');
INSERT INTO PHONG (maPhong,soLuongSV,tinhTrangPhong) VALUES
('C1.302',8,N'Tốt');


--Sinh Viên
INSERT INTO SINHVIEN (maSV,hoTen,ngaySinh,gioiTinh,cmnd,sdt,lop) VALUES
('4051050084',N'Võ Thị Thao','1999/03/06',N'Nữ','215483525','0914585561','CNTT K40B');
INSERT INTO SINHVIEN (maSV,hoTen,ngaySinh,gioiTinh,cmnd,sdt,lop) VALUES
('4051050023',N'Trần Thái Nguyên','1999/10/04',N'Nam','214483575','0918547213','CNTT K40B');
INSERT INTO SINHVIEN (maSV,hoTen,ngaySinh,gioiTinh,cmnd,sdt,lop) VALUES
('4051050096',N'Mai Thanh Phong','1999/04/11',N'Nam','213478561','0385910661','QLNN K41');
INSERT INTO SINHVIEN (maSV,hoTen,ngaySinh,gioiTinh,cmnd,sdt,lop) VALUES
('4051050094',N'Trịnh Ngọc Hiếu','1999/12/06',N'Nam','215421534','035847661','QTKD K42');
INSERT INTO SINHVIEN (maSV,hoTen,ngaySinh,gioiTinh,cmnd,sdt,lop) VALUES
('4051050034',N'Trần Duy Phương','1999/03/06',N'Nữ','215483525','0914785514','SP Tin');
INSERT INTO SINHVIEN (maSV,hoTen,ngaySinh,gioiTinh,cmnd,sdt,lop) VALUES
('4051010012',N'Võ Thị Mỹ Linh','1998/10/24',N'Nữ','213542178','0381023178',N'SP Toán');
INSERT INTO SINHVIEN (maSV,hoTen,ngaySinh,gioiTinh,cmnd,sdt,lop) VALUES
('4051040122',N'Phạm Mỹ Uyên','2000/01/14',N'Nữ','215478326','037514782',N'Ngôn Ngữ Anh');

--PHONGSV
INSERT INTO PHONGSV(maPhong,maSV,ngayBatDau,ngayKetThuc) VALUES
('C1.101','4051050084','2019/08/09','');
INSERT INTO PHONGSV(maPhong,maSV,ngayBatDau,ngayKetThuc) VALUES
('C1.101','4051010012','2019/08/09','');
INSERT INTO PHONGSV(maPhong,maSV,ngayBatDau,ngayKetThuc) VALUES
('C1.101','4051040122','2019/08/09','');

--Nhân Viên
INSERT INTO NHANVIEN(maNV,hoTen,ngaySinh,gioiTinh,cmnd,sdt,chucVu) VALUES
('HC01',N'Phạm Thị Lan','1978/02/22',N'Nữ','209145789','034167892',N'NV hành chính');
INSERT INTO NHANVIEN(maNV,hoTen,ngaySinh,gioiTinh,cmnd,sdt,chucVu) VALUES
('TP01',N'Nguyễn Văn An','1974/10/12',N'Nam','207145821','034348751',N'NV trực phòng');
INSERT INTO NHANVIEN(maNV,hoTen,ngaySinh,gioiTinh,cmnd,sdt,chucVu) VALUES
('KL01',N'Trần Anh Tài','1980/06/14',N'Nam','209165678','037146826',N'NV quản lý');
INSERT INTO NHANVIEN(maNV,hoTen,ngaySinh,gioiTinh,cmnd,sdt,chucVu) VALUES
('KL02',N'Lê Minh Anh','1975/12/06',N'Nam','209145786','034148624',N'NV quản lý');

--DIEN
INSERT INTO DIEN (maCongToDien,chiSoDau,chiSoCuoi,tieuThu,gia,thanhTien) VALUES
('CTD101',21,50,29,2500,72500);
INSERT INTO DIEN (maCongToDien,chiSoDau,chiSoCuoi,tieuThu,gia,thanhTien) VALUES
('CTD102',15,25,10,2500,25000);
INSERT INTO DIEN (maCongToDien,chiSoDau,chiSoCuoi,tieuThu,gia,thanhTien) VALUES
('CTD103',25,39,14,2500,35000);
INSERT INTO DIEN (maCongToDien,chiSoDau,chiSoCuoi,tieuThu,gia,thanhTien) VALUES
('CTD202',30,50,20,2500,50000);
INSERT INTO DIEN (maCongToDien,chiSoDau,chiSoCuoi,tieuThu,gia,thanhTien) VALUES
('CTD302',35,50,15,2500,37500);

--NUOC
INSERT INTO NUOC (maCongToNuoc,chiSoDau,chiSoCuoi,tieuThu,gia,thanhTien) VALUES
('CTN101',21,25,4,11000,44000);
INSERT INTO NUOC (maCongToNuoc,chiSoDau,chiSoCuoi,tieuThu,gia,thanhTien) VALUES
('CTN102',15,20,5,11000,55000);
INSERT INTO NUOC (maCongToNuoc,chiSoDau,chiSoCuoi,tieuThu,gia,thanhTien) VALUES
('CTN103',11,14,3,11000,33000);
INSERT INTO NUOC (maCongToNuoc,chiSoDau,chiSoCuoi,tieuThu,gia,thanhTien) VALUES
('CTN202',28,33,5,11000,55000);
INSERT INTO NUOC (maCongToNuoc,chiSoDau,chiSoCuoi,tieuThu,gia,thanhTien) VALUES
('CTN302',25,29,4,11000,44000);

--HOADON
INSERT INTO HOADON(maHD,maNV,maPhong,maCongToDien,maCongToNuoc,tongTien) VALUES
('HD01','TP01','C1.101','CTD101','CTN101',116500);